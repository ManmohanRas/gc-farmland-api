namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppExistUsesQueryViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsSubdivisionApprovals { get; set; }
    public string InfoAboutPremises { get; set; }
    public string LastUpdatedBy { get; set; }
  
}
