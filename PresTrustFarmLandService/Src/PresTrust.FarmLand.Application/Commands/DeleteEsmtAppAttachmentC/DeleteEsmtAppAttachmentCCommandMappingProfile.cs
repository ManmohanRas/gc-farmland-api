
namespace PresTrust.FarmLand.Application.Commands;

public class DeleteEsmtAppAttachmentCCommandMappingProfile:Profile
{
    public DeleteEsmtAppAttachmentCCommandMappingProfile()
    {
        CreateMap<DeleteEsmtAppAttachmentCCommand, EsmtAppAttachmentCEntity>();
    }
}
