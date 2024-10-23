namespace PresTrust.FarmLand.Application.Commands;

public class SaveFeedbackCommandMappingProfile : Profile
{
    public SaveFeedbackCommandMappingProfile()
    {
        CreateMap<SaveFeedbackCommand, FarmFeedbacksEntity>()
             .ForMember(dest => dest.Section, opt => opt.MapFrom<SectionResolver>());
    }
}

public class SectionResolver : IValueResolver<SaveFeedbackCommand, FarmFeedbacksEntity, object>
{
    public object Resolve(SaveFeedbackCommand source, FarmFeedbacksEntity destination, object destMember, ResolutionContext context)
    {
        if (source.ApplicationTypeId == 1)
        {
            // Attempt to parse as TermAppSectionEnum
            if (Enum.TryParse(typeof(TermAppSectionEnum), source.Section, true, out var termSection))
            {
                return (TermAppSectionEnum)termSection;
            }
            throw new ArgumentException($"Invalid section value for TermAppSectionEnum: {source.Section}");
        }
        else
        {
            // Attempt to parse as EsmtAppSectionEnum
            if (Enum.TryParse(typeof(EsmtAppSectionEnum), source.Section, true, out var esmtSection))
            {
                return (EsmtAppSectionEnum)esmtSection;
            }
            throw new ArgumentException($"Invalid section value for EsmtAppSectionEnum: {source.Section}");
        }
    
}
}
