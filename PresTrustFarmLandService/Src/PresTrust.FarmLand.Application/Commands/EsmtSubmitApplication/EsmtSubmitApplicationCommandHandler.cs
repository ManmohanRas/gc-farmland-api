namespace PresTrust.FarmLand.Application.Commands;

public class EsmtSubmitApplicationCommandHandler : BaseHandler, IRequestHandler<EsmtSubmitApplicationCommand, EsmtSubmitApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly IEmailManager repoEmailManager;
    private readonly IEmailTemplateRepository repoEmailTemplate;

    public EsmtSubmitApplicationCommandHandler
   (
       IMapper mapper,
       IPresTrustUserContext userContext,
       IOptions<SystemParameterConfiguration> systemParamOptions,
       IApplicationRepository repoApplication,
       ITermBrokenRuleRepository repoBrokenRules,
       IEmailManager repoEmailManager,
       IEmailTemplateRepository repoEmailTemplate
   ) : base(repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoBrokenRules = repoBrokenRules;
        this.repoEmailManager = repoEmailManager;
        this.repoEmailTemplate = repoEmailTemplate;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    /// 
    public async Task<EsmtSubmitApplicationCommandViewModel> Handle(EsmtSubmitApplicationCommand request, CancellationToken cancellationToken)
    {
        userContext.DeriveUserProfileFromUserId(request.UserId);
        EsmtSubmitApplicationCommandViewModel result = new();

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);
        //AuthorizationCheck(application);


        //update application
        if (application != null)
        {
            application.StatusId = (int)EsmtAppStatusEnum.APPLICATION_SUBMITTED;
            application.LastUpdatedBy = userContext.Email;
        }
         
        // check if any broken rules exists, if yes then return
         var brokenRules = (await repoBrokenRules.GetBrokenRulesAsync(application.Id))?.ToList();

        if (brokenRules != null && brokenRules.Any())
        {
            result.BrokenRules = mapper.Map<IEnumerable<FarmBrokenRuleEntity>, IEnumerable<BrokenRuleViewModel>>(brokenRules);
            return result;
        }

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            // returns broken rules  
            var defaultBrokenRules = ReturnBrokenRulesIfAny(application);

            // save broken rules
            await repoBrokenRules.SaveBrokenRules(defaultBrokenRules);
            await repoApplication.UpdateApplicationStatusAsync(application, EsmtAppStatusEnum.APPLICATION_SUBMITTED);
            FarmApplicationStatusLogEntity appStatusLog = new()
            {
                ApplicationId = application.Id,
                StatusId = application.StatusId,
                StatusDate = DateTime.Now,
                Notes = string.Empty,
                LastUpdatedBy = application.LastUpdatedBy
            };
            await repoApplication.SaveStatusLogAsync(appStatusLog);

            //send Email
            //var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.CHANGE_STATUS_FROM_DRAFT_APPLICATION_TO_APPLICATION_SUBMITTED.ToString());
            //if (template != null)
            //    await repoEmailManager.SendMail(subject: template.Subject, applicationId: request.ApplicationId, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId);
            scope.Complete();
            result.IsSuccess = true;

        }

        return result;
    }

    // <summary>
    /// Return broken rules in case of any business rule failure
    /// </summary>
    /// <param name="request"></param>
    /// <param name="application"></param>
    /// <returns></returns>
    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    {
        List<FarmBrokenRuleEntity> statusChangeRules = new List<FarmBrokenRuleEntity>();

        statusChangeRules.Add(new FarmBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)EsmtAppSectionEnum.ADMIN_DOCUMENT_CHECK_LIST,
            Message = "All documents need to be marked as Approved in the Other Documents section of the Document Checklist",
            IsApplicantFlow = false
        });
        return statusChangeRules;
    }

}

