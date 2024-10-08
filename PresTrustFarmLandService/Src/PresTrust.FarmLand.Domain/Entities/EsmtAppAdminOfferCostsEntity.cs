namespace PresTrust.FarmLand.Domain.Entities;
public class EsmtAppAdminOfferCostsEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public decimal? CadbLandOwnerOffer { get; set; }
    public decimal? AmountPerAcre { get; set; }
    public bool IsOfferAccepted { get; set; }
    public decimal? TotalCostPerAcre { get; set; }
    public decimal? TotalCost { get; set; }
    public decimal? MCCostSharePct { get; set; }
    public decimal? McCountyCostShareTotal { get; set; }
    public decimal? SADCCostSharePct { get; set; }
    public decimal? SADCCostShareTotal { get; set; }
    public decimal? OtherCostShareTotal { get; set; }
    public decimal? OtherSource { get; set; }
    public string? CostNote {  get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }

}
