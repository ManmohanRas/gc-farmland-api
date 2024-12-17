
using PresTrust.FarmLand.Domain.CommonViewModels;
using PresTrust.FarmLand.Domain.Enums;

namespace PresTrust.FarmLand.Application;

public class ApplicationDocumentTreeBuilder
{
    #region " Members ... "

    private List<DocumentTypeViewModel> documentsTree = default;
    private IEnumerable<TermOtherDocumentsEntity> documents = default;
    private MapperConfiguration _autoMapperConfig;

    public List<DocumentChecklistViewModel> documentChecklistItems = new();

    #endregion

    #region " Procedures (Documents) ..."

    #region " ctor ..."

    public ApplicationDocumentTreeBuilder(IEnumerable<TermOtherDocumentsEntity> documents, bool buildChecklist = false, int applicationTypeId = 0)
    {

        this.documents = documents ?? Enumerable.Empty<TermOtherDocumentsEntity>();
        _autoMapperConfig = new MapperConfiguration(static cfg =>
       {
           cfg.CreateMap<TermOtherDocumentsEntity, DocumentsViewModel>()
            .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType.ToString()))
            .ForMember(dest => dest.Section, opt => opt.MapFrom(src => src.Section));
       });

        if (buildChecklist == true && applicationTypeId == (int)ApplicationTypeEnum.TERM)
        {
            BuildDocumentChecklistTree();
        }
        if (buildChecklist == true && applicationTypeId == (int)ApplicationTypeEnum.EASEMENT) 
        {
            BuildEsmtDocumentChecklistTree();
        }
        else
        {
            BuildDocuments();
        }
    }
    #endregion

    #region " Public Properties ..."

    public List<DocumentTypeViewModel> DocumentsTree { get => documentsTree; }

    #endregion

    private void BuildDocuments()
    {
        if (!documents.Any())
            return;

        documentsTree = new List<DocumentTypeViewModel>();
        var mapper = _autoMapperConfig.CreateMapper();

        // Group the document types using DocumentType as the key value 
        // and selecting list of documents for each value.
        IEnumerable<IGrouping<string, TermOtherDocumentsEntity>> query =
            documents.GroupBy(doc => doc.DocumentType.ToString());

        // Iterate over each IGrouping in the collection.
        foreach (IGrouping<string, TermOtherDocumentsEntity> docGroup in query)
        {
            List<DocumentsViewModel> docs = new List<DocumentsViewModel>();
            foreach (var doc in docGroup)
            {
                var vm = mapper.Map<TermOtherDocumentsEntity, DocumentsViewModel>(doc);
                if (doc.Id > 0) docs.Add(vm);
            }

            var vmDocType = new DocumentTypeViewModel()
            {
                DocumentType = docGroup.Key,
                Documents = docs
            };

            documentsTree.Add(vmDocType);
        }
    }

    private void BuildDocumentChecklistTree()
    {
        if (!documents.Any())
            return;

        var mapper = _autoMapperConfig.CreateMapper();
        documentChecklistItems = documents.OrderBy(s => s.SectionId).GroupBy(s => s.Section).Select(s => new DocumentChecklistViewModel()
        {
            Section = SetTermSectionTitle((TermAppSectionEnum)s.Key),
            DocumentChecklistDocTypeItems = s.GroupBy(d => d.DocumentType).Select(d =>
            {
                var item = d.FirstOrDefault();
                return new DocumentChecklistDocTypeViewModel()
                {
                    Id = item.Id,
                    ApplicationId = item.ApplicationId,
                    Section = item.Section.ToString(),
                    DocumentType = item.DocumentType.ToString(),
                    Documents = d.Select(o =>
                    {
                        return mapper.Map<TermOtherDocumentsEntity, DocumentsViewModel>(o);
                    }).Where(o => o.Id > 0).ToList() ?? new List<DocumentsViewModel>()
                };
            }).ToList() ?? new List<DocumentChecklistDocTypeViewModel>()
        }).ToList() ?? new List<DocumentChecklistViewModel>();
        if (documentChecklistItems.Count > 0)
            documentChecklistItems = documentChecklistItems.Where(o => !string.IsNullOrWhiteSpace(o.Section)).ToList();


    }
    private void BuildEsmtDocumentChecklistTree()
    {
        if (!documents.Any())
            return;

        var mapper = _autoMapperConfig.CreateMapper();
        documentChecklistItems = documents.OrderBy(s => s.SectionId).GroupBy(s => s.EsmtSection).Select(s => new DocumentChecklistViewModel()
        {
            Section = SetEsmtSectionTitle(s.Key),
            DocumentChecklistDocTypeItems = s.GroupBy(d => d.DocumentType).Select(d =>
            {
                var item = d.FirstOrDefault();
                return new DocumentChecklistDocTypeViewModel()
                {
                    Id = item.Id,
                    ApplicationId = item.ApplicationId,
                    Section = item.EsmtSection.ToString(),
                    DocumentType = item.DocumentType.ToString(),
                    Documents = d.Select(o =>
                    {
                        return mapper.Map<TermOtherDocumentsEntity, DocumentsViewModel>(o);
                    }).Where(o => o.Id > 0).ToList() ?? new List<DocumentsViewModel>()
                };
            }).ToList() ?? new List<DocumentChecklistDocTypeViewModel>()
        }).ToList() ?? new List<DocumentChecklistViewModel>();
        if (documentChecklistItems.Count > 0)
            documentChecklistItems = documentChecklistItems.Where(o => !string.IsNullOrWhiteSpace(o.Section)).ToList();


    }
    
    private string SetTermSectionTitle(TermAppSectionEnum enumSection)
    {
        string title = string.Empty;
        switch (enumSection)
        {
            case TermAppSectionEnum.LOCATION:
                title = "Location";
                break;
           
            case TermAppSectionEnum.OWNER_DETAILS:
                title = "Owner Details";
                break;
            case TermAppSectionEnum.ROLES:
                title = "Roles";
                break;
            case TermAppSectionEnum.SITE_CHARACTERISTICS:
                title = "Site Characteristics";
                break;
            case TermAppSectionEnum.SIGNATORY:
                title = "Signatory";
                break;
            case TermAppSectionEnum.OTHER_DOCUMENTS:
                title = "Other Documents";
                break;
            case TermAppSectionEnum.ADMIN_DETAILS:
                title = "Admin Details";
                break;
            case TermAppSectionEnum.ADMIN_DEED_DETAILS:
                title = "Deed Details";
                break;
        }
        return title;
    }

    private string SetEsmtSectionTitle(EsmtAppSectionEnum enumSection)
    {
        string title = string.Empty;
        switch (enumSection)
        {
            case EsmtAppSectionEnum.OTHER_DOCUMENTS:
                title= "Other Documents";
                break;
            case EsmtAppSectionEnum.ADMIN_DOCUMENT_CHECK_LIST:
                title = "Admin Document Checklist";
                break;
            case EsmtAppSectionEnum.ADMIN_CLOSING_DOCS:
                title = "Admin Closing Docs";
                break;
            case EsmtAppSectionEnum.ADMIN_SADC:
                title = "Admin SADC";
                break;

        }
        return title;
    }

    #endregion
    
}
