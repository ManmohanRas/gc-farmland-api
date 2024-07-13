IF OBJECT_ID('[Farm].[FarmTermAppAdminContacts]') IS NOT NULL
BEGIN

	ALTER TABLE [Farm].[FarmTermAppAdminContact] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmTermAppAdminContacts];

	ALTER TABLE [Farm].[FarmTermAppAdminContact] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_FarmTermAppAdminContacts];

	
END;
GO

DROP TABLE IF EXISTS [Farm].[FarmTermAppAdminContact]
GO

CREATE TABLE [Farm].[FarmTermAppAdminContact](
	[Id]					[integer]			IDENTITY(1,1)	NOT NULL,
	[ApplicationId]			[integer]							NOT NULL,
	[ContactName]			[varchar](76)						NULL,
	[Agency]				[varchar](128)						NULL,
	[Email]					[varchar](128)						NULL,
	[MainNumber]			[varchar](128)						NULL,
	[AlternateNumber]		[varchar](128)						NULL,
	[SelectContact]			[bit]								NULL,
	[LastUpdatedBy]			[varchar](128)						NULL	,
	[LastUpdatedOn]			[datetime]							NOT NULL,
CONSTRAINT [PK_FarmTermAppAdminContacts_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Farm].[FarmTermAppAdminContacts] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppAdminContacts]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].[FarmApplication](Id);
GO

ALTER TABLE [Farm].[FarmTermAppAdminContacts] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppAdminContacts]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO
