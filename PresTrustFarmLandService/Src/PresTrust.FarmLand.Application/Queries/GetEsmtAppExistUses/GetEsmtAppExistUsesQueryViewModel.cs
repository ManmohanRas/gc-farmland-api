namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppExistUsesQueryViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsSubdivisionApproval { get; set; }
    public string InfoAboutPremises { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime? LastUpdatedOn { get; set; }
    public List<DocumentTypeViewModel> DocumentsTree { get; set; } = new List<DocumentTypeViewModel>();

    public IEnumerable<GetEsmtAppAttachmentCQueryViewModel> attachmentCs {  get; set; }


}
public class GetEsmtAppAttachmentCQueryViewModel
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