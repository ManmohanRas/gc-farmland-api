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

    public async Task<FarmBlockLotEntity> GetFarmBlockLotByIdAsync(int id)
    {
        FarmBlockLotEntity result = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarmBlockLotByIdSqlQuery();
        var results = await conn.QueryAsync<FarmBlockLotEntity>(sqlCommand.ToString(),
                    commandType: CommandType.Text,
                    commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                    param: new { @p_Id = id });

        return results.FirstOrDefault();
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
                @p_ExceptionAreaAcres = parcel.ExceptionAreaAcres,
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
                @p_PropertyClassCode = parcel.PropertyClassCode,
                @p_DeedBook = parcel.DeedBook,
                @p_DeedPage = parcel.DeedPage,
                @p_CreatedByProgramUser = parcel.CreatedByProgramUser,
                @p_IsWarning = parcel.IsWarning,
                @p_IsValidPamsPin = parcel.IsValidPamsPin,
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
                @p_ExceptionAreaAcres = parcel.ExceptionAreaAcres,
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
                @p_PropertyClassCode = parcel.PropertyClassCode,
                @p_DeedBook = parcel.DeedBook,
                @p_DeedPage = parcel.DeedPage,
                @p_CreatedByProgramUser = parcel.CreatedByProgramUser,
                @p_IsWarning = parcel.IsWarning,
                @p_IsValidPamsPin  =  parcel.IsValidPamsPin,
                @p_LastUpdatedBy = parcel.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return parcel;
    }

    public async Task<bool> ResolveParcelWarning(int parcelId)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateParcelWarningSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = parcelId,

            });

        return true;

    }

    public async Task<bool> DeleteFarmBlockLotById(int id)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new DeleteFarmBlockLotSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
                    commandType: CommandType.Text,
                    commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                    param: new { @p_Id = id });

        return true;
    }

    public async Task<bool> CheckParcelExists(string pamsPin, int farmListId, int id)
    {
        bool result = false;
        using var conn = context.CreateConnection();
        var sqlCommand = new CheckParcelExistsSqlCommand();
        var count = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_PamsPin = pamsPin,
                @p_FarmListId = farmListId

            });

        if (count > 0 && id == 0)
        {
            result = true;
        }else if(count > 1 && id > 0)
        {
            result = true;
        }else
        {
            result = false;
        }

        return result;

    }

}
