namespace PresTrust.FarmLand.Application.Queries;

public class GetTermCommentsQueryMappingProfile : Profile
{
    public GetTermCommentsQueryMappingProfile() 
    {
        CreateMap<TermCommentsEntity, GetTermCommentsQueryViewModel>();
    }
}
