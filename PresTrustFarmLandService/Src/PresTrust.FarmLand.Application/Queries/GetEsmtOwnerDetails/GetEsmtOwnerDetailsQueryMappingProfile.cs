namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtOwnerDetailsQueryMappingProfile : Profile
{
    public GetEsmtOwnerDetailsQueryMappingProfile()
    {
        CreateMap<EsmtOwnerDetailsEntity, GetEsmtOwnerDetailsQueryViewModel>();
    }
}
