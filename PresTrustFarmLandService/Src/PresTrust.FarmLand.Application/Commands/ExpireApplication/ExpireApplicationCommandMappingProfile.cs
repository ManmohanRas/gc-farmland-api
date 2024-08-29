namespace PresTrust.FarmLand.Application.Commands;

public class ExpireApplicationCommandMappingProfile : Profile
{
    public ExpireApplicationCommandMappingProfile()
    {
        CreateMap<FarmBrokenRuleEntity, TermBrokenRuleViewModel>()
               .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Section.ToString()));
    }
}
