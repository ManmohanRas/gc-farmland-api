namespace PresTrust.FarmLand.Infrastructure.SqlServerDb;

public class FarmEsmtAttachmentARepository : IFarmEsmtAttachmentARepository
{
    #region " Members ... "

    private readonly PresTrustSqlDbContext context;
    protected readonly SystemParameterConfiguration systemParamConfig;

    #endregion

    #region " ctor ... "

    /// <summary>
    /// </summary>
    /// <param name="context"></param>
    /// <param name="systemParamConfigOptions"></param>
    public FarmEsmtAttachmentARepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion

    /// <summary>
    /// get Attachment A details
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>

    public async Task<IEnumerable<FarmEsmtAttachmentAEntity>> GetEsmtAttachmentAAsync(int applicationId)
    {
        IEnumerable<FarmEsmtAttachmentAEntity> results = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarmEsmtAttachmentASqlQuery();
        results = await conn.QueryAsync<FarmEsmtAttachmentAEntity>(sqlCommand.ToString(),
                            commandType: CommandType.Text,
                            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new
                            {
                                @p_ApplicationId = applicationId,
                            });

        return results;

    }
    /// <summary>
    /// Save AttachmentA details
    /// </summary>
    /// <param name="AttachmentADetails"></param>
    /// <returns></returns>

    public async Task<FarmEsmtAttachmentAEntity> SaveEsmtAttachmentADetailsAsync(FarmEsmtAttachmentAEntity AttachmentADetails)
    {
        if (AttachmentADetails.Id > 0)
            return await UpdateAsync(AttachmentADetails);
        else
            return await SaveAsync(AttachmentADetails);
    }

     private async Task<FarmEsmtAttachmentAEntity> SaveAsync(FarmEsmtAttachmentAEntity AttachmentADetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new CreateFarmEsmtAttachmentASqlCommand();
        var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {

                             @p_Id                                      =   AttachmentADetails.Id
                            ,@p_ApplicationId                           =   AttachmentADetails.ApplicationId
                            ,@p_IsOfferPriceIndicated                   =   AttachmentADetails.IsOfferPriceIndicated
                            ,@p_OfferPriceOpinion                       =   AttachmentADetails.OfferPriceOpinion
                            ,@p_AveragePerAcre                          =   AttachmentADetails.AveragePerAcre
                            ,@p_OfferPriceComments                      =   AttachmentADetails.OfferPriceComments
                            ,@p_LastUpdatedBy                           =   AttachmentADetails.LastUpdatedBy  
			                ,@p_LastUpdatedOn                           =   DateTime.Now


            });

            AttachmentADetails.Id = id;

        return AttachmentADetails;
    }

    private async Task<FarmEsmtAttachmentAEntity> UpdateAsync(FarmEsmtAttachmentAEntity AttachmentADetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateFarmEsmtAttachmentASqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id                      =   AttachmentADetails.Id
               ,@p_ApplicationId           =   AttachmentADetails.ApplicationId
               ,@p_IsOfferPriceIndicated   =   AttachmentADetails.IsOfferPriceIndicated
               ,@p_OfferPriceOpinion       =   AttachmentADetails.OfferPriceOpinion
               ,@p_AveragePerAcre          =   AttachmentADetails.AveragePerAcre
               ,@p_OfferPriceComments      =   AttachmentADetails.OfferPriceComments
               ,@p_LastUpdatedBy           =   AttachmentADetails.LastUpdatedBy  
               ,@p_LastUpdatedOn           =   DateTime.Now
            });

        return AttachmentADetails;
    }

    public async Task DeleteEsmtAttachmentADetailsAsync(FarmEsmtAttachmentAEntity AttachmentADetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new DeleteFarmEsmtAttachmentASqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = AttachmentADetails.Id,
                @p_ApplicationId = AttachmentADetails.ApplicationId,
            });

    }
}
