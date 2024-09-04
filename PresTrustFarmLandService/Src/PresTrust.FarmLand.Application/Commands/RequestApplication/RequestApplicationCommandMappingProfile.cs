namespace PresTrust.FarmLand.Application.Commands;

public class RequestApplicationCommandMappingProfile : Profile
{
    public RequestApplicationCommandMappingProfile()
    {
        CreateMap<FarmBrokenRuleEntity, BrokenRuleViewModel>();
    }
}