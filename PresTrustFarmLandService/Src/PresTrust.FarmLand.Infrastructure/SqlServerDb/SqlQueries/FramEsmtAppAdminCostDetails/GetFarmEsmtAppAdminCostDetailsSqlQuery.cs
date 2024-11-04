namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmEsmtAppAdminCostDetailsSqlQuery
{
    private readonly string _sqlCommand =
      @"  SELECT     [Id]
                ,[ApplicationId]
                ,[GrossAcers]
                ,[SADCBeforeValueAC]                   
                ,[SADCAfterValueAC]                    
                ,[OfferToSADC]                         
                ,[SADCCostShareAC]                     
                ,[SADCCostShareTotal]                  
                ,[SADCCostShareAcqTotal]               
                ,[NoteOfBreakdown]                     
                ,[SADCCostShareofOfferPct]            
                ,[SADCCertifiedEasementValuePerAcre]   
                ,[SADCPctofCertifiedEaseValue]         
                ,[NetAcres]                            
                ,[MCOffertoLandowner]                  
                ,[MCCertifiedBeforeValue]              
                ,[MCCostSharePerAcre]                  
                ,[OtherSource]                         
                ,[OtherCostShare]                      
                ,[MCCostSharePct]                      
                ,[MCCostShareTotal]                    
                ,[TotalCost]                           
                ,[TotalCostPerAcre]
                ,[CountyFunds]
                ,[LastUpdatedBy]
                ,[LastUpdatedOn]
                FROM [Farm].[FarmEsmtAppAdminCostDetails] 
                WHERE ApplicationId = @p_ApplicationId"
      ;
    public GetFarmEsmtAppAdminCostDetailsSqlQuery()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
