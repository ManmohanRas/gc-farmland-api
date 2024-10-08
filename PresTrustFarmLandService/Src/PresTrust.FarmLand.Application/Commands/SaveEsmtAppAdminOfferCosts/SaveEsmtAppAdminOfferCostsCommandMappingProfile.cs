namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAdminOfferCostsCommandMappingProfile:Profile
{
    public SaveEsmtAppAdminOfferCostsCommandMappingProfile()
    {
        CreateMap<SaveEsmtAppAdminOfferCostsCommand,EsmtAppAdminOfferCostsEntity>();
    }
}
