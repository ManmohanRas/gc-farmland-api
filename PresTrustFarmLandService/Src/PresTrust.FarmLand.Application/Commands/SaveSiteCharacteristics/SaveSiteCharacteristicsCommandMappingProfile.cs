

namespace PresTrust.FarmLand.Application.Commands;

public class SaveSiteCharacteristicsCommandMappingProfile:Profile
{

    public SaveSiteCharacteristicsCommandMappingProfile() {
        CreateMap<SaveSiteCharacteristicsCommand, SiteCharacteristicsEntity>();
    }
}
