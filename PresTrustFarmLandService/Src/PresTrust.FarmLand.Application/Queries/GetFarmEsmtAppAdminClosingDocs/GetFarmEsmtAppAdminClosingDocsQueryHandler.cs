namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmEsmtAppAdminClosingDocsQueryHandler : BaseHandler, IRequestHandler<GetFarmEsmtAppAdminClosingDocsQuery , GetFarmEsmtAppAdminClosingDocsQueryViewModel>
    {

        private IMapper mapper;
        private readonly IApplicationRepository repoApplication;
        private readonly IFarmEsmtAppAdminClosingDocsRepository repoClosingDocs;


        public GetFarmEsmtAppAdminClosingDocsQueryHandler
            (
            IMapper mapper,
            IApplicationRepository repoApplication,
            IFarmEsmtAppAdminClosingDocsRepository repoClosingDocs
            ) : base(repoApplication: repoApplication)
        {
            this.mapper = mapper;
            this.repoApplication = repoApplication;
            this.repoClosingDocs = repoClosingDocs;
        }


        public async Task<GetFarmEsmtAppAdminClosingDocsQueryViewModel> Handle(GetFarmEsmtAppAdminClosingDocsQuery request, CancellationToken cancellationToken)
        {
            //get application details
            var application = await GetIfApplicationExists(request.ApplicationId);

            //get ClosingDocs
            var closingDocs = await this.repoClosingDocs.GetClosingDocsAsync(request.ApplicationId);
            var result = mapper.Map<FarmEsmtAppAdminClosingDocsEntity, GetFarmEsmtAppAdminClosingDocsQueryViewModel>(closingDocs);
            return result;

        }
    }
}
