namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAdminSADCCommandMappingProfile : Profile
{
    public SaveEsmtAppAdminSADCCommandMappingProfile()
    {
        CreateMap<SaveEsmtAppAdminSADCCommand,EsmtAppAdminSADCEntity>();
    }
}
