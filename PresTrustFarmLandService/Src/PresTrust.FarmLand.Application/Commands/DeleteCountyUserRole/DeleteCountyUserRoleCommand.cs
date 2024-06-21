namespace PresTrust.FarmLand.Application.Commands;

public class DeleteCountyUserRoleCommand : IRequest<bool>
{
    public string Email { get; set; }
    public string Role { get; set; }

}
