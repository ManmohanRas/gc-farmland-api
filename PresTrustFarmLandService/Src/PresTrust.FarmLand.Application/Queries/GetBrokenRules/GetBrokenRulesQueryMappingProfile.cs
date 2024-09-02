namespace PresTrust.FarmLand.Application.Queries;

public class GetBrokenRulesQueryMappingProfile: Profile
{
    public GetBrokenRulesQueryMappingProfile() 
    {
        CreateMap<FarmBrokenRuleEntity, GetBrokenRulesQueryViewModel>();
    }
}
