namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppExistUsesQueryViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsSubdivisionApproval { get; set; }
    public string InfoAboutPremises { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
    public List<DocumentTypeViewModel> DocumentsTree { get; set; } = new List<DocumentTypeViewModel>();


}
