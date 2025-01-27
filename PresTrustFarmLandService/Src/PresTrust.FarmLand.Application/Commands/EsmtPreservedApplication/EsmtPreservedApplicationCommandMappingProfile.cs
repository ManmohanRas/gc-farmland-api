namespace PresTrust.FarmLand.Application.Commands;

public class EsmtPreservedApplicationCommandMappingProfile: Profile
{
    public EsmtPreservedApplicationCommandMappingProfile() 
    {
        CreateMap<FarmBrokenRuleEntity, BrokenRuleViewModel>();
    }
}
