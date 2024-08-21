namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IEsmtOwnerDetailsRepository
{
    /// <summary>
    /// Get Owner Details.
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    Task<EsmtOwnerDetailsEntity> GetOwnerDetailsAsync(int applicationId);
    /// <summary>
    /// Save Owner Details.
    /// </summary>
    /// <param name="FarmOwner"></param>
    /// <returns></returns>
    Task<EsmtOwnerDetailsEntity> SaveOwnerDetailsAsync(EsmtOwnerDetailsEntity FarmOwner);
}
