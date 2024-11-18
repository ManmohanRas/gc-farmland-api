namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtSadcHistoryQueryMappingProfile : Profile
{
    public GetFarmEsmtSadcHistoryQueryMappingProfile()
    {
        CreateMap<FarmEsmtSadcHistoryEntity, GetFarmEsmtSadcHistoryQueryViewModel>();
    }
}
