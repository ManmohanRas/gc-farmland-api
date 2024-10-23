namespace PresTrust.FarmLand.Application.Queries
{
    public class GetEsmtAppAdminAppraisalReportQueryHandler : BaseHandler, IRequestHandler<GetEsmtAppAdminAppraisalReportQuery, GetEsmtAppAdminAppraisalReportQueryViewModel>
    {
        private readonly IMapper mapper;
        private readonly IApplicationRepository repoApplication;
        private readonly IFarmEsmtAppAdminAppraisalReportRepository repoAppraisal;
        private readonly IFarmEsmtAppAdminCostDetailsRepository repoCostDetails;


        public GetEsmtAppAdminAppraisalReportQueryHandler
           (
               IMapper mapper,
               IFarmEsmtAppAdminAppraisalReportRepository repoAppraisal,
               IFarmEsmtAppAdminCostDetailsRepository repoCostDetails,
               IApplicationRepository repoApplication
            ) : base(repoApplication: repoApplication)
        {
            this.mapper = mapper;
            this.repoAppraisal = repoAppraisal;
            this.repoApplication = repoApplication;
            this.repoCostDetails = repoCostDetails;
        }

        public async Task<GetEsmtAppAdminAppraisalReportQueryViewModel> Handle(GetEsmtAppAdminAppraisalReportQuery request, CancellationToken cancellationToken)
        {
            //get application details
            var application = await GetIfApplicationExists(request.ApplicationId);

            var reqAppraisal = await repoAppraisal.GetAppraisalReport(request.ApplicationId);

            var costDetails = await repoCostDetails.GetCostDetailsAsync(request.ApplicationId);
            costDetails = costDetails ?? new FarmEsmtAppAdminCostDetailsEntity();

            var appraisalReportDetails = mapper.Map<FarmEsmtAppAdminAppraisalReportEntity, GetEsmtAppAdminAppraisalReportQueryViewModel>(reqAppraisal);
            appraisalReportDetails.SADCBeforeValueAC  = costDetails.SADCBeforeValueAC  ?? 0;
            appraisalReportDetails.SADCAfterValueAC  = costDetails.SADCAfterValueAC  ?? 0;
            appraisalReportDetails.SADCCertifiedEasementValuePerAcre = costDetails.SADCCertifiedEasementValuePerAcre ?? 0;
            return appraisalReportDetails;

        }
    }
}

