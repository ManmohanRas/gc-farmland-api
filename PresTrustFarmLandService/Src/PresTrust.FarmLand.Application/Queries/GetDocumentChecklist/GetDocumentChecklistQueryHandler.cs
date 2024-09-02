namespace PresTrust.FarmLand.Application.Queries;

public class GetDocumentChecklistQueryHandler : BaseHandler, IRequestHandler<GetDocumentChecklistQuery, IEnumerable<DocumentChecklistViewModel>>
{
    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    //private readonly ISiteRepository repoSite;
    private readonly ITermOtherDocumentsRepository repoDocuments;

    public GetDocumentChecklistQueryHandler
   (
       IMapper mapper,
       IApplicationRepository repoApplication,
       ITermOtherDocumentsRepository repoDocuments
   ) : base(repoApplication)
    {
        this.mapper = mapper;
        this.repoApplication = repoApplication;
        this.repoDocuments = repoDocuments;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<IEnumerable<DocumentChecklistViewModel>> Handle(GetDocumentChecklistQuery request, CancellationToken cancellationToken)
    {
        // get application details
        var application = await GetIfApplicationExists(request.ApplicationId);

        // get documents 
        var documents = await repoDocuments.GetTermDocumentChecklistAsync(request.ApplicationId);

        // build checklist view model
        var docBuilder = new ApplicationDocumentTreeBuilder(documents, buildChecklist: true);
        return docBuilder.documentChecklistItems;
    }
}
