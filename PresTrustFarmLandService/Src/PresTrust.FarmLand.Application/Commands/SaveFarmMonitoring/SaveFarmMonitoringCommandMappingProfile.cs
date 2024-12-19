namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmMonitoringCommandMappingProfile : Profile
{
    public SaveFarmMonitoringCommandMappingProfile()
    {
        CreateMap<SaveFarmMonitoringCommand, FarmMonitoringEntity>();
    }
}
