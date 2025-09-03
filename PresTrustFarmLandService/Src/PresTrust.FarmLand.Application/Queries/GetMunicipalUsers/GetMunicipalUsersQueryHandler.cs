using Microsoft.Extensions.Options;
using PresTrust.FarmLand.Application.Services.IdentityApi;
using PresTrust.FarmLand.Domain.Configurations;

namespace PresTrust.FarmLand.Application.Queries;

public class GetMunicipalUsersQueryHandler : IRequestHandler<GetMunicipalUsersQuery, IEnumerable<PresTrustUserEntity>>
{

    private readonly IMapper mapper;
    private readonly IApplicationRepository applicationRepo;
    private readonly IPresTrustUserContext userContext;
    private readonly IIdentityApiConnect identityApiConnect;
    private readonly SystemParameterConfiguration systemParamOptions;


    /// <summary>
    /// 
    /// </summary>
   
    public GetMunicipalUsersQueryHandler(
                IMapper mapper,
                IPresTrustUserContext userContext,
               IOptions<SystemParameterConfiguration> systemParamOptions,
                IIdentityApiConnect identityApiConnect,
                IApplicationRepository applicationRepo)
    {
        this.mapper = mapper;
        this.identityApiConnect = identityApiConnect;
        this.systemParamOptions = systemParamOptions.Value;
        this.applicationRepo = applicationRepo;
        this.userContext = userContext;
    }

        /// <summary>
        ///
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IEnumerable<PresTrustUserEntity>> Handle(GetMunicipalUsersQuery request, CancellationToken cancellationToken)
        {
        //TBD
        var resultUsers = new List<IdentityApiUser>() {
                    new IdentityApiUser() { Email = "agencyadmin_1401@gmail.com", IsEnabled = true, PhoneNumber="9873734737", UserId="1401", UserName="agencyadmin_1401", Title="",
                    Roles = new List<IdentityUserRole>(){ new IdentityUserRole() { Name = "farm_agencyadmin" } } },
                    new IdentityApiUser() { Email = "agencyeditor_1402@gmail.com", IsEnabled = false, PhoneNumber="9786756756", UserId="1402", UserName="agencyeditor_1402", Title="",
                    Roles = new List<IdentityUserRole>(){ new IdentityUserRole() { Name = "farm_agencyeditor" } } },
                    new IdentityApiUser() { Email = "agencysignatory_1403@gmail.com", IsEnabled = false, PhoneNumber="9786756756", UserId="1403", UserName="agencysignatory_1403", Title="",
                    Roles = new List<IdentityUserRole>(){ new IdentityUserRole() { Name = "farm_agencysignature" } } },
                    new IdentityApiUser() { Email = "agencyreadonly_1404@gmail.com", IsEnabled = false, PhoneNumber="9786756756", UserId="1404", UserName="agencyreadonly_1404", Title="",
                    Roles = new List<IdentityUserRole>(){ new IdentityUserRole() { Name = "farm_agencyreadonly" } } },
                };
        var agencyUsers = mapper.Map<IEnumerable<IdentityApiUser>, IEnumerable<PresTrustUserEntity>>(resultUsers);

        foreach(var agency in agencyUsers)
        {
            agency.Status = agency.IsEnabled ? "Active" : "In-Active";
        }

        return agencyUsers;
    }
    
}
