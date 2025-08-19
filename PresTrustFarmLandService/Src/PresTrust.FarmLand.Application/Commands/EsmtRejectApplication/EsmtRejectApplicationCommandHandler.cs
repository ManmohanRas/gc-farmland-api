namespace PresTrust.FarmLand.Application.Commands;
public class EsmtRejectApplicationCommandHandler :BaseHandler,IRequestHandler<EsmtRejectApplicationCommand,Unit>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly IApplicationRepository repoApplication;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly ITermBrokenRuleRepository repoBrokenRules;
    private readonly IEmailTemplateRepository repoEmailTemplate;
    private readonly IEmailManager repoEmailManager;


    public EsmtRejectApplicationCommandHandler
        (IMapper mapper,
        IPresTrustUserContext userContext, 
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IEmailTemplateRepository repoEmailTemplate,
        IEmailManager repoEmailManager,
        ITermBrokenRuleRepository repoBrokenRules) :base(repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.repoApplication = repoApplication;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoBrokenRules = repoBrokenRules;
        this.repoEmailTemplate = repoEmailTemplate;
        this.repoEmailManager = repoEmailManager;
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(EsmtRejectApplicationCommand request, CancellationToken cancellationToken)
    {
        userContext.DeriveUserProfileFromUserId(request.UserId);
        var application = await repoApplication.GetApplicationAsync(request.ApplicationId);


        //update application
        if (application != null)
        {
            application.StatusId = (int)EsmtAppStatusEnum.REJECTED;
            application.LastUpdatedBy = userContext.Email;
        }

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoApplication.UpdateApplicationStatusAsync(application, EsmtAppStatusEnum.REJECTED);
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
            //var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.CHANGE_STATUS_FROM_IN_REVIEW_TO_REJECTED.ToString());
            //if (template != null)
            //    await repoEmailManager.SendMail(subject: template.Subject, applicationId: application.Id, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId);

            scope.Complete();
        }

        return Unit.Value;
    }
}
