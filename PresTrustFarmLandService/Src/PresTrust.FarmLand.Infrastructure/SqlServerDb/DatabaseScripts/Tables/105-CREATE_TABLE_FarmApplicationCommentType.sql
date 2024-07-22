-- Drop Constraints
IF OBJECT_ID('[Farm].[FarmApplicationCommentType]') IS NOT NULL
BEGIN
	ALTER TABLE [Farm].[FarmApplicationCommentType] DROP CONSTRAINT IF EXISTS  [DF_FarmApplicationCommentType_Description];
	
	ALTER TABLE [Farm].[FarmApplicationCommentType] DROP CONSTRAINT IF EXISTS  [DF_FarmApplicationCommentType_IsActive];
	
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationCommentType];
GO

-- Create Table
CREATE TABLE [Farm].[FarmAppCommentType](
	[Id]				[smallint] 			NOT NULL,
	[Title]				[varchar](128)		NOT NULL,
	[Description]		[varchar](512)		NULL,		
	[IsActive]			[bit]				NULL,
CONSTRAINT [PK_FarmApplicationCommentType_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraints
ALTER TABLE [Farm].[FarmAppCommentType] WITH NOCHECK ADD  CONSTRAINT [DF_FarmAppCommentType_Description]  DEFAULT ('') FOR [Description]
GO 
 
ALTER TABLE [Farm].[FarmAppCommentType] WITH NOCHECK ADD  CONSTRAINT [DF_FarmAppCommentType_IsActive]  DEFAULT (1) FOR [IsActive]
GO

 
