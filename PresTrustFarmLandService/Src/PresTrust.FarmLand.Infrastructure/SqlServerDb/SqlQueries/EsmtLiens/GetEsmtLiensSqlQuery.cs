namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetEsmtLiensSqlQuery
{
    private readonly string _sqlCommand =
      @"  SELECT    [Id]                                                        
                        ,[ApplicationId]
                       ,[PremisePreserved]				
                       ,[BankruptcyJudgment]			
                       ,[PowerLines]					
                       ,[WaterLines]					
                       ,[Sewer]							
                       ,[Bridge]						
                       ,[FloodRightWay]					
                       ,[TelephoneLines]				
                       ,[GasLines]						
                       ,[Other]							
                       ,[AccessEasement]				
                       ,[AccessDescribe]				
                       ,[ConservationEasement]			
                       ,[ConservationDescribe]			
                       ,[FederalProgram]				
                       ,[FederalDescribe]				
                       ,[SolarWindBiomass]				
                       ,[BiomassDescribe]				
                       ,[DateInstallation]				
                       ,[PropertySale]					
                       ,[EstateSituation]				
                       ,[Bankruptcy]	
                       ,[ForeClosure]
                        ,[LastUpdatedBy]                                           
                        ,[LastUpdatedOn]
            FROM [Farm].[FarmEsmtLiens] 
            WHERE ApplicationId = @p_ApplicationId";

    public GetEsmtLiensSqlQuery()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
