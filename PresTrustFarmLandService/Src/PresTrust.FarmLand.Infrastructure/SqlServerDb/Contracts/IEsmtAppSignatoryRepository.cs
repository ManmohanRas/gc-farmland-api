namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IEsmtAppSignatoryRepository
{
    Task<FarmEsmtAppSignatoryEntity> GetSignatoryAsync(int applicationId);

    Task<FarmEsmtAppSignatoryEntity> SaveAsync(FarmEsmtAppSignatoryEntity farmApplicationSignatory);
}
