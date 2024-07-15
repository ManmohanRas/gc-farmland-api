namespace PresTrust.FarmLand.Application.Commands;

public class EnableSadcCommandHandler : BaseHandler, IRequestHandler<EnableSadcCommand, Unit>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly IEmailTemplateRepository repoEmailTemplate;
    private readonly IEmailManager repoEmailManager;

    public EnableSadcCommandHandler
        (

        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IEmailTemplateRepository repoEmailTemplate,
        IEmailManager repoEmailManager
        ) : base (repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoEmailTemplate = repoEmailTemplate;
        this.repoEmailManager = repoEmailManager;
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(EnableSadcCommand request, CancellationToken cancellationToken)
    {

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);

        //Send Email 
        var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.TRIGER_THE_EMAIL_WHEN__SADC_BUTTON_IS_ENABLED.ToString());
            if (template != null)
                await repoEmailManager.SendMail(subject: template.Subject, applicationId: application.Id, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId);

        return Unit.Value;
    }
}
