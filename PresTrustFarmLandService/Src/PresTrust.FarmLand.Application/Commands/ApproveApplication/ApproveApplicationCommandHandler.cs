namespace PresTrust.FarmLand.Application.Commands;

public class ApproveApplicationCommandHandler : BaseHandler, IRequestHandler<ApproveApplicationCommand, ApproveApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly ITermOtherDocumentsRepository repoOtherDocs;
    private readonly IEmailTemplateRepository repoEmailTemplate;
    private readonly IEmailManager repoEmailManager;

    public ApproveApplicationCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ITermBrokenRuleRepository repoBrokenRules,
        ITermOtherDocumentsRepository repoOtherDocs,
        IEmailTemplateRepository repoEmailTemplate,
        IEmailManager repoEmailManager
    ) : base(repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoBrokenRules = repoBrokenRules;
        this.repoOtherDocs = repoOtherDocs;
        this.repoEmailTemplate = repoEmailTemplate;
        this.repoEmailManager = repoEmailManager;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ApproveApplicationCommandViewModel> Handle(ApproveApplicationCommand request, CancellationToken cancellationToken)
    {
        ApproveApplicationCommandViewModel result = new();

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);

        //update application
        if (application != null)
        {
            application.StatusId = (int)TermAppStatusEnum.PETITION_APPROVED;
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
            await repoApplication.UpdateApplicationStatusAsync(application, TermAppStatusEnum.PETITION_APPROVED);
            FarmApplicationStatusLogEntity appStatusLog = new()
            {
                ApplicationId = application.Id,
                StatusId = application.StatusId,
                StatusDate = DateTime.Now,
                Notes = string.Empty,
                LastUpdatedBy = application.LastUpdatedBy
            };
            await repoApplication.SaveStatusLogAsync(appStatusLog);
            //Send Email 
            var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.CHANGE_STATUS_FROM_REQUESTED_TO_APPROVED.ToString());
            if (template != null)
                await repoEmailManager.SendMail(subject: template.Subject, applicationId: application.Id, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId, municapality: application.Municipality);

            scope.Complete();
            result.IsSuccess = true;
        }

        return result;
    }



    /// <summary>
    /// Return broken rules in case of any business rule failure
    /// </summary>
    /// <param name="request"></param>
    /// <param name="application"></param>
    /// <returns></returns>
    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    {
        List<FarmBrokenRuleEntity> statusChangeRules = new List<FarmBrokenRuleEntity>();

        // add default broken rule while initiating application flow
        statusChangeRules.Add(new FarmBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)TermAppSectionEnum.ADMIN_DETAILS,
            Message = "All required fields on ADMIN_DETAILS tab have not been filled.",

        });


      
        return statusChangeRules;
    }

}
