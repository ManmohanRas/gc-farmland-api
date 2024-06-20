namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermFeedbackCommandMappingProfile : Profile
{
    public SaveTermFeedbackCommandMappingProfile()
    {
        CreateMap<SaveTermFeedbackCommand, TermFeedbacksEntity>()
            .ForMember(dest => dest.Section, opt => opt.MapFrom(src => (ApplicationSectionEnum)Enum.Parse(typeof(ApplicationSectionEnum), src.Section, true)));
    }
}
