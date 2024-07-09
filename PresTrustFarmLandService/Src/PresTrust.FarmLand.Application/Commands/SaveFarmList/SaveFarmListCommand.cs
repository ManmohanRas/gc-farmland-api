namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmListCommand
{
    public string FarmName { get; set; }
    public string FarmNumber { get; set; }
    public string Status { get; set; }
    public string OriginalLandowner { get; set; }
    public string Address { get; set; }
}
