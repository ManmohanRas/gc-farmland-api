namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveFarmSadcAppEligibilityCommandMappingProfile : Profile
    {
        public SaveFarmSadcAppEligibilityCommandMappingProfile()
        {
            CreateMap<SaveFarmSadcAppEligibilityCommand, FarmSadcAppEligibilityEntity>();
        }
    }
}
