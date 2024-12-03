

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IFarmReSaleRepository
{
    public Task<IEnumerable<FarmReSaleEntity>> GetFarmReSaleAsync();

    public Task<FarmReSaleEntity> SaveFarmReSaleAsync(FarmReSaleEntity farmResale);

    public Task DeleteFarmReSaleById(FarmReSaleEntity farmResale);
}
