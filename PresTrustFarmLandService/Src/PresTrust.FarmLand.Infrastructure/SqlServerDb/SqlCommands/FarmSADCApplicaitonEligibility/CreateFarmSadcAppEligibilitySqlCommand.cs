namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands
{
	public class CreateFarmSadcAppEligibilitySqlCommand
	{
		private readonly string _sqlCommand =
                @"INSERT INTO [Farm].[FarmEsmtSadcEligibility]
						(
								
								 ApplicationId          
								,ProjectAreaAppEl       
								,RankScore              
								,RankPoints             
								,SoilPercentage         
								,IsLandsLessThan10Ac    
								,IsLandsGreaterThan10Ac 
								,Is75PercentTillable    
								,Percent75Tillable1     
								,Acre75Tillable         
								,Is75PercentLand        
								,Percent75Land          
								,Acre75Land             
								,Is50PercentTillable    
								,Percent50Tillable      
								,Acre50Tillable         
								,Is50PercentLand        
								,Percent50Land          
								,Acre50Land             
								,LastUpdatedBy
								,LastUpdatedOn
						)

						VALUES
						(	
								
								 @p_ApplicationId          
								,@p_ProjectAreaAppEl       
								,@p_RankScore              
								,@p_RankPoints             
								,@p_SoilPercentage         
								,@p_IsLandsLessThan10Ac    
								,@p_IsLandsGreaterThan10Ac 
								,@p_Is75PercentTillable    
								,@p_Percent75Tillable1     
								,@p_Acre75Tillable         
								,@p_Is75PercentLand        
								,@p_Percent75Land          
								,@p_Acre75Land             
								,@p_Is50PercentTillable    
								,@p_Percent50Tillable      
								,@p_Acre50Tillable         
								,@p_Is50PercentLand        
								,@p_Percent50Land          
								,@p_Acre50Land             
								,@p_LastUpdatedBy
								,GETDATE()
						);

				 SELECT CAST( SCOPE_IDENTITY() AS INT);";

        public CreateFarmSadcAppEligibilitySqlCommand()
        {
        }

        public override string ToString()
        {
            return _sqlCommand;
        }
    }
  
}