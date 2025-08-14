namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAppAdminDetailsCommandHandler : BaseHandler, IRequestHandler<SaveFarmEsmtAppAdminDetailsCommand, int>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly IApplicationFeedbackRepository repoFeedback;
    private IFarmEsmtAppAdminDetailsRepository repoAdminDetails;


    public SaveFarmEsmtAppAdminDetailsCommandHandler
    (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IFarmEsmtAppAdminDetailsRepository repoAdminDetails,
        IApplicationFeedbackRepository repoFeedback
    ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoAdminDetails = repoAdminDetails;
        this.repoFeedback = repoFeedback;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<int> Handle(SaveFarmEsmtAppAdminDetailsCommand request, CancellationToken cancellationToken)
    {
        userContext.DeriveUserProfileFromUserId(request.UserId);
        int adminDetailsId = 0;

        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // map command object to the FarmEsmtAppAdminDetailsEntity
        var reqAdminDetails = mapper.Map<SaveFarmEsmtAppAdminDetailsCommand, FarmEsmtAppAdminDetailsEntity>(request);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            var adminDetails = await repoAdminDetails.SaveAsync(reqAdminDetails);
            if (adminDetails != null)
            {
                adminDetailsId = adminDetails.Id;
            }

            scope.Complete();

        }

        return adminDetailsId;
    }
}
