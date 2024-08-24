using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands
{
    public class CreateEsmtLiensSqlCommand
    {
        private readonly string _sqlCommand =
    @"INSERT INTO  [Farm].[FarmEsmtLiens]
              (
                         ApplicationId
                        ,PremisePreserved				
                        ,BankruptcyJedgement			
                        ,PowerLines					
                        ,WaterLines					
                        ,Sewer							
                        ,Bridge						
                        ,FloodRightWay					
                        ,TelephoneLines				
                        ,GasLines						
                        ,Other							
                        ,AvvessEasement				
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
                        ,LastUpdatedBy
                        ,LastUpdatedOn
              )

			  VALUES
			  (  
                     @p_ApplicationId
                    ,@p_PremisePreserved				
                    ,@p_BankruptcyJedgement			
                    ,@p_PowerLines					
                    ,@p_WaterLines					
                    ,@p_Sewer							
                    ,@p_Bridge						
                    ,@p_FloodRightWay					
                    ,@p_TelephoneLines				
                    ,@p_GasLines						
                    ,@p_Other							
                    ,@p_AvvessEasement				
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
}
