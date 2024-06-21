namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;
public class MunicipalTrustFundPermittedUsesRepository : IMunicipalTrustFundPermittedUsesRepository
{
    #region " Members ... "

    private readonly PresTrustSqlDbContext context;
    protected readonly SystemParameterConfiguration systemParamConfig;

    #endregion

    #region " ctor ... "
    public MunicipalTrustFundPermittedUsesRepository(
       PresTrustSqlDbContext context,
       IOptions<SystemParameterConfiguration> systemParamConfigOptions
       )
    {
        this.context = context;
        this.systemParamConfig = systemParamConfigOptions.Value;
    }
    #endregion

    public async Task<FarmMunicipalTrustFundPermittedUsesEntity> GetMunicipalTrustFundPermittedUses(int agencyId)
    {
        FarmMunicipalTrustFundPermittedUsesEntity result = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new GetMunicipalTrustFundPermittedUsesDetailsSqlCommand();
        var results = await conn.QueryAsync<FarmMunicipalTrustFundPermittedUsesEntity>(sqlCommand.ToString(),
                            commandType: CommandType.Text,
                            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new { @p_AgencyId = agencyId });
        result = results.FirstOrDefault();

        return result;
    }

    /// <summary>
    /// Save farmMunicipalTrustFundPermittedUses.
    /// </summary>
    /// <param name="farmMunicipalTrustFundPermittedUses"></param>
    /// <returns></returns>
    public async Task<int> SaveAsync(FarmMunicipalTrustFundPermittedUsesEntity farmMunicipalTrustFundPermittedUses)
    {
        if (farmMunicipalTrustFundPermittedUses == null) throw new ArgumentNullException();

        if (farmMunicipalTrustFundPermittedUses.Id > 0)
            return await UpdateAsync(farmMunicipalTrustFundPermittedUses);
        else
            return await CreateAsync(farmMunicipalTrustFundPermittedUses);
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="farmMunicipalTrustFundPermittedUses"></param>
    /// <returns></returns>
    private async Task<int> CreateAsync(FarmMunicipalTrustFundPermittedUsesEntity farmMunicipalTrustFundPermittedUses)
    {
        int result = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateMunicipalTrustFundPermittedUsesSqlCommand();
        result = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_AgencyId = farmMunicipalTrustFundPermittedUses.AgencyId,
                @p_YearOfInception = farmMunicipalTrustFundPermittedUses.YearOfInception,
                @p_AcquisitionOfLands = farmMunicipalTrustFundPermittedUses.AcquisitionOfLands,
                @p_AcquisitionOfFarmLands = farmMunicipalTrustFundPermittedUses.AcquisitionOfFarmLands,
                @p_DevelopmentOfLands = farmMunicipalTrustFundPermittedUses.DevelopmentOfLands,
                @p_MaintenanceOfLands = farmMunicipalTrustFundPermittedUses.MaintenanceOfLands,
                @p_SalariesAndBenefits = farmMunicipalTrustFundPermittedUses.SalariesAndBenefits,
                @p_BondDownPayments = farmMunicipalTrustFundPermittedUses.BondDownPayments,
                @p_HistoricPreservation = farmMunicipalTrustFundPermittedUses.HistoricPreservation,
                @p_OpenspaceMasterPlan = farmMunicipalTrustFundPermittedUses.OpenspaceMasterPlan,
                @p_OpenspaceMasterPlanDate = farmMunicipalTrustFundPermittedUses.OpenspaceMasterPlanDate,
                @p_GreenAcresGrant = farmMunicipalTrustFundPermittedUses.GreenAcresGrant,
                @p_Other = farmMunicipalTrustFundPermittedUses.Other,
                @p_TrustFundComments = farmMunicipalTrustFundPermittedUses.TrustFundComments
            });

        return result;
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="farmMunicipalTrustFundPermittedUses"></param>
    /// <returns></returns>
    private async Task<int> UpdateAsync(FarmMunicipalTrustFundPermittedUsesEntity farmMunicipalTrustFundPermittedUses)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateMunicipalTrustFundPermittedUsesSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = farmMunicipalTrustFundPermittedUses.Id,
                @p_AgencyId = farmMunicipalTrustFundPermittedUses.AgencyId,
                @p_YearOfInception = farmMunicipalTrustFundPermittedUses.YearOfInception,
                @p_AcquisitionOfLands = farmMunicipalTrustFundPermittedUses.AcquisitionOfLands,
                @p_AcquisitionOfFarmLands = farmMunicipalTrustFundPermittedUses.AcquisitionOfFarmLands,
                @p_DevelopmentOfLands = farmMunicipalTrustFundPermittedUses.DevelopmentOfLands,
                @p_MaintenanceOfLands = farmMunicipalTrustFundPermittedUses.MaintenanceOfLands,
                @p_SalariesAndBenefits = farmMunicipalTrustFundPermittedUses.SalariesAndBenefits,
                @p_BondDownPayments = farmMunicipalTrustFundPermittedUses.BondDownPayments,
                @p_HistoricPreservation = farmMunicipalTrustFundPermittedUses.HistoricPreservation,
                @p_OpenspaceMasterPlan = farmMunicipalTrustFundPermittedUses.OpenspaceMasterPlan,
                @p_OpenspaceMasterPlanDate = farmMunicipalTrustFundPermittedUses.OpenspaceMasterPlanDate,
                @p_GreenAcresGrant = farmMunicipalTrustFundPermittedUses.GreenAcresGrant,
                @p_Other = farmMunicipalTrustFundPermittedUses.Other,
                @p_TrustFundComments = farmMunicipalTrustFundPermittedUses.TrustFundComments
            });

        return farmMunicipalTrustFundPermittedUses.Id;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="yearOfInception"></param>
    /// <param name="agencyId"></param>
    /// <returns></returns>
    public async Task UpdateYearOfInception(string yearOfInception, int agencyId)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateYearOfInceptionSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_YearOfInception = yearOfInception,
                @p_AgencyId = agencyId
            });

    }

}

