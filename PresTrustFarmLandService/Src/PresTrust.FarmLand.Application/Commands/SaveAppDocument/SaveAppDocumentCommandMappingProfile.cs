namespace PresTrust.FarmLand.Application.Commands;

public class SaveAppDocumentCommandMappingProfile : Profile
{
    public SaveAppDocumentCommandMappingProfile()
    {
        CreateMap<SaveAppDocumentCommand, TermOtherDocumentsEntity>();
        CreateMap<TermOtherDocumentsEntity, SaveAppDocumentCommandViewModel>();

    }
}
