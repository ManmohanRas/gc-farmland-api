
using PresTrust.FarmLand.Domain.CommonViewModels;

namespace PresTrust.FarmLand.Application;

public class ApplicationDocumentTreeBuilder
{
    #region " Members ... "

    private List<TermDocumentTypeViewModel> documentsTree = default;
    private IEnumerable<TermOtherDocumentsEntity> documents = default;
    private MapperConfiguration _autoMapperConfig;

    public List<TermDocumentChecklistViewModel> documentChecklistItems = new();

    #endregion

    #region " Procedures (Documents) ..."

    #region " ctor ..."

    public ApplicationDocumentTreeBuilder(IEnumerable<TermOtherDocumentsEntity> documents, bool buildChecklist = false)
    {

        this.documents = documents ?? Enumerable.Empty<TermOtherDocumentsEntity>();
        _autoMapperConfig = new MapperConfiguration(cfg =>
       {
           cfg.CreateMap<TermOtherDocumentsEntity, TermDocumentsViewModel>()
            .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType.ToString()));
       });

        if (buildChecklist == true)
        {
            BuildDocumentChecklistTree();
        }
        else
        {
            BuildDocuments();
        }
    }
    #endregion

    #region " Public Properties ..."

    public List<TermDocumentTypeViewModel> DocumentsTree { get => documentsTree; }

    #endregion

    private void BuildDocuments()
    {
        if (!documents.Any())
            return;

        documentsTree = new List<TermDocumentTypeViewModel>();
        var mapper = _autoMapperConfig.CreateMapper();

        // Group the document types using DocumentType as the key value 
        // and selecting list of documents for each value.
        IEnumerable<IGrouping<string, TermOtherDocumentsEntity>> query =
            documents.GroupBy(doc => doc.DocumentType.ToString());

        // Iterate over each IGrouping in the collection.
        foreach (IGrouping<string, TermOtherDocumentsEntity> docGroup in query)
        {
            List<TermDocumentsViewModel> docs = new List<TermDocumentsViewModel>();
            foreach (var doc in docGroup)
            {
                var vm = mapper.Map<TermOtherDocumentsEntity, TermDocumentsViewModel>(doc);
                if (doc.Id > 0) docs.Add(vm);
            }

            var vmDocType = new TermDocumentTypeViewModel()
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
        documentChecklistItems = documents.OrderBy(s => s.SectionId).GroupBy(s => s.Section).Select(s => new TermDocumentChecklistViewModel()
        {
            Section = SetSectionTitle(s.Key),
            DocumentChecklistDocTypeItems = s.GroupBy(d => d.DocumentType).Select(d =>
            {
                var item = d.FirstOrDefault();
                return new TermDocumentChecklistDocTypeViewModel()
                {
                    Id = item.Id,
                    ApplicationId = item.ApplicationId,
                    Section = item.Section.ToString(),
                    DocumentType = item.DocumentType.ToString(),
                    Documents = d.Select(o =>
                    {
                        return mapper.Map<TermOtherDocumentsEntity, TermDocumentsViewModel>(o);
                    }).Where(o => o.Id > 0).ToList() ?? new List<TermDocumentsViewModel>()
                };
            }).ToList() ?? new List<TermDocumentChecklistDocTypeViewModel>()
        }).ToList() ?? new List<TermDocumentChecklistViewModel>();
        if (documentChecklistItems.Count > 0)
            documentChecklistItems = documentChecklistItems.Where(o => !string.IsNullOrWhiteSpace(o.Section)).ToList();


    }

    private string SetSectionTitle(TermAppSectionEnum enumSection)
    {
        string title = string.Empty;
        switch (enumSection)
        {
            case TermAppSectionEnum.LOCATION:
                title = "Location";
                break;
            case TermAppSectionEnum.ROLES:
                title = "Roles";
                break;
            case TermAppSectionEnum.OWNER_DETAILS:
                title = "Owner Details";
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

    #endregion

}
