namespace PresTrust.FarmLand.Application.Queries
{
    public class GetEsmtAppAdminAppraisalReportQueryMappingProfile :Profile
    {
        public GetEsmtAppAdminAppraisalReportQueryMappingProfile()
        {
            CreateMap<FarmEsmtAppAdminAppraisalReportEntity, GetEsmtAppAdminAppraisalReportQueryViewModel>();
        }
    }
}
