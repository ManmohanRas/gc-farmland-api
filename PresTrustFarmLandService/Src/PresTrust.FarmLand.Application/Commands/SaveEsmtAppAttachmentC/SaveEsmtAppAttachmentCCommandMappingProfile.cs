namespace PresTrust.FarmLand.Application.Commands;

public class SaveEsmtAppAttachmentCCommandMappingProfile:Profile
{
    public SaveEsmtAppAttachmentCCommandMappingProfile()
    {
        CreateMap<SaveEsmtAppAttachmentCCommand, EsmtAppAttachmentCEntity>();
    }
}
