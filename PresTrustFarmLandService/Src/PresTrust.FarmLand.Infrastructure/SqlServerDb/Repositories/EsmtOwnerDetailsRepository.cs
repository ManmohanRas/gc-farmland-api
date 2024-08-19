namespace PresTrust.FarmLand.Infrastructure.SqlServerDb;

public class EsmtOwnerDetailsRepository : IEsmtOwnerDetailsRepository
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
    public EsmtOwnerDetailsRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion

    /// <summary>
    ///  Procedure to fetch tech details by Id.
    /// </summary>
    /// <param name="applicationId"> Id.</param>
    /// <returns> Returns esmtOwnerDetails Entity.</returns>
    public async Task<EsmtOwnerDetailsEntity> GetOwnerDetailsAsync(int applicationId)
    {
        EsmtOwnerDetailsEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetEsmtOwnerDetailsSql();
        var results = await conn.QueryAsync<EsmtOwnerDetailsEntity>(sqlCommand.ToString(),
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
    /// <param name="esmtOwnerDetails"></param>
    /// <returns></returns>
    private async Task<EsmtOwnerDetailsEntity> SaveAsync(EsmtOwnerDetailsEntity esmtOwnerDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new CreateEsmtOwnerDetailsSqlCommand();
        var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId         = esmtOwnerDetails.ApplicationId         ,
                @p_SoleProprietor        = esmtOwnerDetails.SoleProprietor        ,
                @p_ProprirtorPartnership = esmtOwnerDetails.ProprirtorPartnership ,
                @p_MultiProprietor       = esmtOwnerDetails.MultiProprietor       ,
                @p_ExecutorEstate        = esmtOwnerDetails.ExecutorEstate        ,
                @p_CPFeeSimple           = esmtOwnerDetails.CPFeeSimple           ,
                @p_CPEasement            = esmtOwnerDetails.CPEasement            ,
                @p_MunicipalityCurrentEO = esmtOwnerDetails.MunicipalityCurrentEO ,
                @p_ConservationOrg       = esmtOwnerDetails.ConservationOrg       ,
                @p_FarmName              = esmtOwnerDetails.FarmName              ,
                @p_ResidentName          = esmtOwnerDetails.ResidentName          ,
                @p_AttarneyName          = esmtOwnerDetails.AttarneyName          ,
                @p_AtMailingAddress      = esmtOwnerDetails.AtMailingAddress      ,
                @p_ATFirmName            = esmtOwnerDetails.ATFirmName            ,
                @p_ResiPhoneNumber       = esmtOwnerDetails.ResiPhoneNumber       ,
                @p_PdStreetAddress       = esmtOwnerDetails.PdStreetAddress       ,
                @p_OwnedContinuesly      = esmtOwnerDetails.OwnedContinuesly      ,
                @p_SubjectProperty       = esmtOwnerDetails.SubjectProperty       ,
                @p_LastUpdatedBy = esmtOwnerDetails.LastUpdatedBy

            });

        esmtOwnerDetails.Id = id;

        return esmtOwnerDetails;
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="esmtOwnerDetails"></param>
    /// <returns></returns>
    private async Task<EsmtOwnerDetailsEntity> UpdateAsync(EsmtOwnerDetailsEntity esmtOwnerDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateEsmtOwnerDetailsSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = esmtOwnerDetails.Id,
                @p_ApplicationId = esmtOwnerDetails.ApplicationId,
                @p_SoleProprietor = esmtOwnerDetails.SoleProprietor,
                @p_ProprirtorPartnership = esmtOwnerDetails.ProprirtorPartnership,
                @p_MultiProprietor = esmtOwnerDetails.MultiProprietor,
                @p_ExecutorEstate = esmtOwnerDetails.ExecutorEstate,
                @p_CPFeeSimple = esmtOwnerDetails.CPFeeSimple,
                @p_CPEasement = esmtOwnerDetails.CPEasement,
                @p_MunicipalityCurrentEO = esmtOwnerDetails.MunicipalityCurrentEO,
                @p_ConservationOrg = esmtOwnerDetails.ConservationOrg,
                @p_FarmName = esmtOwnerDetails.FarmName,
                @p_ResidentName = esmtOwnerDetails.ResidentName,
                @p_AttarneyName = esmtOwnerDetails.AttarneyName,
                @p_AtMailingAddress = esmtOwnerDetails.AtMailingAddress,
                @p_ATFirmName = esmtOwnerDetails.ATFirmName,
                @p_ResiPhoneNumber = esmtOwnerDetails.ResiPhoneNumber,
                @p_PdStreetAddress = esmtOwnerDetails.PdStreetAddress,
                @p_OwnedContinuesly = esmtOwnerDetails.OwnedContinuesly,
                @p_SubjectProperty = esmtOwnerDetails.SubjectProperty,
                @p_LastUpdatedBy = esmtOwnerDetails.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now,             
            });

        return esmtOwnerDetails;
    }
    /// <summary>
    /// Save .
    /// </summary>
    /// <param name="esmtOwnerDetails"></param>
    /// <returns></returns>

    public async Task<EsmtOwnerDetailsEntity> SaveOwnerDetailsAsync(EsmtOwnerDetailsEntity esmtOwnerDetails)
    {
        if (esmtOwnerDetails.Id > 0)
            return await UpdateAsync(esmtOwnerDetails);
        else
            return await SaveAsync(esmtOwnerDetails);
    }
}
