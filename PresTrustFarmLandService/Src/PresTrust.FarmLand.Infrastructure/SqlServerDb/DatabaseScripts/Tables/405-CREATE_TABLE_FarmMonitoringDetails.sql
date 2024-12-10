IF OBJECT_ID('[Farm].[FarmMonitoringDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmMonitoringDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmMonitoringDetails];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmMonitoringDetails]
GO

-- Create Table
CREATE TABLE [Farm].[FarmMonitoringDetails](
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
CONSTRAINT [PK_FarmMonitoringDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint 
ALTER TABLE [Farm].[FarmMonitoringDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmMonitoringDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  