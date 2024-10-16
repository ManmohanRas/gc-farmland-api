IF OBJECT_ID('[Farm].[FarmEsmtAppAdminClosingDocStatus]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminClosingDocStatus];
		
	ALTER TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminClosingDocStatus];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminClosingDocStatus]
GO

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[ProjectStatus]					[varchar](128)						NULL,
	[EPDeedBook]					[integer]							NULL,
	[EPDeedPage]					[integer]							NULL,
	[EPDeedFiled]					[datetime]							NULL,
	[EPDeedClerkID]					[varChar](128)						NULL,
	[CountyAttorney]				[varChar](128)						NULL,
	[CountyAttorneyInfo]			[varChar](4000)						NULL,
	[SurveyDate]					[datetime]							NULL,
	[Surveyor]						[varchar](128)						NULL,
	[TitleCompany]					[varChar](128)						NULL,
	[TitlePolicy#]					[varChar](128)						NULL,
	[ClosingDate]					[datetime]							NULL,
	[EndorsementDates]				[varChar](4000)						NULL,
	[LastUpdatedBy]					[varchar](128)						NULL,
	[LastUpdatedOn]					[datetime]						NOT NULL,
CONSTRAINT [PK_FarmEsmtAppAdminClosingDocStatus_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminClosingDocStatus]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminClosingDocStatus]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  