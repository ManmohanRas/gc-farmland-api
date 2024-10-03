namespace PresTrust.FarmLand.Domain.Entities;

public class EsmtAppAdminSADCEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string ProgramName { get; set; }
    public string SADCFundingRoundYear { get; set; }
    public decimal SADCQualityScore { get; set; }
    public int SADCPrelimRank { get; set; }
    public int SADCFinalRank { get; set; }
    public int SADCFinalScore { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
}
