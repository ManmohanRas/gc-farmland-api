namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateEsmtOwnerDetailsSqlCommand
{
    private readonly string _sqlCommand =
 @"UPDATE  [Farm].[FarmTermAppOwnerDetails]
                 SET
                        [ApplicationId]         = @p_ApplicationId,
                       [SoleProprietor]        =@p_SoleProprietor,
                       [ProprirtorPartnership] =@p_ProprirtorPartnership,         
                        [MultiProprietor]       =@p_MultiProprietor,                     
                        [ExecutorEstate]        = @p_ExecutorEstate,
                        [CPFeeSimple]           =@p_CPFeeSimple,                   
                        [CPEasement]            =@p_CPEasement,                  
                        [MunicipalityCurrentEO] =@p_MunicipalityCurrentEO,                            
                        [ConservationOrg]       =@p_ConservationOrg,                    
                        [FarmName]              = @p_FarmName,                 
                        [ResidentName]          =@p_ResidentName,         
                       [AttarneyName]          =@p_AttarneyName,
                       [AtMailingAddress]      =@p_AtMailingAddress,         
                        [ATFirmName]            =@p_ATFirmName,                     
                        [ResiPhoneNumber]      = @p_ResiPhoneNumber,
                        [PdStreetAddress]      =@p_PdStreetAddress,                   
                        [OwnedContinuesly]     =@p_OwnedContinuesly,                  
                        [SubjectProperty]      =@p_SubjectProperty,                                
                        [LastUpdatedBy]        = @p_LastUpdatedBy,                                
                        [LastUpdatedOn]       = @p_LastUpdatedOn                
                                                          
                      WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId";



    public UpdateEsmtOwnerDetailsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
