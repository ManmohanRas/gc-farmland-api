namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtSadcHistoryCommandMappingProfile : Profile
{
    public SaveFarmEsmtSadcHistoryCommandMappingProfile()
    {
        CreateMap<SaveFarmEsmtSadcHistoryCommand, FarmEsmtSadcHistoryEntity>();
    }
}
