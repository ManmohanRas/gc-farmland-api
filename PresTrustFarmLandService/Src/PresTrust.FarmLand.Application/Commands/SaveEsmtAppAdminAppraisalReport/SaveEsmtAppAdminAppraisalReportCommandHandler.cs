namespace PresTrust.FarmLand.Application.Commands
{
    public class SaveEsmtAppAdminAppraisalReportCommandHandler :BaseHandler, IRequestHandler<SaveEsmtAppAdminAppraisalReportCommand, int>
    {
        private readonly IMapper mapper;
        private readonly IFarmEsmtAppAdminAppraisalReportRepository repoAppraisal;
        private readonly IPresTrustUserContext userContext;
        private readonly IApplicationRepository repoApplication;
        private readonly SystemParameterConfiguration systemParamOptions;


        public SaveEsmtAppAdminAppraisalReportCommandHandler(
           IMapper mapper,
           IFarmEsmtAppAdminAppraisalReportRepository repoAppraisal,
           IPresTrustUserContext userContext,
           IApplicationRepository repoApplication,
           IOptions<SystemParameterConfiguration> systemParamOptions
           ) : base(repoApplication: repoApplication)
        {
            this.mapper = mapper;
            this.repoAppraisal = repoAppraisal;
            this.userContext = userContext;
            this.repoApplication = repoApplication;
            this.systemParamOptions = systemParamOptions.Value;
        }


        public async Task<int> Handle(SaveEsmtAppAdminAppraisalReportCommand request, CancellationToken cancellationToken)
        {
            userContext.DeriveUserProfileFromUserId(request.UserId);
            // get application details
            var application = await GetIfApplicationExists(request.ApplicationId);

            var reqAppraisal = mapper.Map<SaveEsmtAppAdminAppraisalReportCommand, FarmEsmtAppAdminAppraisalReportEntity>(request);
            reqAppraisal.LastUpdatedBy = userContext.Email;
            var result = await repoAppraisal.SaveAppraisalAsync(reqAppraisal);

            return result.Id;
        }
    }
}
