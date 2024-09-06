IF OBJECT_ID('[Farm].[FarmEsmtAppSignatory]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppSignatory] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppSignatory];
		
	ALTER TABLE [Farm].[FarmEsmtAppSignatory] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppSignatory];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppSignatory]
GO

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppSignatory](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[AmountPerAcre]                 [decimal](18,4)                 NULL    ,
	[Designation]					[varchar](128)					NULL	,
	[Title]							[varchar](128)					NULL	, 
	[SignedOn]						[DateTime]						NULL	, 
	[LastUpdatedBy]					[varchar](128)					NULL	, 
	[LastUpdatedOn]					[DateTime]						NOT NULL, 
CONSTRAINT [PK_FarmEsmtAppSignatory_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppSignatory] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppSignatory]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmEsmtAppSignatory] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppSignatory]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  

