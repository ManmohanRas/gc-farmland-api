namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateEsmtLiensSqlCommand
{
    private readonly string _sqlCommand =
        @" UPDATE  [Farm].[FarmEsmtLiens]
                 SET
                         ApplicationId           =   @p_ApplicationId
                        ,PremisePreserved		=   @p_PremisePreserved					
                        ,BankruptcyJudgment	    =   @p_BankruptcyJudgment				
                        ,PowerLines				=   @p_PowerLines						
                        ,WaterLines				=   @p_WaterLines						
                        ,Sewer					=   @p_Sewer								
                        ,Bridge					=   @p_Bridge							
                        ,FloodRightWay			=   @p_FloodRightWay						
                        ,TelephoneLines			=   @p_TelephoneLines					
                        ,GasLines				=   @p_GasLines							
                        ,Other					=   @p_Other								
                        ,AccessEasement			=   @p_AccessEasement					
                        ,AccessDescribe			=   @p_AccessDescribe					
                        ,ConservationEasement	=   @p_ConservationEasement				
                        ,ConservationDescribe	=   @p_ConservationDescribe				
                        ,FederalProgram			=   @p_FederalProgram					
                        ,FederalDescribe		=   @p_FederalDescribe					
                        ,SolarWindBiomass		=   @p_SolarWindBiomass					
                        ,BiomassDescribe		=   @p_BiomassDescribe					
                        ,DateInstallation		=   @p_DateInstallation					
                        ,PropertySale			=   @p_PropertySale						
                        ,EstateSituation		=   @p_EstateSituation					
                        ,Bankruptcy				=   @p_Bankruptcy	
                        ,ForeClosure            =   @p_ForeClosure
                        ,LastUpdatedBy            =   @p_LastUpdatedBy                                
                        ,LastUpdatedOn           =   @p_LastUpdatedOn                  
                      WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId";



    public UpdateEsmtLiensSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }

}
