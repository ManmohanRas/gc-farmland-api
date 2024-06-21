namespace PresTrust.FarmLand.Application.Queries;

public class GetTermFeedbacksQueryMappingProfile : Profile
{
    public GetTermFeedbacksQueryMappingProfile()
    {
        CreateMap<TermFeedbacksEntity, GetTermFeedbacksQueryViewModel>()
        .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Section.ToString()));

    }
}