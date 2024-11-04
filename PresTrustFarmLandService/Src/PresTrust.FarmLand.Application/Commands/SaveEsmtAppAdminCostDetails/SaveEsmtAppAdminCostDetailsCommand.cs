namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAdminCostDetailsCommand : IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public decimal? GrossAcers { get; set; }
    public decimal? SADCBeforeValueAC { get; set; }
    public decimal? SADCAfterValueAC { get; set; }
    public decimal? OfferToSADC { get; set; }
    public decimal? SADCCostShareAC { get; set; }
    public decimal? SADCCostShareTotal { get; set; }
    public decimal? SADCCostShareAcqTotal { get; set; }
    public string NoteOfBreakdown { get; set; }
    public decimal? SADCCostShareofOfferPct { get; set; }
    public decimal? SADCCertifiedEasementValuePerAcre { get; set; }
    public decimal? SADCPctofCertifiedEaseValue { get; set; }
    public decimal? NetAcres { get; set; }
    public decimal? MCOffertoLandowner { get; set; }
    public decimal? MCCertifiedBeforeValue { get; set; }
    public decimal? MCCostSharePerAcre { get; set; }
    public decimal? MCCostSharePct { get; set; }
    public decimal? MCCostShareTotal { get; set; }
    public string OtherSource { get; set; }
    public decimal? OtherCostShare { get; set; }
    public decimal? TotalCost { get; set; }
    public decimal? TotalCostPerAcre { get; set; }
    public string CountyFunds { get;set; }
}
