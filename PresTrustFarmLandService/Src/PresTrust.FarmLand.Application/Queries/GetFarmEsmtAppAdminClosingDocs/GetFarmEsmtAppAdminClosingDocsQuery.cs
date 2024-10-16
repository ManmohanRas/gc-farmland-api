namespace PresTrust.FarmLand.Application.Queries
{
    public class GetFarmEsmtAppAdminClosingDocsQuery :IRequest<GetFarmEsmtAppAdminClosingDocsQueryViewModel>
    {
        public int ApplicationId { get; set; }
    }
}   