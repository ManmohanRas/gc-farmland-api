


namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public  interface ISiteCharacteristicsRepository

{
    /// <summary>
    /// Get SiteCharacteristics.
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    public Task<SiteCharacteristicsEntity> GetSiteCharacteristicsAsync(int applicationId);

    /// <summary>
    /// Save SiteCharacteristics.
    /// </summary>
    /// <param name="SiteCharacteristics"></param>
    /// <returns></returns>

    Task <SiteCharacteristicsEntity> SaveSiteCharacteristicsAsync(SiteCharacteristicsEntity siteCharacteristics);

}
