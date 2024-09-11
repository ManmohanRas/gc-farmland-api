
namespace PresTrust.FarmLand.Infrastructure.SqlServerDb;


public class FarmEsmtAttachmentBRepository : IFarmEsmtAttachmentBRepository
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
    public FarmEsmtAttachmentBRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion
  
    /// <summary>
    /// get AttachmentB details
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>

    public async Task<IEnumerable<FarmEsmtAttachmentBEntity>> GetEsmtAttachmentBAsync(int applicationId)
    {
        IEnumerable<FarmEsmtAttachmentBEntity> results = default;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetFarmEsmtAttachmentBSqlQuery();
        results = await conn.QueryAsync<FarmEsmtAttachmentBEntity>(sqlCommand.ToString(),
                            commandType: CommandType.Text,
                            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new
                            {
                                @p_ApplicationId = applicationId,
                            });

        return results;

    }

    /// <summary>
    /// Save AttachmentB details
    /// </summary>
    /// <param name="AttachmentBDetails"></param>
    /// <returns></returns>
    public async Task<FarmEsmtAttachmentBEntity> SaveEsmtAttachmentBDetailsAsync(FarmEsmtAttachmentBEntity AttachmentBDetails)
    {
        if (AttachmentBDetails.Id > 0)
            return await UpdateAsync(AttachmentBDetails);
        else
            return await SaveAsync(AttachmentBDetails);
    }

    /// <summary>
    /// save new record in AttachmentB details
    /// </summary>
    /// <param name="AttachmentBDetails"></param>
    /// <returns></returns>

    private async Task<FarmEsmtAttachmentBEntity> SaveAsync(FarmEsmtAttachmentBEntity AttachmentBDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new CreateFarmEsmtAttachmentBSqlCommand();
        var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {

                             @p_Id                                      =   AttachmentBDetails.Id
                            ,@p_ApplicationId                           =   AttachmentBDetails.ApplicationId
                            ,@p_LocationOfException                     =   AttachmentBDetails.LocationOfException
                            ,@p_Block                                   =   AttachmentBDetails.Block
                            ,@p_Lot                                     =   AttachmentBDetails.Lot
                            ,@p_ExceptionSize                           =   AttachmentBDetails.ExceptionSize
                            ,@p_ReasonForException                      =   AttachmentBDetails.ReasonForException
                            ,@p_IsExceptionSoldFromPreserved            =   AttachmentBDetails.IsExceptionSoldFromPreserved
                            ,@p_IsRestrictExceptionToResiUnit           =   AttachmentBDetails.IsRestrictExceptionToResiUnit
                            ,@p_IsExceptionInNonAgriUse                 =   AttachmentBDetails.IsExceptionInNonAgriUse
                            ,@p_IsResiExceptionArea                     =   AttachmentBDetails.IsResiExceptionArea
                            ,@p_IsNonResiExceptionArea                  =   AttachmentBDetails.IsNonResiExceptionArea
                            ,@p_NonAgriExceptionArea                    =   AttachmentBDetails.NonAgriExceptionArea
                            ,@p_SingleFamilyResidence                   =   AttachmentBDetails.SingleFamilyResidence
                            ,@p_ResiHomePermFoundation                  =   AttachmentBDetails.ResiHomePermFoundation
                            ,@p_ResiDuplex                              =   AttachmentBDetails.ResiDuplex
                            ,@p_ResiHomeWithoutFoundation               =   AttachmentBDetails.ResiHomeWithoutFoundation
                            ,@p_ResidenceGarage                         =   AttachmentBDetails.ResidenceGarage
                            ,@p_ResiDormitory                           =   AttachmentBDetails.ResiDormitory
                            ,@p_ResiAttachedTo                          =   AttachmentBDetails.ResiAttachedTo
                            ,@p_ResiGarriageHouse                       =   AttachmentBDetails.ResiGarriageHouse
                            ,@p_NonResidentialBarn                      =   AttachmentBDetails.NonResidentialBarn
                            ,@p_NonResidentialShed                      =   AttachmentBDetails.NonResidentialShed 
                            ,@p_NonResidentialGarage                    =   AttachmentBDetails.NonResidentialGarage 
                            ,@p_NonResidentialSilo                      =   AttachmentBDetails.NonResidentialSilo 
                            ,@p_NonResidentialStable                    =   AttachmentBDetails.NonResidentialStable
                            ,@p_LastUpdatedBy                           =   AttachmentBDetails.LastUpdatedBy  
			                ,@p_LastUpdatedOn                           =   DateTime.Now


            });

            AttachmentBDetails.Id = id;

        return AttachmentBDetails;
    }

    private async Task<FarmEsmtAttachmentBEntity> UpdateAsync(FarmEsmtAttachmentBEntity AttachmentBDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateFarmEsmtAttachmentBSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id                                           =   AttachmentBDetails.Id,
                @p_ApplicationId                                =   AttachmentBDetails.ApplicationId
               ,@p_LocationOfException                          =   AttachmentBDetails.LocationOfException
               ,@p_Block                                        =   AttachmentBDetails.Block
               ,@p_Lot                                          =   AttachmentBDetails.Lot
               ,@p_ExceptionSize                                =   AttachmentBDetails.ExceptionSize
               ,@p_ReasonForException                           =   AttachmentBDetails.ReasonForException
               ,@p_IsExceptionSoldFromPreserved                 =   AttachmentBDetails.IsExceptionSoldFromPreserved
               ,@p_IsRestrictExceptionToResiUnit                =   AttachmentBDetails.IsRestrictExceptionToResiUnit
               ,@p_IsExceptionInNonAgriUse                      =   AttachmentBDetails.IsExceptionInNonAgriUse
               ,@p_IsResiExceptionArea                          =   AttachmentBDetails.IsResiExceptionArea
               ,@p_IsNonResiExceptionArea                       =   AttachmentBDetails.IsNonResiExceptionArea
               ,@p_NonAgriExceptionArea                         =   AttachmentBDetails.NonAgriExceptionArea
               ,@p_SingleFamilyResidence                        =   AttachmentBDetails.SingleFamilyResidence
               ,@p_ResiHomePermFoundation                       =   AttachmentBDetails.ResiHomePermFoundation
               ,@p_ResiDuplex                                   =   AttachmentBDetails.ResiDuplex
               ,@p_ResiHomeWithoutFoundation                    =   AttachmentBDetails.ResiHomeWithoutFoundation
               ,@p_ResidenceGarage                              =   AttachmentBDetails.ResidenceGarage
               ,@p_ResiDormitory                                =   AttachmentBDetails.ResiDormitory
               ,@p_ResiAttachedTo                               =   AttachmentBDetails.ResiAttachedTo
               ,@p_ResiGarriageHouse                            =   AttachmentBDetails.ResiGarriageHouse
               ,@p_NonResidentialBarn                           =   AttachmentBDetails.NonResidentialBarn
               ,@p_NonResidentialShed                           =   AttachmentBDetails.NonResidentialShed 
               ,@p_NonResidentialGarage                         =   AttachmentBDetails.NonResidentialGarage 
               ,@p_NonResidentialSilo                           =   AttachmentBDetails.NonResidentialSilo 
               ,@p_NonResidentialStable                         =   AttachmentBDetails.NonResidentialStable
               ,@p_LastUpdatedBy                                =   AttachmentBDetails.LastUpdatedBy
               ,@p_LastUpdatedOn                                =   DateTime.Now
            });

        return AttachmentBDetails;
    }



    public async Task DeleteEsmtAttachmentBDetailsAsync(FarmEsmtAttachmentBEntity AttachmentBDetails)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new DeleteFarmEsmtAttachmentBSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = AttachmentBDetails.Id,
                @p_ApplicationId = AttachmentBDetails.ApplicationId,
            });

    }
}
