namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAdminExceptionRDSOCommand : IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public int? NumberofExceps { get; set; }
    public decimal? Excep1Acres { get; set; }
    public string X1Purpose { get; set; }
    public bool X1Severable { get; set; }
    public bool X1IsSubdividable { get; set; }
    public bool X1IsRTF { get; set; }
    public decimal? Excep2Acres { get; set; }
    public string X2Purpose { get; set; }
    public bool X2IsSeverable { get; set; }
    public bool X2IsSubdividable { get; set; }
    public bool X2IsRTF { get; set; }
    public decimal? Excep3Acres { get; set; }
    public string X3Purpose { get; set; }
    public bool X3IsSeverable { get; set; }
    public bool X3IsSubdividable { get; set; }
    public bool X3IsRTF { get; set; }
    public int? RDSOSNum { get; set; }
    public string RDSOExplan { get; set; }
    public bool IsRDSOExercised { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
    public string UserId { get; set; }
}
