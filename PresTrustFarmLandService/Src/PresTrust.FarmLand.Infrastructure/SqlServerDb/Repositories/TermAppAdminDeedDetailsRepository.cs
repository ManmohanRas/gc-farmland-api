namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class TermAppAdminDeedDetailsRepository : ITermAppAdminDeedDetailsRepository
{
    private readonly PresTrustSqlDbContext context;
    protected readonly SystemParameterConfiguration systemParamConfig;

    public TermAppAdminDeedDetailsRepository(
        PresTrustSqlDbContext context,
     IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        this.systemParamConfig = systemParamConfigOptions.Value;
    }

    public async Task<List<TermAppAdminDeedDetailsEntity>> GetTermAppAdminDeedDetails(int applicationId)
    {
        List<TermAppAdminDeedDetailsEntity> results;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetTermAppAdminDeedDetailsSqlCommand();
        results = (await conn.QueryAsync<TermAppAdminDeedDetailsEntity>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new { @p_ApplicationId = applicationId })).ToList();
        return results ?? new();
    }

    private async Task<TermAppAdminDeedDetailsEntity> CreateAsync(TermAppAdminDeedDetailsEntity deedDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new CreateTermAppAdminDeedDetailsSqlCommand();
        var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {

                @p_ApplicationId = deedDetails.ApplicationId,
                @p_ParcelId = deedDetails.ParcelId,
                @p_OriginalBlock = deedDetails.OriginalBlock,
                @p_OriginalLot = deedDetails.OriginalLot,
                @p_MunicipalityId = deedDetails.Municipalityid,
                @p_QualificationCode = deedDetails.Qualificationcode,
                @p_Municipality = deedDetails.Municipality,
                @p_OriginalBook = deedDetails.OriginalBook,
                @p_OriginalPage = deedDetails.OriginalPage,
                @p_NOTBook = deedDetails.NOTBook,
                @p_NOTPage = deedDetails.NOTPage,
                @p_RDBook = deedDetails.RDBook,
                @p_RDPage = deedDetails.RDPage,
                @p_IsChecked = deedDetails.IsChecked,
                @p_LastUpdatedBy = deedDetails.LastUpdatedBy
            });

        deedDetails.Id = id;

        return deedDetails;
    }
    public async Task<TermAppAdminDeedDetailsEntity> SaveAsync(TermAppAdminDeedDetailsEntity deedDetails)
    {
        if (deedDetails.Id > 0)
            return await UpdateAsync(deedDetails);
        else
            return await CreateAsync(deedDetails);
    }

    private async Task<TermAppAdminDeedDetailsEntity> UpdateAsync(TermAppAdminDeedDetailsEntity deedDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateTermAppAdminDeedDetailsSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = deedDetails.Id,
                @p_ApplicationId = deedDetails.ApplicationId,
                @p_parcelId = deedDetails.ParcelId,
                @p_OriginalBlock = deedDetails.OriginalBlock,
                @p_OriginalLot = deedDetails.OriginalLot,
                @p_OriginalBook = deedDetails.OriginalBook,
                @p_MunicipalityId = deedDetails.Municipalityid,
                @p_QualificationCode = deedDetails.Qualificationcode,
                @p_Municipality = deedDetails.Municipality,
                @p_OriginalPage = deedDetails.OriginalPage,
                @p_NOTBook = deedDetails.NOTBook,
                @p_NOTPage = deedDetails.NOTPage,
                @p_RDBook = deedDetails.RDBook,
                @p_RDPage = deedDetails.RDPage,
                @p_IsChecked = deedDetails.IsChecked,
                @p_LastUpdatedBy = deedDetails.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return deedDetails;
    }


    public async Task<bool> CheckDeedLocationParcel(int applicationId, FarmTermAppDeedLocationEntity entity)
    {
        using var conn = context.CreateConnection();

        var sqlCommand = new CreateTermAppDeedLocationSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new
                            {
                                @p_ApplicationId = applicationId,
                                @p_ParcelId = entity.ParcelId,
                                @p_DeedId = entity.DeedId,
                                @p_IsChecked = entity.IsChecked
                            });

        return true;
    }

    public async Task<List<FarmTermAppDeedLocationEntity>> GetTermAppAdminDeedLocationDetails(int applicationId)
    {
        List<FarmTermAppDeedLocationEntity> results;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetTermAppAdminDeedLocationDetails();
        results = (await conn.QueryAsync<FarmTermAppDeedLocationEntity>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new { @p_ApplicationId = applicationId })).ToList();
        return results ?? new();
    }

    public async Task<bool> UpdateTermAppDeedLocation(int applicationId, int parcelId, bool IsChecked)
    {
        using var conn = context.CreateConnection();

        var sqlCommand = new UpdateTermAppDeedLocationSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new
                            {
                                @p_IsChecked = IsChecked,
                                @p_ApplicationId = applicationId,
                                @p_ParcelId = parcelId
                            });

        return true;
    }

}
