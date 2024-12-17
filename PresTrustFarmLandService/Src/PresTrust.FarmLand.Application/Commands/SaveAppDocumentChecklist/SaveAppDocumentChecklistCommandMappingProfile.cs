namespace PresTrust.FarmLand.Application.Commands;

public class SaveAppDocumentChecklistCommandMappingProfile : Profile
{
    /// <summary>
    /// 
    /// </summary>
    public SaveAppDocumentChecklistCommandMappingProfile()
    {
        CreateMap<DocumentsViewModel, TermOtherDocumentsEntity>()
           .ForMember(dest => dest.Section, opt => opt.MapFrom<SectionResolver>())
           .ForMember(dest => dest.DocumentTypeId, opt => opt.MapFrom(src => MapDocumentType(src.DocumentType)));
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

    public int MapSection(string section)
    {
        // Example of how to map from string to enum value or integer
        return Enum.TryParse<TermAppSectionEnum>(section,ignoreCase: true, out var sectionEnum)
            ? (int)sectionEnum
            : 0; 
    }

    public class SectionResolver : IValueResolver<DocumentsViewModel, TermOtherDocumentsEntity, object>
    {
        public object Resolve(DocumentsViewModel source, TermOtherDocumentsEntity destination, object destMember, ResolutionContext context)
        {
            if (source.ApplicationTypeId == 1)
            {
                // Attempt to parse as TermAppSectionEnum
                if (Enum.TryParse(typeof(TermAppSectionEnum), source.Section, true, out var termSection))
                {
                    return (TermAppSectionEnum)termSection;
                }
                throw new ArgumentException($"Invalid section value for TermAppSectionEnum: {source.Section}");
            }
            else
            {
                // Attempt to parse as EsmtAppSectionEnum
                if (Enum.TryParse(typeof(EsmtAppSectionEnum), source.Section, true, out var esmtSection))
                {
                    return (EsmtAppSectionEnum)esmtSection;
                }
                throw new ArgumentException($"Invalid section value for EsmtAppSectionEnum: {source.Section}");
            }

        }
    }
}

