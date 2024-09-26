namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// This class handles the command to update data and build response
/// </summary>
public class CreateEsmtApplicationCommandHandler : BaseHandler, IRequestHandler<CreateEsmtApplicationCommand, CreateEsmtApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IApplicationCommentRepository repoComment;
    private readonly IApplicationFeedbackRepository repoFeedback;
    private readonly ITermBrokenRuleRepository repoBrokenRule;


    public CreateEsmtApplicationCommandHandler
        (
        IMapper mapper,
        IApplicationRepository repoApplication,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IApplicationCommentRepository repoComment,
        IApplicationFeedbackRepository repoFeedback,
        ITermBrokenRuleRepository  repoBrokenRule
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoComment = repoComment;
        this.repoFeedback = repoFeedback;
        this.repoBrokenRule = repoBrokenRule;
    }
    public async Task<CreateEsmtApplicationCommandViewModel> Handle(CreateEsmtApplicationCommand request, CancellationToken cancellationToken)
    {
        var reqApplication = mapper.Map<CreateEsmtApplicationCommand, FarmApplicationEntity>(request);
        
        
            reqApplication.Status = EsmtAppStatusEnum.DRAFT_APPLICATION;
        
        reqApplication.CreatedByProgramUser = userContext.Role == UserRoleEnum.PROGRAM_ADMIN;
        reqApplication.LastUpdatedBy = userContext.Email;
        reqApplication.CreatedBy = userContext.Email;
        reqApplication.IsApprovedByMunicipality = request.IsApprovedByMunicipality;
        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoApplication.SaveAsync(reqApplication);
            FarmApplicationStatusLogEntity appStatusLog = new()
            {
                ApplicationId = reqApplication.Id,
                StatusId = reqApplication.StatusId,
                StatusDate = DateTime.Now,
                Notes = string.Empty,
                LastUpdatedBy = reqApplication.LastUpdatedBy
            };
            // returns broken rules  
            var brokenRule = ReturnBrokenRulesIfAny(request, reqApplication);
            // save broken rules
            await repoBrokenRule.SaveBrokenRules(brokenRule);

            await repoApplication.SaveStatusLogAsync(appStatusLog);

            scope.Complete();
        }

        var application = await GetIfApplicationExists(reqApplication.Id);
        var result = mapper.Map<FarmApplicationEntity, CreateEsmtApplicationCommandViewModel>(reqApplication);
        result.FarmName = application.FarmName;

        // apply security
        FarmEsmtAppSecurityManager securityMgr = default;
        // derive user's role for a given agency
        userContext.DeriveRole(application.AgencyId);

        securityMgr = new FarmEsmtAppSecurityManager(userContext.Role, application.Status);

        var comments = await repoComment.GetAllCommentsAsync(application.Id);
        var feedbacks = await repoFeedback.GetFeedbacksAsync(application.Id);

        result.Comments = comments;
        result.Feedbacks = feedbacks;
        result.Agency = application.Agency;
        result.EsmtPermission = securityMgr.EsmtPermission;
        result.NavigationItems = securityMgr.NavigationItems;
        result.AdminNavigationItems = securityMgr.AdminNavigationItems;
        result.PostApprovedNavigationItems = securityMgr.PostApprovedNavigationItems;
        result.DefaultNavigationItem = securityMgr.DefaultNavigationItem;

        return result;

    }


    /// Ensure that a user has the relevant authorizations to perform an action
    /// </summary>
    private void AuthorizationCheck(FarmApplicationEntity application)
    {
        // security
        userContext.DeriveRole(application.AgencyId);
        IsAuthorizedOperation(userRole: userContext.Role, application: application, operation: TermUserPermissionEnum.CREATE_APPLICATION);
    }

    /// <summary>
    /// Return broken rules in case of any business rule failure
    /// </summary>
    /// <param name="request"></param>
    /// <param name="application"></param>
    /// <returns></returns>
    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(CreateEsmtApplicationCommand request, FarmApplicationEntity application)
    {
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        return brokenRules;
    }
}
