namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface ITermAppLocationRepository
{
    Task<List<FarmBlockLotEntity>> GetParcelsByFarmID(int applicationId, int farmListID);

    Task<bool> CheckLocationParcel(int applicationId, List<FarmTermAppLocationEntity> parcels);

}
