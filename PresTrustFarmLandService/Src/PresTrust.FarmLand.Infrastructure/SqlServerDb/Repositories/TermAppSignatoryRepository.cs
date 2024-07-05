namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;
public class TermAppSignatoryRepository : ITermAppSignatoryRepository
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
    public TermAppSignatoryRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion



    /// <summary>
    ///  Procedure to fetch Signatory details by Id.
    /// </summary>
    /// <param name="applicationId"> Id.</param>
    /// <returns> Returns FarmTermAppSignatoryEntity.</returns>
    public async Task<FarmTermAppSignatoryEntity> GetSignatoryAsync(int applicationId)
    {
        FarmTermAppSignatoryEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetTermAppSignatorySqlCommand();
        var results = await conn.QueryAsync<FarmTermAppSignatoryEntity>(sqlCommand.ToString(),
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
    public async Task<FarmTermAppSignatoryEntity> SaveAsync(FarmTermAppSignatoryEntity farmApplicationSignatory)
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
    private async Task<FarmTermAppSignatoryEntity> CreateAsync(FarmTermAppSignatoryEntity farmApplicationSignatory)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateTermAppSignatorySqlCommand();
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
    private async Task<FarmTermAppSignatoryEntity> UpdateAsync(FarmTermAppSignatoryEntity farmApplicationSignatory)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateTermAppSignatorySqlCommand();
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
