using System.Threading.Tasks;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts
{
    public interface IFarmEsmtAppAdminAppraisalReportRepository
    {
        Task<FarmEsmtAppAdminAppraisalReportEntity> SaveAppraisalAsync(FarmEsmtAppAdminAppraisalReportEntity appraisal);
        Task<FarmEsmtAppAdminAppraisalReportEntity> GetAppraisalReport(int applicationId);

    }
}
