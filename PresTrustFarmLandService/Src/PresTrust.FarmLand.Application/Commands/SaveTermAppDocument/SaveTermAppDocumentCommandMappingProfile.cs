namespace PresTrust.FarmLand.Application.Commands;

public class SaveTermAppDocumentCommandMappingProfile : Profile
{
    public SaveTermAppDocumentCommandMappingProfile()
    {
        CreateMap<SaveTermAppDocumentCommand, TermOtherDocumentsEntity>();
        CreateMap<TermOtherDocumentsEntity, SaveTermAppDocumentCommandViewModel>();

    }
}
