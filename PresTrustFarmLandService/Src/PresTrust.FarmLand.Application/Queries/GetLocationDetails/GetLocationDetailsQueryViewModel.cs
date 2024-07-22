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
    public int FarmListID { get; set; }
    public int ParcelId { get; set; }
    public string PamsPin { get; set; }
    public string Block { get; set; }
    public string Lot { get; set; }
    public string QualificationCode { get; set; }
    public string DeedBook { get; set; }
    public string DeedPage { get; set; }
    public bool IsChecked { get; set; }
    public bool IsWarning { get; set; }
    public bool CreatedByProgramUser { get; set; }
}
