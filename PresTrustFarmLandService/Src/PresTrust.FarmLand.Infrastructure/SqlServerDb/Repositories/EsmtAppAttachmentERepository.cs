
using static Dapper.SqlMapper;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;
public class EsmtAppAttachmentERepository : IEsmtAppAttachmentERepository
{
   PresTrustSqlDbContext context;
   SystemParameterConfiguration configuration;

    public EsmtAppAttachmentERepository(PresTrustSqlDbContext context, IOptions <SystemParameterConfiguration> configuration) 
    {
    
       this.context = context;  
       this.configuration= configuration.Value;
    
    }
    public async Task<IEnumerable<EsmtAppAttachmentEEntity>> GetEsmtAppAttachmentEAsync(int ApplicationId)
    { 
        IEnumerable<EsmtAppAttachmentEEntity> result = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetEsmtAppAttachmentESqlCommand();
       

        result = await conn.QueryAsync<EsmtAppAttachmentEEntity>(sqlCommand.ToString(),
            commandType:CommandType.Text,
            commandTimeout:configuration.SQLCommandTimeoutInSeconds,
            param:new {@p_ApplicationId= ApplicationId } );

        return result;

    }

    public async Task<EsmtAppAttachmentEEntity> SaveEsmtAppAttachmentEAsync(EsmtAppAttachmentEEntity request)
    {
        if(request.Id > 0)
            return await UpdateAsync(request);
        else
            return await SaveAsync(request);

    }


    public async Task<EsmtAppAttachmentEEntity> SaveAsync(EsmtAppAttachmentEEntity request)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new CreateEsmtAppAttachmentESqlCommand();
        var id= await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: configuration.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = request.Id,
                @p_ApplicationId = request.ApplicationId,
                @p_TypeOfDevelopment = request.TypeOfDevelopment,
                @p_PreliminaryApprovalDate = request.PreliminaryApprovalDate,
                @p_FinalApprovalDate = request.FinalApprovalDate,
                @p_ScaleofSubdivision = request.ScaleofSubdivision,
                @P_OtherPertinentInformation = request.OtherPertinentInformation,
                @P_IsOpenEnrollment = request.IsOpenEnrollment,
                @P_IsPropertyOutlined = request.IsPropertyOutlined,
                @P_IsAllExpAreasIdentified = request.IsAllExpAreasIdentified,
                @P_IsAllNonAgriEquiUsesDetailed = request.IsAllNonAgriEquiUsesDetailed,
                @P_IsCopyOfDeed = request.IsCopyOfDeed,
                @P_IsSignOfAllPropOwnersListed = request.IsSignOfAllPropOwnersListed,
                @P_IsFarmLandAssReportCopy = request.IsFarmLandAssReportCopy,
                @p_LastUpdatedBy = request.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now,
            });
        request.Id = id; 
          return request;
    }
    public async Task<EsmtAppAttachmentEEntity> UpdateAsync(EsmtAppAttachmentEEntity request)
    {

        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateEsmtAppAttachmentESqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
             commandType: CommandType.Text,
             commandTimeout: configuration.SQLCommandTimeoutInSeconds,
             param: new
             {
                 @p_Id = request.Id,
                 @p_ApplicationId = request.ApplicationId,
                 @p_TypeOfDevelopment = request.TypeOfDevelopment,
                 @p_PreliminaryApprovalDate = request.PreliminaryApprovalDate,
                 @p_FinalApprovalDate = request.FinalApprovalDate,
                 @p_ScaleofSubdivision = request.ScaleofSubdivision,
                 @P_OtherPertinentInformation = request.OtherPertinentInformation,
                 @P_IsOpenEnrollment = request.IsOpenEnrollment,
                 @P_IsPropertyOutlined = request.IsPropertyOutlined,
                 @P_IsAllExpAreasIdentified = request.IsAllExpAreasIdentified,
                 @P_IsAllNonAgriEquiUsesDetailed = request.IsAllNonAgriEquiUsesDetailed,
                 @P_IsCopyOfDeed = request.IsCopyOfDeed,
                 @P_IsSignOfAllPropOwnersListed = request.IsSignOfAllPropOwnersListed,
                 @P_IsFarmLandAssReportCopy = request.IsFarmLandAssReportCopy,
                 @p_LastUpdatedBy = request.LastUpdatedBy,
                 @p_LastUpdatedOn = DateTime.Now,

             });
        return request;

    }

    public async Task DeleteEsmtAppAttachmentEAsync(EsmtAppAttachmentEEntity request)
    {
        using var con = context.CreateConnection();
        var sqlCommand = new DeleteEsmtAppAttachmentESqlCommand();
        await con.ExecuteAsync(sqlCommand.ToString(),
                  commandType:CommandType.Text,
                  commandTimeout:configuration.SQLCommandTimeoutInSeconds,
                  param: new
                  {
                      @p_Id = request.Id,
                      @p_ApplicationId = request.ApplicationId,
                  });
    }
}
