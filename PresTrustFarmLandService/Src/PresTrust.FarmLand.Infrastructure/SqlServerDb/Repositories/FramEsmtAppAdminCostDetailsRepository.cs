namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class FarmEsmtAppAdminCostDetailsRepository : IFarmEsmtAppAdminCostDetailsRepository
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
    public FarmEsmtAppAdminCostDetailsRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion



    /// <summary>
    /// </summary>
    ///  Procedure to fetch Signatory details by Id.
    /// <param name="applicationId"> Id.</param>
    /// <returns> Returns FarmEsmtAppAdminCostDetailsEntity.</returns>
    public async Task<FarmEsmtAppAdminCostDetailsEntity> GetCostDetailsAsync(int applicationId)
    {
        FarmEsmtAppAdminCostDetailsEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarmEsmtAppAdminCostDetailsSqlQuery();
        var results = await conn.QueryAsync<FarmEsmtAppAdminCostDetailsEntity>(sqlCommand.ToString(),
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
    /// <param name="farmEsmtAppAdminCostDetails"></param>
    /// <returns></returns>
    public async Task<FarmEsmtAppAdminCostDetailsEntity> SaveAsync(FarmEsmtAppAdminCostDetailsEntity farmEsmtAppAdminCostDetails)
    {
        if (farmEsmtAppAdminCostDetails.Id > 0)
            return await UpdateAsync(farmEsmtAppAdminCostDetails);
        else
            return await CreateAsync(farmEsmtAppAdminCostDetails);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="farmEsmtAppAdminCostDetails"></param>
    /// <returns></returns>
    private async Task<FarmEsmtAppAdminCostDetailsEntity> CreateAsync(FarmEsmtAppAdminCostDetailsEntity farmEsmtAppAdminCostDetails)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateFarmEsmtAppAdminCostDetailsCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId                      = farmEsmtAppAdminCostDetails.ApplicationId,
                @p_GrossAcers                         = farmEsmtAppAdminCostDetails.GrossAcers,
                @p_SADCBeforeValueAC                  = farmEsmtAppAdminCostDetails.SADCBeforeValueAC,
                @p_SADCAfterValueAC                   = farmEsmtAppAdminCostDetails.SADCAfterValueAC,
                @p_OfferToSADC                        = farmEsmtAppAdminCostDetails.OfferToSADC,
                @p_SADCCostShareAC                    = farmEsmtAppAdminCostDetails.SADCCostShareAC,
                @p_SADCCostShareTotal                 = farmEsmtAppAdminCostDetails.SADCCostShareTotal,
                @p_SADCCostShareAcqTotal              = farmEsmtAppAdminCostDetails.SADCCostShareAcqTotal,
                @p_NoteOfBreakdown                    = farmEsmtAppAdminCostDetails.NoteOfBreakdown,
                @p_SADCCostShareofOfferPct            = farmEsmtAppAdminCostDetails.SADCCostShareofOfferPct,
                @p_SADCCertifiedEasementValuePerAcre  = farmEsmtAppAdminCostDetails.SADCCertifiedEasementValuePerAcre,
                @p_SADCPctofCertifiedEaseValue        = farmEsmtAppAdminCostDetails.SADCPctofCertifiedEaseValue,
                @p_NetAcres                           = farmEsmtAppAdminCostDetails.NetAcres,
                @p_MCOffertoLandowner                 = farmEsmtAppAdminCostDetails.MCOffertoLandowner,
                @p_MCCertifiedBeforeValue             = farmEsmtAppAdminCostDetails.MCCertifiedBeforeValue,
                @p_MCCostSharePerAcre                 = farmEsmtAppAdminCostDetails.MCCostSharePerAcre,
                @p_OtherSource                        = farmEsmtAppAdminCostDetails.OtherSource,
                @p_OtherCostShare                     = farmEsmtAppAdminCostDetails.OtherCostShare,
                @p_MCCostSharePct                     = farmEsmtAppAdminCostDetails.MCCostSharePct,
                @p_MCCostShareTotal                   = farmEsmtAppAdminCostDetails.MCCostShareTotal,
                @p_TotalCost                          = farmEsmtAppAdminCostDetails.TotalCost,
                @p_TotalCostPerAcre                   = farmEsmtAppAdminCostDetails.TotalCostPerAcre,
                @p_CountyFunds                        = farmEsmtAppAdminCostDetails.CountyFunds,
                @p_LastUpdatedBy                      = farmEsmtAppAdminCostDetails.LastUpdatedBy
            });

        farmEsmtAppAdminCostDetails.Id = id;

        return farmEsmtAppAdminCostDetails;
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="farmEsmtAppAdminCostDetails"></param>
    /// <returns></returns>
    private async Task<FarmEsmtAppAdminCostDetailsEntity> UpdateAsync(FarmEsmtAppAdminCostDetailsEntity farmEsmtAppAdminCostDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateFarmEsmtAppAdminCostDetailsCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = farmEsmtAppAdminCostDetails.Id,
                @p_ApplicationId = farmEsmtAppAdminCostDetails.ApplicationId,
                @p_GrossAcers = farmEsmtAppAdminCostDetails.GrossAcers,
                @p_SADCBeforeValueAC = farmEsmtAppAdminCostDetails.SADCBeforeValueAC,
                @p_SADCAfterValueAC = farmEsmtAppAdminCostDetails.SADCAfterValueAC,
                @p_OfferToSADC = farmEsmtAppAdminCostDetails.OfferToSADC,
                @p_SADCCostShareAC = farmEsmtAppAdminCostDetails.SADCCostShareAC,
                @p_SADCCostShareTotal = farmEsmtAppAdminCostDetails.SADCCostShareTotal,
                @p_SADCCostShareAcqTotal = farmEsmtAppAdminCostDetails.SADCCostShareAcqTotal,
                @p_NoteOfBreakdown = farmEsmtAppAdminCostDetails.NoteOfBreakdown,
                @p_SADCCostShareofOfferPct = farmEsmtAppAdminCostDetails.SADCCostShareofOfferPct,
                @p_SADCCertifiedEasementValuePerAcre = farmEsmtAppAdminCostDetails.SADCCertifiedEasementValuePerAcre,
                @p_SADCPctofCertifiedEaseValue = farmEsmtAppAdminCostDetails.SADCPctofCertifiedEaseValue,
                @p_NetAcres = farmEsmtAppAdminCostDetails.NetAcres,
                @p_MCOffertoLandowner = farmEsmtAppAdminCostDetails.MCOffertoLandowner,
                @p_MCCertifiedBeforeValue = farmEsmtAppAdminCostDetails.MCCertifiedBeforeValue,
                @p_MCCostSharePerAcre = farmEsmtAppAdminCostDetails.MCCostSharePerAcre,
                @p_OtherSource = farmEsmtAppAdminCostDetails.OtherSource,
                @p_OtherCostShare = farmEsmtAppAdminCostDetails.OtherCostShare,
                @p_MCCostSharePct = farmEsmtAppAdminCostDetails.MCCostSharePct,
                @p_MCCostShareTotal = farmEsmtAppAdminCostDetails.MCCostShareTotal,
                @p_TotalCost = farmEsmtAppAdminCostDetails.TotalCost,
                @p_TotalCostPerAcre = farmEsmtAppAdminCostDetails.TotalCostPerAcre,
                @p_CountyFunds = farmEsmtAppAdminCostDetails.CountyFunds,
                @p_LastUpdatedBy = farmEsmtAppAdminCostDetails.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return farmEsmtAppAdminCostDetails;
    }

}
