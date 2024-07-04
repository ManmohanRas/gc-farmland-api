namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;
public class ApplicationSignatoryRepository : IApplicationSignatoryRepository
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
    public ApplicationSignatoryRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion



    /// <summary>
    ///  Procedure to fetch Signatory details by Id.
    /// </summary>
    /// <param name="applicationId"> Id.</param>
    /// <returns> Returns FarmApplicationSignatoryEntity.</returns>
    public async Task<FarmApplicationSignatoryEntity> GetSignatoryAsync(int applicationId)
    {
        FarmApplicationSignatoryEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetApplicationSignatorySqlCommand();
        var results = await conn.QueryAsync<FarmApplicationSignatoryEntity>(sqlCommand.ToString(),
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
    /// Save Signatory.
    /// </summary>
    /// <param name="farmApplicationSignatory"></param>
    /// <returns></returns>
    public async Task<FarmApplicationSignatoryEntity> SaveAsync(FarmApplicationSignatoryEntity farmApplicationSignatory)
    {
        if (farmApplicationSignatory.Id > 0)
            return await UpdateAsync(farmApplicationSignatory);
        else
            return await CreateAsync(farmApplicationSignatory);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="farmApplicationSignatory"></param>
    /// <returns></returns>
    private async Task<FarmApplicationSignatoryEntity> CreateAsync(FarmApplicationSignatoryEntity farmApplicationSignatory)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateApplicationSignatorySqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId = farmApplicationSignatory.ApplicationId,
                @p_Designation = farmApplicationSignatory.Designation,
                @p_Title = farmApplicationSignatory.Title,
                @p_SignedOn = farmApplicationSignatory.SignedOn,
                @p_LastUpdatedBy = farmApplicationSignatory.LastUpdatedBy
            });

        farmApplicationSignatory.Id = id;

        return farmApplicationSignatory;
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="farmApplicationSignatory"></param>
    /// <returns></returns>
    private async Task<FarmApplicationSignatoryEntity> UpdateAsync(FarmApplicationSignatoryEntity farmApplicationSignatory)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateApplicationSignatorySqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = farmApplicationSignatory.Id,
                @p_ApplicationId = farmApplicationSignatory.ApplicationId,
                @p_Designation = farmApplicationSignatory.Designation,
                @p_Title = farmApplicationSignatory.Title,
                @p_SignedOn = farmApplicationSignatory.SignedOn,
                @p_LastUpdatedBy = farmApplicationSignatory.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return farmApplicationSignatory;
    }

}
