namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAppAdminDetailsQueryMappingProfile : Profile
{
    public GetFarmEsmtAppAdminDetailsQueryMappingProfile()
    {
        CreateMap<FarmEsmtAppAdminDetailsEntity, GetFarmEsmtAppAdminDetailsQueryViewModel>();
    }
}
