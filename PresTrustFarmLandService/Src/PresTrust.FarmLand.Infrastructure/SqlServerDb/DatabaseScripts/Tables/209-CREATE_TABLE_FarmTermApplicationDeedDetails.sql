IF OBJECT_ID('[Farm].[FarmTermAppDeedDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppDeedDetails];
		
	ALTER TABLE [Farm].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppDeedDetails];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppDeedDetails]
GO

-- Create Table
CREATE TABLE [Farm].[FarmTermAppDeedDetails](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[OriginalBlock]					[varchar](50)					NOT NULL,
	[OriginalLot]					[varchar](50)					NOT NULL,
	[OriginalBook]					[varchar](50)					NOT NULL,
	[OriginalPage]					[integer]						NOT NULL,
	[NOTBook]						[varchar](50)					NOT NULL,
	[NOTPage]						[varchar](50)					NOT NULL,
	[RDBook]						[varchar](50)					NOT NULL,
	[RDPage]						[varchar](50)					NOT NULL,
	[LastUpdatedBy]					[varchar](128)					NULL	, 
	[LastUpdatedOn]					[datetime]						NOT NULL, 
CONSTRAINT [PK_FarmTermAppDeedDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppDeedDetails] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppDeedDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmTermAppDeedDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppDeedDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  

