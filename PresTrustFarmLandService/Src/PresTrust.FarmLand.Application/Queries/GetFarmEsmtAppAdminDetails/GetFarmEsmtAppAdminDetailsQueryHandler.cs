namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAppAdminDetailsQueryHandler : BaseHandler, IRequestHandler<GetFarmEsmtAppAdminDetailsQuery, GetFarmEsmtAppAdminDetailsQueryViewModel>
{
    private IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private IFarmEsmtAppAdminDetailsRepository repoAdminDetails;
    private readonly IPresTrustUserContext userContext;

    public GetFarmEsmtAppAdminDetailsQueryHandler(
        IMapper mapper,
        IApplicationRepository repoApplication,
        IFarmEsmtAppAdminDetailsRepository repoAdminDetails,
        IPresTrustUserContext userContext
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoAdminDetails = repoAdminDetails;
        this.userContext = userContext;
    }

    public async Task<GetFarmEsmtAppAdminDetailsQueryViewModel> Handle(GetFarmEsmtAppAdminDetailsQuery request, CancellationToken cancellationToken)
    {
        userContext.DeriveUserProfileFromUserId(request.UserId);
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // get AdminDetails details
        var adminDetails = await this.repoAdminDetails.GetAdminDetailsAsync(request.ApplicationId);
        var result = mapper.Map<FarmEsmtAppAdminDetailsEntity, GetFarmEsmtAppAdminDetailsQueryViewModel>(adminDetails);

        return result;
    }
}
