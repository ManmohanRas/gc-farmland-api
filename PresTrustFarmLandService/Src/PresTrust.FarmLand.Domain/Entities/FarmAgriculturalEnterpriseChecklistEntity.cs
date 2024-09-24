

namespace PresTrust.FarmLand.Domain.Entities;

public class FarmAgriculturalEnterpriseChecklistEntity
{
    public int Id { get; set; }
    public int ApplicationId { get; set; }
    public int ActivitySubTypeId { get; set; }
    public string Title { get; set; }
    public string SicCode { get; set; }
    public int ActivityTypeId { get; set; }
    public bool IsPrimary { get; set; }
    public bool IsSecondary { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public FarmEsmtAgricultureProdTypeEnum FarmEsmtAgriProdType
    {
        get
        {
            return (FarmEsmtAgricultureProdTypeEnum)ActivitySubTypeId;
        }
        set
        {
            this.ActivitySubTypeId =(int)value;
        }
    }
}
