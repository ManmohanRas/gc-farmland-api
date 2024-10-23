namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAppAdminStructNonAgWetlandsQueryMappingProfile : Profile
{
    public GetFarmEsmtAppAdminStructNonAgWetlandsQueryMappingProfile()
    {
        CreateMap<FarmEsmtAppAdminStructNonAgWetlandsEntity, GetFarmEsmtAppAdminStructNonAgWetlandsQueryViewModel>();
    }
}
