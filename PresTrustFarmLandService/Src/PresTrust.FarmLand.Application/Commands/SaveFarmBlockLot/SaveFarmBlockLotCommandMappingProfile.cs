namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmBlockLotCommandMappingProfile: Profile
{
    public SaveFarmBlockLotCommandMappingProfile()
    {
        CreateMap<SaveFarmBlockLotCommand, FarmBlockLotEntity>();

        CreateMap<FarmBlockLotEntity, SaveFarmBlockLotCommandViewModel>();
    }
}
