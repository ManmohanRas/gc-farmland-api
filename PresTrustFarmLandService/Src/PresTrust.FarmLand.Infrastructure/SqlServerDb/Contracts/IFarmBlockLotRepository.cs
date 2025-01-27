namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;
public interface IFarmBlockLotRepository
{
    Task<IEnumerable<FarmBlockLotEntity>> GetFarmBlockLotAsync();

    Task<IEnumerable<FarmBlockLotEntity>> GetProgramManagerBlockLotAsync();

    public Task<FarmBlockLotEntity> GetFarmBlockLotByIdAsync(int id);

    Task<FarmBlockLotEntity> SaveAsync(FarmBlockLotEntity parcel);

    Task<bool> ResolveParcelWarning(int ParcelId);

    public Task<bool> DeleteFarmBlockLotById(int id);

    public Task<bool> CheckParcelExists(string PamsPin, int farmListId, int id);
}
