namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface ITermAppLocationRepository
{
    Task<List<FarmBlockLotEntity>> GetParcelsByFarmID(int applicationId, int farmListID);

    Task<bool> CheckLocationParcel(int applicationId, FarmTermAppLocationEntity parcel);

    Task<bool> DeleteTermAppLocationBlockLot(int applicationId, int parcelId);


}
