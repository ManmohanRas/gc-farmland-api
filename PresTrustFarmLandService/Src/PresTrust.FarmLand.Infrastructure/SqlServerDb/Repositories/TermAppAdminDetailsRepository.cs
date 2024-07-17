namespace PresTrust.FarmLand.Infrastructure.SqlServerDb;

public class TermAppAdminDetailsRepository : ITermAppAdminDetailsRepository
{
    #region " Members ... "

    private readonly PresTrustSqlDbContext context;
    private readonly SystemParameterConfiguration systemParameterConfiguration;

    #endregion

    #region " ctor ... "

    /// <summary>
    /// 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="systemParamConfigOptions"></param>
    public TermAppAdminDetailsRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParameterConfiguration = systemParamConfigOptions.Value;
    }

    #endregion
    public async Task<FarmTermAppAdminDetailsEntity> GetTermAppAdminDetailsAsync(int applicationId)
    {
        FarmTermAppAdminDetailsEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetTermAppAdminDetailsSqlCommand();
        var results = await conn.QueryAsync<FarmTermAppAdminDetailsEntity>(sqlCommand.ToString(),
                            commandType: CommandType.Text,
                            commandTimeout: systemParameterConfiguration.SQLCommandTimeoutInSeconds,
                            param: new
                            {
                                @p_ApplicationId = applicationId,
                            });

        result = results.FirstOrDefault();

        return result ?? new();
    }

    public async Task<FarmTermAppAdminDetailsEntity> SaveAsync(FarmTermAppAdminDetailsEntity farmTermAppAdminDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new CreateTermAppAdminDetailsSqlCommand();
        var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
        commandType: CommandType.Text,
            commandTimeout: systemParameterConfiguration.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId = farmTermAppAdminDetails.ApplicationId,
                @p_SADCId = farmTermAppAdminDetails.SADCId,
                @p_MaxGrant = farmTermAppAdminDetails.MaxGrant,
                @p_PermanentlyPreserved = farmTermAppAdminDetails.PermanentlyPreserved,
                @p_MunicipallyApproved = farmTermAppAdminDetails.MunicipallyApproved,
                @p_EnrollmentDate = farmTermAppAdminDetails.EnrollmentDate,
                @p_RenewalDate = farmTermAppAdminDetails.RenewalDate,
                @p_ExpirationDate = farmTermAppAdminDetails.ExpirationDate,
                @p_RenewalExpirationDate = farmTermAppAdminDetails.RenewalExpirationDate,
                @p_Comment  = farmTermAppAdminDetails.Comment,
                @p_LastUpdatedBy = farmTermAppAdminDetails.LastUpdatedBy

            });
        farmTermAppAdminDetails.Id = id;

        return farmTermAppAdminDetails;
    }

    public async Task<FarmTermAppAdminDetailsEntity> UpdateAsync(FarmTermAppAdminDetailsEntity farmTermAppAdminDetails)
    {

        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateTermAppAdminDetails();

        await conn.ExecuteAsync(sqlCommand.ToString(),
        commandTimeout: systemParameterConfiguration.SQLCommandTimeoutInSeconds,
        param: new
        {
            @p_Id = farmTermAppAdminDetails.Id,
            @p_ApplicationId= farmTermAppAdminDetails.ApplicationId,
            @p_SADCId= farmTermAppAdminDetails.SADCId,
            @p_MaxGrant= farmTermAppAdminDetails.MaxGrant,
            @p_PermanentlyPreserved= farmTermAppAdminDetails.PermanentlyPreserved,
            @p_MunicipallyApproved= farmTermAppAdminDetails.MunicipallyApproved,
            @p_EnrollmentDate= farmTermAppAdminDetails.EnrollmentDate,
            @p_RenewalDate= farmTermAppAdminDetails.RenewalDate,
            @p_ExpirationDate= farmTermAppAdminDetails.ExpirationDate,
            @p_RenewalExpirationDate= farmTermAppAdminDetails.RenewalExpirationDate,
            @p_Comment = farmTermAppAdminDetails.Comment,
            @p_LastUpdatedBy = farmTermAppAdminDetails.LastUpdatedBy,
            @p_LastUpdatedOn = DateTime.Now,
        });
        return farmTermAppAdminDetails;
    }

    public async Task<FarmTermAppAdminDetailsEntity> SaveTermAppAdminDetailsAsync(FarmTermAppAdminDetailsEntity farmTermAppAdminDetails)
    {
        if (farmTermAppAdminDetails.Id > 0)
        {
            return await UpdateAsync(farmTermAppAdminDetails);
        }
        else
        {
            return await SaveAsync(farmTermAppAdminDetails);
        }

    }

}
