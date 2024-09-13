namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmBlockLotQueryViewModel
{
    public int Id { get; set; }
    public int MunicipalityId { get; set; }
    public int FarmListID { get; set; }
    public string PropertyClassCode { get; set; }
    public string DeedBook { get; set; }
    public string DeedPage { get; set; }
    public DateTime DeedDate { get; set; }
    public string Block { get; set; }
    public string Lot { get; set; }
    public string QualificationCode { get; set; }
    public string Section { get; set; }
    public bool Partial { get; set; }
    public double Acres { get; set; }
    public double AcresToBeAcquired { get; set; }
    public bool ExceptionArea { get; set; }
    public string Notes { get; set; }
    public bool IsValidFeatureId { get; set; }
    public string InterestType { get; set; }
    public string EasementId { get; set; }
    public string ChangeType { get; set; }
    public DateTime? ChangeDate { get; set; }
    public string ReasonForChange { get; set; }
    public bool IsActive { get; set; }
    public string PamsPin { get; set; }
    public bool IsValidPamsPin { get; set; }
    public bool IsWarning { get; set; }
    public bool CreatedByProgramUser { get; set; }
    public bool IsClassCodeWarning { get; set; }
    public string CorePropertyClassCode { get; set; }
}
