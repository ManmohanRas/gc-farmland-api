namespace PresTrust.FarmLand.Application.Commands;

public class AssignRolesCommandHandler : BaseHandler, IRequestHandler<AssignRolesCommand, Unit>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IFarmRolesRepository repoApplicationUser;
    private readonly IApplicationRepository repoApplication;
    private readonly ITermBrokenRuleRepository repoBrokenRules;


    public AssignRolesCommandHandler(
         IMapper mapper,
         IPresTrustUserContext userContext,
         IOptions<SystemParameterConfiguration> systemParamOptions,
         IFarmRolesRepository repoApplicationUser,
         IApplicationRepository repoApplication,
         ITermBrokenRuleRepository repoBrokenRules
         ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplicationUser = repoApplicationUser;
        this.repoApplication = repoApplication;
        this.repoBrokenRules = repoBrokenRules;
    }

    public async Task<Unit> Handle(AssignRolesCommand request, CancellationToken cancellationToken)
    {

        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqApplicationUsers = mapper.Map<IEnumerable<FarmRolesViewModel>, IEnumerable<FarmRolesEntity>>(request.ApplicationUsers).ToList();

       // List<FarmRolesEntity> users = reqApplicationUsers.Where(au => (au.IsPrimaryContact) || (au.IsAlternateContact)).ToList();

        foreach (var applicationUser in reqApplicationUsers)
        {
            applicationUser.LastUpdatedBy = userContext.Email;
            applicationUser.ApplicationId = request.ApplicationId;
        }

        // returns broken rules  
        var brokenRules = ReturnBrokenRulesIfAny(application, reqApplicationUsers);

        using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        {
            await repoApplicationUser.DeleteRolesAsync(request.ApplicationId);
            List<FarmRolesEntity> users = reqApplicationUsers.Where(au => (au.IsPrimaryContact) || (au.IsAlternateContact)).ToList();

            await repoApplicationUser.SaveAsync(users);

            await repoBrokenRules.DeleteBrokenRulesAsync(application.Id, EsmtAppSectionEnum.ROLES);

            if (brokenRules.Count() > 0)
            await repoBrokenRules.SaveBrokenRules(brokenRules);

            scope.Complete();
        }
        return Unit.Value;
    }


    /// <summary>
    /// Return broken rules in case of any business rule failure
    /// </summary>
    /// <param name="request"></param>
    /// <param name="application"></param>
    /// <returns></returns>
    private List<FarmBrokenRuleEntity> ReturnBrokenRulesIfAny(FarmApplicationEntity application, List<FarmRolesEntity> reqApplicationUsers)
    {
        int sectionId = (int)EsmtAppSectionEnum.ROLES;
        List<FarmBrokenRuleEntity> brokenRules = new List<FarmBrokenRuleEntity>();

        var primaryContacts = reqApplicationUsers.Where(au => au.IsPrimaryContact).ToList();

        // empty primary contacts list
        if (application.Status == EsmtAppStatusEnum.DRAFT_APPLICATION)
        {
            if (primaryContacts == null || primaryContacts.Count() == 0)
                brokenRules.Add(new FarmBrokenRuleEntity()
                {
                    ApplicationId = application.Id,
                    SectionId = sectionId,
                    Message = "Primary Contact must be assigned to the application.",
                    IsApplicantFlow = true
                });
        }

        return brokenRules;
    }
}
