namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmListQueryMappingProfile: Profile
    {
        public GetFarmListQueryMappingProfile()
        {
            CreateMap<FarmListEntity, GetFarmListQueryViewModel>();
        }
    }
}
