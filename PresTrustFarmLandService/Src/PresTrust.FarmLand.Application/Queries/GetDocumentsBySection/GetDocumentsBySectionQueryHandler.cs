namespace PresTrust.FarmLand.Application.Queries;

public class GetDocumentsBySectionQueryHandler : BaseHandler,IRequestHandler<GetDocumentsBySectionQuery, IEnumerable<DocumentTypeViewModel>>
{
    private readonly IMapper mapper;
    private readonly ITermOtherDocumentsRepository repoDocument;
    private readonly IApplicationRepository repoApplication;

    public GetDocumentsBySectionQueryHandler(
         IMapper mapper,
        ITermOtherDocumentsRepository repoDocument,
        IApplicationRepository repoApplication
        ) : base(repoApplication: repoApplication) 
    {
        this.mapper = mapper;
        this.repoDocument = repoDocument;
        this.repoApplication = repoApplication;
    }

    public async Task<IEnumerable<DocumentTypeViewModel>> Handle(GetDocumentsBySectionQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        List<TermOtherDocumentsEntity>  documents = default;


        if (application.ApplicationType == ApplicationTypeEnum.TERM)
        {
            Enum.TryParse(value: request.SectionName, ignoreCase: true, out TermAppSectionEnum applicationSection);
            documents = await repoDocument.GetTermDocumentsAsync(application.Id, (int)applicationSection);

        }else
        {
            Enum.TryParse(value: request.SectionName, ignoreCase: true, out EsmtAppSectionEnum applicationSectionEsmt);
            documents = await repoDocument.GetTermDocumentsAsync(application.Id, (int)applicationSectionEsmt);

        }

        List<DocumentTypeViewModel>? documentsTree = default;

        if (documents.Count() > 0)
        {
            var docBuilder = new ApplicationDocumentTreeBuilder(documents);
            documentsTree = docBuilder.DocumentsTree;
        }
        else
        {
            documentsTree = new List<DocumentTypeViewModel>();
        }

        return documentsTree;
    }
}
