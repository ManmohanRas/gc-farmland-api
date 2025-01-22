namespace PresTrust.FarmLand.Application.Commands;

public class SaveEmailTemplateCommandHandler: IRequestHandler<SaveEmailTemplateCommand, int>
{
     private readonly IMapper mapper;
     private readonly IPresTrustUserContext userContext;
     private readonly IEmailTemplateRepository repoEmailTemplate;
     private readonly IEmailManager repoEmailManager;
     private readonly SystemParameterConfiguration systemParamOptions;

    public SaveEmailTemplateCommandHandler
    (
    IMapper mapper,
    IPresTrustUserContext userContext,
    IEmailTemplateRepository repoEmailTemplate,
    IEmailManager repoEmailManager,
    IOptions<SystemParameterConfiguration> systemParamOptions
    )
{
    this.mapper = mapper;
    this.userContext = userContext;
    this.repoEmailTemplate = repoEmailTemplate;
    this.repoEmailManager = repoEmailManager;
    this.systemParamOptions = systemParamOptions.Value;
    }

    public async Task<int> Handle(SaveEmailTemplateCommand request, CancellationToken cancellationToken)
{
    FarmEmailTemplateEntity emailTemplate = default;

    // map command object to the HistEmailTemplateEntity
    var reqTemplate = mapper.Map<SaveEmailTemplateCommand, FarmEmailTemplateEntity>(request);
    reqTemplate.LastUpdatedBy = userContext.Email;

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            emailTemplate = await repoEmailTemplate.SaveEmailAsync(reqTemplate);

            //Send Email
            if (reqTemplate.TemplateCode == EmailTemplateCodeTypeEnum.FARM_MONITORING.ToString())
            {
                var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.FARM_MONITORING.ToString());
                if (template != null)
                    await repoEmailManager.SendMail(subject: template.Subject, applicationId: 0, applicationName: string.Empty, htmlBody: template.Description, agencyId: 0);
            }

            scope.Complete();

        }
        return emailTemplate.Id;

    }
}
