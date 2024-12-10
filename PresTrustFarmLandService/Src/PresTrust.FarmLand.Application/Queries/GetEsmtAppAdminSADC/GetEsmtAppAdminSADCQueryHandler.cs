namespace PresTrust.FarmLand.Application.Queries;

public class GetEsmtAppAdminSADCQueryHandler : BaseHandler, IRequestHandler<GetEsmtAppAdminSADCQuery, GetEsmtAppAdminSADCQueryViewModel>
{
    private readonly IMapper mapper;
    private readonly IApplicationRepository repoApplication;
    private readonly IEsmtAppAdminSADCRepository repoSADC;
    private ITermOtherDocumentsRepository repoDocuments;

    public GetEsmtAppAdminSADCQueryHandler
       (
             IMapper mapper,
           IEsmtAppAdminSADCRepository repoSADC,
           IApplicationRepository repoApplication,
           ITermOtherDocumentsRepository repoDocuments
        ) : base(repoApplication: repoApplication)
    {
        this.mapper = mapper;
        this.repoSADC = repoSADC;
        this.repoApplication = repoApplication;
        this.repoDocuments = repoDocuments;
    }

    public async Task<GetEsmtAppAdminSADCQueryViewModel> Handle(GetEsmtAppAdminSADCQuery request, CancellationToken cancellationToken)
    {
        EsmtAppAdminSADCEntity results = default;

        var application = await GetIfApplicationExists(request.ApplicationId);
        var reqSADCDetails = await repoSADC.GetEsmtAppAdminSADCDetailsAsync(request.ApplicationId);
       var documents = await GetDocuments(request.ApplicationId);
        var SADCDetails = mapper.Map<EsmtAppAdminSADCEntity, GetEsmtAppAdminSADCQueryViewModel>(reqSADCDetails);
        SADCDetails.DocumentsTree = documents ?? new List<DocumentTypeViewModel>();
        return SADCDetails;
    }

    public async Task<List<DocumentTypeViewModel>> GetDocuments(int ApplicationId)
    {

        var documents = await repoDocuments.GetTermDocumentsAsync(ApplicationId, (int)EsmtAppSectionEnum.ADMIN_SADC);

        List<DocumentTypeViewModel> documentsTree = new List<DocumentTypeViewModel>();

        if (documents != null)
        {
            var docBuilder = new ApplicationDocumentTreeBuilder(documents);
            documentsTree = docBuilder.DocumentsTree;

        }
        return documentsTree;

    }
}
