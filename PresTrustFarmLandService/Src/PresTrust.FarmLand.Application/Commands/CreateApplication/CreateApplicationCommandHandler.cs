namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// This class handles the command to update data and build response
/// </summary>
public class CreateApplicationCommandHandler : BaseHandler, IRequestHandler<CreateApplicationCommand, CreateApplicationCommandViewModel>
{
    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly ITermCommentsRepository repoComment;
    private readonly ITermFeedbacksRepository repoFeedback;
    private readonly ITermBrokenRuleRepository repoBrokenRule;


    public CreateApplicationCommandHandler
        (
        IMapper mapper,
        IApplicationRepository repoApplication,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        ITermCommentsRepository repoComment,
        ITermFeedbacksRepository repoFeedback,
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
    public async Task<CreateApplicationCommandViewModel> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
    {
        var reqApplication = mapper.Map<CreateApplicationCommand, FarmApplicationEntity>(request);
        reqApplication.Status = ApplicationStatusEnum.PETITION_DRAFT;
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
        var result = mapper.Map<FarmApplicationEntity, CreateApplicationCommandViewModel>(reqApplication);
        result.FarmName = application.FarmName;

        // apply security
        FarmApplicationSecurityManager securityMgr = default;
        // derive user's role for a given agency
        userContext.DeriveRole(application.AgencyId);

        securityMgr = new FarmApplicationSecurityManager(userContext.Role, application.Status, application.ApplicationType);

        var comments = await repoComment.GetAllCommentsAsync(application.Id);
        var feedbacks = await repoFeedback.GetFeedbacksAsync(application.Id);

        result.Comments = comments;
        result.Feedbacks = feedbacks;
        result.Agency = application.Agency;
        result.Permission = securityMgr.Permission;
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
        IsAuthorizedOperation(userRole: userContext.Role, application: application, operation: UserPermissionEnum.CREATE_APPLICATION);
    }

    /// <summary>vere intiki
    /// Return broken rules in case of any business rule failure
    /// </summary>
    /// <param name="request"></param>
    /// <param name="application"></param>
    /// <returns></returns>
    private List<TermBrokenRuleEntity> ReturnBrokenRulesIfAny(CreateApplicationCommand request, FarmApplicationEntity application)
    {
        List<TermBrokenRuleEntity> brokenRules = new List<TermBrokenRuleEntity>();

        // add default broken rule while creating an application
        brokenRules.Add(new TermBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)ApplicationSectionEnum.TERM_LOCATION,
            Message = "All required fields on Location tab have not been filled.",
            IsApplicantFlow = true
        });

        brokenRules.Add(new TermBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)ApplicationSectionEnum.TERM_OWNER_DETAILS,
            Message = "All required fields on Owner Details tab have not been filled.",
            IsApplicantFlow = true
        });

        brokenRules.Add(new TermBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)ApplicationSectionEnum.TERM_SITE_CHARACTERISTICS,
            Message = "All required fields on Site Charecteristics tab have not been filled.",
            IsApplicantFlow = true
        });
        brokenRules.Add(new TermBrokenRuleEntity()
        {
            ApplicationId = application.Id,
            SectionId = (int)ApplicationSectionEnum.TERM_SIGNATORY,
            Message = "All required fields on Signatory tab have not been filled.",
            IsApplicantFlow = true
        });

        return brokenRules;
    }
}
