namespace PresTrust.FarmLand.Application.Queries;

public class GetMunicipalFinanceQueryMappingProfile : Profile
{
    public GetMunicipalFinanceQueryMappingProfile()
    {
        CreateMap<FarmMunicipalTrustFundPermittedUsesEntity, GetMunicipalFinanceQueryViewModel>();
    }
}
