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
	[ParcelId]						[integer]						NOT NULL,
	[OriginalBlock]					[varchar](50)					NOT NULL,
	[OriginalLot]					[varchar](50)					NOT NULL,
	[OriginalBook]					[varchar](50)					NULL,
	[OriginalPage]					[varchar](50)					NULL,
	[NOTBlock]						[varchar](50)					NULL,
	[NOTLot]						[varchar](50)					NULL,
	[NOTBook]						[varchar](50)					NULL,
	[NOTPage]						[varchar](50)					NULL,
	[RDBlock]						[varchar](50)					NULL,
	[RDLot]							[varchar](50)					NULL,
	[RDBook]						[varchar](50)					NULL,
	[RDPage]						[varchar](50)					NULL,
	[IsChecked]						[bit]							NOT NULL,
	[LastUpdatedBy]					[varchar](128)					NULL, 
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

