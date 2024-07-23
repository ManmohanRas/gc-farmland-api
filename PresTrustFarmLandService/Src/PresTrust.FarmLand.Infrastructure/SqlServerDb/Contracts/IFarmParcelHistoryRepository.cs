namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IFarmParcelHistoryRepository
{
    Task<List<FarmParcelHistoryEntity>> GetParcelHistoryAsync(int parcelId);

    Task<FarmParcelHistoryEntity> SaveParcelHistoryItemAsync(FarmParcelHistoryEntity parcel);
}
