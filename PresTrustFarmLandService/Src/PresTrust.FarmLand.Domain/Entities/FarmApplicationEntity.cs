namespace PresTrust.FarmLand.Domain.Entities;

public class FarmApplicationEntity
{
    public int Id { get; set; }
    public int AgencyId { get; set; }
    public int FarmListId { get; set; }
    public string Title { get; set; }
    public int ApplicationTypeId { get; set; }
    public int StatusId { get; set; }
    public int PrevStatusId { get; set; }
    public bool CreatedByProgramUser { get; set; }
    public bool IsApprovedByMunicipality { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public bool IsActive { get; set; }
    public int MunicipalID { get; set; }
    public string FarmName { get; set; }
    public string Municipality { get; set; }
    public string OriginalLandowner { get; set; }
    public string PresentOwner { get; set; }
    public string AgencyJSON { get; set; }
    public string CommentsJSON { get; set; }
    public string FeedbacksJSON { get; set; }
    public bool IsSADC {  get; set; }
    public DateTime? EnrollmentDate { get; set; }
    public double Acres { get; set; }
    public DateTime? ClosingDate { get; set; }

    public ApplicationTypeEnum ApplicationType
    {
        get
        {
            return (ApplicationTypeEnum)ApplicationTypeId;
        }
        set
        {
            this.ApplicationTypeId = (int)value;
        }
    }

    public dynamic Status
    {
        get
        {
            if (this.StatusId > 199 || this.PrevStatusId>199)
            {
                return (EsmtAppStatusEnum)StatusId;
            }
            else
            return (TermAppStatusEnum)StatusId;
        }
        set
        {
            this.StatusId = (int)value;
        }
    }

    public dynamic PrevStatus
    {
        get
        {
            if ( this.PrevStatusId > 199)
            {
                return (EsmtAppStatusEnum)PrevStatusId;
            }
            else
                return (TermAppStatusEnum)PrevStatusId;
        }
        set
        {
            this.PrevStatusId = (int)value;
        }
    }


    public FarmAgencyEntity Agency
    {
        get
        {
            return this.AgencyJSON == null ? new() : JsonSerializer.Deserialize<FarmAgencyEntity>(this.AgencyJSON);
        }
    }

    public IEnumerable<FarmCommentsEntity> Comments
    {
        get
        {
            return this.CommentsJSON == null ? new List<FarmCommentsEntity>() : JsonSerializer.Deserialize<IEnumerable<FarmCommentsEntity>>(this.CommentsJSON);
        }
    }

    public IEnumerable<FarmFeedbacksEntity> Feedbacks
    {
        get
        {
            return this.FeedbacksJSON == null ? new List<FarmFeedbacksEntity>() : JsonSerializer.Deserialize<IEnumerable<FarmFeedbacksEntity>>(this.FeedbacksJSON);
        }
    }

}
