namespace PresTrust.FarmLand.Application.Commands;

public class SaveMunicipalFinanceCommandMappingProfile : Profile
{
    public SaveMunicipalFinanceCommandMappingProfile()
    {
        CreateMap<SaveMunicipalFinanceCommand, FarmMunicipalFinanceEntity>();
    }
}
