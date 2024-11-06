

using PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class SiteCharacteristicsRepository : ISiteCharacteristicsRepository
{
    #region "..members."
    private readonly PresTrustSqlDbContext context;
    private readonly SystemParameterConfiguration systemParameterConfiguration;
    #endregion

    #region "...ctor"
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
                               param: new { @p_ApplicationId = applicationId });
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
            return await UpdateAsync(siteCharcteristics);
        }
        else {
            return await SaveAsync(siteCharcteristics);
        }
        
    }

    /// <summary>
    /// Save .
    /// </summary>
    /// <param name="siteCharcteristics"></param>
    /// <returns></returns>


 

    public async Task<SiteCharacteristicsEntity> SaveAsync(SiteCharacteristicsEntity siteCharacteristics) {

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateSiteCharacteristicsSqlCommand();
        var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(), 
            commandType: CommandType.Text,
            commandTimeout: systemParameterConfiguration.SQLCommandTimeoutInSeconds,
            param: new {
                @p_ApplicationId = siteCharacteristics.ApplicationId,
                @p_Area = siteCharacteristics.Area,
                @p_LandUse = siteCharacteristics.LandUse,
                @p_Cropland = siteCharacteristics.CropLand,
                @p_Woodland = siteCharacteristics.WoodLand,
                @p_Pasture = siteCharacteristics.Pasture,
                @p_Orchard = siteCharacteristics.Orchard,
                @p_Other = siteCharacteristics.Other,
                @p_IsEasement = siteCharacteristics.IsEasement,
                @p_IsRightOfway = siteCharacteristics.IsRightOfway,
                @p_NoteEasementRightOfway = siteCharacteristics.NoteEasementRightOfway,
                @p_IsMortgage = siteCharacteristics.IsMortgage,
                @p_IsLiens = siteCharacteristics.IsLiens,
                @p_NoteMortgageLiens = siteCharacteristics.NoteMortgageLiens,
                @p_LastUpdatedBy = siteCharacteristics.LastUpdatedBy,
            });
        siteCharacteristics.Id = id;

    return siteCharacteristics;
    }
    /// <summary>
    /// Save .
    /// </summary>
    /// <param name="siteCharcteristics"></param>
    /// <returns></returns> CreateSiteCharacteristicsSqlCommand
    public async Task<SiteCharacteristicsEntity> UpdateAsync(SiteCharacteristicsEntity siteCharacteristics)
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
            @p_Cropland = siteCharacteristics.CropLand,
            @p_Woodland = siteCharacteristics.WoodLand,
            @p_Pasture = siteCharacteristics.Pasture,
            @p_Orchard = siteCharacteristics.Orchard,
            @p_Other = siteCharacteristics.Other,
            @p_IsEasement = siteCharacteristics.IsEasement,
            @p_IsRightOfway = siteCharacteristics.IsRightOfway,
            @p_NoteEasementRightOfway = siteCharacteristics.NoteEasementRightOfway,
            @p_IsMortgage = siteCharacteristics.IsMortgage,
            @p_IsLiens = siteCharacteristics.IsLiens,
            @p_NoteMortgageLiens = siteCharacteristics.NoteMortgageLiens,
            @p_LastUpdatedBy = siteCharacteristics.LastUpdatedBy,
            @p_LastUpdatedOn = DateTime.Now,
        });
        return  siteCharacteristics;
    }
}
