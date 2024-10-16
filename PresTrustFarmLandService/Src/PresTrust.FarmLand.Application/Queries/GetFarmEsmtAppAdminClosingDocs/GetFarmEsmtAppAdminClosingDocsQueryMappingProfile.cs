namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmEsmtAppAdminClosingDocsQueryMappingProfile : Profile
    {
        public GetFarmEsmtAppAdminClosingDocsQueryMappingProfile()
        {
            CreateMap<FarmEsmtAppAdminClosingDocsEntity, GetFarmEsmtAppAdminClosingDocsQueryViewModel>();
        }
    }
}
