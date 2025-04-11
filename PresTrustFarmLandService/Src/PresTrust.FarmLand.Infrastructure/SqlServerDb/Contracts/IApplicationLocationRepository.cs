namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IApplicationLocationRepository
{
    Task<List<FarmBlockLotEntity>> GetParcelsByFarmID(int applicationId, int farmListID, int applicationTypeId = default);

    Task<List<FarmBlockLotEntity>> GetUnLinkedParcelsByFarmID(int applicationId, int farmListID, int applicationTypeId = default);

    Task<FarmAppLocationDetailsEntity> CheckLocationParcel(int applicationId, FarmAppLocationDetailsEntity parcel);

    Task<bool> DeleteAppLocationBlockLot(int applicationId, int parcelId);


}
