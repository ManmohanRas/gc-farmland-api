namespace PresTrust.FarmLand.Application.Queries;
/// <summary>
/// This class handles the query to fetch data and build response
/// </summary>
public class GetRolesQueryHandler : BaseHandler, IRequestHandler<GetRolesQuery, IEnumerable<FarmRolesViewModel>>
{
    private IMapper mapper;
    private readonly SystemParameterConfiguration systemparamoptions;
    private readonly IIdentityApiConnect identityApiConnect;
    private readonly IFarmRolesRepository repoRolesUser;

    public GetRolesQueryHandler
        (
        IMapper mapper,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IIdentityApiConnect identityApiConnect,
        IApplicationRepository repoApplication,
        IFarmRolesRepository repoRolesUser
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.systemparamoptions = systemParamOptions.Value;
        this.identityApiConnect = identityApiConnect;
        this.repoRolesUser = repoRolesUser;
    }
    public async Task<IEnumerable<FarmRolesViewModel>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        try
        {
            // get identity users by agency id
            var endPoint = $"{systemparamoptions.IdentityApiSubDomain}/UserAdmin/users/pres-trust/farm/{request.AgencyId ?? application.AgencyId}";
            var usersResult = new List<IdentityApiUser>() {
                new IdentityApiUser() {   UserId =  "1" , UserName =  "Agencyadmin1401", Email =  "agencyadmin1401@gmail.com", PhoneNumber =  "(973) 999-9999", Title =  "",
                    Roles = new List<IdentityUserRole>() { new IdentityUserRole() { Name ="ostf_agencyadmin"} }
                },
                new IdentityApiUser() {
                     UserId =  "2",
                     UserName =  "Consultant",
                     Email =  "consultant1@gmail.com",
                     PhoneNumber =  "",
                     Roles = new List<IdentityUserRole>() { new IdentityUserRole() { Name = "ostf_agencyeditor" } }
                },
                new IdentityApiUser() {
                     UserId =  "3",
                     UserName =  "Planning Director",
                     Email =  "adirector@mytown.com",
                     PhoneNumber = "",
                     Roles = new List<IdentityUserRole>() { new IdentityUserRole() { Name = "ostf_agencyreadonly" } }
                },
                new IdentityApiUser() {
                    UserId =  "4",
                    UserName =  "Agencysignatory1401",
                    Email =  "agencysignatory1401@gmail.com",
                    PhoneNumber =  "(973) 999-9999",
                    Roles = new List<IdentityUserRole>() { new IdentityUserRole() { Name = "ostf_agencysignature" } }
                }
                };
            var vmAgencyUsers = mapper.Map<IEnumerable<IdentityApiUser>, IEnumerable<FarmRolesViewModel>>(usersResult);

            var applicationUsers = await repoRolesUser.GetRolesAsync(request.ApplicationId);
            var vmApplicationUsers = mapper.Map<IEnumerable<FarmRolesEntity>, IEnumerable<FarmRolesViewModel>>(applicationUsers);

            if (vmApplicationUsers != null && vmApplicationUsers.Count() > 0)
            {
                foreach (var pc in vmApplicationUsers)
                {
                    foreach (var agencyUser in vmAgencyUsers)
                    {
                        if (string.Compare(agencyUser.Email, pc.Email, true) == 0)
                        {
                            agencyUser.Id = pc.Id;
                            agencyUser.IsPrimaryContact = pc.IsPrimaryContact;
                            agencyUser.IsAlternateContact = pc.IsAlternateContact;
                        }
                    }
                }
            }
            return vmAgencyUsers;
        }
        catch (Exception ex)
        {
            return new List<FarmRolesViewModel>();
        }

    }
}
