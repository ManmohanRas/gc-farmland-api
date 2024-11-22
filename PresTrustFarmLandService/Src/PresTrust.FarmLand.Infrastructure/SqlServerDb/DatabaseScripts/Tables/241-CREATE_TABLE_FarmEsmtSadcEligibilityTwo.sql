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
   [Prime]                                                 [varchar](128)                      NULL,
   [PrimeacresPct]                                         [decimal](10,2)                     NULL,   
   [Statewide]                                             [varchar](128)                      NULL,   
   [StatewideAcresPct]                                     [decimal](10,2)                     NULL,   
   [Local]                                                 [varchar](128)                      NULL,
   [LocalAcresPct]                                         [decimal](10,2)                     NULL, 
   [Unique]                                                [varchar](128)                      NULL,   
   [UniqueAcresPct]                                        [decimal](10,2)                     NULL,
   [UniqueSoils]                                           [varchar](4000)                     NULL,   
   [ListCropUniqueSoil]                                    [varchar](4000)                     NULL,   
   [Other]                                                 [varchar](4000)                     NULL,   
   [OtherAcresPct]                                         [decimal](10,2)                     NULL,   
   [TotalNetAcres]                                         [varchar](4000)                     NULL,   
   [TotalNetAcresPct]                                      [decimal](10,2)                     NULL,
   [CroplandHarvested]                                     [varchar](128)                      NULL,
   [CroplandHarvestedPct]                                  [decimal](10,2)                     NULL,
   [CroplandPastured]                                      [varchar](128)                      NULL,
   [CroplandPasturedPct]                                   [decimal](10,2)                     NULL,
   [PermanentPasture]                                      [varchar](128)                      NULL,
   [PermanentPasturePct]                                   [decimal](10,2)                     NULL,
   [Woodlands]                                             [varchar](128)                      NULL,
   [WoodlandsPct]                                          [decimal](10,2)                     NULL,
   [ExceptionOther]                                        [varchar](4000)                     NULL,
   [ExceptionOtherPct]                                     [decimal](10,2)                      NULL,
   [ExceptionTotalNetAcres]                                [varchar](4000)                     NULL,
   [ExceptionTotalNetAcresPct]                             [decimal](10,2)                     NULL,
   [ZoningCode]                                            [varchar](4000)                     NULL,   
   [MinimumLotSize]                                        [varchar](4000)                     NULL,   
   [Regional]                                              [varchar](4000)                     NULL,   
   [IsHighlandsRegion]                                     [bit]                               NULL,   
   [IsPreservation]                                        [bit]                               NULL,   
   [IsPlanningArea]                                        [bit]                               NULL,   
   [CountyaverageRank]                                     [varchar](4000)                     NULL,     
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