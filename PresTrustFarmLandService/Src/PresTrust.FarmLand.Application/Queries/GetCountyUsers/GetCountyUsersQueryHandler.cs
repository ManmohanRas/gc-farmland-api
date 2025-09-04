using Microsoft.Extensions.Options;
using PresTrust.FarmLand.Application.Services.IdentityApi;
using PresTrust.FarmLand.Domain.Configurations;

namespace PresTrust.FarmLand.Application.Queries;

public class GetCountyUsersQueryHandler : IRequestHandler<GetCountyUsersQuery, IEnumerable<PresTrustUserEntity>>
{
    private readonly IMapper mapper;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IIdentityApiConnect identityApiConnect;
    private readonly IApplicationRepository repoApplication;


    public GetCountyUsersQueryHandler(
        IMapper mapper,
        IOptions<SystemParameterConfiguration> systemParamOptions,
        IIdentityApiConnect identityApiConnect
        )
    {
        this.mapper = mapper;
        this.systemParamOptions = systemParamOptions.Value;
        this.identityApiConnect = identityApiConnect;
    }
    public async Task<IEnumerable<PresTrustUserEntity>> Handle(GetCountyUsersQuery request, CancellationToken cancellationToken)
    {
        // Identity's Users api - IdentityApi

        var users = new List<IdentityApiUser>() {
                new IdentityApiUser() { Email = "programcommittee@gmail.com", IsEnabled = true, PhoneNumber="9873734737", UserId="1", UserName="programcommittee", Title="",
                    Roles = new List<IdentityUserRole>(){ new IdentityUserRole() { Name = "farm_program_committee" } } },
                new IdentityApiUser() { Email = "programeditor@gmail.com", IsEnabled = false, PhoneNumber="9786756756", UserId="2", UserName="programeditor", Title="",
                Roles = new List<IdentityUserRole>(){ new IdentityUserRole() { Name = "farm_program_editor" } } },
                new IdentityApiUser() { Email = "programreadonly@gmail.com", IsEnabled = false, PhoneNumber="9786756756", UserId="4", UserName="programreadonly", Title="",
                Roles = new List<IdentityUserRole>(){ new IdentityUserRole() { Name = "farm_program_readonly" } } },
                new IdentityApiUser() { Email = "programcommittee2@gmail.com", IsEnabled = true, PhoneNumber="9873734737", UserId="1", UserName="programcommittee2", Title="",
                    Roles = new List<IdentityUserRole>(){ new IdentityUserRole() { Name = "farm_program_committee" } } },
                new IdentityApiUser() { Email = "programeditor2@gmail.com", IsEnabled = false, PhoneNumber="9786756756", UserId="2", UserName="programeditor2", Title="",
                Roles = new List<IdentityUserRole>(){ new IdentityUserRole() { Name = "farm_program_editor" } } },
                new IdentityApiUser() { Email = "programreadonly2@gmail.com", IsEnabled = false, PhoneNumber="9786756756", UserId="4", UserName="programreadonly2", Title="",
                Roles = new List<IdentityUserRole>(){ new IdentityUserRole() { Name = "farm_program_readonly" } } }
                };
        var result = mapper.Map<IEnumerable<IdentityApiUser>, IEnumerable<PresTrustUserEntity>>(users);

        foreach(var item in result)
        {
            item.Status = item.IsEnabled ? "Active" : "In-Active";
        }
        return result;
    }
}
