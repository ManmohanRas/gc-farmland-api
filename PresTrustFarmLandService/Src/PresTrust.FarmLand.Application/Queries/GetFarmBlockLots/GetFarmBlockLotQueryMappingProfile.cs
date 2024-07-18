namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmBlockLotQueryMappingProfile: Profile
{
    public GetFarmBlockLotQueryMappingProfile()
    {
        CreateMap<FarmBlockLotEntity, GetFarmBlockLotQueryViewModel>();
    }
}
