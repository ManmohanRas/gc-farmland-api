namespace PresTrust.FarmLand.Application.Queries;

public class GetTermApplicationDetailsQueryHandler : BaseHandler, IRequestHandler<GetTermApplicationDetailsQuery, GetTermApplicationDetailsQueryViewModel>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly IApplicationCommentRepository repoComment;
    private readonly IApplicationFeedbackRepository repoFeedback;

    public GetTermApplicationDetailsQueryHandler
        (
        IMapper mapper,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationRepository repoApplication,
        IApplicationCommentRepository repoComment,
        IApplicationFeedbackRepository repoFeedback
        ) : base (repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplication = repoApplication;
        this.repoComment = repoComment;
        this.repoFeedback = repoFeedback;
    }

    public async Task<GetTermApplicationDetailsQueryViewModel> Handle(GetTermApplicationDetailsQuery request, CancellationToken cancellationToken)
    {
        userContext.DeriveUserProfileFromUserId(request.UserId);
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);
        var comments = await repoComment.GetAllCommentsAsync(request.ApplicationId);
        var feedbacks = await repoFeedback.GetFeedbacksAsync(request.ApplicationId);

        var result = mapper.Map<FarmApplicationEntity, GetTermApplicationDetailsQueryViewModel>(application);

        FarmApplicationSecurityManager securityMgr = default;
        userContext.DeriveRole(application.AgencyId);

        switch (application.Status)
        {
            case TermAppStatusEnum.PETITION_REQUEST:
            case TermAppStatusEnum.PETITION_APPROVED:
            case TermAppStatusEnum.AGREEMENT_APPROVED:
            case TermAppStatusEnum.EXPIRED:
            case TermAppStatusEnum.REJECTED:
            case TermAppStatusEnum.ACTIVE:
                var feedbacksReqForCorrections = feedbacks.Where(f => f.RequestForCorrection == true && string.Compare(f.CorrectionStatus, ApplicationCorrectionStatusEnum.REQUEST_SENT.ToString(), true) == 0).ToList();
                securityMgr = new FarmApplicationSecurityManager(userContext.Role, application.Status, application.ApplicationType, feedbacksReqForCorrections);
                break;
            default:
                securityMgr = new FarmApplicationSecurityManager(userContext.Role, application.Status, application.ApplicationType);
                break;
        }

        

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
