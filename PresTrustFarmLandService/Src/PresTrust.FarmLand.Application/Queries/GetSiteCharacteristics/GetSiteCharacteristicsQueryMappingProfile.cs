

namespace PresTrust.FarmLand.Application.Queries;

public class GetSiteCharacteristicsQueryMappingProfiles:Profile
{
    public GetSiteCharacteristicsQueryMappingProfiles() {
        CreateMap<SiteCharacteristicsEntity, GetSiteCharacteristicsQueryViewModel>();
    }
}
