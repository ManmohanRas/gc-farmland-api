namespace PresTrust.FarmLand.Domain.Entities;

public class FarmRolesViewModel : PresTrustUserEntity
{
    public int Id { get; set; }
    public bool IsPrimaryContact { get; set; }
    public bool IsAlternateContact { get; set; }
}
