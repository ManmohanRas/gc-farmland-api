namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmListCommand: IRequest<int>
{
    public string AgencyId { get; set; }
    public string FarmName { get; set; }
    public string FarmNumber { get; set; }
    public string Status { get; set; }
    public string OriginalLandowner { get; set; }
    public string Address1 { get; set; }
    public string Address2 { get; set; }
    public string FarmListID { get; set; }
    public int MunicipalId { get; set; }

}
