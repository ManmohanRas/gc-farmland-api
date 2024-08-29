namespace PresTrust.FarmLand.Application.Queries;

public class GetTermBrokenRulesQueryMappingProfile: Profile
{
    public GetTermBrokenRulesQueryMappingProfile() 
    {
        CreateMap<FarmBrokenRuleEntity, GetTermBrokenRulesQueryViewModel>();
    }
}
