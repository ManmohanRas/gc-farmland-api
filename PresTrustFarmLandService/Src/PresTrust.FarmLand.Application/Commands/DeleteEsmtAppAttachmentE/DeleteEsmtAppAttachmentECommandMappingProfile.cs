namespace PresTrust.FarmLand.Application.Commands;
public class DeleteEsmtAppAttachmentECommandMappingProfile:Profile
{

    public DeleteEsmtAppAttachmentECommandMappingProfile()
    {
        CreateMap<DeleteEsmtAppAttachmentECommand, EsmtAppAttachmentEEntity>();
    }


}
