namespace PresTrust.FarmLand.Application.Queries;

public class GetLocationDetailsQueryViewModel
{
    public int ApplicationId { get; set; }
    public List<GetFarmParcelViewModel> Parcels { get; set; }

}

public class GetFarmParcelViewModel
{
     public int Id { get; set; }
    public int ApplicationId { get; set; }
    public int MunicipalityId { get; set; }
    public int FarmListID { get; set; }
    public string PamsPin { get; set; }
    public string PropertyClassCode { get; set; }
    public string Block { get; set; }
    public string Lot { get; set; }
    public string QualificationCode { get; set; }
    public int ParcelId { get; set; }

    public bool IsChecked { get; set; }
}
