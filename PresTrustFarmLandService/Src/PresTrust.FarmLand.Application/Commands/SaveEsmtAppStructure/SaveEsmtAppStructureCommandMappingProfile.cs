
namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppStructureCommandMappingProfile:Profile
{
    public SaveEsmtAppStructureCommandMappingProfile()
    {
        CreateMap<SaveEsmtAppStructureCommand, EsmtStructureAppEntity>();
    }
}
