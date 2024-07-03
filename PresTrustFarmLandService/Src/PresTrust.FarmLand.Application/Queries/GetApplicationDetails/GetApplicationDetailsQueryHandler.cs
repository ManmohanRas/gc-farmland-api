namespace PresTrust.FarmLand.Application.Queries;

public class GetApplicationDetailsQueryHandler : BaseHandler, IRequestHandler<GetApplicationDetailsQuery, GetApplicationDetailsQueryViewModel>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermCommentsRepository repoComment;
    private readonly ITermFeedbacksRepository repoFeedback;

    public GetApplicationDetailsQueryHandler
        (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        ITermCommentsRepository repoComment,
        ITermFeedbacksRepository repoFeedback
        ) : base (repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoComment = repoComment;
        this.repoFeedback = repoFeedback;
    }

    public async Task<GetApplicationDetailsQueryViewModel> Handle(GetApplicationDetailsQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        var result = mapper.Map<FarmApplicationEntity, GetApplicationDetailsQueryViewModel>(application);

        FarmApplicationSecurityManager securityMgr = default;
        userContext.DeriveRole(application.AgencyId);

        securityMgr = new FarmApplicationSecurityManager(userContext.Role,application.Status, application.ApplicationType);

        var comments = await repoComment.GetAllCommentsAsync(request.ApplicationId);
        var feedbacks = await repoFeedback.GetFeedbacksAsync(request.ApplicationId);

        result.Comments = comments;
        result.Feedbacks = feedbacks;
        result.Permission = securityMgr.Permission;
        result.NavigationItems = securityMgr.NavigationItems;
        result.AdminNavigationItems = securityMgr.AdminNavigationItems;
        result.PostApprovedNavigationItems = securityMgr.PostApprovedNavigationItems;
        result.DefaultNavigationItem = securityMgr.DefaultNavigationItem;

        return result;
    }
}
