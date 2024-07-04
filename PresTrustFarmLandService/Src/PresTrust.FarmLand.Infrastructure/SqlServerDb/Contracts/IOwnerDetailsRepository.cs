namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IOwnerDetailsRepository
{
    /// <summary>
    /// Get Owner Details.
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    Task<IEnumerable<OwnerDetailsEntity>> GetOwnerDetailsAsync(int applicationId);
    /// <summary>
    /// Save Owner Details.
    /// </summary>
    /// <param name="FarmOwner"></param>
    /// <returns></returns>
    Task<OwnerDetailsEntity> SaveOwnerDetailsAsync(OwnerDetailsEntity FarmOwner);
    /// <summary>
    /// Delete Owner Details.
    /// </summary>
    /// <param name="FarmOwner"></param>
    /// <returns></returns>
    Task DeleteOwnerDetailsAsync(int applicationId, int id);
}
