
using System;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;


public class EsmtAppAdminExceptionRDSORepository : IEsmtAppAdminExceptionRDSORepository
{

    private readonly PresTrustSqlDbContext context;
    protected readonly SystemParameterConfiguration systemParamConfig;

    public EsmtAppAdminExceptionRDSORepository
        (
           PresTrustSqlDbContext context,
           IOptions<SystemParameterConfiguration> systemParamConfigOptions
        )
    {
        this.context = context;
        this.systemParamConfig = systemParamConfigOptions.Value;
    }
    public async Task<EsmtAppAdminExceptionRDSOEntity> GetEsmtAppAdminExceptionRDSODetailsAsync(int applicationId)
    {
        EsmtAppAdminExceptionRDSOEntity? result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetEsmtAppAdminExceotionRDSOSqlQuery();
        var results = await conn.QueryAsync<EsmtAppAdminExceptionRDSOEntity>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new { @p_ApplicationId = applicationId });

        result = results.FirstOrDefault();

        return result ?? new();
    }

    public async Task<EsmtAppAdminExceptionRDSOEntity> SaveExceptionRDSOdetailsAsync(EsmtAppAdminExceptionRDSOEntity exceptionRDSOdetails)
    {

        if (exceptionRDSOdetails.Id > 0)
            return await UpdateAsync(exceptionRDSOdetails);
        else
            return await CreateAsync(exceptionRDSOdetails);
    }

    private async Task<EsmtAppAdminExceptionRDSOEntity> UpdateAsync(EsmtAppAdminExceptionRDSOEntity exceptionRDSOdetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateEsmtAppAdminExceptionRDSOSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id                = exceptionRDSOdetails.Id,
                @p_ApplicationId     = exceptionRDSOdetails.ApplicationId    ,
                @p_NumberofExceps    = exceptionRDSOdetails.NumberofExceps   ,
                @p_Excep1Acres       = exceptionRDSOdetails.Excep1Acres      ,
                @p_X1Purpose         = exceptionRDSOdetails.X1Purpose        ,
                @p_X1Severable       = exceptionRDSOdetails.X1Severable      ,
                @p_X1IsSubdividable  = exceptionRDSOdetails.X1IsSubdividable ,
                @p_X1IsRTF           = exceptionRDSOdetails.X1IsRTF          ,
                @p_Excep2Acres       = exceptionRDSOdetails.Excep2Acres      ,
                @p_X2Purpose         = exceptionRDSOdetails.X2Purpose        ,
                @p_X2IsSeverable     = exceptionRDSOdetails.X2IsSeverable    ,
                @p_X2IsSubdividable  = exceptionRDSOdetails.X2IsSubdividable ,
                @p_X2IsRTF           = exceptionRDSOdetails.X2IsRTF          ,
                @p_Excep3Acres       = exceptionRDSOdetails.Excep3Acres      ,
                @p_X3Purpose         = exceptionRDSOdetails.X3Purpose        ,
                @p_X3IsSeverable     = exceptionRDSOdetails.X3IsSeverable    ,
                @p_X3IsSubdividable  = exceptionRDSOdetails.X3IsSubdividable ,
                @p_X3IsRTF           = exceptionRDSOdetails.X3IsRTF          ,
                @p_RDSOsNum          = exceptionRDSOdetails.RDSOsNum		 ,
                @p_RDSOExplan        = exceptionRDSOdetails.RDSOExplan       ,
                @p_IsRDSOExercised   = exceptionRDSOdetails.IsRDSOExercised  ,
                @p_LastUpdatedBy     = exceptionRDSOdetails.LastUpdatedBy    ,
                @p_LastUpdatedOn     = DateTime.Now,
            });
        return exceptionRDSOdetails;
    }


    private async Task<EsmtAppAdminExceptionRDSOEntity> CreateAsync(EsmtAppAdminExceptionRDSOEntity exceptionRDSOdetails)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateEsmtAppAdminExceptionRDSOSqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {

                @p_Id = exceptionRDSOdetails.Id,
                @p_ApplicationId = exceptionRDSOdetails.ApplicationId,
                @p_NumberofExceps = exceptionRDSOdetails.NumberofExceps,
                @p_Excep1Acres = exceptionRDSOdetails.Excep1Acres,
                @p_X1Purpose = exceptionRDSOdetails.X1Purpose,
                @p_X1Severable = exceptionRDSOdetails.X1Severable,
                @p_X1IsSubdividable = exceptionRDSOdetails.X1IsSubdividable,
                @p_X1IsRTF = exceptionRDSOdetails.X1IsRTF,
                @p_Excep2Acres = exceptionRDSOdetails.Excep2Acres,
                @p_X2Purpose = exceptionRDSOdetails.X2Purpose,
                @p_X2IsSeverable = exceptionRDSOdetails.X2IsSeverable,
                @p_X2IsSubdividable = exceptionRDSOdetails.X2IsSubdividable,
                @p_X2IsRTF = exceptionRDSOdetails.X2IsRTF,
                @p_Excep3Acres = exceptionRDSOdetails.Excep3Acres,
                @p_X3Purpose = exceptionRDSOdetails.X3Purpose,
                @p_X3IsSeverable = exceptionRDSOdetails.X3IsSeverable,
                @p_X3IsSubdividable = exceptionRDSOdetails.X3IsSubdividable,
                @p_X3IsRTF = exceptionRDSOdetails.X3IsRTF,
                @p_RDSOsNum = exceptionRDSOdetails.RDSOsNum,
                @p_RDSOExplan = exceptionRDSOdetails.RDSOExplan,
                @p_IsRDSOExercised = exceptionRDSOdetails.IsRDSOExercised,
                @p_LastUpdatedBy = exceptionRDSOdetails.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now,

            });

        exceptionRDSOdetails.Id = id;

        return exceptionRDSOdetails;
    }

}

