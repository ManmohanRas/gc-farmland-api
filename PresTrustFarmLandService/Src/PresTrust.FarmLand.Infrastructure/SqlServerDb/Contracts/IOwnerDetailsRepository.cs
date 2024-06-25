namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IOwnerDetailsRepository
{
    /// <summary>
    /// Get Tech.
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    Task<IEnumerable<OwnerDetailsEntity>> GetOwnerDetailsAsync(int applicationId);
    /// <summary>
    /// Save Tech.
    /// </summary>
    /// <param name="FarmOwner"></param>
    /// <returns></returns>
    Task<OwnerDetailsEntity> SaveOwnerDetailsAsync(OwnerDetailsEntity FarmOwner);
}
