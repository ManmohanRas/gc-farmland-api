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

    public IEnumerable<GetEsmtAppAttachmentEQueryViewModel> attachmentEs { get; set; }


}
public class GetEsmtAppAttachmentCQueryViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public bool IsExceptionAreaPreserved { get; set; }
    public bool IsNonAgriPremisesPreserved { get; set; }
    public bool IsLeaseWithAnotherParty { get; set; }
    public string DescNonAgriUses { get; set; }
    public string NonAgriAreaUtilization { get; set; }
    public string NonAgriLease { get; set; }
    public string NonAgriUseAccessParcel { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }

}

public class GetEsmtAppAttachmentEQueryViewModel
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public string TypeOfDevelopment { get; set; }
    public DateTime? PreliminaryApprovalDate { get; set; }
    public DateTime? FinalApprovalDate { get; set; }
    public string ScaleofSubdivision { get; set; }
    public string OtherPertinentInformation { get; set; }
    public bool IsOpenEnrollment { get; set; }
    public bool IsPropertyOutlined { get; set; }
    public bool IsAllExpAreasIdentified { get; set; }
    public bool IsAllNonAgriEquiUsesDetailed { get; set; }
    public bool IsCopyOfDeed { get; set; }
    public bool IsSignOfAllPropOwnersListed { get; set; }
    public bool IsFarmLandAssReportCopy { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}