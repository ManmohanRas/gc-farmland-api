IF OBJECT_ID('[Farm].[FarmApplication]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_CreatedByProgramAdmin_FarmApplication];

	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplication];

	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_IsActive_FarmApplication];

END;
GO
 
 
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplication]
GO

-- Create Table
CREATE TABLE [Farm].[FarmApplication](
	[Id]						[integer] 		IDENTITY(1,1)	NOT NULL,
	[Title]						[varchar](256)					NOT NULL,
	[AgencyId]					[integer]						NOT NULL,
	[ApplicationTypeId]			[smallint]						NOT NULL,
	[StatusId]					[smallint]						NOT NULL,
	[CreatedByProgramAdmin]		[bit]							NOT NULL,
	[LastUpdatedBy]				[varchar](128)					NULL	,
	[LastUpdatedOn]				[datetime]						NOT NULL,
	[IsActive]					[bit]							NOT NULL,	
CONSTRAINT [PK_FarmApplication_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraints
ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_CreatedByProgramAdmin_FarmApplication]  DEFAULT (0) FOR [CreatedByProgramAdmin]
GO

ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplication]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  

ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_IsActive_FarmApplication]  DEFAULT (1) FOR [IsActive]
GO
