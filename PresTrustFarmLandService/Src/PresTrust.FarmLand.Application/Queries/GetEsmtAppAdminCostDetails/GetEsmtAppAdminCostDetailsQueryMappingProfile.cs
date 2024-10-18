namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminCostDetailsQueryMappingProfile : Profile
{
    public GetEsmtAppAdminCostDetailsQueryMappingProfile()
    {
        CreateMap<FarmEsmtAppAdminCostDetailsEntity, GetEsmtAppAdminCostDetailsQueryViewModel>();
    }
}
