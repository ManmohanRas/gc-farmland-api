namespace PresTrust.FarmLand.Application.Queries;

public class GetTermDocumentChecklistQueryHandler : BaseHandler, IRequestHandler<GetTermDocumentChecklistQuery, IEnumerable<TermDocumentChecklistViewModel>>
{
    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    //private readonly ISiteRepository repoSite;
    private readonly ITermOtherDocumentsRepository repoDocuments;

    public GetTermDocumentChecklistQueryHandler
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
    public async Task<IEnumerable<TermDocumentChecklistViewModel>> Handle(GetTermDocumentChecklistQuery request, CancellationToken cancellationToken)
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
