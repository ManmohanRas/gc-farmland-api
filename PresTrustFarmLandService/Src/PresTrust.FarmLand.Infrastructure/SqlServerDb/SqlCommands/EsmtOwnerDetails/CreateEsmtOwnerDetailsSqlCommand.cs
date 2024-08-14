namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateEsmtOwnerDetailsSqlCommand
{
    private readonly string _sqlCommand =
    @"INSERT INTO  [Farm].[FarmEsmtAppOwnerDetails]
              (
                         [ApplicationId]
                       ,[SoleProprietor]
                       ,[ProprirtorPartnership]                      
                        ,[MultiProprietor]                            
                        ,[ExecutorEstate]           
                        ,[CPFeeSimple]                       
                        ,[CPEasement]                     
                        ,[MunicipalityCurrentEO]                                      
                        ,[ConservationOrg]                                     
                        ,[FarmName]                                  
                        ,[ResidentName]
                       ,[AttarneyName]                       
                        ,[AtMailingAddress]                     
                        ,[ATFirmName]                                      
                        ,[ResiPhoneNumber]                                     
                        ,[PdStreetAddress]                                  
                        ,[OwnedContinuesly]
                        ,[SubjectProperty]  
                       ,[LastUpdatedBy]
                       ,[LastUpdatedOn]
              )

			  VALUES
			  (  
                      @p_ApplicationId,
                      @p_SoleProprietor,
                      @p_ProprirtorPartnership,                      
                       @p_MultiProprietor,                        
                       @p_ExecutorEstate,   
                       @p_CPFeeSimple,
                       @p_CPEasement,
                       @p_MunicipalityCurrentEO,
                       @p_ConservationOrg,                            
                       @p_FarmName,                                  
                       @p_ResidentName,   
                      @p_AttarneyName,
                      @p_AtMailingAddress,                      
                       @p_ATFirmName,                        
                       @p_ResiPhoneNumber,   
                       @p_PdStreetAddress,
                       @p_OwnedContinuesly,
                       @p_SubjectProperty, 
                       @p_LastUpdatedBy,
                       GETDATE()
						);

				  SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateEsmtOwnerDetailsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
