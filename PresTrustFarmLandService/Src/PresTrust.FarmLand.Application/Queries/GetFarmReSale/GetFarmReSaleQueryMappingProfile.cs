namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmReSaleQueryMappingProfile : Profile
{
    public GetFarmReSaleQueryMappingProfile()
    {
        CreateMap<FarmReSaleEntity, GetFarmReSaleQueryViewModel>();
    }
}
