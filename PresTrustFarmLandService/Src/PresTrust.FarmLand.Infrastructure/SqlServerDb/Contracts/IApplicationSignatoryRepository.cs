namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;
public interface IApplicationSignatoryRepository
{
    Task<FarmApplicationSignatoryEntity> GetSignatoryAsync(int applicationId);

    Task<FarmApplicationSignatoryEntity> SaveAsync(FarmApplicationSignatoryEntity farmApplicationSignatory);
}