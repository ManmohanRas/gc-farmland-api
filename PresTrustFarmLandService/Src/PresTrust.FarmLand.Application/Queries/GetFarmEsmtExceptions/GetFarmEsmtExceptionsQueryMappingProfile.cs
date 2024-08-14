namespace PresTrust.FarmLand.Application.Queries;

public class GetFarmEsmtExceptionsQueryMappingProfile : Profile
{
    public GetFarmEsmtExceptionsQueryMappingProfile()
    {
        CreateMap<FarmEsmtExceptionsEntity, GetFarmEsmtExceptionsQueryViewModel>();
    }
}
