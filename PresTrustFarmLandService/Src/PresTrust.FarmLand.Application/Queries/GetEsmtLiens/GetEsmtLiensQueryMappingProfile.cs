namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtLiensQueryMappingProfile : Profile
{
    public GetEsmtLiensQueryMappingProfile()
    {
        CreateMap<EsmtLiensEntity, GetEsmtLiensQueryViewModel>();
    }

}
