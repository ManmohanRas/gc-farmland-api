namespace PresTrust.FarmLand.Application.Commands;
public class SaveFarmEsmtSadcFarmInfoCommandMappingProfile:Profile
{
    public SaveFarmEsmtSadcFarmInfoCommandMappingProfile()
    {
        CreateMap<SaveFarmEsmtSadcFarmInfoCommand, FarmEsmtSadcFarmInfoEntity>();
    }
}
