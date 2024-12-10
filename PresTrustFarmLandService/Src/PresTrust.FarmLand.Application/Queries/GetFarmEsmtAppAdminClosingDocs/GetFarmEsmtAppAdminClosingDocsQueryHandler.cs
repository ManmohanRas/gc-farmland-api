namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmEsmtAppAdminClosingDocsQueryHandler : BaseHandler, IRequestHandler<GetFarmEsmtAppAdminClosingDocsQuery , GetFarmEsmtAppAdminClosingDocsQueryViewModel>
    {

        private IMapper mapper;
        private readonly IApplicationRepository repoApplication;
        private readonly IFarmEsmtAppAdminClosingDocsRepository repoClosingDocs;
        private ITermOtherDocumentsRepository repoDocuments;



        public GetFarmEsmtAppAdminClosingDocsQueryHandler
            (
            IMapper mapper,
            IApplicationRepository repoApplication,
            IFarmEsmtAppAdminClosingDocsRepository repoClosingDocs,
            ITermOtherDocumentsRepository repoDocuments
            ) : base(repoApplication: repoApplication)
        {
            this.mapper = mapper;
            this.repoApplication = repoApplication;
            this.repoClosingDocs = repoClosingDocs;
            this.repoDocuments = repoDocuments;
        }


        public async Task<GetFarmEsmtAppAdminClosingDocsQueryViewModel> Handle(GetFarmEsmtAppAdminClosingDocsQuery request, CancellationToken cancellationToken)
        {
            //get application details
            var application = await GetIfApplicationExists(request.ApplicationId);

            //get ClosingDocs
            var closingDocs = await this.repoClosingDocs.GetClosingDocsAsync(request.ApplicationId);
            var documents = await GetDocuments(request.ApplicationId);
            var result = mapper.Map<FarmEsmtAppAdminClosingDocsEntity, GetFarmEsmtAppAdminClosingDocsQueryViewModel>(closingDocs);
            result.DocumentsTree = documents ?? new List<DocumentTypeViewModel>();
            return result;

        }

        public async Task<List<DocumentTypeViewModel>> GetDocuments(int ApplicationId)
        {

            var documents = await repoDocuments.GetTermDocumentsAsync(ApplicationId, (int)EsmtAppSectionEnum.ADMIN_CLOSING_DOCS);

            List<DocumentTypeViewModel> documentsTree = new List<DocumentTypeViewModel>();

            if (documents != null)
            {
                var docBuilder = new ApplicationDocumentTreeBuilder(documents);
                documentsTree = docBuilder.DocumentsTree;

            }
            return documentsTree;

        }
    }
}
