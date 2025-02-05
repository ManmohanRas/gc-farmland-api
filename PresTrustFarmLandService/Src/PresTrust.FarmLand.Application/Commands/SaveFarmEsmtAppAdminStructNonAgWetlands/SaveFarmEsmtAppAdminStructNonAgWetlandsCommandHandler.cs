namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAppAdminStructNonAgWetlandsCommandHandler : BaseHandler, IRequestHandler<SaveFarmEsmtAppAdminStructNonAgWetlandsCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly IApplicationFeedbackRepository repoFeedback;
    private IFarmEsmtAppAdminStructNonAgWetlandsRepository repoWetlands;


    public SaveFarmEsmtAppAdminStructNonAgWetlandsCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IFarmEsmtAppAdminStructNonAgWetlandsRepository repoWetlands,
        IApplicationFeedbackRepository repoFeedback
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoWetlands = repoWetlands;
        this.repoFeedback = repoFeedback;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(SaveFarmEsmtAppAdminStructNonAgWetlandsCommand request, CancellationToken cancellationToken)
    {
        int wetlandsId = 0;

        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // map command object to the FarmEsmtApplicationSignatoryEntity
        var reqWetlands = mapper.Map<SaveFarmEsmtAppAdminStructNonAgWetlandsCommand, FarmEsmtAppAdminStructNonAgWetlandsEntity>(request);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            var wetlands = await repoWetlands.SaveAsync(reqWetlands);
            if (wetlands != null)
            {
                wetlandsId = wetlands.Id;
            }

            scope.Complete();

        }

        return wetlandsId;
    }
}
