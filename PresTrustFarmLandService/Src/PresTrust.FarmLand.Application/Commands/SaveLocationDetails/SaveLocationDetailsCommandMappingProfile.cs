namespace PresTrust.FarmLand.Application.Commands;

public class SaveLocationDetailsCommandMappingProfile: Profile
{
    public SaveLocationDetailsCommandMappingProfile() 
    {
        CreateMap<SaveBlockLot, FarmAppLocationDetailsEntity>();
    }
}
