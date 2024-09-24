namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtAgriEnterpriseQueryMappingProfile : Profile
{
    public GetFarmEsmtAgriEnterpriseQueryMappingProfile()
    {
        CreateMap<FarmEsmtAgriculturalEnterpriseEntity, GetFarmEsmtAgriEnterpriseQueryViewModel>();
        CreateMap<FarmAgriculturalEnterpriseChecklistEntity, FarmEsmtAgriCheckListViewModel>();
    }
}
