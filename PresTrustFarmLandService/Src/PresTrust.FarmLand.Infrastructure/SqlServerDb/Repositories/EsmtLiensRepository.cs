namespace PresTrust.FarmLand.Infrastructure.SqlServerDb;

public class EsmtLiensRepository :IEsmtLiensReposioty
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
    public EsmtLiensRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion

    /// <summary>
    ///  Procedure to fetch tech details by Id.
    /// </summary>
    /// <param name="applicationId"> Id.</param>
    /// <returns> Returns esmtLiens Entity.</returns>
    public async Task<EsmtLiensEntity> GetLiensAsync(int applicationId)
    {
        EsmtLiensEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetEsmtLiensSqlQuery();
        var results = await conn.QueryAsync<EsmtLiensEntity>(sqlCommand.ToString(),
                            commandType: CommandType.Text,
                            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new
                            {
                                @p_ApplicationId = applicationId,
                            });

        result = results.FirstOrDefault();

        return result ?? new();

    }


    /// <summary>
    ///
    /// </summary>
    /// <param name="esmtLiens"></param>
    /// <returns></returns>
    private async Task<EsmtLiensEntity> SaveAsync(EsmtLiensEntity esmtLiens)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new CreateEsmtLiensSqlCommand();
        var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId = esmtLiens.ApplicationId
                ,@p_PremisePreserved		= esmtLiens.PremisePreserved		   
                ,@p_BankruptcyJedgement	= esmtLiens.BankruptcyJedgement	   
                ,@p_PowerLines				= esmtLiens.PowerLines				   
                ,@p_WaterLines				= esmtLiens.WaterLines				   
                ,@p_Sewer					= esmtLiens.Sewer					   
                ,@p_Bridge					= esmtLiens.Bridge					   
                ,@p_FloodRightWay			= esmtLiens.FloodRightWay			   
                ,@p_TelephoneLines			= esmtLiens.TelephoneLines			   
                ,@p_GasLines				= esmtLiens.GasLines				   
                ,@p_Other					= esmtLiens.Other					   
                ,@p_AvvessEasement			= esmtLiens.AvvessEasement			   
                ,@p_AccessDescribe			= esmtLiens.AccessDescribe			   
                ,@p_ConservationEasement	= esmtLiens.ConservationEasement	   
                ,@p_ConservationDescribe	= esmtLiens.ConservationDescribe	   
                ,@p_FederalProgram			= esmtLiens.FederalProgram			   
                ,@p_FederalDescribe		= esmtLiens.FederalDescribe		   
                ,@p_SolarWindBiomass		= esmtLiens.SolarWindBiomass		   
                ,@p_BiomassDescribe		= esmtLiens.BiomassDescribe		   
                ,@p_DateInstallation		= esmtLiens.DateInstallation		   
                ,@p_PropertySale			= esmtLiens.PropertySale			   
                ,@p_EstateSituation		= esmtLiens.EstateSituation		   
                ,@p_Bankruptcy				= esmtLiens.Bankruptcy
                ,@p_LastUpdatedBy = esmtLiens.LastUpdatedBy

            });

        esmtLiens.Id = id;

        return esmtLiens;
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="esmtLiens"></param>
    /// <returns></returns>
    private async Task<EsmtLiensEntity> UpdateAsync(EsmtLiensEntity esmtLiens)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateEsmtLiensSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = esmtLiens.Id
                ,@p_ApplicationId = esmtLiens.ApplicationId
                ,@p_PremisePreserved = esmtLiens.PremisePreserved
                ,@p_BankruptcyJedgement = esmtLiens.BankruptcyJedgement
                ,@p_PowerLines = esmtLiens.PowerLines
                ,@p_WaterLines = esmtLiens.WaterLines
                ,@p_Sewer = esmtLiens.Sewer
                ,@p_Bridge = esmtLiens.Bridge
                ,@p_FloodRightWay = esmtLiens.FloodRightWay
                ,@p_TelephoneLines = esmtLiens.TelephoneLines
                ,@p_GasLines = esmtLiens.GasLines
                ,@p_Other = esmtLiens.Other
                ,@p_AvvessEasement = esmtLiens.AvvessEasement
                ,@p_AccessDescribe = esmtLiens.AccessDescribe
                ,@p_ConservationEasement = esmtLiens.ConservationEasement
                ,@p_ConservationDescribe = esmtLiens.ConservationDescribe
                ,@p_FederalProgram = esmtLiens.FederalProgram
                ,@p_FederalDescribe = esmtLiens.FederalDescribe
                ,@p_SolarWindBiomass = esmtLiens.SolarWindBiomass
                ,@p_BiomassDescribe = esmtLiens.BiomassDescribe
                ,@p_DateInstallation = esmtLiens.DateInstallation
                ,@p_PropertySale = esmtLiens.PropertySale
                ,@p_EstateSituation = esmtLiens.EstateSituation
                ,@p_Bankruptcy = esmtLiens.Bankruptcy
                ,@p_LastUpdatedBy = esmtLiens.LastUpdatedBy
                ,@p_LastUpdatedOn = DateTime.Now,
            });

        return esmtLiens;
    }
    /// <summary>
    /// Save .
    /// </summary>
    /// <param name="esmtLiens"></param>
    /// <returns></returns>

    public async Task<EsmtLiensEntity> SaveLiensAsync(EsmtLiensEntity esmtLiens)
    {
        if (esmtLiens.Id > 0)
            return await UpdateAsync(esmtLiens);
        else
            return await SaveAsync(esmtLiens);
    }

}
