IF OBJECT_ID('[Farm].[FarmEsmtAppAdminDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminDetails];
		
	ALTER TABLE [Farm].[FarmEsmtAppAdminDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminDetails];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminDetails]
GO

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppAdminDetails](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[FarmerName]				    [varchar](128)					    NULL,
	[FarmerPhone]					[varchar](15)						NULL,
	[FarmerContactInfo]			    [varchar](128)						NULL,
	[FarmFeatures]			        [varchar](4000)						NULL,
	[AgreestoHaveSign]				[bit]    							NULL,
	[ConsPlanDate]					[varchar](128) 						NULL, -- dateTime field
	[ConsPlanComment]				[varchar](4000)						NULL,
	[DroppedProjectWhy]			    [varchar](4000)						NULL,
	[ImperviousPercentage]			[decimal](10,2)						NULL,
	[ImperviousSurfaceAcreage]		[decimal](10,2)						NULL,
	[InterestedinSADCSign]          [bit]                               NULL,
	[IsConservationPlan]            [bit]                               NULL,
	[PossibleClosingDate]           [varchar](128)                      NULL, --datetime field
	[PreservedOrder]                [decimal](10,2)                     NULL,
	[SADCSignLocation]              [varchar](4000)                     NULL,
	[StaffComments]                 [varchar](4000)                     NULL,
	[ZoningJan12004]                [varchar](128)                      NULL,
	[RFPIsAppraisal]                [bit]                               NULL,
	[RFPIsSurvey]                   [bit]                               NULL,
	[RFPIsWetlands]                 [bit]                               NULL,
	[CADBAppYear]                   [integer]                           NULL,
	[ProjectYear]                   [integer]                           NULL,
	[OriginalDeed]					[varchar](128)                      NULL,
	[OriginalPage]					[varchar](128)                      NULL,
	[SmallOrLargeSign]				[varchar](128)                      NULL,
	[Year]							[datetime]							NULL,
	[LastUpdatedBy]					[varchar](128)						NULL,
	[LastUpdatedOn]					[datetime]							NULL,
CONSTRAINT [PK_FarmEsmtAppAdminDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminDetails] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmEsmtAppAdminDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  