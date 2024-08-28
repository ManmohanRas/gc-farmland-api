namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateEsmtLiensSqlCommand
{
    private readonly string _sqlCommand =
@"INSERT INTO  [Farm].[FarmEsmtLiens]
              (
                         ApplicationId
                        ,PremisePreserved				
                        ,BankruptcyJudgment			
                        ,PowerLines					
                        ,WaterLines					
                        ,Sewer							
                        ,Bridge						
                        ,FloodRightWay					
                        ,TelephoneLines				
                        ,GasLines						
                        ,Other							
                        ,AccessEasement				
                        ,AccessDescribe				
                        ,ConservationEasement			
                        ,ConservationDescribe			
                        ,FederalProgram				
                        ,FederalDescribe				
                        ,SolarWindBiomass				
                        ,BiomassDescribe				
                        ,DateInstallation				
                        ,PropertySale					
                        ,EstateSituation				
                        ,Bankruptcy	
                        ,ForeClosure
                        ,LastUpdatedBy
                        ,LastUpdatedOn
              )

			  VALUES
			  (  
                     @p_ApplicationId
                    ,@p_PremisePreserved				
                    ,@p_BankruptcyJudgment			
                    ,@p_PowerLines					
                    ,@p_WaterLines					
                    ,@p_Sewer							
                    ,@p_Bridge						
                    ,@p_FloodRightWay					
                    ,@p_TelephoneLines				
                    ,@p_GasLines						
                    ,@p_Other							
                    ,@p_AccessEasement				
                    ,@p_AccessDescribe				
                    ,@p_ConservationEasement			
                    ,@p_ConservationDescribe			
                    ,@p_FederalProgram				
                    ,@p_FederalDescribe				
                    ,@p_SolarWindBiomass				
                    ,@p_BiomassDescribe				
                    ,@p_DateInstallation				
                    ,@p_PropertySale					
                    ,@p_EstateSituation				
                    ,@p_Bankruptcy	
                    ,@p_ForeClosure
                    ,@p_LastUpdatedBy
                     ,GETDATE()
                                );
				  SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateEsmtLiensSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
