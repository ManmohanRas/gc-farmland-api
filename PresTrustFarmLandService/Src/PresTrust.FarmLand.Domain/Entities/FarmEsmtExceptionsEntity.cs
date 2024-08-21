namespace PresTrust.FarmLand.Domain.Entities;

public class FarmEsmtExceptionsEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool ExpectedTaxLots { get; set; }
    public string ExceptionNonServable { get; set; }
    public string ExceptionTotalNonServable {  get; set; }
    public string ExceptionServable { get; set; }
    public string ExceptionTotalServable { get; set; }
    public decimal Acres { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
}
