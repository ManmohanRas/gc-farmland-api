namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class FarmEsmtExceptionsRepository : IFarmEsmtExceptionsRepository
{
    private readonly PresTrustSqlDbContext context;
    protected readonly SystemParameterConfiguration systemParamConfig;

    public FarmEsmtExceptionsRepository
        (
            PresTrustSqlDbContext context,
           IOptions<SystemParameterConfiguration> systemParamConfigOptions
        )
    {
        this.context = context;
        this.systemParamConfig = systemParamConfigOptions.Value;
    }

    public async Task<FarmEsmtExceptionsEntity> GetEsmtExceptionsDetailsAsync(int applicationId)
    {
        FarmEsmtExceptionsEntity? result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarmEsmtExceptionsSqlQuery();
        var results = await conn.QueryAsync<FarmEsmtExceptionsEntity>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new { @p_ApplicationId = applicationId });

        result = results.FirstOrDefault();

        return result ?? new();
    }


    public async Task<FarmEsmtExceptionsEntity> SaveAsync(FarmEsmtExceptionsEntity exceptions)
    {
        if (exceptions.Id > 0)
            return await UpdateAsync(exceptions);
        else
            return await CreateAsync(exceptions);
    }

    private async Task<FarmEsmtExceptionsEntity> UpdateAsync(FarmEsmtExceptionsEntity exceptionsDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateEsmtExceptionsSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = exceptionsDetails.Id,
                @p_ApplicationId = exceptionsDetails.ApplicationId,
                @p_ExpectedTaxLots = exceptionsDetails.ExpectedTaxLots,
                @p_ExceptionNonSeverable = exceptionsDetails.ExceptionNonSeverable,
                @p_ExceptionTotalNonSeverable = exceptionsDetails.ExceptionTotalNonSeverable,
                @p_ExceptionSeverable = exceptionsDetails.ExceptionSeverable,
                @p_ExceptionTotalSeverable = exceptionsDetails.ExceptionTotalSeverable,
                @p_Acres = exceptionsDetails.Acres,
                @p_LastUpdatedBy = exceptionsDetails.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now,
            });
                return exceptionsDetails;
 
    }

    private async Task<FarmEsmtExceptionsEntity> CreateAsync(FarmEsmtExceptionsEntity exceptionsDetails)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateEsmtExceptionsSqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = exceptionsDetails.Id,
                @p_ApplicationId = exceptionsDetails.ApplicationId,
                @p_ExpectedTaxLots = exceptionsDetails.ExpectedTaxLots,
                @p_ExceptionNonSeverable = exceptionsDetails.ExceptionNonSeverable,
                @p_ExceptionTotalNonSeverable = exceptionsDetails.ExceptionTotalNonSeverable,
                @p_ExceptionSeverable = exceptionsDetails.ExceptionSeverable,
                @p_ExceptionTotalSeverable = exceptionsDetails.ExceptionTotalSeverable,
                @p_Acres = exceptionsDetails.Acres,
                @p_LastUpdatedBy = exceptionsDetails.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now,
            });

        exceptionsDetails.Id = id;

        return exceptionsDetails;
    }
}
