namespace PresTrust.FarmLand.Application.Queries;

public class GetCommentsQueryMappingProfile : Profile
{
    public GetCommentsQueryMappingProfile() 
    {
        CreateMap<FarmCommentsEntity, GetCommentsQueryViewModel>();
    }
}
