namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;
public interface IFarmEsmtSadcFarmInfoRepository
{
    /// <summary>
    /// GetEsmtSadcFarmInfo
    /// </summary>
    /// <param name="ApplicationId"></param>
    /// <returns></returns>
    public Task<FarmEsmtSadcFarmInfoEntity> GetEsmtSadcFarmInfo(int ApplicationId);
    /// <summary>
    /// SaveEsmtSadcFarmInfo
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    public Task<FarmEsmtSadcFarmInfoEntity> SaveEsmtSadcFarmInfo(FarmEsmtSadcFarmInfoEntity request);
}
