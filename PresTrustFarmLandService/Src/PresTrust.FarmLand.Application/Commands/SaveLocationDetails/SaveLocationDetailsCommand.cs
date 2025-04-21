namespace PresTrust.FarmLand.Application.Commands;

public class SaveLocationDetailsCommand: IRequest<Unit>
{
    public int ApplicationId { get; set; }
    public List<SaveBlockLot> Parcels { get; set; }

}

public class SaveBlockLot
{
    public int ApplicationId { get; set; }
    public int ParcelId { get; set; }
    public int FarmListID { get; set; }
    public string PamsPin { get; set; }
    public bool IsChecked { get; set; }
    public double AcresToBeAcquired { get; set; }
    public double ExceptionAreaAcres { get; set; }
    public string Notes { get; set; }
    public double Acres { get; set; }
    public bool? ExceptionArea { get; set; }
    public string RowStatus {  get; set; }
}

