namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmSadcResidenceQueryViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsAgriculturalLabor { get; set; }
    public string UnitsUsedForLabor { get; set; }
    public int? Occupants { get; set; }
    public int? MonthsOccupied { get; set; }
    public bool IsOccupantsWork { get; set; }
    public string PleaseExplain { get; set; }
    public bool IsResidencesRented { get; set; }
    public string RDSOsReserve { get; set; }
    public decimal? ExcepAcres1 { get; set; }
    public bool NonSeverable1 { get; set; }
    public bool Severable1 { get; set; }
    public string AdditionalComment1 { get; set; }
    public decimal? ExcepAcres2 { get; set; }
    public bool NonSeverable2 { get; set; }
    public bool Severable2 { get; set; }
    public string AdditionalComment2 { get; set; }
    public string EsmtOthersText { get; set; }
    public bool IsSightTriangle { get; set; }
    public bool IsResipreserved { get; set; }
    public string StdSingleFamilyResidence { get; set; }
    public string MfWithHomePermFoundation { get; set; }
    public string Duplex { get; set; }
    public string MfWithOutHomePermFoundation { get; set; }
    public string ResiGarage { get; set; }
    public string Dormitory { get; set; }
    public string ApartmentAttachedTo { get; set; }
    public string CarriageHouseOrCabin { get; set; }
    public bool IsNonResiStructure { get; set; }
    public string Barn { get; set; }
    public string Shed { get; set; }
    public string NonResiGarage { get; set; }
    public string Silo { get; set; }
    public string Stable { get; set; }
    public string NonResiOther { get; set; }
    public bool IsNonAgriPremisesPreserved { get; set; }
    public string DescNonAgriUses { get; set; }
    public bool PremisePreserved { get; set; }
    public bool PowerLines { get; set; }
    public bool WaterLines { get; set; }
    public bool Sewer { get; set; }
    public bool Bridge { get; set; }
    public bool FloodRightWay { get; set; }
    public bool TelephoneLines { get; set; }
    public bool GasLines { get; set; }
    public bool Other { get; set; }
    public bool SolarWindBiomass { get; set; }
    public string BiomassDescribe { get; set; }
}
