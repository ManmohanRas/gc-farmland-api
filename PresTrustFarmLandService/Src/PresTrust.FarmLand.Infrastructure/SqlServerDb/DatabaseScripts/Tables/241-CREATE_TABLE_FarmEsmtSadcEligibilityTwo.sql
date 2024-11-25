IF OBJECT_ID('[FARM].[FarmEsmtSadcEligibilityTwo]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtSadcEligibilityTwo] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtSadcEligibilityTwo];
	ALTER TABLE [Farm].[FarmEsmtSadcEligibilityTwo] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcEligibilityTwo];
END;
GO
--DROP TABLE
DROP TABLE IF EXISTS [Farm].[FarmEsmtSadcEligibilityTwo]
GO
--CREATE TABLE
CREATE TABLE [Farm].[FarmEsmtSadcEligibilityTwo](
   [Id]													   [integer] 		IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                                         [integer]                       NOT NULL,
   [Prime]                                                 [decimal](10,2)                      NULL,
   [PrimeacresPct]                                         [decimal](10,2)                     NULL,   
   [Statewide]                                             [decimal](10,2)                      NULL,   
   [StatewideAcresPct]                                     [decimal](10,2)                     NULL,   
   [Local]                                                 [decimal](10,2)                      NULL,
   [LocalAcresPct]                                         [decimal](10,2)                     NULL, 
   [Unique]                                                [decimal](10,2)                      NULL,   
   [UniqueAcresPct]                                        [decimal](10,2)                     NULL,
   [UniqueSoils]                                           [varchar](4000)                     NULL,   
   [ListCropUniqueSoil]                                    [varchar](4000)                     NULL,   
   [Other]                                                 [varchar](4000)                     NULL,   
   [OtherAcresPct]                                         [decimal](10,2)                     NULL,   
   [TotalNetAcres]                                         [decimal](10,2)                     NULL,   
   [TotalNetAcresPct]                                      [decimal](10,2)                     NULL,
   [CroplandHarvested]                                     [decimal](10,2)                      NULL,
   [CroplandHarvestedPct]                                  [decimal](10,2)                     NULL,
   [CroplandPastured]                                      [decimal](10,2)                      NULL,
   [CroplandPasturedPct]                                   [decimal](10,2)                     NULL,
   [PermanentPasture]                                      [decimal](10,2)                      NULL,
   [PermanentPasturePct]                                   [decimal](10,2)                     NULL,
   [Woodlands]                                             [decimal](10,2)                      NULL,
   [WoodlandsPct]                                          [decimal](10,2)                     NULL,
   [ExceptionOther]                                        [varchar](4000)                     NULL,
   [ExceptionOtherPct]                                     [decimal](10,2)                      NULL,
   [ExceptionTotalNetAcres]                                [decimal](10,2)                     NULL,
   [ExceptionTotalNetAcresPct]                             [decimal](10,2)                     NULL,
   [ZoningCode]                                            [varchar](4000)                     NULL,   
   [MinimumLotSize]                                        [decimal](10,2)                     NULL,   
   [Regional]                                              [varchar](4000)                     NULL,   
   [IsHighlandsRegion]                                     [bit]                               NULL,   
   [IsPreservation]                                        [bit]                               NULL,   
   [IsPlanningArea]                                        [bit]                               NULL,   
   [CountyaverageRank]                                     [decimal](10,2)                     NULL,     
   [LastUpdatedBy]										   [varchar](128)		               NULL, 
   [LastUpdatedOn]										   [datetime]			           NOT NULL
   CONSTRAINT [PK_FarmEsmtSadcEligibilityTwo_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [Farm].[FarmEsmtSadcEligibilityTwo] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtSadcEligibilityTwo] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO
ALTER TABLE [Farm].[FarmEsmtSadcEligibilityTwo] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtSadcEligibilityTwo]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO