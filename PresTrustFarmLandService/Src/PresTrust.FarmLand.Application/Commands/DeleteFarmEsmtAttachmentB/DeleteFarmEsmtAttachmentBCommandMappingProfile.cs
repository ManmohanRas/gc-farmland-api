namespace PresTrust.FarmLand.Application.Commands;

public class DeleteFarmEsmtAttachmentBCommandMappingProfile : Profile
{
    public DeleteFarmEsmtAttachmentBCommandMappingProfile()
    {
        CreateMap<DeleteFarmEsmtAttachmentBCommand, FarmEsmtAttachmentBEntity>();
    }
}
