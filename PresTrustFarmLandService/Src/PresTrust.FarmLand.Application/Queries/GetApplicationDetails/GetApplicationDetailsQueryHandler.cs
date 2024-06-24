namespace PresTrust.FarmLand.Application.Queries;

public class GetApplicationDetailsQueryHandler : BaseHandler, IRequestHandler<GetApplicationDetailsQuery, GetApplicationDetailsQueryViewModel>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;

    public GetApplicationDetailsQueryHandler
        (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication
        ): base (repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
    }

    public async Task<GetApplicationDetailsQueryViewModel> Handle(GetApplicationDetailsQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        var result = mapper.Map<FarmApplicationEntity, GetApplicationDetailsQueryViewModel>(application);

        FarmApplicationSecurityManager securityMgr = default;
        userContext.DeriveRole(application.AgencyId);

        securityMgr = new FarmApplicationSecurityManager(application.ApplicationType);

        result.Permission = securityMgr.Permission;
        result.NavigationItems = securityMgr.NavigationItems;
        result.AdminNavigationItems = securityMgr.AdminNavigationItems;
        result.PostApprovedNavigationItems = securityMgr.PostApprovedNavigationItems;
        result.DefaultNavigationItem = securityMgr.DefaultNavigationItem;

        return result;
    }
}
