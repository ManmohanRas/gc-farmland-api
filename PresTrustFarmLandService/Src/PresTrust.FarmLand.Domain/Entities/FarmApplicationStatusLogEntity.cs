namespace PresTrust.FarmLand.Domain.Entities;

public class FarmApplicationStatusLogEntity
{
    public int ApplicationId { get; set; }
    public int StatusId { get; set; }
    public DateTime StatusDate { get; set; }
    public string Notes { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public dynamic Status
    {
        get
        {
            if (this.StatusId > 199)
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
}


