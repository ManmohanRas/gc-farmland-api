namespace PresTrust.FarmLand.Application.Commands;

public class SaveAppDocumentChecklistCommandMappingProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public SaveAppDocumentChecklistCommandMappingProfile()
    {
        CreateMap<DocumentsViewModel, TermOtherDocumentsEntity>()
          .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => MapDocumentType(src.DocumentType)));
    }

    /// <summary>
    /// Parse string to enum typeof(DocumentTypeEnum)
    /// </summary>
    /// <param name="docType"></param>
    /// <returns></returns>
    public ApplicationDocumentTypeEnum MapDocumentType(string docType)
    {
        Enum.TryParse(value: docType, ignoreCase: true, out ApplicationDocumentTypeEnum farmDocType);
        return farmDocType;
    }
}

