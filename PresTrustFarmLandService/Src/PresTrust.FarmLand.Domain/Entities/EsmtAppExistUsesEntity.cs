namespace PresTrust.FarmLand.Domain.Entities;

public class EsmtAppExistUsesEntity
{
    public int Id {  get; set; }
    public int ApplicationId { get; set; }
    public bool IsSubdivisionApproval { get; set; }
    public string InfoAboutPremises { get; set; }
    public string LastUpdatedBy {  get; set; }
    public DateTime LastUpdateOn { get; set; }
}
