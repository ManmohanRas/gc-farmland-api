namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IFarmEsmtExceptionsRepository
{
    /// <summary>
    /// Get Exceptions Details
    /// </summary>
    /// <param name="ApplicationId"></param>
    /// <returns></returns>
    Task<FarmEsmtExceptionsEntity> GetEsmtExceptionsDetailsAsync(int ApplicationId);

    /// <summary>
    /// Save Exceptions Details
    /// </summary>
    /// <param name="exceptions"></param>
    /// <returns></returns>
    Task<FarmEsmtExceptionsEntity> SaveAsync(FarmEsmtExceptionsEntity exceptions);
}
