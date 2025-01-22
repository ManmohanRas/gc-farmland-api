namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IApplicationLocationRepository
{
    Task<List<FarmBlockLotEntity>> GetParcelsByFarmID(int applicationId, int farmListID, int applicationTypeId = default);

    Task<List<FarmBlockLotEntity>> GetUnLinkedParcelsByFarmID(int applicationId, int farmListID, int applicationTypeId = default);

    Task<bool> CheckLocationParcel(int applicationId, FarmAppLocationDetailsEntity parcel);

    Task<bool> DeleteTermAppLocationBlockLot(int applicationId, int parcelId);


}
