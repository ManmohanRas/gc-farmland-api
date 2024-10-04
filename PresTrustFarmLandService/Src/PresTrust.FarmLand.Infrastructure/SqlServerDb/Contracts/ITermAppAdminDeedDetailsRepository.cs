namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface ITermAppAdminDeedDetailsRepository
{

    /// <summary>
    ///  Procedure to fetch all contacts by applicationId.
    /// </summary>
    /// <param name="applicationId"> Application Id.</param>
    /// <returns> Returns contacts.</returns>
    /// 

    Task<List<TermAppAdminDeedDetailsEntity>> GetTermAppAdminDeedDetails(int applicationId);

    /// <summary>
    /// Save deedDetails.
    /// </summary>
    /// <param name="deedDetails"></param>
    /// <returns></returns>
    /// 
    Task<TermAppAdminDeedDetailsEntity> SaveAsync(TermAppAdminDeedDetailsEntity deedDetails);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="parcel"></param>
    /// <param name="deed"></param>
    /// <returns></returns>
    Task<bool> CheckDeedLocationParcel(int applicationId, FarmTermAppDeedLocationEntity parcel);

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    Task<List<FarmTermAppDeedLocationEntity>> GetTermAppAdminDeedLocationDetails(int applicationId);
    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="parcelId"></param>
    /// <returns></returns>
    Task<bool> UpdateTermAppDeedLocation(int applicationId, int parcelId, bool IsChecked);
}
