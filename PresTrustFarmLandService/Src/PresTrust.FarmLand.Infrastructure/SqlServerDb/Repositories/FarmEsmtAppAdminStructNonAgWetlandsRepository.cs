namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class FarmEsmtAppAdminStructNonAgWetlandsRepository : IFarmEsmtAppAdminStructNonAgWetlandsRepository
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
    public FarmEsmtAppAdminStructNonAgWetlandsRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion



    /// <summary>
    ///  Procedure to fetch StructNonAgWetlands details by Id.
    /// </summary>
    /// <param name="applicationId"> Id.</param>
    /// <returns> Returns FarmEsmtAppAdminStructNonAgWetlandsEntity.</returns>
    public async Task<FarmEsmtAppAdminStructNonAgWetlandsEntity> GetStructNonAgWetlandsAsync(int applicationId)
    {
        FarmEsmtAppAdminStructNonAgWetlandsEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarnEsmtAppAdminStructNonAgWetlandsSqlQuires();
        var results = await conn.QueryAsync<FarmEsmtAppAdminStructNonAgWetlandsEntity>(sqlCommand.ToString(),
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
    /// Save StructNonAgWetlands.
    /// </summary>
    /// <param name="farmEsmtAppAdminStructNonAgWetlands"></param>
    /// <returns></returns>
    public async Task<FarmEsmtAppAdminStructNonAgWetlandsEntity> SaveAsync(FarmEsmtAppAdminStructNonAgWetlandsEntity farmEsmtAppAdminStructNonAgWetlands)
    {
        if (farmEsmtAppAdminStructNonAgWetlands.Id > 0)
            return await UpdateAsync(farmEsmtAppAdminStructNonAgWetlands);
        else
            return await CreateAsync(farmEsmtAppAdminStructNonAgWetlands);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="farmEsmtAppAdminStructNonAgWetlands"></param>
    /// <returns></returns>
    private async Task<FarmEsmtAppAdminStructNonAgWetlandsEntity> CreateAsync(FarmEsmtAppAdminStructNonAgWetlandsEntity farmEsmtAppAdminStructNonAgWetlands)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateFarnEsmtAppAdminStructNonAgWetlandsSqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId = farmEsmtAppAdminStructNonAgWetlands.ApplicationId,
                @p_IsResidenceOnPresLand = farmEsmtAppAdminStructNonAgWetlands.IsResidenceOnPresLand,
                @p_ImprovRes = farmEsmtAppAdminStructNonAgWetlands.ImprovRes,
                @p_AreNonAgUses = farmEsmtAppAdminStructNonAgWetlands.AreNonAgUses,
                @p_NonAgExplan = farmEsmtAppAdminStructNonAgWetlands.NonAgExplan,
                @p_IsFarmMarket = farmEsmtAppAdminStructNonAgWetlands.IsFarmMarket,
                @p_ImprovAg = farmEsmtAppAdminStructNonAgWetlands.ImprovAg,
                @p_WetlandsSurveyor = farmEsmtAppAdminStructNonAgWetlands.WetlandsSurveyor,
                @p_DateofDelineation = farmEsmtAppAdminStructNonAgWetlands.DateofDelineation,
                @p_AcresofWetlands = farmEsmtAppAdminStructNonAgWetlands.AcresofWetlands,
                @p_AcresofTransitionArea = farmEsmtAppAdminStructNonAgWetlands.AcresofTransitionArea,
                @p_WetlandsClassification = farmEsmtAppAdminStructNonAgWetlands.WetlandsClassification,
                @p_LastUpdatedBy = farmEsmtAppAdminStructNonAgWetlands.LastUpdatedBy
            });

        farmEsmtAppAdminStructNonAgWetlands.Id = id;

        return farmEsmtAppAdminStructNonAgWetlands;
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="farmEsmtAppAdminStructNonAgWetlands"></param>
    /// <returns></returns>
    private async Task<FarmEsmtAppAdminStructNonAgWetlandsEntity> UpdateAsync(FarmEsmtAppAdminStructNonAgWetlandsEntity farmEsmtAppAdminStructNonAgWetlands)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateFarnEsmtAppAdminStructNonAgWetlandsSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = farmEsmtAppAdminStructNonAgWetlands.Id,
                @p_ApplicationId = farmEsmtAppAdminStructNonAgWetlands.ApplicationId,
                @p_IsResidenceOnPresLand = farmEsmtAppAdminStructNonAgWetlands.IsResidenceOnPresLand,
                @p_ImprovRes = farmEsmtAppAdminStructNonAgWetlands.ImprovRes,
                @p_AreNonAgUses = farmEsmtAppAdminStructNonAgWetlands.AreNonAgUses,
                @p_NonAgExplan = farmEsmtAppAdminStructNonAgWetlands.NonAgExplan,
                @p_IsFarmMarket = farmEsmtAppAdminStructNonAgWetlands.IsFarmMarket,
                @p_ImprovAg = farmEsmtAppAdminStructNonAgWetlands.ImprovAg,
                @p_WetlandsSurveyor = farmEsmtAppAdminStructNonAgWetlands.WetlandsSurveyor,
                @p_DateofDelineation = farmEsmtAppAdminStructNonAgWetlands.DateofDelineation,
                @p_AcresofWetlands = farmEsmtAppAdminStructNonAgWetlands.AcresofWetlands,
                @p_AcresofTransitionArea = farmEsmtAppAdminStructNonAgWetlands.AcresofTransitionArea,
                @p_WetlandsClassification = farmEsmtAppAdminStructNonAgWetlands.WetlandsClassification,
                @p_LastUpdatedBy = farmEsmtAppAdminStructNonAgWetlands.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return farmEsmtAppAdminStructNonAgWetlands;
    }

}
