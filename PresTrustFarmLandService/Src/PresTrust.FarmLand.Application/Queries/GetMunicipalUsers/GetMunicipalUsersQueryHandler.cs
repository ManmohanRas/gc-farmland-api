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
            // Identity's Users api - IdentityApi
            var endPoint = $"{systemParamOptions.IdentityApiSubDomain}/UserAdmin/users/pres-trust/farm/{request.AgencyId}";
            var resultUsers = await identityApiConnect.GetDataAsync<List<IdentityApiUser>>(endPoint);
            var municipalUsers = mapper.Map<IEnumerable<IdentityApiUser>, IEnumerable<PresTrustUserEntity>>(resultUsers);
            foreach (var item in municipalUsers)
            {
                item.Status = item.IsEnabled ? "Active" : "In-Active";
            }
            return municipalUsers;
        }
    
}
