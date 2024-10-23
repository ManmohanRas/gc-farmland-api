IF OBJECT_ID('[Farm].[FarmEsmtAppAdminAppraisalReport]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminAppraisalReport] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminAppraisalReport ];
		
	ALTER TABLE [Farm].[FarmEsmtAppAdminAppraisalReport] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminAppraisalReport ];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminAppraisalReport]
GO

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppAdminAppraisalReport](
	[Id]												   [integer] 		IDENTITY(1,1)  NOT NULL,
	[ApplicationId]                                        [integer]                       NOT NULL,
	[AsOfDate]											   [datetime]						   NULL,
	[AppraiserName1]									   [varchar](128)		               NULL,
	[AppraiserName2]									   [varchar](128)		               NULL,
	[LowerAppraiser]									   [varchar](128)		               NULL,
	[HigherAppraiser]									   [varchar](128)		               NULL,
	[PreHLBeforeValue1]									   [decimal](18,2)					   NULL,
	[PreHLAfterValue1]									   [decimal](18,2)					   NULL,
	[PreHLEsmtValue1]									   [decimal](18,2)					   NULL,
	[PreHLBeforeValue2]									   [decimal](18,2)					   NULL,
	[PreHLAfterValue2]									   [decimal](18,2)					   NULL,
	[PreHLEsmtValue2]									   [decimal](18,2)					   NULL,
	[PostHLBeforeValue1]								   [decimal](18,2)					   NULL,
	[PostHLAfterValue1]									   [decimal](18,2)					   NULL,
	[PostHLEsmtValue1]									   [decimal](18,2)					   NULL,
	[PostHLBeforeValue2]								   [decimal](18,2)					   NULL,
	[PostHLAfterValue2]									   [decimal](18,2)					   NULL,
	[PostHLEsmtValue2]									   [decimal](18,2)					   NULL,
	[DiffInEsmtAppraisals]								   [decimal](18,2)					   NULL,
	[PostHLDifference]									   [decimal](18,2)					   NULL,
	[DiffInPreandPostHL]								   [decimal](18,2)					   NULL,
	[WithInHighlands]									   [bit]							   NULL,
	[WithInPreservationArea]							   [bit]							   NULL,
	[SADCCertifiedEsmttotal]							   [decimal](18,2)					   NULL,
	[SADCEsmtBeforePct]                                    [decimal](18,2)					   NULL,
	[AppraisedZoning]									   [varchar](128)		               NULL,
	[ApraisedZoningClass]								   [varchar](128)		               NULL,
	[AppraisalComments]									   [varchar](4000)					   NULL,
	[LastUpdatedBy]										   [varchar](128)		               NULL,
	[LastUpdatedOn]										   [datetime]			           NOT NULL,
CONSTRAINT [PK_FarmEsmtAppAdminAppraisalReport _Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminAppraisalReport] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminAppraisalReport]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmEsmtAppAdminAppraisalReport] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminAppraisalReport]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  