using Dapper;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class TermAppLocationRepository: ITermAppLocationRepository
{
    #region " Members ... "

    private readonly PresTrustSqlDbContext context;
    private readonly SystemParameterConfiguration systemParamConfig;

    #endregion

    #region " ctor ... "

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="systemParamConfigOptions"></param>
    public TermAppLocationRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion

    public async Task<List<FarmBlockLotEntity>> GetParcelsByFarmID(int applicationId, int farmListID)
    {
        List<FarmBlockLotEntity> results;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetTermAppLocationSqlQuery();
        results = (await conn.QueryAsync<FarmBlockLotEntity>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new 
                            { @p_ApplicationId = applicationId, 
                              @p_FarmListID  = farmListID
                            })).ToList();
        return results ?? new();
    }

    public async Task<bool> CheckLocationParcel(int applicationId,List<FarmTermAppLocationEntity> parcels)
    {
        using var conn = context.CreateConnection();
        foreach (var parcel in parcels)
        {
            var sqlCommand = new CreateTermAppLocationSqlCommand();
            await conn.ExecuteAsync(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                                param: new
                                {
                                    @p_ApplicationId = applicationId,
                                    @p_FarmListID = parcel.FarmListID,
                                    @p_ParcelId = parcel.ParcelId,
                                    @p_PamsPin = parcel.PamsPin,
                                    @p_IsChecked = parcel.IsChecked
                                });
        }
        return true;
    }


}
