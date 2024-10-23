namespace PresTrust.FarmLand.Domain.Entities;

public class FarmEsmtAttachmentBEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string LocationOfException { get; set; }
    public string Block {  get; set; }
    public int? Lot {  get; set; }
    public decimal? ExceptionSize { get; set; }
    public string ReasonForException { get; set; }
    public bool IsExceptionSoldFromPreserved { get; set; }
    public bool IsRestrictExceptionToResiUnit { get; set; }
    public bool IsExceptionInNonAgriUse { get; set; }
    public bool IsResiExceptionArea { get; set; }
    public bool IsNonResiExceptionArea {get; set; }
    public string NonAgriExceptionArea { get; set; }
    public int? SingleFamilyResidence { get; set; }
    public int? ResiHomePermFoundation { get; set; }
    public int? ResiDuplex {  get; set; }
    public int? ResiHomeWithoutFoundation {  get; set; }
    public int? ResidenceGarage { get; set; }
    public int? ResiDormitory { get; set; }
    public int? ResiAttachedTo { get; set; }
    public int? ResiGarriageHouse { get; set; }
    public int? NonResidentialBarn {  get; set; }
    public int? NonResidentialShed { get; set; }
    public int? NonResidentialGarage { get; set; }
    public int? NonResidentialSilo { get; set; }
    public int? NonResidentialStable { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
}
