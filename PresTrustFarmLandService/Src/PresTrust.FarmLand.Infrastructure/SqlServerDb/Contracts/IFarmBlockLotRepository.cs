namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;
public interface IFarmBlockLotRepository
{
    Task<IEnumerable<FarmBlockLotEntity>> GetFarmBlockLotAsync();

    public Task<FarmBlockLotEntity> GetFarmBlockLotByIdAsync(int id);

    Task<FarmBlockLotEntity> SaveAsync(FarmBlockLotEntity parcel);

    Task<bool> ResolveParcelWarning(int ParcelId);

}
