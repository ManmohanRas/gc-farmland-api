namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateFarmMonitoringSqlCommand
{
    private readonly string _sqlCommand =
            @"INSERT INTO [Farm].[FarmMonitoringDetails]
                     (
                         [FarmListId]                  
                        ,[FarmNumber]                  
                        ,[OriginalLandowner]           
                        ,[PresentOwner]                
                        ,[FarmName]                    
                        ,[FarmerName]                  
                        ,[IsConservationPlan]          
                        ,[ConsPlanDate]                
                        ,[ConsPlanComment]              
                        ,[Street1]                     
                        ,[Street2]                     
                        ,[FirstName]                   
                        ,[LastName]                    
                        ,[PhoneNumber]			
                        ,[City]					
                        ,[State]					
                        ,[ZipCode]				
                        ,[ClosingDate]                 
                        ,[TitlePolicy]                 
                        ,[TitleCompany]                
                        ,[EPDeedBook]			
                        ,[EPDeedPage]			
                        ,[EPDeedFiled]			
                        ,[GrossAcers]                  
                        ,[RDSOsNum]		              
                        ,[RDSOExplan]				  
                        ,[IsRDSOExercised]			  
                        ,[ImprovRes]	       
                        ,[ImprovAg]                    
                        ,[AreNonAgUses]				  
                        ,[NonAgExplan]				  
                        ,[FirstInspect]                
                        ,[PreviousInspect]             
                        ,[LastInspect]                 
                        ,[ChangesSinceLastInspect]     
                        ,[IssuesImpactingFarm]         
                        ,[IsInCompliance]              
                        ,[NonComplianceExplan]         
                        ,[InspectionComments]          
                        ,[CurrentDeedBook]             
                        ,[CurrentDeedPage]              
                        ,[CurrentDeedFiled]
                        ,[LastUpdatedBy] 
                        ,[LastUpdatedOn] 
                      )
			  VALUES
			  (  
                         @p_FarmListId                 
                        ,@p_FarmNumber                  
                        ,@p_OriginalLandowner           
                        ,@p_PresentOwner           
                        ,@p_FarmName            
                        ,@p_FarmerName                               
                        ,@p_IsConservationPlan          
                        ,@p_ConsPlanDate             
                        ,@p_ConsPlanComment            
                        ,@p_Street1              
                        ,@p_Street2              
                        ,@p_FirstName                   
                        ,@p_LastName                
                        ,@p_PhoneNumber			
                        ,@p_City			
                        ,@p_State		
                        ,@p_ZipCode				
                        ,@p_ClosingDate                
                        ,@p_TitlePolicy                
                        ,@p_TitleCompany                
                        ,@p_EPDeedBook			
                        ,@p_EPDeedPage		
                        ,@p_EPDeedFiled			
                        ,@p_GrossAcers                  
                        ,@p_RDSOsNum	             
                        ,@p_RDSOExplan				  
                        ,@p_IsRDSOExercised			  
                        ,@p_ImprovRes	       
                        ,@p_ImprovAg                    
                        ,@p_AreNonAgUses				  
                        ,@p_NonAgExplan				  
                        ,@p_FirstInspect                
                        ,@p_PreviousInspect             
                        ,@p_LastInspect                
                        ,@p_ChangesSinceLastInspect   
                        ,@p_IssuesImpactingFarm         
                        ,@p_IsInCompliance              
                        ,@p_NonComplianceExplan         
                        ,@p_InspectionComments          
                        ,@p_CurrentDeedBook             
                        ,@p_CurrentDeedPage              
                        ,@p_CurrentDeedFiled 
                        ,@p_LastUpdatedBy
                        ,GETDATE()
						);

				  SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateFarmMonitoringSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
