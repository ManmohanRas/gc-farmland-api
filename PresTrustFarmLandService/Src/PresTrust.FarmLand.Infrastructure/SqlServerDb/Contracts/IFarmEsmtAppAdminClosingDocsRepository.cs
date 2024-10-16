using PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts
{
    public interface IFarmEsmtAppAdminClosingDocsRepository
    {
        Task<FarmEsmtAppAdminClosingDocsEntity> GetClosingDocsAsync(int applicationId);

        Task<FarmEsmtAppAdminClosingDocsEntity> SaveClosingDocsAsync(FarmEsmtAppAdminClosingDocsEntity closingDocs);
    }
}
