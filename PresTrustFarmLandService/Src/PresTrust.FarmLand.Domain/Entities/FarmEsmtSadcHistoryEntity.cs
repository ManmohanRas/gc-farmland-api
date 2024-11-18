namespace PresTrust.FarmLand.Domain.Entities;
public class FarmEsmtSadcHistoryEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string ScaleofSubdivision { get; set; }
    public string TypeOfDevelopment { get; set; }
    public decimal? SquareFootage  { get; set; }
    public DateTime? PreliminaryApprovalDate { get; set; }
    public DateTime? PreliminaryExpiration {  get; set; }
    public DateTime? FinalApprovalDate { get; set; }
    public DateTime? FinalExpiration { get; set; }
    public bool PropertySale { get; set; }
    public bool EstateSituation { get; set; }
    public bool EstateWill {  get; set; }
    public bool TaxWaiver { get; set; }
    public bool NoWaiver { get; set; }
    public bool TrustWill { get; set; }
    public bool TrustDocuments { get; set; }
    public bool Bankruptcy {  get; set; }
    public bool ForeClosure { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}
