IF OBJECT_ID('[Farm].[FarmParcelHistory]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [FK_ParcelId_FarmParcelHistory];

	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmParcelHistory];

	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [DF_IsActive_FarmParcelHistory];

END
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmParcelHistory]
GO

-- Create Table
CREATE TABLE [Farm].[FarmParcelHistory](
	[Id]								[integer] 		IDENTITY(1,1)	NOT NULL,
	[ParcelId]							[integer] 						NOT NULL,
	[CurrentPamsPin]					[varchar](76)					NOT NULL,
	[PreviousPamsPin]					[varchar](76)					NOT NULL,
	[Section]							[varchar](128)					NULL,
	[Acres]								[decimal](18,4)					NULL,
	[AcresToBeAcquired]					[decimal](18,4)					NULL,
	[Partial]							[bit]							NULL,
	[InterestType]						[varchar](100)					NULL,
	[IsThisAnExclusionArea]				[bit]							NULL,
	[Notes]								[varchar](4000)					NULL,
	[EasementId]						[varchar](100)					NULL,
	[IsActive]							[bit]							NOT NULL,
	[ChangeType]                        [varchar](100)                  NULL,
	[ChangeDate]						[datetime]                      NULL,
	[ReasonForChange]					[varchar](4000)					NULL,
	[LastUpdatedBy]						[varchar](128)					NOT NULL,
	[LastUpdatedOn]						[datetime]						NOT NULL,
	
CONSTRAINT [PK_FarmParcelHistory_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraints  

ALTER TABLE [Farm].[FarmParcelHistory] ADD CONSTRAINT [FK_ParcelId_FarmParcelHistory] FOREIGN KEY (ParcelId) REFERENCES [Farm].[FarmMunicipalityBlockLotParcel](Id);
GO

ALTER TABLE [Farm].[FarmParcelHistory] WITH NOCHECK ADD  CONSTRAINT [DF_IsActive_FarmParcelHistory]  DEFAULT (0) FOR [IsActive]
GO 

ALTER TABLE [Farm].[FarmParcelHistory] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmParcelHistory]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO
