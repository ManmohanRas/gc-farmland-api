namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtSadcHistoryCommandHandler : BaseHandler, IRequestHandler<SaveFarmEsmtSadcHistoryCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private IFarmEsmtSadcHistoryRepository repoSadcHistory;


    public SaveFarmEsmtSadcHistoryCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IFarmEsmtSadcHistoryRepository repoSadcHistory,
        IApplicationFeedbackRepository repoFeedback
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoSadcHistory = repoSadcHistory;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(SaveFarmEsmtSadcHistoryCommand request, CancellationToken cancellationToken)
    {
        userContext.DeriveUserProfileFromUserId(request.UserId);
        int sadcHistoryId = 0;

        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // map command object to the FarmEsmtSadcHistoryEntity
        var reqSadcHistory = mapper.Map<SaveFarmEsmtSadcHistoryCommand, FarmEsmtSadcHistoryEntity>(request);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            var sadcHistory = await repoSadcHistory.SaveAsync(reqSadcHistory);
            if (sadcHistory != null)
            {
                sadcHistoryId = sadcHistory.Id;
            }

            scope.Complete();

        }

        return sadcHistoryId;
    }
}
