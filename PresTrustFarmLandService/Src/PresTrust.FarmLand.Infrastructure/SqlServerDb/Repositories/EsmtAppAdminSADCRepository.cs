
using System;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;


public class EsmtAppAdminSADCRepository : IEsmtAppAdminSADCRepository
{
    private readonly PresTrustSqlDbContext context;
    protected readonly SystemParameterConfiguration systemParamConfig;

    public EsmtAppAdminSADCRepository 
        (
           PresTrustSqlDbContext context,
           IOptions<SystemParameterConfiguration> systemParamConfigOptions
        )
    {
        this.context = context;
        this.systemParamConfig = systemParamConfigOptions.Value;
    }

    public async Task<EsmtAppAdminSADCEntity> GetEsmtAppAdminSADCDetailsAsync(int applicationId)
    {
        EsmtAppAdminSADCEntity? result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetEsmtAppAdminSADCSqlQuery();
        var results = await conn.QueryAsync<EsmtAppAdminSADCEntity>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new { @p_ApplicationId = applicationId });

        result = results.FirstOrDefault();

        return result ?? new();
    }

    public async Task<EsmtAppAdminSADCEntity> SaveSADCdetailsAsync(EsmtAppAdminSADCEntity SADCdetails)
    {
        if (SADCdetails.Id > 0)
            return await UpdateAsync(SADCdetails);
        else
            return await CreateAsync(SADCdetails);
    }

    private async Task<EsmtAppAdminSADCEntity> UpdateAsync(EsmtAppAdminSADCEntity SADCdetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateEsmtAppAdminSADCSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = SADCdetails.Id,
                @p_ApplicationId = SADCdetails.ApplicationId,
                @p_ProgramName = SADCdetails.ProgramName,
                @p_SADCFundingRoundYear = SADCdetails.SADCFundingRoundYear,
                @p_SADCQualityScore = SADCdetails.SADCQualityScore,
                @p_SADCPrelimRank = SADCdetails.SADCPrelimRank,
                @p_SADCFinalRank = SADCdetails.SADCFinalRank,
                @p_SADCFinalScore = SADCdetails.SADCFinalScore,
                @p_LastUpdatedBy = SADCdetails.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now,
            });
        return SADCdetails;

    }

    private async Task<EsmtAppAdminSADCEntity> CreateAsync(EsmtAppAdminSADCEntity SADCdetails)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateEsmtAppAdminSADCSqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = SADCdetails.Id,
                @p_ApplicationId = SADCdetails.ApplicationId,
                @p_ProgramName = SADCdetails.ProgramName,
                @p_SADCFundingRoundYear = SADCdetails.SADCFundingRoundYear,
                @p_SADCQualityScore = SADCdetails.SADCQualityScore,
                @p_SADCPrelimRank = SADCdetails.SADCPrelimRank,
                @p_SADCFinalRank = SADCdetails.SADCFinalRank,
                @p_SADCFinalScore = SADCdetails.SADCFinalScore,
                @p_LastUpdatedBy = SADCdetails.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now,
            });

        SADCdetails.Id = id;

        return SADCdetails;
    }
}
