namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// This class handles the query to fetch data and build response
/// </summary>
public class WithdrawApplicationCommandHandler : BaseHandler, IRequestHandler<WithdrawApplicationCommand, Unit>
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
    public WithdrawApplicationCommandHandler
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
    public async Task<Unit> Handle(WithdrawApplicationCommand request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // update application status
        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoApplication.UpdateApplicationStatusAsync(application, TermAppStatusEnum.WITHDRAWN);

            scope.Complete();
        };

        return Unit.Value;
    }



}
