namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface  IFarmEsmtAppAdminDetailsRepository
{
    Task<FarmEsmtAppAdminDetailsEntity> GetAdminDetailsAsync(int applicationId);

    Task<FarmEsmtAppAdminDetailsEntity> SaveAsync(FarmEsmtAppAdminDetailsEntity farmEsmtAppAdminDetails);
}
