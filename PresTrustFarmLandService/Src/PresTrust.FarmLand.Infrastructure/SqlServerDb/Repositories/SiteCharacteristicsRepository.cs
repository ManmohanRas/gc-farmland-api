

using PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class SiteCharacteristicsRepository : ISiteCharacteristicsRepository
{
    #region "..members."
    private readonly PresTrustSqlDbContext context;
    private readonly SystemParameterConfiguration systemParameterConfiguration;
    #endregion

    #region "...ctor....."
    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="systemParamConfigOptions"></param>
    /// 
    public SiteCharacteristicsRepository(
        PresTrustSqlDbContext context,
      IOptions<SystemParameterConfiguration> systemParamConfigOptions
)
    {
        this.context = context;
        this.systemParameterConfiguration = systemParamConfigOptions.Value;

    }

    #endregion
    public async Task<SiteCharacteristicsEntity> GetSiteCharacteristicsAsync(int applicationId)
    {
        SiteCharacteristicsEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetSiteCharacteristicsSqlCommand();

        var results = await conn.QueryAsync<SiteCharacteristicsEntity>(sqlCommand.ToString(),
                               commandType: CommandType.Text,
                               commandTimeout: systemParameterConfiguration.SQLCommandTimeoutInSeconds,
                               param: new { @p_Id = applicationId });
        result = results.FirstOrDefault();

        return result ?? new();

    }

    /// <summary>
    /// Save .
    /// </summary>
    /// <param name="siteCharcteristics"></param>
    /// <returns></returns>

    public async Task<SiteCharacteristicsEntity> SaveSiteCharacteristicsAsync(SiteCharacteristicsEntity siteCharcteristics)
    {
        if (siteCharcteristics.Id > 0)
        {
            return await updateAsync(siteCharcteristics);
        }
        else {
            return await saveAsync(siteCharcteristics);
        }
        
    }

    /// <summary>
    /// Save .
    /// </summary>
    /// <param name="siteCharcteristics"></param>
    /// <returns></returns>


 

    public async Task<SiteCharacteristicsEntity> saveAsync(SiteCharacteristicsEntity siteCharacteristics) {

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateSiteCharacteristicsSqlCommand();
         var id   =  await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(), commandType: CommandType.Text,
             commandTimeout:systemParameterConfiguration.SQLCommandTimeoutInSeconds,
             param: new{
                 @p_Id = siteCharacteristics.Id,
                 @p_ApplicationId = siteCharacteristics.ApplicationId,
                 @p_Area = siteCharacteristics.Area,
                 @p_LandUse = siteCharacteristics.LandUse,
                 @p_Cropland = siteCharacteristics.Cropland,
                 @p_Woodland = siteCharacteristics.Woodland,
                 @p_Pasture = siteCharacteristics.Pasture,
                 @p_Orchard = siteCharacteristics.Orchard,
                 @p_Other   =siteCharacteristics.Other,
                 @p_EasementOrRightOfway = siteCharacteristics.EasementOrRightOfway,
                 @p_NoteEasementOrRightOfway = siteCharacteristics.EasementOrRightOfway,
                 @p_MortgageLiens = siteCharacteristics.MortgageLiens,
                 @p_NoteMortgageLiens = siteCharacteristics.NoteMortgageLiens,
             });
        siteCharacteristics.Id = id;

    return siteCharacteristics;
    }
    /// <summary>
    /// Save .
    /// </summary>
    /// <param name="siteCharcteristics"></param>
    /// <returns></returns> CreateSiteCharacteristicsSqlCommand
    public async Task<SiteCharacteristicsEntity> updateAsync(SiteCharacteristicsEntity siteCharacteristics)
    {

        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateSiteCharacteristicsSqlCommand();

        await conn.ExecuteAsync(sqlCommand.ToString() ,
        commandTimeout:systemParameterConfiguration.SQLCommandTimeoutInSeconds,
        param: new
        {
            @p_Id = siteCharacteristics.Id,
            @p_ApplicationId = siteCharacteristics.ApplicationId,
            @p_Area = siteCharacteristics.Area,
            @p_LandUse = siteCharacteristics.LandUse,
            @p_Cropland = siteCharacteristics.Cropland,
            @p_Woodland = siteCharacteristics.Woodland,
            @p_Pasture = siteCharacteristics.Pasture,
            @p_Orchard = siteCharacteristics.Orchard,
            @p_EasementOrRightOfway = siteCharacteristics.EasementOrRightOfway,
            @p_NoteEasementOrRightOfway = siteCharacteristics.EasementOrRightOfway,
            @p_MortgageLiens = siteCharacteristics.MortgageLiens,
            @p_NoteMortgageLiens = siteCharacteristics.NoteMortgageLiens,


        });
        return  siteCharacteristics;
    }
}
