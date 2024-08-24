using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries
{
    public class GetEsmtLiensSqlQuery
    {
        private readonly string _sqlCommand =
          @"  SELECT    [Id]                                                        
                        ,[ApplicationId]
                       ,[PremisePreserved]				
                       ,[BankruptcyJedgement]			
                       ,[PowerLines]					
                       ,[WaterLines]					
                       ,[Sewer]							
                       ,[Bridge]						
                       ,[FloodRightWay]					
                       ,[TelephoneLines]				
                       ,[GasLines]						
                       ,[Other]							
                       ,[AvvessEasement]				
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
                        ,[LastUpdatedBy]                                           
                        [LastUpdatedOn]
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
}
