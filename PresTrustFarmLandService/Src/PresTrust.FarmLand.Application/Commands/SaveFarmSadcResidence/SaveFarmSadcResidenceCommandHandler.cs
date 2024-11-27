namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmSadcResidenceCommandHandler : BaseHandler, IRequestHandler<SaveFarmSadcResidenceCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private IFarmSadcResidenceRepository repoSadcResidence;


    public SaveFarmSadcResidenceCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IFarmSadcResidenceRepository repoSadcResidence,
        IApplicationFeedbackRepository repoFeedback
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoSadcResidence = repoSadcResidence;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(SaveFarmSadcResidenceCommand request, CancellationToken cancellationToken)
    {
        int sadcResidenceId = 0;

        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // map command object to the FarmSadcResidenceEntity
        var reqSadcResidence = mapper.Map<SaveFarmSadcResidenceCommand, FarmSadcResidenceEntity>(request);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            var sadcResidence = await repoSadcResidence.SaveAsync(reqSadcResidence);
            if (sadcResidence != null)
            {
                sadcResidenceId = sadcResidence.Id;
            }

            scope.Complete();

        }

        return sadcResidenceId;
    }
}
