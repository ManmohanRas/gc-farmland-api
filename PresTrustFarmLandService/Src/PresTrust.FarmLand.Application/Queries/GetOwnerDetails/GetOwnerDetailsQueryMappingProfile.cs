namespace PresTrust.FarmLand.Application.Queries;

public class GetOwnerDetailsQueryMappingProfile : Profile
{
    public GetOwnerDetailsQueryMappingProfile()
    {
        CreateMap<OwnerDetailsEntity, GetOwnerDetailsQueryViewModel>();
    }
}
