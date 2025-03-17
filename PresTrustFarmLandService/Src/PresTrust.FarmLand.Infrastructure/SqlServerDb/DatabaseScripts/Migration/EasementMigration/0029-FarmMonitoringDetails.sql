BEGIN TRY
BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmMonitoringDetails

-- Create Table
CREATE TABLE #FarmMonitoringDetails(
[Id]                                  [integer] IDENTITY(1,1)   NOT NULL,
[FarmListId]                          [integer]                 NOT NULL,
[FarmNumber]                          [varchar](5)                  NULL,
[OriginalLandowner]                   [varchar](128)                NULL,
[PresentOwner]                        [varchar](128)                NULL,
[FarmName]                            [varchar](128)                NULL,
[FarmerName]                          [varchar](128)                NULL,
[IsConservationPlan]                  [bit]                         NULL,
[ConsPlanDate]                        [varchar](128)                NULL,
[ConsPlanComment]                     [varchar](4000)               NULL, 
[Street1]                             [varchar](128)                NULL,
[Street2]                             [varchar](128)                NULL,
[FirstName]                           [varchar](128)                NULL,
[LastName]                            [varchar](128)                NULL,
[PhoneNumber]					      [varchar](15)				    NULL,
[City]							      [varchar](128)			    NULL,
[State]							      [varchar](128)				NULL,
[ZipCode]						      [integer] 					NULL,
[ClosingDate]                         [DateTime]                    NULL,
[TitlePolicy]                         [varchar](128)                NULL,
[TitleCompany]                        [varchar](128)                NULL,
[EPDeedBook]					      [integer]					    NULL,
[EPDeedPage]					      [integer]					    NULL,
[EPDeedFiled]					      [datetime]				    NULL,
[GrossAcers]                          [decimal](10,2)               NULL,
[RDSOsNum]		                      [integer]				        NULL,
[RDSOExplan]				          [varchar](128)			    NULL,
[IsRDSOExercised]			          [bit]					        NULL,
[ImprovRes]	         				  [varchar](4000)			    NULL,
[ImprovAg]                            [varchar](4000)	            NULL,
[AreNonAgUses]				          [bit]					        NULL,
[NonAgExplan]				          [varchar](4000)			    NULL,
[FirstInspect]                        [DateTime]                    NULL,
[PreviousInspect]                     [DateTime]                    NULL,
[LastInspect]                         [DateTime]                    NULL,
[ChangesSinceLastInspect]             [varchar](4000)               NULL,
[IssuesImpactingFarm]                 [varchar](128)                NULL,
[IsInCompliance]                      [bit]                         NULL,
[NonComplianceExplan]                 [varchar](4000)               NULL,
[InspectionComments]                  [varchar](4000)               NULL,
[CurrentDeedBook]                     [varchar](50)                 NULL,
[CurrentDeedPage]                     [varchar](50)                 NULL, 
[CurrentDeedFiled]                    [DateTime]                    NULL,
[LastUpdatedBy]					      [varchar](128)			    NULL, 
[LastUpdatedOn]					      [DateTime]				NOT NULL,
CONSTRAINT [PK_#FarmMonitoringDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmMonitoringDetails, we are Inserting Data for Every Column, 
---some of them are Populating From Another Tables
INSERT INTO #FarmMonitoringDetails
            (
			  FarmListId 
			 ,FirstInspect              
			 ,PreviousInspect            
			 ,LastInspect    
			 ,ChangesSinceLastInspect    
			 ,IssuesImpactingFarm        
			 ,IsInCompliance              
			 ,NonComplianceExplan         
			 ,InspectionComments         
			 ,CurrentDeedBook            
			 ,CurrentDeedPage             
			 ,CurrentDeedFiled
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
            SELECT 
			  FL.NewFarmListID
		     ,CASE WHEN ISDATE(OW.FirstInspect) = 1 THEN CAST(OW.FirstInspect AS DATE) ELSE NULL END AS FirstInspect
	         ,CASE WHEN ISDATE(OW.PreviousInspect) = 1 THEN CAST(OW.PreviousInspect AS DATE) ELSE NULL END AS PreviousInspect
	         ,CASE WHEN ISDATE(OW.LastInspect) = 1 THEN CAST(OW.LastInspect AS DATE) ELSE NULL END AS LastInspect
			 ,OW.ChangesSinceLastInspect    
			 ,OW.IssuesImpactingFarm  
			 ,CASE 
			      WHEN OW.IsInCompliance = 'Yes' THEN 1
				  WHEN OW.IsInCompliance = 'No' THEN 0
				  ELSE NULL
				  END AS IsInCompliance         
			 ,OW.NonComplianceExplan         
			 ,OW.InspectionComments        
			 ,OW.CurrentDeedBook          
			 ,OW.CurrentDeedPage             
			 ,OW.CurrentDeedFiled
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02 OW
			 JOIN [Farm].[FarmListLegacy] FL ON OW.FarmListID = FL.LegacyFarmListId 
			 WHERE OW.[Status] IN ('Preserved','Fee Simple Purchase')

            COMMIT;
            PRINT 'Program Manager Monitoring Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH