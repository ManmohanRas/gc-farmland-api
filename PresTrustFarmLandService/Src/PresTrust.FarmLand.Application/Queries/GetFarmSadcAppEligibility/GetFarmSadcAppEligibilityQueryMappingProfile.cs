namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmSadcAppEligibilityQueryMappingProfile : Profile
    {
        public GetFarmSadcAppEligibilityQueryMappingProfile()
        {
            CreateMap<FarmSadcAppEligibilityEntity, GetFarmSadcAppEligibilityQueryViewModel>();
        }
    }
}
