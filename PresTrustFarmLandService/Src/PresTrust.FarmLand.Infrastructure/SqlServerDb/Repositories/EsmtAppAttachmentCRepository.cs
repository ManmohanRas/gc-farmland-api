namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class EsmtAppAttachmentCRepository : IEsmtAppAttachmentCRepository
{
    #region " Members ... "
    private readonly PresTrustSqlDbContext context;
    private readonly SystemParameterConfiguration systemParamConfig;
    #endregion




    public EsmtAppAttachmentCRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfig)
    {
        this.context = context;
        this.systemParamConfig = systemParamConfig.Value;
    }
   

    public async Task<IEnumerable<EsmtAppAttachmentCEntity>> GetEsmtAppAttachmentCAsync(int ApplicationId)
    {
        IEnumerable <EsmtAppAttachmentCEntity> results = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetESmtAppAttachmentCSqlCommand();
         results = await conn.QueryAsync<EsmtAppAttachmentCEntity>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new { @p_ApplicationId = ApplicationId });


        return results;
    }

  
    public async Task<EsmtAppAttachmentCEntity> SaveEsmtAppAttachmentCAsync(EsmtAppAttachmentCEntity entity)
    {
        if (entity.Id > 0)       
            return await UpdateAsyc(entity);      
        else     
            return await SaveAsync(entity);
        

    }


    public async Task<EsmtAppAttachmentCEntity> SaveAsync(EsmtAppAttachmentCEntity entity)
    {

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateEsmtAppAttachmentCSqlCommand();
        var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
                         commandType: CommandType.Text,
                         commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                         param: new
                         {
                             @p_Id = entity.Id,
                             @p_ApplicationId = entity.ApplicationId,
                             @p_IsExceptionAreaPreserved = entity.IsExceptionAreaPreserved,
                             @p_IsNonAgriPremisesPreserved = entity.IsNonAgriPremisesPreserved,
                             @p_IsLeaseWithAnotherParty = entity.IsLeaseWithAnotherParty,
                             @p_DescNonAgriUses = entity.DescNonAgriUses,
                             @p_NonAgriAreaUtilization = entity.NonAgriAreaUtilization,
                             @p_NonAgriLease = entity.NonAgriLease,
                             @p_NonAgriUseAccessParcel = entity.NonAgriUseAccessParcel,
                             @p_LastUpdatedBy = entity.LastUpdatedBy,
                             @p_LastUpdatedOn = DateTime.Now,

                         }
               );
        entity.Id = id;

        return entity;
    }

    public async Task<EsmtAppAttachmentCEntity> UpdateAsyc(EsmtAppAttachmentCEntity entity)
    {

        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateEsmtAppAttachmentCSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
                         commandType: CommandType.Text,
                         commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                         param: new
                         {
                             @p_Id = entity.Id,
                             @p_ApplicationId = entity.ApplicationId,
                             @p_IsExceptionAreaPreserved = entity.IsExceptionAreaPreserved,
                             @p_IsNonAgriPremisesPreserved = entity.IsNonAgriPremisesPreserved,
                             @p_IsLeaseWithAnotherParty = entity.IsLeaseWithAnotherParty,
                             @p_DescNonAgriUses = entity.DescNonAgriUses,
                             @p_NonAgriAreaUtilization = entity.NonAgriAreaUtilization,
                             @p_NonAgriLease = entity.NonAgriLease,
                             @p_NonAgriUseAccessParcel = entity.NonAgriUseAccessParcel,
                             @p_LastUpdatedBy = entity.LastUpdatedBy,
                             @p_LastUpdatedOn = DateTime.Now,

                         } );

        return entity;
    }

    public async Task DeleteEsmtAppAttachmentCAsync(EsmtAppAttachmentCEntity entity)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new DeleteEsmtAppAttachmentCSqlCommand();

        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = entity.Id,
                @p_ApplicationId = entity.ApplicationId,
            });
    }

}


