namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface IEsmtAppStructureRepository
{
    /// <summary>
    /// Get Esmt Structure.
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    /// 
    public Task<EsmtStructureAppEntity> GetEsmtStructureEntityAsync(int applicationId);
    /// <summary>
    /// Get Esmt Structure.
    /// </summary>
    /// <param name="Structure"></param>
    /// <returns></returns>
    /// 
    public Task<EsmtStructureAppEntity> SaveEsmtStructureEntityAsync (EsmtStructureAppEntity entity);
   

    


}
