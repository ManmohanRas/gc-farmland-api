namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminSADCQueryViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string ProgramName { get; set; }
    public string SADCFundingRoundYear { get; set; }
    public decimal SADCQualityScore { get; set; }
    public int SADCPrelimRank { get; set; }
    public int SADCFinalRank { get; set; }
    public int SADCFinalScore { get; set; }
    public List<DocumentTypeViewModel> DocumentsTree { get; set; } = new List<DocumentTypeViewModel>();
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
}
