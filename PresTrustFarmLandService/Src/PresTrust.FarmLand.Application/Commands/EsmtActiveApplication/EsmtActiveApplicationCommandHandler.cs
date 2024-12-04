using Microsoft.AspNetCore.Builder;

namespace PresTrust.FarmLand.Application.Commands;

public class EsmtActiveApplicationCommandHandler : BaseHandler, IRequestHandler<EsmtActiveApplicationCommand, EsmtActiveApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly IEmailTemplateRepository repoEmailTemplate;
    private readonly IEmailManager repoEmailManager;

    public EsmtActiveApplicationCommandHandler
    (
      IMapper mapper,
      IPresTrustUserContext userContext,
      IOptions<SystemParameterConfiguration> systemParamOptions,
      IApplicationRepository repoApplication,
       IEmailTemplateRepository repoEmailTemplate,
        IEmailManager repoEmailManager
    ) : base(repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoEmailTemplate = repoEmailTemplate;
        this.repoEmailManager = repoEmailManager;
    }
    public async Task<EsmtActiveApplicationCommandViewModel> Handle(EsmtActiveApplicationCommand request, CancellationToken cancellationToken)
    {
        EsmtActiveApplicationCommandViewModel result = new();

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);

        //update application
        if (application != null)
        {
            application.StatusId = (int)EsmtAppStatusEnum.ACTIVE;
            application.LastUpdatedBy = userContext.Email;
        }

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoApplication.UpdateApplicationStatusAsync(application, EsmtAppStatusEnum.ACTIVE);
            FarmApplicationStatusLogEntity appStatusLog = new()
            {
                ApplicationId = application.Id,
                StatusId = application.StatusId,
                StatusDate = DateTime.Now,
                Notes = string.Empty,
                LastUpdatedBy = application.LastUpdatedBy
            };
            await repoApplication.SaveStatusLogAsync(appStatusLog);

            // Send Email
            var template = await repoEmailTemplate.GetEmailTemplate(EmailTemplateCodeTypeEnum.CHANGE_STATUS_PENDING_TO_ACTIVE.ToString());
            if (template != null)
              await repoEmailManager.SendMail(subject: template.Subject, applicationId: application.Id, applicationName: application.Title, htmlBody: template.Description, agencyId: application.AgencyId);
            scope.Complete();
            result.IsSuccess = true;
        }

        return result;
    }
}
