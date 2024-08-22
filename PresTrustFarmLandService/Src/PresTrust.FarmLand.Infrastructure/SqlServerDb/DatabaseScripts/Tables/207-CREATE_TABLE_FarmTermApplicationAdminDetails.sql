IF OBJECT_ID('[Farm].[FarmTermAppAdminDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmTermAppAdminDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppAdminDetails];
		
	ALTER TABLE [Farm].[FarmTermAppAdminDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppAdminDetails];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppAdminDetails]
GO

-- Create Table
CREATE TABLE [Farm].[FarmTermAppAdminDetails](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[SADCId]						[integer]							NULL,
	[MaxGrant]						[decimal](18,2)						NULL,
	[PermanentlyPreserved]			[bit]								NULL,
	[MunicipallyApproved]			[bit]								NULL,
	[EnrollmentDate]				[dateTime]							NULL,
	[RenewalDate]					[dateTime]							NULL,
	[ExpirationDate]				[dateTime]							NULL,
	[RenewalExpirationDate]			[dateTime]							NULL,
	[Comment]						[varchar](128)						Null,
	[LastUpdatedBy]					[varchar](128)						NULL,
	[LastUpdatedOn]					[datetime]							NULL,
CONSTRAINT [PK_FarmTermAppAdminDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppAdminDetails] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppAdminDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmTermAppAdminDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppAdminDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  