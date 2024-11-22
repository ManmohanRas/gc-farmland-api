namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmSadcResidenceCommandMappingProfile : Profile
{
    public SaveFarmSadcResidenceCommandMappingProfile()
    {
        CreateMap<SaveFarmSadcResidenceCommand, FarmSadcResidenceEntity>();
    }
}
