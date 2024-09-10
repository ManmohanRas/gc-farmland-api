namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IEsmtAppExistUsesRepository
{

    /// <summary>
    /// Get Esmt Exist uses.
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    /// 

    public Task<EsmtAppExistUsesEntity> GetEsmtAppExistUses(int applicationId);

    /// <summary>
    /// Save Esmt Exist uses.
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    /// 
    public Task<EsmtAppExistUsesEntity> SaveEsmtAppExistUses(EsmtAppExistUsesEntity entity);
}
