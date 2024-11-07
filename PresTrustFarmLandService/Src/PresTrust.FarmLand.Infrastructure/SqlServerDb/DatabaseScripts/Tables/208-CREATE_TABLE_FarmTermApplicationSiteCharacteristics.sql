IF OBJECT_ID('[Farm].[FarmTermAppSiteCharacteristics]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppSiteCharacteristics];
		
	ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppSiteCharacteristics];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppSiteCharacteristics]
GO

-- Create Table
CREATE TABLE [Farm].[FarmTermAppSiteCharacteristics](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[Area]							[decimal]							NULL,--ProjectRegion or ProjectGeneralLocation or FarmLocation legacy
	[LandUse]						[varchar](4000)						NULL,
	[CropLand]						[decimal](18,2)						NULL,
	[WoodLand]						[decimal](18,2)						NULL,
	[Pasture]						[decimal](18,2)						NULL,
	[Orchard]						[decimal](18,2)						NULL,
	[Other]							[decimal](18,2)						NULL,--like this OrchardAcres, OtherAcres
	[IsEasement]			        [bit]						        NULL,
	[IsRightOfway]		        	[bit]						        NULL,
	[NoteEasementRightOfway]		[varchar](4000)						NULL,
	[IsMortgage]			        [bit]						        NULL,
	[IsLiens]					    [bit]								NULL,
	[NoteMortgageLiens]				[varchar](4000)						NULL,
	[LastUpdatedBy]					[varchar](128)						NULL,
	[LastUpdatedOn]					[datetime]						NOT NULL,
CONSTRAINT [PK_FarmTermAppSiteCharacteristics_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppSiteCharacteristics]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppSiteCharacteristics]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  