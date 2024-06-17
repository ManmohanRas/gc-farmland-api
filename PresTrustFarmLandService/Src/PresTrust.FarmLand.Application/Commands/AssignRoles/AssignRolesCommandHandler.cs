namespace PresTrust.FarmLand.Application.Commands;

public class AssignRolesCommandHandler : BaseHandler, IRequestHandler<AssignRolesCommand, Unit>
{
    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IFarmRolesRepository repoApplicationUser;
    private readonly IApplicationRepository repoApplication;
    public AssignRolesCommandHandler(
         IMapper mapper,
         IPresTrustUserContext userContext,
         IOptions<SystemParameterConfiguration> systemParamOptions,
         IFarmRolesRepository repoApplicationUser,
         IApplicationRepository repoApplication
         ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.repoApplicationUser = repoApplicationUser;
        this.repoApplication = repoApplication;
    }

    public async Task<Unit> Handle(AssignRolesCommand request, CancellationToken cancellationToken)
    {

        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        var reqApplicationUsers = mapper.Map<IEnumerable<AssignRolesCommandViewModel>, IEnumerable<FarmRolesEntity>>(request.ApplicationUsers).ToList();

        List<FarmRolesEntity> users = reqApplicationUsers.Where(au => (au.IsPrimaryContact) || (au.IsAlternateContact)).ToList();

        foreach (var applicationUser in reqApplicationUsers)
        {
            applicationUser.LastUpdatedBy = userContext.Email;
            applicationUser.ApplicationId = request.ApplicationId;
        }

        //using (var scope = TransactionScopeBuilder.CreateReadCommitted(systemParamOptions.TransScopeTimeOutInMinutes))
        //{
            await repoApplicationUser.SaveAsync(users);

        //}
        return Unit.Value;
    }
}
