namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class FarmEsmtAppAdminDetailsRepository : IFarmEsmtAppAdminDetailsRepository
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
    public FarmEsmtAppAdminDetailsRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion



    /// <summary>
    /// </summary>
    ///  Procedure to fetch Signatory details by Id.
    /// <param name="applicationId"> Id.</param>
    /// <returns> Returns FarmEsmtAppAdminDetailsEntity.</returns>
    public async Task<FarmEsmtAppAdminDetailsEntity> GetAdminDetailsAsync(int applicationId)
    {
        FarmEsmtAppAdminDetailsEntity result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarmEsmtAppAdminDetailsSqlQuery();
        var results = await conn.QueryAsync<FarmEsmtAppAdminDetailsEntity>(sqlCommand.ToString(),
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
    /// <param name="farmEsmtAppAdminDetails"></param>
    /// <returns></returns>
    public async Task<FarmEsmtAppAdminDetailsEntity> SaveAsync(FarmEsmtAppAdminDetailsEntity farmEsmtAppAdminDetails)
    {
        if (farmEsmtAppAdminDetails.Id > 0)
            return await UpdateAsync(farmEsmtAppAdminDetails);
        else
            return await CreateAsync(farmEsmtAppAdminDetails);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="farmEsmtAppAdminDetails"></param>
    /// <returns></returns>
    private async Task<FarmEsmtAppAdminDetailsEntity> CreateAsync(FarmEsmtAppAdminDetailsEntity farmEsmtAppAdminDetails)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateFarmEsmtAppAdminDetailsSqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId = farmEsmtAppAdminDetails.ApplicationId,
                @p_FarmerName = farmEsmtAppAdminDetails.FarmerName,
                @p_FarmerPhone = farmEsmtAppAdminDetails.FarmerPhone,
                @p_FarmerContactInfo = farmEsmtAppAdminDetails.FarmerContactInfo,
                @p_FarmFeatures = farmEsmtAppAdminDetails.FarmFeatures,
                @p_AgreestoHaveSign = farmEsmtAppAdminDetails.AgreestoHaveSign,
                @p_ConsPlanDate = farmEsmtAppAdminDetails.ConsPlanDate,
                @p_ConsPlanComment = farmEsmtAppAdminDetails.ConsPlanComment,
                @p_DroppedProjectWhy = farmEsmtAppAdminDetails.DroppedProjectWhy,
                @p_ImperviousPercentage = farmEsmtAppAdminDetails.ImperviousPercentage,
                @p_ImperviousSurfaceAcreage = farmEsmtAppAdminDetails.ImperviousSurfaceAcreage,
                @p_InterestedinSADCSign = farmEsmtAppAdminDetails.InterestedinSADCSign,
                @p_IsConservationPlan = farmEsmtAppAdminDetails.IsConservationPlan,
                @p_PossibleClosingDate = farmEsmtAppAdminDetails.PossibleClosingDate,
                @p_PreservedOrder = farmEsmtAppAdminDetails.PreservedOrder,
                @p_SADCSignLocation = farmEsmtAppAdminDetails.SADCSignLocation,
                @p_StaffComments = farmEsmtAppAdminDetails.StaffComments,
                @p_ZoningJan12004 = farmEsmtAppAdminDetails.ZoningJan12004,
                @p_RFPIsAppraisal = farmEsmtAppAdminDetails.RFPIsAppraisal,
                @p_RFPIsSurvey = farmEsmtAppAdminDetails.RFPIsSurvey,
                @p_RFPIsWetlands = farmEsmtAppAdminDetails.RFPIsWetlands,
                @p_CADBAppYear = farmEsmtAppAdminDetails.CADBAppYear,
                @p_ProjectYear = farmEsmtAppAdminDetails.ProjectYear,
                @p_OriginalDeed = farmEsmtAppAdminDetails.OriginalDeed,
                @p_OriginalPage = farmEsmtAppAdminDetails.OriginalPage,
                @p_SmallOrLargeSign = farmEsmtAppAdminDetails.SmallOrLargeSign,
                @p_AdYear = farmEsmtAppAdminDetails.AdYear,
                @p_LastUpdatedBy = farmEsmtAppAdminDetails.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        farmEsmtAppAdminDetails.Id = id;

        return farmEsmtAppAdminDetails;
    }
    /// <summary>
    ///
    /// </summary>
    /// <param name="farmEsmtAppAdminDetails"></param>
    /// <returns></returns>
    private async Task<FarmEsmtAppAdminDetailsEntity> UpdateAsync(FarmEsmtAppAdminDetailsEntity farmEsmtAppAdminDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateFarmEsmtAppAdminDetailsSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = farmEsmtAppAdminDetails.Id,
                @p_ApplicationId = farmEsmtAppAdminDetails.ApplicationId,
                @p_FarmerName = farmEsmtAppAdminDetails.FarmerName,
                @p_FarmerPhone = farmEsmtAppAdminDetails.FarmerPhone,
                @p_FarmerContactInfo = farmEsmtAppAdminDetails.FarmerContactInfo,
                @p_FarmFeatures = farmEsmtAppAdminDetails.FarmFeatures,
                @p_AgreestoHaveSign = farmEsmtAppAdminDetails.AgreestoHaveSign,
                @p_ConsPlanDate = farmEsmtAppAdminDetails.ConsPlanDate,
                @p_ConsPlanComment = farmEsmtAppAdminDetails.ConsPlanComment,
                @p_DroppedProjectWhy = farmEsmtAppAdminDetails.DroppedProjectWhy,
                @p_ImperviousPercentage = farmEsmtAppAdminDetails.ImperviousPercentage,
                @p_ImperviousSurfaceAcreage = farmEsmtAppAdminDetails.ImperviousSurfaceAcreage,
                @p_InterestedinSADCSign = farmEsmtAppAdminDetails.InterestedinSADCSign,
                @p_IsConservationPlan = farmEsmtAppAdminDetails.IsConservationPlan,
                @p_PossibleClosingDate = farmEsmtAppAdminDetails.PossibleClosingDate,
                @p_PreservedOrder = farmEsmtAppAdminDetails.PreservedOrder,
                @p_SADCSignLocation = farmEsmtAppAdminDetails.SADCSignLocation,
                @p_StaffComments = farmEsmtAppAdminDetails.StaffComments,
                @p_ZoningJan12004 = farmEsmtAppAdminDetails.ZoningJan12004,
                @p_RFPIsAppraisal = farmEsmtAppAdminDetails.RFPIsAppraisal,
                @p_RFPIsSurvey = farmEsmtAppAdminDetails.RFPIsSurvey,
                @p_RFPIsWetlands = farmEsmtAppAdminDetails.RFPIsWetlands,
                @p_CADBAppYear = farmEsmtAppAdminDetails.CADBAppYear,
                @p_ProjectYear = farmEsmtAppAdminDetails.ProjectYear,
                @p_OriginalDeed = farmEsmtAppAdminDetails.OriginalDeed,
                @p_OriginalPage = farmEsmtAppAdminDetails.OriginalPage,
                @p_SmallOrLargeSign = farmEsmtAppAdminDetails.SmallOrLargeSign,
                @p_AdYear = farmEsmtAppAdminDetails.AdYear,
                @p_LastUpdatedBy = farmEsmtAppAdminDetails.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            }); 
        return farmEsmtAppAdminDetails;
    }

}
