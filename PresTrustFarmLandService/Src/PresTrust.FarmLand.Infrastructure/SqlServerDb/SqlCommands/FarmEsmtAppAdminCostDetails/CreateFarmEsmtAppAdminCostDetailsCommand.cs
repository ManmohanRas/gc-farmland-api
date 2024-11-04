namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateFarmEsmtAppAdminCostDetailsCommand
{
    private readonly string _sqlCommand =
            @" INSERT INTO [Farm].[FarmEsmtAppAdminCostDetails]
               (
                 [ApplicationId]
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
                ,LastUpdatedBy
			    ,LastUpdatedOn
               )
            VALUES
               (
                 @p_ApplicationId
                ,@p_GrossAcers
                ,@p_SADCBeforeValueAC                 
                ,@p_SADCAfterValueAC                   
                ,@p_OfferToSADC                       
                ,@p_SADCCostShareAC                     
                ,@p_SADCCostShareTotal                  
                ,@p_SADCCostShareAcqTotal               
                ,@p_NoteOfBreakdown                
                ,@p_SADCCostShareofOfferPct            
                ,@p_SADCCertifiedEasementValuePerAcre   
                ,@p_SADCPctofCertifiedEaseValue    
                ,@p_NetAcres          
                ,@p_MCOffertoLandowner                  
                ,@p_MCCertifiedBeforeValue              
                ,@p_MCCostSharePerAcre               
                ,@p_OtherSource                   
                ,@p_OtherCostShare                      
                ,@p_MCCostSharePct                      
                ,@p_MCCostShareTotal                    
                ,@p_TotalCost                     
                ,@p_TotalCostPerAcre
                ,@p_CountyFunds
                ,@p_LastUpdatedBy  
			    ,GETDATE()
               );
             SELECT CAST(SCOPE_IDENTITY() AS INT);";

    public CreateFarmEsmtAppAdminCostDetailsCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
