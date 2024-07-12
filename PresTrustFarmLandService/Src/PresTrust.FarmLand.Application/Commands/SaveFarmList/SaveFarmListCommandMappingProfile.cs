namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmListCommandMappingProfile: Profile
{
    public SaveFarmListCommandMappingProfile()
    {
        CreateMap<SaveFarmListCommand, FarmListEntity>();
    }
}
