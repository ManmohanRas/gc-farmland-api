namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetEsmtOwnerDetailsSql
{
    private readonly string _sqlCommand =
  @"  SELECT            [Id]                                                        
                        ,[ApplicationId]
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
                        [LastUpdatedOn]
            FROM [Farm].[FarmEsmtAppOwnerDetails] 
            WHERE ApplicationId = @p_ApplicationId";

    public GetEsmtOwnerDetailsSql()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}