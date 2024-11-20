namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtApplicationDetailsQueryHandler : BaseHandler, IRequestHandler<GetEsmtApplicationDetailsQuery, GetEsmtApplicationDetailsQueryViewModel>
{
    private IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationRepository repoApplication;
    private readonly IApplicationCommentRepository repoComment;
    private readonly IApplicationFeedbackRepository repoFeedback;

    public GetEsmtApplicationDetailsQueryHandler
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

    public async Task<GetEsmtApplicationDetailsQueryViewModel> Handle(GetEsmtApplicationDetailsQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);
        var comments = await repoComment.GetAllCommentsAsync(request.ApplicationId);
        var feedbacks = await repoFeedback.GetFeedbacksAsync(request.ApplicationId);

        var result = mapper.Map<FarmApplicationEntity, GetEsmtApplicationDetailsQueryViewModel>(application);

        FarmEsmtAppSecurityManager securityMgr = default;
        //userContext.DeriveRole(application.AgencyId);

        switch (application.Status)
        {

            case EsmtAppStatusEnum.APPLICATION_SUBMITTED:
            case EsmtAppStatusEnum.IN_REVIEW:
            case EsmtAppStatusEnum.PENDING:
            case EsmtAppStatusEnum.REJECTED:
            case EsmtAppStatusEnum.ACTIVE:
            case EsmtAppStatusEnum.CLOSING:
            case EsmtAppStatusEnum.POST_CLOSING:
            case EsmtAppStatusEnum.PRESERVED:
            case EsmtAppStatusEnum.WITHDRAWN:
                var feedbacksReqForCorrections = feedbacks.Where(f => f.RequestForCorrection == true && string.Compare(f.CorrectionStatus, ApplicationCorrectionStatusEnum.REQUEST_SENT.ToString(), true) == 0).ToList();
                securityMgr = new FarmEsmtAppSecurityManager(userContext.Role, application.Status, feedbacksReqForCorrections, application.IsSADC);
                break;
            default:

                securityMgr = new FarmEsmtAppSecurityManager(userContext.Role, application.Status);
                break;
        }

        

        result.Comments = comments;
        result.Feedbacks = feedbacks;
        result.EsmtPermission = securityMgr.EsmtPermission;
        result.NavigationItems = securityMgr.NavigationItems;
        result.AdminNavigationItems = securityMgr.AdminNavigationItems;
        result.PostApprovedNavigationItems = securityMgr.PostApprovedNavigationItems;
        result.SADCNavigationItems = securityMgr.SADCNavigationItems;
        result.DefaultNavigationItem = securityMgr.DefaultNavigationItem;

        return result;
    }
}
