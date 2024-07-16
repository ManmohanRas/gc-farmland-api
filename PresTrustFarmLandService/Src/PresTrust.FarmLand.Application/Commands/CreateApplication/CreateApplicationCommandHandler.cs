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


    public CreateApplicationCommandHandler
        (
        IMapper mapper,
        IApplicationRepository repoApplication,
        IPresTrustUserContext userContext,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        ITermCommentsRepository repoComment,
        ITermFeedbacksRepository repoFeedback
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoComment = repoComment;
        this.repoFeedback = repoFeedback;
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

            await repoApplication.SaveStatusLogAsync(appStatusLog);

            scope.Complete();
        }

        var application = await GetIfApplicationExists(reqApplication.Id);
        var result = mapper.Map<FarmApplicationEntity, CreateApplicationCommandViewModel>(reqApplication);

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
}
