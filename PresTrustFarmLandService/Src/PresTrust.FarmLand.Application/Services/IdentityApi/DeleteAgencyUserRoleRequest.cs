namespace PresTrust.FarmLand.Application.Services.IdentityApi;

public class DeleteAgencyUserRoleRequest
{
    public string Email { get; set; }
    public IdentityUserClaim Claim { get; set; }
}
