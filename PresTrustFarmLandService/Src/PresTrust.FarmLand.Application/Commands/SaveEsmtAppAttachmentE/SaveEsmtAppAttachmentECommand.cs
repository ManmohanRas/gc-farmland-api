using Microsoft.AspNetCore.Http.HttpResults;

namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAttachmentECommand:IRequest<int>
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
    public string UserId { get; set; }
}


