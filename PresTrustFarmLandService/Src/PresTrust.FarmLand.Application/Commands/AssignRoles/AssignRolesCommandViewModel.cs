namespace PresTrust.FarmLand.Application.Commands;

public class AssignRolesCommandViewModel: PresTrustUserEntity
{
    public int Id { get; set; }
    public bool IsPrimaryContact { get; set; }
    public bool IsAlternateContact { get; set; }
}
