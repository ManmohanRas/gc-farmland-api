namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateFarmMonitoringSqlCommand
{
    private readonly string _sqlCommand =
 @" UPDATE [Farm].[FarmMonitoringDetails]
            SET              FarmListId                 = @p_FarmListId                 
                            ,FarmNumber                 = @p_FarmNumber                  
                            ,OriginalLandowner          = @p_OriginalLandowner           
                            ,PresentOwner               = @p_PresentOwner           
                            ,FarmName                   = @p_FarmName            
                            ,FarmerName                 = @p_FarmerName                               
                            ,IsConservationPlan         = @p_IsConservationPlan          
                            ,ConsPlanDate               = @p_ConsPlanDate             
                            ,ConsPlanComment            = @p_ConsPlanComment            
                            ,Street1                    = @p_Street1              
                            ,Street2                    = @p_Street2              
                            ,FirstName                  = @p_FirstName                   
                            ,LastName                   = @p_LastName                
                            ,PhoneNumber			    = @p_PhoneNumber			
                            ,City			            = @p_City			
                            ,State		                = @p_State		
                            ,ZipCode				    = @p_ZipCode				
                            ,ClosingDate                = @p_ClosingDate                
                            ,TitlePolicy                = @p_TitlePolicy                
                            ,TitleCompany               = @p_TitleCompany                
                            ,EPDeedBook			        = @p_EPDeedBook			
                            ,EPDeedPage		            = @p_EPDeedPage		
                            ,EPDeedFiled			    = @p_EPDeedFiled			
                            ,GrossAcers                 = @p_GrossAcers                  
                            ,RDSOsNum	                = @p_RDSOsNum	             
                            ,RDSOExplan			        = @p_RDSOExplan				  
                            ,IsRDSOExercised		    = @p_IsRDSOExercised			  
                            ,ImprovRes	                = @p_ImprovRes	       
                            ,ImprovAg                   = @p_ImprovAg                    
                            ,AreNonAgUses			    = @p_AreNonAgUses				  
                            ,NonAgExplan			    = @p_NonAgExplan				  
                            ,FirstInspect               = @p_FirstInspect                
                            ,PreviousInspect            = @p_PreviousInspect             
                            ,LastInspect                = @p_LastInspect                
                            ,ChangesSinceLastInspect    = @p_ChangesSinceLastInspect   
                            ,IssuesImpactingFarm        = @p_IssuesImpactingFarm         
                            ,IsInCompliance             = @p_IsInCompliance              
                            ,NonComplianceExplan        = @p_NonComplianceExplan         
                            ,InspectionComments         = @p_InspectionComments          
                            ,CurrentDeedBook            = @p_CurrentDeedBook             
                            ,CurrentDeedPage            = @p_CurrentDeedPage              
                            ,CurrentDeedFiled           = @p_CurrentDeedFiled            
                            ,LastUpdatedBy              = @p_LastUpdatedBy
                            ,LastUpdatedOn              = GETDATE()
                 WHERE Id = @p_Id AND FarmName = @p_FarmName AND FarmNumber = @p_FarmNumber;";

    public UpdateFarmMonitoringSqlCommand()
    { }


    public override string ToString()
    {
        return _sqlCommand;
    }
}
