namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAppAdminDetailsCommandMappingProfile : Profile
{
    public SaveFarmEsmtAppAdminDetailsCommandMappingProfile()
    {
        CreateMap<SaveFarmEsmtAppAdminDetailsCommand, FarmEsmtAppAdminDetailsEntity>();
    }
}
