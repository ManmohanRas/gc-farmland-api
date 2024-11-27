namespace PresTrust.FarmLand.Application.Commands;
public class SaveFarmEsmtSadcAppEligiblityTwoCommandMappingProfile:Profile
{
    public SaveFarmEsmtSadcAppEligiblityTwoCommandMappingProfile()
    {
        CreateMap<SaveFarmEsmtSadcAppEligiblityTwoCommand, FarmEsmtSadcAppEligiblityTwoEntity>();
    }
}
