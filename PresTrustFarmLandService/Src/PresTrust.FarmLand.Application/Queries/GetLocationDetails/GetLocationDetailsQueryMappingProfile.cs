namespace PresTrust.FarmLand.Application.Queries;

public class GetLocationDetailsQueryMappingProfile: Profile
{
    public GetLocationDetailsQueryMappingProfile()
    {
        CreateMap<FarmBlockLotEntity, GetFarmParcelViewModel>();
    }
}
