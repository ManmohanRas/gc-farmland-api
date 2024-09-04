namespace PresTrust.FarmLand.Application.Commands;

public class ApproveAggrementCommandMappingProfile : Profile
{
    public ApproveAggrementCommandMappingProfile()
    {
        CreateMap<FarmBrokenRuleEntity, BrokenRuleViewModel>();
    }
}
