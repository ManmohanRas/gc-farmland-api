namespace PresTrust.FarmLand.Application.Queries;

public class GetLocationDetailsQueryViewModel
{
    public int ApplicationId { get; set; }
    public List<GetFarmParcelViewModel> Parcels { get; set; }

}

public class GetFarmParcelViewModel: FarmBlockLotEntity
{
   
}
