namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// This class handles the query to fetch data and build response
/// </summary>
public class EsmtWithdrawApplicationCommandHandler : BaseHandler, IRequestHandler<EsmtWithdrawApplicationCommand, Unit>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly IApplicationRepository repoApplication;
    private readonly SystemParameterConfiguration systemParamOptions;

    /// <summary>
    /// 
    /// </summary>
    /// <param name="mapper"></param>
    /// <param name="repoApplication"></param>
    public EsmtWithdrawApplicationCommandHandler
    (
         IMapper mapper,
         IPresTrustUserContext userContext,
         IOptions<SystemParameterConfiguration> systemParamOptions,
         IApplicationRepository repoApplication

    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.repoApplication = repoApplication;
        this.systemParamOptions = systemParamOptions.Value;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Unit> Handle(EsmtWithdrawApplicationCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        //update application
        if (application != null)
        {
            application.StatusId = (int)EsmtAppStatusEnum.WITHDRAWN;
            application.LastUpdatedBy = userContext.Email;
        }

        // update application status
        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoApplication.UpdateApplicationStatusAsync(application, EsmtAppStatusEnum.WITHDRAWN);
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
        };

        return Unit.Value;
    }
}
