IF OBJECT_ID('[Flood].[FarmTermAppDeedDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Flood].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppDeedDetails];
		
	ALTER TABLE [Flood].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppDeedDetails];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Flood].[FarmTermAppDeedDetails]
GO

-- Create Table
CREATE TABLE [Flood].[FarmTermAppDeedDetails](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[OriginalBlock]					[varchar](20)					NOT NULL,
	[OriginalLot]					[varchar](20)					NOT NULL,
	[OriginalBook]					[varchar](20)					NOT NULL,
	[OriginalPage]					[integer]						NOT NULL,
	[NOTBook]						[varchar](20)					NOT NULL,
	[NOTPage]						[varchar](20)					NOT NULL,
	[RDBook]						[varchar](20)					NOT NULL,
	[RDPage]						[varchar](20)					NOT NULL,
	[LastUpdatedBy]					[varchar](128)					NULL	, 
	[LastUpdatedOn]					[datetime]						NOT NULL, 
CONSTRAINT [PK_FarmTermAppDeedDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Flood].[FarmTermAppDeedDetails] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppDeedDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Flood].FloodApplication(Id);
GO 

ALTER TABLE [Flood].[FarmTermAppDeedDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppDeedDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  

