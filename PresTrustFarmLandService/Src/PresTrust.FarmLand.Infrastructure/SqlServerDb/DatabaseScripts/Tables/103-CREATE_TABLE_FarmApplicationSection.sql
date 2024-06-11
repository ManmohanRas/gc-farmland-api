-- Drop Constraints
IF OBJECT_ID('[Farm].[FarmApplicationSection]') IS NOT NULL
BEGIN
	ALTER TABLE [Farm].[FarmApplicationSection] DROP CONSTRAINT IF EXISTS  [DF_FarmApplicationSection_Description]
	
	ALTER TABLE [Farm].[FarmApplicationSection] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationSection] 	
END
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationSection];
GO
 
-- Create Table
CREATE TABLE [Farm].[FarmApplicationSection](
	[Id]				[smallint] 			NOT NULL,
	[Title]				[varchar](128)		NOT NULL,
	[Description]		[varchar](512)		NULL,
	[ApplicationTypeId] [smallint]	        NOT NULL,
CONSTRAINT [PK_FarmApplicationSection_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmApplicationSection] WITH NOCHECK ADD  CONSTRAINT [DF_FarmApplicationSection_Description]  DEFAULT ('') FOR [Description]
GO

-- Create Constraints
ALTER TABLE [Farm].[FarmApplicationSection] ADD CONSTRAINT [FK_ApplicationTypeId_FarmApplicationSection]  FOREIGN KEY (ApplicationTypeId) REFERENCES [Farm].FarmApplicationType(Id);
GO