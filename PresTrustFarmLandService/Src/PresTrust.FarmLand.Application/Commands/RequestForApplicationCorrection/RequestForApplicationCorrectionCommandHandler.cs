namespace PresTrust.FarmLand.Application.Commands;

public class RequestForApplicationCorrectionCommandHandler : BaseHandler, IRequestHandler<RequestForApplicationCorrectionCommand, bool>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly IApplicationFeedbackRepository repoFeedback;
    private readonly IEmailManager repoEmailManager;
    private readonly IEmailTemplateRepository repoEmailTemplate;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="userContext"></param>
    /// <param name="systemParamOptions"></param>
    /// <param name="repoApplication"></param>
    /// <param name="repoFeedback"></param>

    public RequestForApplicationCorrectionCommandHandler
     (
         IMapper mapper,
         IPresTrustUserContext userContext,
         IOptions<SystemParameterConfiguration> systemParamOptions,
         IApplicationRepository repoApplication,
         IApplicationFeedbackRepository repoFeedback,
         IEmailManager repoEmailManager,
        IEmailTemplateRepository repoEmailTemplate
     ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoFeedback = repoFeedback;
        this.repoEmailManager = repoEmailManager;
        this.repoEmailTemplate = repoEmailTemplate;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> Handle(RequestForApplicationCorrectionCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);
       // AuthorizationCheck(application);

        // update feedback status and send email to an applicant
        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoFeedback.RequestForApplicationCorrectionAsync(application.Id);

            // Send Email
            var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.FEEDBACK_RECEIVED_EMAIL.ToString());
            if (template != null)
                await repoEmailManager.SendMail(subject: template.Subject, applicationId: application.Id, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId);


            scope.Complete();
        };

        return true;
    }

}
