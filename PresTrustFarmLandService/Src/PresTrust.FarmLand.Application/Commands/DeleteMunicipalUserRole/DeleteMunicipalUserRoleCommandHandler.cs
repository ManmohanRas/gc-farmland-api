using Microsoft.Extensions.Options;
using PresTrust.FarmLand.Application.Services.IdentityApi;
using PresTrust.FarmLand.Domain.Configurations;

namespace PresTrust.FarmLand.Application.Commands;

public class DeleteMunicipalUserRoleCommandHandler : IRequestHandler<DeleteMunicipalUserRoleCommand , bool>
{

    private readonly IMapper mapper;
    private readonly IPresTrustUserContext userContext;
    private readonly SystemParameterConfiguration systemParamOptions;
    private readonly IIdentityApiConnect identityApiConnect;

    public DeleteMunicipalUserRoleCommandHandler(
         IMapper mapper,
            IPresTrustUserContext userContext,
            IOptions<SystemParameterConfiguration> systemParamOptions,
            IIdentityApiConnect identityApiConnect
        )
    {
        this.mapper = mapper;
        this.userContext = userContext;
        this.systemParamOptions = systemParamOptions.Value;
        this.identityApiConnect = identityApiConnect;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<bool> Handle(DeleteMunicipalUserRoleCommand request, CancellationToken cancellationToken)
    {
        userContext.DeriveRole(request.AgencyId);

        if (userContext.Role != UserRoleEnum.AGENCY_ADMIN && userContext.Role != UserRoleEnum.PROGRAM_ADMIN && userContext.Role != UserRoleEnum.SYSTEM_ADMIN)
            throw new UnauthorizedAccessException("Unauthorized operation.");

        // call external api - IdentityApi
        var postUserJson = new JsonContent(new DeleteAgencyUserRoleRequest()
        {
            Email = request.Email,
            Claim = new IdentityUserClaim() { ClaimType = request.Role, ClaimValue = request.AgencyId.ToString() }
        });

        var result = await this.identityApiConnect.PostDataAsync<string, JsonContent>($"{systemParamOptions.IdentityApiSubDomain}/UserAdmin/user-claim/delete", postUserJson);

        return true;
    }
}
