namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class ApplicationRepository : IApplicationRepository
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
    public ApplicationRepository(
        PresTrustSqlDbContext context,
        IOptions<SystemParameterConfiguration> systemParamConfigOptions
        )
    {
        this.context = context;
        this.systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion

    public async Task<FarmApplicationEntity> GetApplicationAsync(int applicationId)
    {
        FarmApplicationEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetApplicationDetailsSqlCommand();
        var results = await conn.QueryAsync<FarmApplicationEntity>(sqlCommand.ToString(),
                            commandType: CommandType.Text,
                            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new { @p_Id = applicationId });
        result = results.FirstOrDefault();

        return result ?? new();
    }

    public async Task<List<FarmApplicationEntity>> GetApplicationsAsync()
    {
        List<FarmApplicationEntity> results = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetApplicationsSqlQuery();
        results = (await conn.QueryAsync<FarmApplicationEntity>(sqlCommand.ToString(),
                            commandType: CommandType.Text,
                            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new { }
                            )).ToList();

        return results ?? new();
    }

    public async Task<FarmApplicationEntity> SaveAsync(FarmApplicationEntity application)
    {
        if (application.Id > 0)
            return await UpdateAsync(application);
        else
            return await CreateAsync(application);

    }

    private async Task<FarmApplicationEntity> CreateAsync(FarmApplicationEntity application)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateApplicationSqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
        param: new
        {
                @p_Title = application.Title,
                @p_AgencyId = application.AgencyId,
                @p_FarmListId = application.FarmListId,
                @p_ApplicationTypeId = application.ApplicationTypeId,
                @p_StatusId = application.StatusId,
                @p_CreatedByProgramUser = application.CreatedByProgramUser,
                @p_IsApprovedByMunicipality = application.IsApprovedByMunicipality,
                @p_CreatedBy = application.CreatedBy,
                @p_LastUpdatedBy = application.LastUpdatedBy
            });

        application.Id = id;

        return application;
    }

    public async Task<bool> SaveStatusLogAsync(FarmApplicationStatusLogEntity applicationStatusLog)
    {
        bool result = false;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateApplicationStatusLogSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId = applicationStatusLog.ApplicationId,
                @p_StatusId = applicationStatusLog.StatusId,
                @p_StatusDate = applicationStatusLog.StatusDate,
                @p_Notes = applicationStatusLog.Notes,
                @p_LastUpdatedBy = applicationStatusLog.LastUpdatedBy,
            });

        result = true;
        return result;
    }

    private async Task<FarmApplicationEntity> UpdateAsync(FarmApplicationEntity application)
    {
        int id = default;

        return application;
    }

    public async Task<FarmApplicationEntity> SaveApplicationWorkflowStatusAsync(FarmApplicationEntity application)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateApplicationWorkflowStatusSqlCommand();
        id = await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
        param: new
        {
            @p_ApplicationId = application.Id,
            @p_StatusId = application.StatusId,
            @p_LastUpdatedBy = application.LastUpdatedBy
        });

        return application;
    }


    /// <summary>
    /// update application status
    /// </summary>
    /// <param name="application"></param>
    /// <param name="enumStatus"></param>
    /// <returns></returns>
    public async Task<bool> UpdateApplicationStatusAsync(FarmApplicationEntity application, ApplicationStatusEnum enumStatus)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateApplicationWorkflowStatusSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = application.Id,
                @p_StatusId = enumStatus,
                @p_PrevStatusId = application.StatusId,
                @p_LastUpdatedBy = application.LastUpdatedBy
            });

        return true;
    }

}

