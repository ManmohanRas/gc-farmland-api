namespace PresTrust.FarmLand.Application.Queries;
public class GetEsmtAppAdminOfferCostsQueryMappingProfile:Profile
{
    public GetEsmtAppAdminOfferCostsQueryMappingProfile()
    {
        CreateMap<EsmtAppAdminOfferCostsEntity, GetEsmtAppAdminOfferCostsQueryViewModel>();
    }
}
