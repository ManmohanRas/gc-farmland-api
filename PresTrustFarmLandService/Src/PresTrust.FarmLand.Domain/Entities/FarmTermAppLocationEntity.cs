namespace PresTrust.FarmLand.Domain.Entities;

public class FarmAppLocationDetailsEntity
{
    public int ApplicationId { get; set; }
    public int ParcelId { get; set; }
    public int FarmListID { get; set; }
    public string PamsPin { get; set; }
    public bool IsChecked { get; set; }
    public string RowStatus { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
}
