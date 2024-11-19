namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class FarmEsmtSadcHistoryRepository : IFarmEsmtSadcHistoryRepository
{

    #region " Members ... "

    private readonly PresTrustSqlDbContext context;
    protected readonly SystemParameterConfiguration systemParamConfig;

    #endregion

    #region " ctor ... "

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="systemParamConfigOptions"></param>
    public FarmEsmtSadcHistoryRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion



    /// <summary>
    ///  Procedure to fetch SADC History details by Id.
    /// </summary>
    /// <param name="applicationId"> Id.</param>
    /// <returns> Returns FarmEsmtSadcHistoryEntity.</returns>
    public async Task<FarmEsmtSadcHistoryEntity> GetSadcHistoryAsync(int applicationId)
    {
        FarmEsmtSadcHistoryEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarmEsmtSadcHistorySqlQuery();
        var results = await conn.QueryAsync<FarmEsmtSadcHistoryEntity>(sqlCommand.ToString(),
                            commandType: CommandType.Text,
                            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new
                            {
                                @p_ApplicationId = applicationId
                            });

        result = results.FirstOrDefault();

        return result ?? new();
    }

    /// <summary>
    /// Save SADC History.
    /// </summary>
    /// <param name="farmSadcHistory"></param>
    /// <returns></returns>
    public async Task<FarmEsmtSadcHistoryEntity> SaveAsync(FarmEsmtSadcHistoryEntity farmSadcHistory)
    {
        if (farmSadcHistory.Id > 0)
            return await UpdateAsync(farmSadcHistory);
        else
            return await CreateAsync(farmSadcHistory);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="farmSadcHistory"></param>
    /// <returns></returns>
    private async Task<FarmEsmtSadcHistoryEntity> CreateAsync(FarmEsmtSadcHistoryEntity farmSadcHistory)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateFarmEsmtSadcHistorySqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId = farmSadcHistory.ApplicationId,
                @p_SquareFootage = farmSadcHistory.SquareFootage,
                @p_PreliminaryExpiration = farmSadcHistory.PreliminaryExpiration,
                @p_FinalExpiration = farmSadcHistory.FinalExpiration,
                @p_EstateWill = farmSadcHistory.EstateWill,
                @p_TaxWaiver = farmSadcHistory.TaxWaiver,
                @p_NoWaiver = farmSadcHistory.NoWaiver,
                @p_TrustWill = farmSadcHistory.TrustWill,
                @p_TrustDocuments = farmSadcHistory.TrustDocuments,
                @p_LastUpdatedBy = farmSadcHistory.LastUpdatedBy
            });

        farmSadcHistory.Id = id;

        return farmSadcHistory;
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="farmSadcHistory"></param>
    /// <returns></returns>
    private async Task<FarmEsmtSadcHistoryEntity> UpdateAsync(FarmEsmtSadcHistoryEntity farmSadcHistory)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateFarmEsmtSadcHistorySqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = farmSadcHistory.Id,
                @p_ApplicationId = farmSadcHistory.ApplicationId,
                @p_SquareFootage = farmSadcHistory.SquareFootage,
                @p_PreliminaryExpiration = farmSadcHistory.PreliminaryExpiration,
                @p_FinalExpiration = farmSadcHistory.FinalExpiration,
                @p_EstateWill = farmSadcHistory.EstateWill,
                @p_TaxWaiver = farmSadcHistory.TaxWaiver,
                @p_NoWaiver = farmSadcHistory.NoWaiver,
                @p_TrustWill = farmSadcHistory.TrustWill,
                @p_TrustDocuments = farmSadcHistory.TrustDocuments,
                @p_LastUpdatedBy = farmSadcHistory.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return farmSadcHistory;
    }
}
