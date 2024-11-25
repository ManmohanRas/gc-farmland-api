namespace PresTrust.FarmLand.Application.Commands;
public class SaveFarmEsmtSadcFarmInfoCommand:IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string AlternatePhoneNumber { get; set; }
    public string County { get; set; }
    public decimal? TotalFarmAcreage { get; set; }
    public decimal ? Acres { get; set; }
    public bool IsContactSame { get; set; }
    public bool IsOtherContact { get; set; }
    public string OtherPrimaryFirstName { get; set; }
    public string OtherPrimaryRelation { get; set; }
    public string OtherPrimaryPhoneNumber { get; set; }
    public string OtherPrimaryEmail { get; set; }
    public string OtherPrimaryAddress { get; set; }
    public bool IsVisitPrimaryContact { get; set; }
    public bool IsVisitLandOwner { get; set; }
    public bool IsVisitOther { get; set; }
    public string VisitName { get; set; }
    public string VisitRelation { get; set; }
    public string VisitPhoneNumber { get; set; }
    public string VisitEmail { get; set; }
    public string VisitSADCID { get; set; }
    public DateTime ? VisitDateRecieved { get; set; }
    public bool IsImmediateCurrentMember { get; set; }
    public string Position { get; set; }
    public string Term { get; set; }



}
