namespace PresTrust.FarmLand.Application.Commands;

public class EsmtPostClosingApplicationCommandHandler : BaseHandler, IRequestHandler<EsmtPostClosingApplicationCommand, EsmtPostClosingApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;

    public EsmtPostClosingApplicationCommandHandler
  (
    IMapper mapper,
    IPresTrustUserContext userContext,
    IOptions<SystemParameterConfiguration> systemParamOptions,
    IApplicationRepository repoApplication
  ) : base(repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
    }

    public async Task<EsmtPostClosingApplicationCommandViewModel> Handle(EsmtPostClosingApplicationCommand request, CancellationToken cancellationToken)
    {
        EsmtPostClosingApplicationCommandViewModel result = new();

        // check if application exists
        var application = await GetIfApplicationExists(request.ApplicationId);

        //update application
        if (application != null)
        {
            application.StatusId = (int)EsmtAppStatusEnum.POST_CLOSING;
            application.LastUpdatedBy = userContext.Email;
        }

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoApplication.UpdateApplicationStatusAsync(application, EsmtAppStatusEnum.POST_CLOSING);
            FarmApplicationStatusLogEntity appStatusLog = new()
            {
                ApplicationId = application.Id,
                StatusId = application.StatusId,
                StatusDate = DateTime.Now,
                Notes = string.Empty,
                LastUpdatedBy = application.LastUpdatedBy
            };
            await repoApplication.SaveStatusLogAsync(appStatusLog);

            scope.Complete();
            result.IsSuccess = true;

        }

        return result;
    }
}
