namespace PresTrust.FarmLand.Application.Commands;

public class ExpireApplicationCommandMappingProfile : Profile
{
    public ExpireApplicationCommandMappingProfile()
    {
        CreateMap<TermBrokenRuleEntity, TermBrokenRuleViewModel>()
               .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Section.ToString()));
    }
}
