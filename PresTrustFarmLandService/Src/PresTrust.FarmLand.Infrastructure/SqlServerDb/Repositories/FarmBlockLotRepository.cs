namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;
public class FarmBlockLotRepository: IFarmBlockLotRepository
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
    public FarmBlockLotRepository(
        PresTrustSqlDbContext context,
        IOptions<SystemParameterConfiguration> systemParamConfigOptions
        )
    {
        this.context = context;
        this.systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion

    public async Task<IEnumerable<FarmBlockLotEntity>> GetFarmBlockLotAsync()
    {
        IEnumerable<FarmBlockLotEntity> results = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarmBlockLotSqlQuery();
        results = await conn.QueryAsync<FarmBlockLotEntity>(sqlCommand.ToString(),
                    commandType: CommandType.Text,
                    commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                    param: new {});

        return results;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="parcel"></param>
    /// <returns></returns>
    public async Task<FarmBlockLotEntity> SaveAsync(FarmBlockLotEntity parcel)
    {
        if (parcel.Id > 0)
            return await UpdateMunicipalityBlockLotParcelAsync(parcel);
        else
            return await CreateMunicipalityBlockLotParcelAsync(parcel);
    }
    private async Task<FarmBlockLotEntity> CreateMunicipalityBlockLotParcelAsync(FarmBlockLotEntity parcel)
    {

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateFarmBlockLotSqlCommand();
        var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {

                @p_MunicipalityId = parcel.MunicipalityId,
                @p_FarmListID = parcel.FarmListID,
                @p_Block = parcel.Block,
                @p_Lot = parcel.Lot,
                @p_QualificationCode = parcel.QualificationCode,
                @p_Partial = parcel.Partial,
                @p_Section = parcel.Section,
                @p_Acres = parcel.Acres,
                @p_AcresToBeAcquired = parcel.AcresToBeAcquired,
                @p_ExceptionArea = parcel.ExceptionArea,
                @p_Notes = parcel.Notes,
                @p_PamsPin = parcel.PamsPin,
                @p_IsValidFeatureId = parcel.IsValidFeatureId,
                @p_InterestType = parcel.InterestType,
                @p_EasementId = parcel.EasementId,
                @p_ChangeType = parcel.ChangeType,
                @p_ChangeDate = parcel.ChangeDate,
                @p_ReasonForChange = parcel.ReasonForChange,
                @p_IsActive = parcel.IsActive,
                @p_LastUpdatedBy = parcel.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });
        parcel.Id = id;
        return parcel;
    }

    private async Task<FarmBlockLotEntity> UpdateMunicipalityBlockLotParcelAsync(FarmBlockLotEntity parcel)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateFarmBlockLotSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = parcel.Id,
                @p_MunicipalityId = parcel.MunicipalityId,
                @p_FarmListID = parcel.FarmListID,
                @p_Block = parcel.Block,
                @p_Lot = parcel.Lot,
                @p_QualificationCode = parcel.QualificationCode,
                @p_Partial = parcel.Partial,
                @p_Section = parcel.Section,
                @p_Acres = parcel.Acres,
                @p_AcresToBeAcquired = parcel.AcresToBeAcquired,
                @p_ExceptionArea = parcel.ExceptionArea,
                @p_Notes = parcel.Notes,
                @p_PamsPin = parcel.PamsPin,
                @p_IsValidFeatureId = parcel.IsValidFeatureId,
                @p_InterestType = parcel.InterestType,
                @p_EasementId = parcel.EasementId,
                @p_ChangeType = parcel.ChangeType,
                @p_ChangeDate = parcel.ChangeDate,
                @p_ReasonForChange = parcel.ReasonForChange,
                @p_IsActive = parcel.IsActive,
                @p_LastUpdatedBy = parcel.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return parcel;
    }

}
