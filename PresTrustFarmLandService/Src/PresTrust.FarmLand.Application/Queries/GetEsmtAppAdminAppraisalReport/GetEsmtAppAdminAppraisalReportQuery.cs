namespace PresTrust.FarmLand.Application.Queries
{
    public class GetEsmtAppAdminAppraisalReportQuery: IRequest<GetEsmtAppAdminAppraisalReportQueryViewModel>
    {
        public int ApplicationId { get; set; }
    }
}

