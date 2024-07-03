IF OBJECT_ID('[Farm].[FarmApplicationUser]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS  [DF_IsPrimaryContact_FarmApplicationUser];

	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS  [DF_IsAlternateContact_FarmApplicationUser];
			
	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationUser];

    ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS   [DF_FirstName_FarmApplicationUser];  

	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS   [DF_LastName_FarmApplicationUser];  
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationUser]
GO

-- Create Table
CREATE TABLE [Farm].[FarmApplicationUser](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	--[ApplicationTypeId]             [smallint]                      NOT NULL,
	[Email]							[varchar](128)					NULL	,
	[UserId]						[varchar](128)					NOT NULL,
	[UserName]						[varchar](128)					NOT NULL,
	[FirstName]						[varchar](128)					NULL,
	[LastName]						[varchar](128)					NULL,
	[Title]							[varchar](128)					NULL	,
	[PhoneNumber]					[varchar](15)					NULL	,
	[IsPrimaryContact]				[bit]							NOT NULL,
	[IsAlternateContact]			[bit]							NOT NULL,
	[LastUpdatedBy]					[varchar](128)					NULL	,
	[LastUpdatedOn]					[datetime]						NOT NULL,
CONSTRAINT [PK_FarmRole_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_IsPrimaryContact_FarmApplicationUser]  DEFAULT (0) FOR [IsPrimaryContact]
GO  

ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_IsAlternateContact_FarmApplicationUser]  DEFAULT (0) FOR [IsAlternateContact]
GO  

ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_FirstName_FarmApplicationUser]  DEFAULT ('') FOR [FirstName];
GO

ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_LastName_FarmApplicationUser]  DEFAULT ('') FOR [LastName];
GO

ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationUser]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO
