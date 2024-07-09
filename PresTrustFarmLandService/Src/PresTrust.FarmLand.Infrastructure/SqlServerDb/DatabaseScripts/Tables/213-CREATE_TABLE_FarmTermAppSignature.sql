IF OBJECT_ID('[Farm].[FarmTermAppSignature]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmTermAppSignature] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppSignature];
		
	ALTER TABLE [Farm].[FarmTermAppSignature] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppSignature];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppSignature]
GO

-- Create Table
CREATE TABLE [Farm].[FarmTermAppSignature](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[Designation]					[varchar](128)					NULL	,
	[Title]							[varchar](128)					NULL	, 
	[SignedOn]						[DateTime]						NULL	, 
	[LastUpdatedBy]					[varchar](128)					NULL	,--SignatoryType 
	[LastUpdatedOn]					[DateTime]						NOT NULL, 
CONSTRAINT [PK_FarmTermAppSignature_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppSignature] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppSignature]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmTermAppSignature] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppSignature]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  

