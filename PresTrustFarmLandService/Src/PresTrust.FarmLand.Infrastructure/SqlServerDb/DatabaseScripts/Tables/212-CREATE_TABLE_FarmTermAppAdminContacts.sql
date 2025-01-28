IF OBJECT_ID('[Farm].[FarmAppAdminContact]') IS NOT NULL
BEGIN

	ALTER TABLE [Farm].[FarmAppAdminContact] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmAppAdminContact];

	ALTER TABLE [Farm].[FarmAppAdminContact] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_FarmAppAdminContact];

	
END;
GO

DROP TABLE IF EXISTS [Farm].[FarmAppAdminContact]
GO

CREATE TABLE [Farm].[FarmAppAdminContact](
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
CONSTRAINT [PK_FarmAppAdminContact_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Farm].[FarmAppAdminContact] ADD CONSTRAINT [FK_ApplicationId_FarmAppAdminContact]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].[FarmApplication](Id);
GO

ALTER TABLE [Farm].[FarmAppAdminContact] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmAppAdminContact]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO
