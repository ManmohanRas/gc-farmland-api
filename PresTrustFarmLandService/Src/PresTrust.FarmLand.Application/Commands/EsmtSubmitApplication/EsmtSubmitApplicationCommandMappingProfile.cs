namespace PresTrust.FarmLand.Application.Commands;

public class EsmtSubmitApplicationCommandMappingProfile : Profile
{
    public EsmtSubmitApplicationCommandMappingProfile()
    {
        CreateMap<FarmBrokenRuleEntity, BrokenRuleViewModel>();
    }
}