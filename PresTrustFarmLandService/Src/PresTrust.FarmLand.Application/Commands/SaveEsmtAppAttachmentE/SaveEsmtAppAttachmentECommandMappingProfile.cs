namespace PresTrust.FarmLand.Application.Commands;
public class SaveEsmtAppAttachmentECommandMappingProfile:Profile
{
    public SaveEsmtAppAttachmentECommandMappingProfile()
    {
        CreateMap<SaveEsmtAppAttachmentECommand, EsmtAppAttachmentEEntity>();
    }
}
