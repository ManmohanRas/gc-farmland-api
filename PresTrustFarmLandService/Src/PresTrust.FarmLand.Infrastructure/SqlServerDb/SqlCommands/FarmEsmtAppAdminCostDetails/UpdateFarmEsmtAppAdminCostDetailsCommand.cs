namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateFarmEsmtAppAdminCostDetailsCommand
{
    private readonly string _sqlCommand =
      @" UPDATE [Farm].[FarmEsmtAppAdminCostDetails]
               SET  ApplicationId                      = @p_ApplicationId
                   ,GrossAcers                         = @p_GrossAcers
                   ,SADCBeforeValueAC                  = @p_SADCBeforeValueAC                 
                   ,SADCAfterValueAC                   = @p_SADCAfterValueAC                   
                   ,OfferToSADC                        = @p_OfferToSADC                       
                   ,SADCCostShareAC                    = @p_SADCCostShareAC                     
                   ,SADCCostShareTotal                 = @p_SADCCostShareTotal                  
                   ,SADCCostShareAcqTotal              = @p_SADCCostShareAcqTotal               
                   ,NoteOfBreakdown                    = @p_NoteOfBreakdown                
                   ,SADCCostShareofOfferPct            = @p_SADCCostShareofOfferPct            
                   ,SADCCertifiedEasementValuePerAcre  = @p_SADCCertifiedEasementValuePerAcre   
                   ,SADCPctofCertifiedEaseValue        = @p_SADCPctofCertifiedEaseValue    
                   ,NetAcres                           = @p_NetAcres          
                   ,MCOffertoLandowner                 = @p_MCOffertoLandowner                  
                   ,MCCertifiedBeforeValue             = @p_MCCertifiedBeforeValue              
                   ,MCCostSharePerAcre                 = @p_MCCostSharePerAcre               
                   ,OtherSource                        = @p_OtherSource                   
                   ,OtherCostShare                     = @p_OtherCostShare                      
                   ,MCCostSharePct                     = @p_MCCostSharePct                      
                   ,MCCostShareTotal                   = @p_MCCostShareTotal                    
                   ,TotalCost                          = @p_TotalCost                     
                   ,TotalCostPerAcre                   = @p_TotalCostPerAcre
                   ,LastUpdatedBy                      = @p_LastUpdatedBy
                   ,LastUpdatedOn                      = @p_LastUpdatedOn
             WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId";

    public UpdateFarmEsmtAppAdminCostDetailsCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
