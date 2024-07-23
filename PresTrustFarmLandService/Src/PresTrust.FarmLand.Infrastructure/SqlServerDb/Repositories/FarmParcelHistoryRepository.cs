namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class FarmParcelHistoryRepository: IFarmParcelHistoryRepository
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
    public FarmParcelHistoryRepository(
        PresTrustSqlDbContext context,
        IOptions<SystemParameterConfiguration> systemParamConfigOptions
        )
    {
        this.context = context;
        this.systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion

    public async Task<List<FarmParcelHistoryEntity>> GetParcelHistoryAsync(int parcelId)
    {
        List<FarmParcelHistoryEntity> results;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarmParcelHistorySqlQuery();
        results = (await conn.QueryAsync<FarmParcelHistoryEntity>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new { @p_ParcelId = parcelId })).ToList();
        return results ?? new();
    }

    public async Task<FarmParcelHistoryEntity> SaveParcelHistoryItemAsync(FarmParcelHistoryEntity parcel)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new SaveFarmParcelHistorySqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ParcelId = parcel.ParcelId,
                @p_CurrentPamsPin = parcel.CurrentPamsPin,
                @p_PreviousPamsPin = parcel.PreviousPamsPin,
                @p_ReasonForChange = parcel.ReasonForChange,
                @p_LastUpdatedBy = parcel.LastUpdatedBy
            });

        parcel.Id = id;

        return parcel;
    }
}
