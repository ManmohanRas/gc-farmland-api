namespace PresTrust.FarmLand.Domain.Entities;

public class EsmtStructureAppEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsResipreserved { get; set; }
    public string StdSingleFamilyResidence { get; set; }
    public string MfWithHomePermFoundation { get; set; }
    public string Duplex { get; set; }
    public string MfWithOutHomePermFoundation { get; set; }
    public string ResiGarage { get; set; }
    public string Dormitory { get; set; }
    public string ApartmentAttachedTo { get; set; }
    public string CarriageHouseOrCabin { get; set; }
    public string ResiOther { get; set; }
    public string UnitsAgricuturalLabor { get; set; }
    public string UnitsRentedOrLease { get; set; }
    public bool IsNonResiStructure { get; set; }
    public string Barn { get; set; }
    public string Shed { get; set; }
    public string NonResiGarage { get; set; }
    public string Silo { get; set; }
    public string Stable { get; set; }
    public string NonResiOther { get; set; }
    public bool IsHistBuildingOrStructure { get; set; }
    public string HistoricSignificance { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}
