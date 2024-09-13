namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAttachmentCCommand:IRequest<int>
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsExceptionAreaPreserved { get; set; }
    public bool IsNonAgriPremisesPreserved { get; set; }
    public string DescNonAgriUses { get; set; }
    public string NonAgriAreaUtilization { get; set; }
    public string NonAgriLease { get; set; }
    public string NonAgriUseAccessParcel { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }

}
