namespace PresTrust.FarmLand.Infrastructure.SqlServerDb;

public class OwnerDetailsRepository : IOwnerDetailsRepository
{

    #region " Members ... "

    private readonly PresTrustSqlDbContext context;
    protected readonly SystemParameterConfiguration systemParamConfig;

    #endregion

    #region " ctor ... "

    /// <summary>
    /// </summary>
    /// <param name="context"></param>
    /// <param name="systemParamConfigOptions"></param>
    public OwnerDetailsRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion

    /// <summary>
    ///  Procedure to fetch tech details by Id.
    /// </summary>
    /// <param name="applicationId"> Id.</param>
    /// <returns> Returns farmOwnerDetails Entity.</returns>
    public async Task<IEnumerable<OwnerDetailsEntity>> GetOwnerDetailsAsync(int applicationId)
    {
        IEnumerable<OwnerDetailsEntity> results = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetOwnerDetailsSqlCommand();
        results = await conn.QueryAsync<OwnerDetailsEntity>(sqlCommand.ToString(),
                            commandType: CommandType.Text,
                            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new
                            {
                                @p_ApplicationId = applicationId,
                            });


        return results;
    }

    /// <summary>
    /// Save .
    /// </summary>
    /// <param name="farmOwnerDetails"></param>
    /// <returns></returns>
    public async Task<OwnerDetailsEntity> SaveOwnerDetailsAsync(OwnerDetailsEntity farmOwnerDetails)
    {
        if (farmOwnerDetails.Id > 0)
            return await UpdateAsync(farmOwnerDetails);
        else
            return await SaveAsync(farmOwnerDetails);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="farmOwnerDetails"></param>
    /// <returns></returns>
    private async Task<OwnerDetailsEntity> SaveAsync(OwnerDetailsEntity farmOwnerDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new CreateOwnerDetailsSqlCommand();
        var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {

                @p_ApplicationId = farmOwnerDetails.ApplicationId,
                @p_FirstName = farmOwnerDetails.FirstName,
                @p_LastName = farmOwnerDetails.LastName,
                @p_PropertyLocation = farmOwnerDetails.PropertyLocation,
                @p_Municipality = farmOwnerDetails.Municipality,
                @p_MailingAddress1 = farmOwnerDetails.MailingAddress1,
                @p_MailingAddress2 = farmOwnerDetails.MailingAddress2,
                @p_PhoneNumber = farmOwnerDetails.PhoneNumber,
                @p_City = farmOwnerDetails.city,
                @p_State = farmOwnerDetails.state,
                @p_ZipCode = farmOwnerDetails.ZipCode,
                @p_LastUpdatedBy = farmOwnerDetails.LastUpdatedBy,

            });

        farmOwnerDetails.Id = id;

        return farmOwnerDetails;
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="farmOwnerDetails"></param>
    /// <returns></returns>
    private async Task<OwnerDetailsEntity> UpdateAsync(OwnerDetailsEntity farmOwnerDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateOwnerDetailsSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = farmOwnerDetails.Id,
                @p_ApplicationId = farmOwnerDetails.ApplicationId,
                @p_FirstName = farmOwnerDetails.FirstName,
                @p_LastName = farmOwnerDetails.LastName,
                @p_PropertyLocation = farmOwnerDetails.PropertyLocation,
                @p_Municipality = farmOwnerDetails.Municipality,
                @p_MailingAddress1 = farmOwnerDetails.MailingAddress1,
                @p_MailingAddress2 = farmOwnerDetails.MailingAddress2,
                @p_PhoneNumber = farmOwnerDetails.PhoneNumber,
                @p_city = farmOwnerDetails.city,
                @p_state = farmOwnerDetails.state,
                @p_ZipCode = farmOwnerDetails.ZipCode,
                @p_LastUpdatedBy = farmOwnerDetails.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return farmOwnerDetails;
    }

    public async Task DeleteOwnerDetailsAsync(int applicationId, int id)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new DeleteOwnerDetailsSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = id,
                @p_ApplicationId = applicationId
            });

    }
}
