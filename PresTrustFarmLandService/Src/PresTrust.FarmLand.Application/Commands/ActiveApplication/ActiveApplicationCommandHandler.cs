namespace PresTrust.FarmLand.Application.Commands;

public class ActiveApplicationCommandHandler : BaseHandler, IRequestHandler<ActiveApplicationCommand, ActiveApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly IEmailTemplateRepository repoEmailTemplate;
    private readonly IEmailManager repoEmailManager;
    private readonly ITermAppAdminDetailsRepository repoTermAppAdminDetailsRepository;
    private readonly ITermBrokenRuleRepository repoBrokenRules;

    public ActiveApplicationCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IEmailTemplateRepository repoEmailTemplate,
        IEmailManager repoEmailManager,
        ITermAppAdminDetailsRepository repoTermAppAdminDetailsRepository,
        ITermBrokenRuleRepository repoBrokenRules
    ) : base(repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoEmailTemplate = repoEmailTemplate;
        this.repoEmailManager = repoEmailManager;
        this.repoTermAppAdminDetailsRepository = repoTermAppAdminDetailsRepository;
        this.repoBrokenRules = repoBrokenRules;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ActiveApplicationCommandViewModel> Handle(ActiveApplicationCommand request, CancellationToken cancellationToken)
    {
        ActiveApplicationCommandViewModel result = new();

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);

        //update application
        if (application != null)
        {
            application.StatusId = (int)ApplicationStatusEnum.ACTIVE;
            application.LastUpdatedBy = userContext.Email;
        }

        // check if any broken rules exists, if yes then return
        var brokenRules = (await repoBrokenRules.GetBrokenRulesAsync(application.Id))?.ToList();

        if (brokenRules != null && brokenRules.Any())
        {
            result.BrokenRules = mapper.Map<IEnumerable<TermBrokenRuleEntity>, IEnumerable<TermBrokenRuleViewModel>>(brokenRules);
            return result;
        }

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            var defaultBrokenRules = ReturnBrokenRulesIfAny(application);
            await repoBrokenRules.SaveBrokenRules(defaultBrokenRules);

            // save broken rules
            await repoApplication.UpdateApplicationStatusAsync(application, ApplicationStatusEnum.ACTIVE);
            FarmApplicationStatusLogEntity appStatusLog = new()
            {
                ApplicationId = application.Id,
                StatusId = application.StatusId,
                StatusDate = DateTime.Now,
                Notes = string.Empty,
                LastUpdatedBy = application.LastUpdatedBy
            };
            await repoApplication.SaveStatusLogAsync(appStatusLog);

            var admindetails = await this.repoTermAppAdminDetailsRepository.GetTermAppAdminDetailsAsync(request.ApplicationId);



            //Send Email 
            var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.CHANGE_STATUS_FROM_AGREEMENT_APPROVED_TO_ACTIVE.ToString());
            if (template != null)
                await repoEmailManager.SendMail(subject: template.Subject, applicationId: application.Id, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId);

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
    private List<TermBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application)
    {
        List<TermBrokenRuleEntity> statusChangeRules = new List<TermBrokenRuleEntity>();

        statusChangeRules.Add(new TermBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)ApplicationSectionEnum.ADMIN_DETAILS,
            Message = "All required fields on ADMIN DETAILS tab have not been filled.",
        });
        return statusChangeRules;
    }
}
