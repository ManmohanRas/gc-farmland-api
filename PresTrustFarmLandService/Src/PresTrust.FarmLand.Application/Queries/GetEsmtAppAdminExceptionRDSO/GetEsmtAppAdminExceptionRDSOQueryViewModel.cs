namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminExceptionRDSOQueryViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public int NumberofExceps { get; set; }
    public int Excep1Acres { get; set; }
    public string X1Purpose { get; set; }
    public string X1Severable { get; set; }
    public string X1IsSubdividable { get; set; }
    public string X1IsRTF { get; set; }
    public int Excep2Acres { get; set; }
    public string X2Purpose { get; set; }
    public string X2IsSeverable { get; set; }
    public string X2IsSubdividable { get; set; }
    public string X2IsRTF { get; set; }
    public int Excep3Acres { get; set; }
    public string X3Purpose { get; set; }
    public string X3IsSeverable { get; set; }
    public string X3IsSubdividable { get; set; }
    public string X3IsRTF { get; set; }
    public int RDSOsNum { get; set; }
    public string RDSOExplan { get; set; }
    public string IsRDSOExercised { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }

}
