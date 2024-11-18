namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IFarmEsmtSadcHistoryRepository
{
    Task<FarmEsmtSadcHistoryEntity> GetSadcHistoryAsync(int applicationId);

    Task<FarmEsmtSadcHistoryEntity> SaveAsync(FarmEsmtSadcHistoryEntity farmSadcHistory);
}
