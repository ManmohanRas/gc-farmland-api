namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAdminExceptionRDSOCommandMappingProfile : Profile
{
    public SaveEsmtAppAdminExceptionRDSOCommandMappingProfile()
    {
        CreateMap<SaveEsmtAppAdminExceptionRDSOCommand, EsmtAppAdminExceptionRDSOEntity>();
    }

}
