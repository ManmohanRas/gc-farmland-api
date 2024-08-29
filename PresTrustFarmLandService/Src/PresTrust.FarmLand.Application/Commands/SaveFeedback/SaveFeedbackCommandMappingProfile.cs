namespace PresTrust.FarmLand.Application.Commands;

public class SaveFeedbackCommandMappingProfile : Profile
{
    public SaveFeedbackCommandMappingProfile()
    {
        CreateMap<SaveFeedbackCommand, FarmFeedbacksEntity>()
            .ForMember(dest => dest.Section, opt => opt.MapFrom(src => (TermAppSectionEnum)Enum.Parse(typeof(TermAppSectionEnum), src.Section, true)));
    }
}
