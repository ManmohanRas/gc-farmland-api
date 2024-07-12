namespace PresTrust.FarmLand.Domain.Entities;
public class FarmListEntity
{
    public int FarmListID { get; set; }
    public int ProjectID { get; set; }
    public string FarmNumber { get; set; }
    public int TermID { get; set; }
    public string FarmName { get; set; }
    public string ProjectName { get; set; }
    public string Status { get; set; }
    public string OriginalLandowner { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public int MunicipalID { get; set; }
    public int AgencyID { get; set; }
    public string PresentOwner { get; set; }


    public string Address
    {
        get
        {
            string result = string.Empty;
            result = (this.Address1 ?? string.Empty) + " " + (this.Address2 ?? string.Empty);
            return result;
        }
    }
}
