namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmMonitoringQueryViewModel
{
    public int Id { get; set; }
    public int FarmListID { get; set; }
    public string FarmNumber { get; set; }
    public string FarmName { get; set; }
    public string OriginalLandowner { get; set; }
    public string PresentOwner { get; set; }
    public string FarmerName { get; set; }
    public string FarmLocation { get; set; }
    public string PamsPin { get; set; }
    public string AddBlock { get; set; }
    public string AddLots { get; set; }
    public decimal? NetAcres { get; set; }
    public string Municipality { get; set; }
    public string Block { get; set; }
    public string Lot { get; set; }
    public bool IsConservationPlan { get; set; }
    public DateTime? ConsPlanDate { get; set; }
    public string ConsPlanComment { get; set; }
    public string Street1 { get; set; }
    public string Street2 { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public DateTime? ClosingDate { get; set; }
    public string TitlePolicy { get; set; }
    public string TitleCompany { get; set; }
    public int? EPDeedBook { get; set; }
    public int? EPDeedPage { get; set; }
    public DateTime? EPDeedFiled { get; set; }
    public decimal? GrossAcers { get; set; }
    public int? RDSOsNum { get; set; }
    public string RDSOExplan { get; set; }
    public bool IsRDSOExercised { get; set; }
    public string ImprovRes { get; set; }
    public string ImprovAg { get; set; }
    public bool AreNonAgUses { get; set; }
    public string NonAgExplan { get; set; }
    public DateTime? FirstInspect { get; set; }
    public DateTime? PreviousInspect { get; set; }
    public DateTime? LastInspect { get; set; }
    public string ChangesSinceLastInspect { get; set; }
    public string IssuesImpactingFarm { get; set; }
    public bool IsInCompliance { get; set; }
    public string NonComplianceExplan { get; set; }
    public string InspectionComments { get; set; }
    public string CurrentDeedBook { get; set; }
    public string CurrentDeedPage { get; set; }
    public DateTime? CurrentDeedFiled { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}
