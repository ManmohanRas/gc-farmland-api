namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtAppAdminClosingDocsCommandHandler: BaseHandler, IRequestHandler<SaveEsmtAppAdminClosingDocsCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IFarmEsmtAppAdminClosingDocsRepository repoClosingDocs;
        private readonly IPresTrustUserContext userContext;
        private readonly IApplicationRepository repoApplication;
        private readonly SystemParameterConfiguration systemParamOptions;


        public SaveEsmtAppAdminClosingDocsCommandHandler(
           IMapper mapper,
           IFarmEsmtAppAdminClosingDocsRepository repoClosingDocs,
           IPresTrustUserContext userContext,
           IApplicationRepository repoApplication,
           IOptions<SystemParameterConfiguration> systemParamOptions
           ) : base(repoApplication: repoApplication)
        {
            this.mapper = mapper;
            this.repoClosingDocs = repoClosingDocs;
            this.userContext = userContext;
            this.repoApplication = repoApplication;
            this.systemParamOptions = systemParamOptions.Value; 
        }


        public async Task<int> Handle(SaveEsmtAppAdminClosingDocsCommand request, CancellationToken cancellationToken)
        {
            userContext.DeriveUserProfileFromUserId(request.UserId);
            // get application details
            var application = await GetIfApplicationExists(request.ApplicationId);

            var reqCLosingDocs = mapper.Map<SaveEsmtAppAdminClosingDocsCommand, FarmEsmtAppAdminClosingDocsEntity>(request);
            reqCLosingDocs.LastUpdatedBy = userContext.Email;
            var result = await repoClosingDocs.SaveClosingDocsAsync(reqCLosingDocs);

            return result.Id;
        }
    }
}
