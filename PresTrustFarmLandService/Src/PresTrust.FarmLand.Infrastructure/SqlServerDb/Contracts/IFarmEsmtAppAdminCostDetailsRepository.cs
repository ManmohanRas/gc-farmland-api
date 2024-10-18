namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IFarmEsmtAppAdminCostDetailsRepository
{
    Task<FarmEsmtAppAdminCostDetailsEntity> GetCostDetailsAsync(int applicationId);

    Task<FarmEsmtAppAdminCostDetailsEntity> SaveAsync(FarmEsmtAppAdminCostDetailsEntity farmEsmtAppAdminCostDetails);
}
