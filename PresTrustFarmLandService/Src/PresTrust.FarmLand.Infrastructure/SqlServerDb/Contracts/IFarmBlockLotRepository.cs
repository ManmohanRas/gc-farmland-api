namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;
public interface IFarmBlockLotRepository
{
    Task<IEnumerable<FarmBlockLotEntity>> GetFarmBlockLotAsync();

    Task<FarmBlockLotEntity> SaveAsync(FarmBlockLotEntity parcel);

}
