IF OBJECT_ID('[Farm].[FarmApplicationComment]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmApplicationComment] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationComment];
	
	ALTER TABLE [Farm].[FarmApplicationComment] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationComment];
END;
GO
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationComment]
GO

-- Create Table
CREATE TABLE [Farm].[FarmApplicationComment](
	[Id]									[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]							[integer]						NOT NULL,
	[Comment]								[varchar](4000)					NOT NULL,
	[CommentTypeId]							[smallint]						NOT NULL,
	[LastUpdatedBy]							[varchar](128)					NULL	,
	[LastUpdatedOn]							[datetime]			   			NOT NULL,

CONSTRAINT [PK_FarmApplicationComment_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraints
ALTER TABLE [Farm].[FarmApplicationComment] ADD CONSTRAINT [FK_ApplicationId_FarmApplicationComment]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmApplicationComment] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationComment]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  


