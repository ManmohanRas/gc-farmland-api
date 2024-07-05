namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;
public interface ITermAppSignatoryRepository
{
    Task<FarmTermAppSignatoryEntity> GetSignatoryAsync(int applicationId);

    Task<FarmTermAppSignatoryEntity> SaveAsync(FarmTermAppSignatoryEntity farmApplicationSignatory);
}