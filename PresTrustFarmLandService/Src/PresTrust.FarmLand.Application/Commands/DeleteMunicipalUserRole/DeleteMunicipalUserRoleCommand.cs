namespace PresTrust.FarmLand.Application.Commands;

public class DeleteMunicipalUserRoleCommand : IRequest<bool>
{
    public int AgencyId { get; set; }
    public string Email { get; set; }
    public string Role {  get; set; }

}
