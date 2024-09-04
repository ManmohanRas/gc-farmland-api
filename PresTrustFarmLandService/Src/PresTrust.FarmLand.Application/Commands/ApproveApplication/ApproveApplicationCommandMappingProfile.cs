namespace PresTrust.FarmLand.Application.Commands;

public class ApproveApplicationCommandMappingProfile : Profile
{
    public ApproveApplicationCommandMappingProfile() 
    {
        CreateMap<FarmBrokenRuleEntity, BrokenRuleViewModel>();
    }
}
