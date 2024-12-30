namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmReSaleCommandMappingProfile : Profile
{
    public SaveFarmReSaleCommandMappingProfile()
    {
        CreateMap<SaveFarmReSaleCommand, FarmReSaleEntity>();
    }
}
