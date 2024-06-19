IF OBJECT_ID('[Farm].[FarmTermAppOwnerDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmTermAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppOwnerDetails];
		
	ALTER TABLE [Farm].[FarmTermAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppOwnerDetails];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppOwnerDetails]
GO

-- Create Table
CREATE TABLE [Farm].[FarmTermAppOwnerDetails](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[FirstName]						[varchar](128)					NULL	,
	[LastName]						[varchar](128)					NULL	, 
	[PropertyLocation]				[varchar](128)					NULL	, 
	[Municipality]					[varchar](128)					NOT NULL,
	[MailingAddress1]				[varchar](128)					NOT NULL,
	[MailingAddress2]				[varchar](128)					NOT NULL,
	[PhoneNumber]					[varchar](15)					NOT NULL,
	[City]							[varchar](128)					NOT NULL,
	[State]							[varchar](128)					NOT NULL,
	[ZipCode]						[varchar](20)					NOT NULL,
	[IsPrimaryOwner]				[bit]							NOT NULL,
	[LastUpdatedBy]					[varchar](128)					NULL	, 
	[LastUpdatedOn]					[datetime]						NOT NULL, 
CONSTRAINT [PK_FarmTermAppOwnerDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppOwnerDetails] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppOwnerDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmTermAppOwnerDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppOwnerDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  