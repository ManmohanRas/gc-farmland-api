namespace PresTrust.FarmLand.Infrastructure.SqlServerDb;

public interface ITermAppAdminDetailsRepository
{
    public Task<FarmTermAppAdminDetailsEntity> GetTermAppAdminDetailsAsync(int applicationId);

   public Task<FarmTermAppAdminDetailsEntity> SaveTermAppAdminDetailsAsync(FarmTermAppAdminDetailsEntity farmTermAppAdminDetails);

}
