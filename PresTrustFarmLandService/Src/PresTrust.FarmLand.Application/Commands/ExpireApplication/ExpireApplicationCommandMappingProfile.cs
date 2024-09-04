namespace PresTrust.FarmLand.Application.Commands;

public class ExpireApplicationCommandMappingProfile : Profile
{
    public ExpireApplicationCommandMappingProfile()
    {
        CreateMap<FarmBrokenRuleEntity, BrokenRuleViewModel>()
               .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Section));
    }
}
