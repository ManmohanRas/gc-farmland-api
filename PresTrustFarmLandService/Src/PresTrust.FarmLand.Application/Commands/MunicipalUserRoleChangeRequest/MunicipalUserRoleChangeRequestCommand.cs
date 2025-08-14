namespace PresTrust.FarmLand.Application.Commands;

public class MunicipalUserRoleChangeRequestCommand : IRequest<bool>
{
    public int AgencyId { get; set; }
    public string Email { get; set; }
    public string Role {  get; set; }
    public string NewRole { get; set; }
    public string UserId { get; set; }

}
