namespace PresTrust.FarmLand.Application.Commands;

public class SaveFarmEsmtAttachmentBCommandMappingProfile : Profile
{
    public SaveFarmEsmtAttachmentBCommandMappingProfile()
    {
        CreateMap<SaveFarmEsmtAttachmentBCommand, FarmEsmtAttachmentBEntity>();
    }
}
