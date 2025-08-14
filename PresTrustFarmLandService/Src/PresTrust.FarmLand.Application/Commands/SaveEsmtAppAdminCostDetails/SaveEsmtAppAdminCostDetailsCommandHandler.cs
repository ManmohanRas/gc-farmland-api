namespace PresTrust.FarmLand.Application.Commands;
public class SaveEsmtAppAdminCostDetailsCommandHandler : BaseHandler, IRequestHandler<SaveEsmtAppAdminCostDetailsCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly IApplicationFeedbackRepository repoFeedback;
    private IFarmEsmtAppAdminCostDetailsRepository repoCostDetails;


    public SaveEsmtAppAdminCostDetailsCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IFarmEsmtAppAdminCostDetailsRepository repoCostDetails,
        IApplicationFeedbackRepository repoFeedback
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoCostDetails = repoCostDetails;
        this.repoFeedback = repoFeedback;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(SaveEsmtAppAdminCostDetailsCommand request, CancellationToken cancellationToken)
    {
        userContext.DeriveUserProfileFromUserId(request.UserId);
        int costDetailsId = 0;

        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // map command object to the FarmEsmtAppAdminCostDetailsEntity
        var reqCostDetails = mapper.Map<SaveEsmtAppAdminCostDetailsCommand, FarmEsmtAppAdminCostDetailsEntity>(request);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            var costDetails = await repoCostDetails.SaveAsync(reqCostDetails);
            if (costDetails != null)
            {
                costDetailsId = costDetails.Id;
            }

            scope.Complete();

        }

        return costDetailsId;
    }
}
