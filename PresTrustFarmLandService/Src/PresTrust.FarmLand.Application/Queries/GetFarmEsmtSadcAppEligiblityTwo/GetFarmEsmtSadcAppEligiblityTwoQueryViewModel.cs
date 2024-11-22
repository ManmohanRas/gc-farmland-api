namespace PresTrust.FarmLand.Application.Queries;
public class GetFarmEsmtSadcAppEligiblityTwoQueryViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string Prime { get; set; }
    public decimal? PrimeacresPct { get; set; }
    public string Statewide { get; set; }
    public decimal? StatewideAcresPct { get; set; }
    public string Local { get; set; }
    public decimal? LocalAcresPct { get; set; }
    public string Unique { get; set; }
    public decimal? UniqueAcresPct { get; set; }
    public string UniqueSoils { get; set; }
    public string ListCropUniqueSoil { get; set; }
    public string Other { get; set; }
    public decimal? OtherAcresPct { get; set; }
    public string TotalNetAcres { get; set; }
    public decimal? TotalNetAcresPct { get; set; }
    public string CroplandHarvested { get; set; }
    public decimal? CroplandHarvestedPct { get; set; }
    public string CroplandPastured { get; set; }
    public decimal? CroplandPasturedPct { get; set; }
    public string PermanentPasture { get; set; }
    public decimal? PermanentPasturePct { get; set; }
    public string Woodlands { get; set; }
    public decimal? WoodlandsPct { get; set; }
    public string ExceptionOther { get; set; }
    public decimal? ExceptionOtherPct { get; set; }
    public string ExceptionTotalNetAcres { get; set; }
    public decimal? ExceptionTotalNetAcresPct { get; set; }
    public string ZoningCode { get; set; }
    public string MinimumLotSize { get; set; }
    public string Regional { get; set; }
    public bool? IsHighlandsRegion { get; set; }
    public bool? IsPreservation { get; set; }
    public bool? IsPlanningArea { get; set; }
    public string CountyaverageRank { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}
