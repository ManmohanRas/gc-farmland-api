namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class FarmSadcResidenceRepository : IFarmSadcResidenceRepository
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
    public FarmSadcResidenceRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion



    /// <summary>
    ///  Procedure to fetch SADC Residence details by Id.
    /// </summary>
    /// <param name="applicationId"> Id.</param>
    /// <returns> Returns FarmSadcResidenceEntity.</returns>
    public async Task<FarmSadcResidenceEntity> GetSadcResidenceAsync(int applicationId)
    {
        FarmSadcResidenceEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarmSadcResidenceSqlQuery();
        var results = await conn.QueryAsync<FarmSadcResidenceEntity>(sqlCommand.ToString(),
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
    /// Save SADC Residence.
    /// </summary>
    /// <param name="farmSadcResidence"></param>
    /// <returns></returns>
    public async Task<FarmSadcResidenceEntity> SaveAsync(FarmSadcResidenceEntity farmSadcResidence)
    {
        if (farmSadcResidence.Id > 0)
            return await UpdateAsync(farmSadcResidence);
        else
            return await CreateAsync(farmSadcResidence);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="farmSadcResidence"></param>
    /// <returns></returns>
    private async Task<FarmSadcResidenceEntity> CreateAsync(FarmSadcResidenceEntity farmSadcResidence)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateFarmSadcResidenceSqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId = farmSadcResidence.ApplicationId,
                @p_IsAgriculturalLabor = farmSadcResidence.IsAgriculturalLabor,
                @p_UnitsUsedForLabor = farmSadcResidence.UnitsUsedForLabor,
                @p_Occupants = farmSadcResidence.Occupants,
                @p_MonthsOccupied = farmSadcResidence.MonthsOccupied,
                @p_IsOccupantsWork = farmSadcResidence.IsOccupantsWork,
                @p_PleaseExplain = farmSadcResidence.PleaseExplain,
                @p_IsResidencesRented = farmSadcResidence.IsResidencesRented,
                @p_RDSOsReserve = farmSadcResidence.RDSOsReserve,
                @p_ExcepAcres1 = farmSadcResidence.ExcepAcres1,
                @p_NonSeverable1 = farmSadcResidence.NonSeverable1,
                @p_Severable1 = farmSadcResidence.Severable1,
                @p_AdditionalComment1 = farmSadcResidence.AdditionalComment1,
                @p_ExcepAcres2 = farmSadcResidence.ExcepAcres2,
                @p_NonSeverable2 = farmSadcResidence.NonSeverable2,
                @p_Severable2 = farmSadcResidence.Severable2,
                @p_AdditionalComment2 = farmSadcResidence.AdditionalComment2,
                @p_EsmtOthersText = farmSadcResidence.EsmtOthersText,
                @p_IsSightTriangle = farmSadcResidence.IsSightTriangle,
                @p_LastUpdatedBy = farmSadcResidence.LastUpdatedBy
            });

        farmSadcResidence.Id = id;

        return farmSadcResidence;
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="farmSadcResidence"></param>
    /// <returns></returns>
    private async Task<FarmSadcResidenceEntity> UpdateAsync(FarmSadcResidenceEntity farmSadcResidence)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateFarmSadcResidenceSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = farmSadcResidence.Id,
                @p_ApplicationId = farmSadcResidence.ApplicationId,
                @p_IsAgriculturalLabor = farmSadcResidence.IsAgriculturalLabor,
                @p_UnitsUsedForLabor = farmSadcResidence.UnitsUsedForLabor,
                @p_Occupants = farmSadcResidence.Occupants,
                @p_MonthsOccupied = farmSadcResidence.MonthsOccupied,
                @p_IsOccupantsWork = farmSadcResidence.IsOccupantsWork,
                @p_PleaseExplain = farmSadcResidence.PleaseExplain,
                @p_IsResidencesRented = farmSadcResidence.IsResidencesRented,
                @p_RDSOsReserve = farmSadcResidence.RDSOsReserve,
                @p_ExcepAcres1 = farmSadcResidence.ExcepAcres1,
                @p_NonSeverable1 = farmSadcResidence.NonSeverable1,
                @p_Severable1 = farmSadcResidence.Severable1,
                @p_AdditionalComment1 = farmSadcResidence.AdditionalComment1,
                @p_ExcepAcres2 = farmSadcResidence.ExcepAcres2,
                @p_NonSeverable2 = farmSadcResidence.NonSeverable2,
                @p_Severable2 = farmSadcResidence.Severable2,
                @p_AdditionalComment2 = farmSadcResidence.AdditionalComment2,
                @p_EsmtOthersText = farmSadcResidence.EsmtOthersText,
                @p_IsSightTriangle = farmSadcResidence.IsSightTriangle,
                @p_LastUpdatedBy = farmSadcResidence.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return farmSadcResidence;
    }
}
