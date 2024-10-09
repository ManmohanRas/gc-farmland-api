namespace PresTrust.FarmLand.Application.Queries;

public class GetFeedbacksQueryMappingProfile : Profile
{
    public GetFeedbacksQueryMappingProfile()
    {
        CreateMap<FarmFeedbacksEntity, GetFeedbacksQueryViewModel>()
        .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Section));

    }
}