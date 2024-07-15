IF OBJECT_ID('[Farm].[FarmEmailTemplate]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEmailTemplate] DROP CONSTRAINT IF EXISTS  [DF_IsActive_FarmEmailTemplate];

	ALTER TABLE [Farm].[FarmEmailTemplate] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEmailTemplate];

END
GO	

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEmailTemplate]
GO

CREATE TABLE [Farm].[FarmEmailTemplate](
[Id] [smallint]  NOT NULL,
[TemplateCode] [varchar](128) NOT NULL,
[Title] [varchar](256) NOT NULL,
[Subject] [varchar](512) NULL,
[Description] [varchar](max) NOT NULL,
[IsActive] [bit] NULL,
[LastUpdatedBy] [varchar](128) NULL,
[LastUpdatedOn] [datetime] NULL,

CONSTRAINT [PK_FarmEmailTemplate_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraints
ALTER TABLE [Farm].[FarmEmailTemplate] WITH NOCHECK ADD  CONSTRAINT [DF_IsActive_FarmEmailTemplate]  DEFAULT (1) FOR [IsActive]
GO

ALTER TABLE [Farm].[FarmEmailTemplate] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEmailTemplate]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO
