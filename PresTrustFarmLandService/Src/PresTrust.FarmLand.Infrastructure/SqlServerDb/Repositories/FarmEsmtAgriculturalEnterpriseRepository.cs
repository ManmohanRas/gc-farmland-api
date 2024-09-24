namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class FarmEsmtAgriculturalEnterpriseRepository: IFarmEsmtAgriculturalEnterpriseRepository
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
    public FarmEsmtAgriculturalEnterpriseRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion



    /// <summary>
    ///  Procedure to fetch Agricultural details by Id.
    /// </summary>
    /// <param name="applicationId"> Id.</param>
    /// <returns> Returns FarmEsmtAgriculturalEnterpriseEntity.</returns>
    public async Task<FarmEsmtAgriculturalEnterpriseEntity> GetAgriEnterprisAsync(int applicationId)
    {
        FarmEsmtAgriculturalEnterpriseEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarmEsmtAgriculturalEnterpriseSqlQuires();
        var results = await conn.QueryAsync<FarmEsmtAgriculturalEnterpriseEntity>(sqlCommand.ToString(),
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
    /// Save Agricultural.
    /// </summary>
    /// <param name="farmEsmtAgriEnterprise"></param>
    /// <returns></returns>
    public async Task<FarmEsmtAgriculturalEnterpriseEntity> SaveAsync(FarmEsmtAgriculturalEnterpriseEntity farmEsmtAgriEnterprise)
    {
        if (farmEsmtAgriEnterprise.Id > 0)
            return await UpdateAsync(farmEsmtAgriEnterprise);
        else
            return await CreateAsync(farmEsmtAgriEnterprise);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="farmEsmtAgriEnterprise"></param>
    /// <returns></returns>
    private async Task<FarmEsmtAgriculturalEnterpriseEntity> CreateAsync(FarmEsmtAgriculturalEnterpriseEntity farmEsmtAgriEnterprise)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateFarmEsmtAgriculturalEnterpriseSqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId = farmEsmtAgriEnterprise.ApplicationId,
                @p_AverageGrossReceipts = farmEsmtAgriEnterprise.AverageGrossReceipts,
                @p_IsFullTimeFarmer = farmEsmtAgriEnterprise.IsFullTimeFarmer,
                @p_HasSoilConservationPlan = farmEsmtAgriEnterprise.HasSoilConservationPlan,
                @p_PlanDate = farmEsmtAgriEnterprise.PlanDate,
                @p_ConservationPractices = farmEsmtAgriEnterprise.ConservationPractices,
                @p_AgriculturalInvestments = farmEsmtAgriEnterprise.AgriculturalInvestments,
                @p_LastUpdatedBy = farmEsmtAgriEnterprise.LastUpdatedBy
            });

        farmEsmtAgriEnterprise.Id = id;

        return farmEsmtAgriEnterprise;
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="farmEsmtAgriEnterprise"></param>
    /// <returns></returns>
    private async Task<FarmEsmtAgriculturalEnterpriseEntity> UpdateAsync(FarmEsmtAgriculturalEnterpriseEntity farmEsmtAgriEnterprise)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateFarmEsmtAgriculturalEnterpriseSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = farmEsmtAgriEnterprise.Id,
                @p_ApplicationId = farmEsmtAgriEnterprise.ApplicationId,
                @p_AverageGrossReceipts = farmEsmtAgriEnterprise.AverageGrossReceipts,
                @p_IsFullTimeFarmer = farmEsmtAgriEnterprise.IsFullTimeFarmer,
                @p_HasSoilConservationPlan = farmEsmtAgriEnterprise.HasSoilConservationPlan,
                @p_PlanDate = farmEsmtAgriEnterprise.PlanDate,
                @p_ConservationPractices = farmEsmtAgriEnterprise.ConservationPractices,
                @p_AgriculturalInvestments = farmEsmtAgriEnterprise.AgriculturalInvestments,
                @p_LastUpdatedBy = farmEsmtAgriEnterprise.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return farmEsmtAgriEnterprise;
    }

    //Check list
    public async Task<List<FarmAgriculturalEnterpriseChecklistEntity>> GetAgriCheckListAsync(int applicationId)
    {
        List<FarmAgriculturalEnterpriseChecklistEntity> results;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarmEsmtAgriEnterpriseChecklistSqlQuery();
        results = (await conn.QueryAsync<FarmAgriculturalEnterpriseChecklistEntity>(sqlCommand.ToString(),
                            commandType: CommandType.Text,
                            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new { @p_ApplicationId = applicationId })).ToList();

        return results ?? new();
    }

    /// <summary>
    /// Save agriCheckList.
    /// </summary>
    /// <param name="agriCheckList"></param>
    /// <returns></returns>
    public async Task<FarmAgriculturalEnterpriseChecklistEntity> SaveAgriCheckListAsync(FarmAgriculturalEnterpriseChecklistEntity agriCheckList)
    {
        if (await CheckIfActivitySubTypeExists(agriCheckList.ApplicationId, agriCheckList.ActivitySubTypeId, agriCheckList.Id))
        {
            throw new InvalidOperationException($"An entry with ActivitySubTypeId {agriCheckList.ActivitySubTypeId} already exists for ApplicationId {agriCheckList.ApplicationId}.");
        }
        if (agriCheckList.Id > 0)
            return await UpdateAsync(agriCheckList);
        else
            return await CreateAsync(agriCheckList);

    }

    /// <summary>
    /// Check if an entry with the same ApplicationId and ActivitySubTypeId already exists, excluding the current entity (if updating)
    /// </summary>
    private async Task<bool> CheckIfActivitySubTypeExists(int applicationId, int activitySubTypeId, int? currentId = null)
    {
        using var conn = context.CreateConnection();

        // SQL query to check for existing ActivitySubTypeId within the same ApplicationId, excluding the current Id (if updating)
        var query = @"
        SELECT COUNT(1)
        FROM [Farm].[FarmAgriculturalEnterpriseChecklist]
        WHERE ApplicationId = @p_ApplicationId
        AND ActivitySubTypeId = @p_ActivitySubTypeId
        AND (@p_Id IS NULL OR Id <> @p_Id)"; // Exclude current record in case of update

        var exists = await conn.ExecuteScalarAsync<int>(query,
            new
            {
                @p_ApplicationId = applicationId,
                @p_ActivitySubTypeId = activitySubTypeId,
                @p_Id = currentId
            });

        return exists > 0;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="agriCheckList"></param>
    /// <returns></returns>
    private async Task<FarmAgriculturalEnterpriseChecklistEntity> CreateAsync(FarmAgriculturalEnterpriseChecklistEntity agriCheckList)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateFarmAgriEnterpriseChecklistSqlCommad();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId = agriCheckList.ApplicationId,
                @p_ActivitySubTypeId = (int)agriCheckList.ActivitySubTypeId,
                @p_Title = agriCheckList.Title,
                @p_SicCode = agriCheckList.SicCode,
                @p_IsPrimary = agriCheckList.IsPrimary,
                @p_IsSecondary = agriCheckList.IsSecondary,
                @p_LastUpdatedBy = agriCheckList.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        agriCheckList.Id = id;

        return agriCheckList;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="fundingSource"></param>
    /// <returns></returns>
    private async Task<FarmAgriculturalEnterpriseChecklistEntity> UpdateAsync(FarmAgriculturalEnterpriseChecklistEntity agriCheckList)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateFarmAgriEnterpriseChecklistSqlCommad();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = agriCheckList.Id,
                @p_ApplicationId = agriCheckList.ApplicationId,
                @p_ActivitySubTypeId = (int)agriCheckList.ActivitySubTypeId,
                @p_Title = agriCheckList.Title,
                @p_SicCode = agriCheckList.SicCode,
                @p_IsPrimary = agriCheckList.IsPrimary,
                @p_IsSecondary = agriCheckList.IsSecondary,
                @p_LastUpdatedBy = agriCheckList.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return agriCheckList;
    }

}
