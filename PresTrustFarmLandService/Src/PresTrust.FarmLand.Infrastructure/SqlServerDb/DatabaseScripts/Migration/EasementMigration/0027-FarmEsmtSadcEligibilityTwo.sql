BEGIN TRY
BEGIN TRANSACTION

--DROP TABLE
DROP TABLE IF EXISTS #FarmEsmtSadcEligibilityTwo

--CREATE TABLE
CREATE TABLE #FarmEsmtSadcEligibilityTwo(
   [Id]													   [integer] 		IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                                         [integer]                       NOT NULL,
   [Prime]                                                 [decimal](10,2)                     NULL,
   [PrimeacresPct]                                         [decimal](10,2)                     NULL,   
   [Statewide]                                             [decimal](10,2)                     NULL,   
   [StatewideAcresPct]                                     [decimal](10,2)                     NULL,   
   [Local]                                                 [decimal](10,2)                     NULL,
   [LocalAcresPct]                                         [decimal](10,2)                     NULL, 
   [Unique]                                                [decimal](10,2)                     NULL,   
   [UniqueAcresPct]                                        [decimal](10,2)                     NULL,
   [UniqueSoils]                                           [varchar](4000)                     NULL,   
   [ListCropUniqueSoil]                                    [varchar](4000)                     NULL,   
   [Other]                                                 [varchar](4000)                     NULL,   
   [OtherAcresPct]                                         [decimal](10,2)                     NULL,   
   [TotalNetAcres]                                         [decimal](10,2)                     NULL,   
   [TotalNetAcresPct]                                      [decimal](10,2)                     NULL,
   [CroplandHarvested]                                     [decimal](10,2)                     NULL,
   [CroplandHarvestedPct]                                  [decimal](10,2)                     NULL,
   [CroplandPastured]                                      [decimal](10,2)                     NULL,
   [CroplandPasturedPct]                                   [decimal](10,2)                     NULL,
   [PermanentPasture]                                      [decimal](10,2)                     NULL,
   [PermanentPasturePct]                                   [decimal](10,2)                     NULL,
   [Woodlands]                                             [decimal](10,2)                     NULL,
   [WoodlandsPct]                                          [decimal](10,2)                     NULL,
   [ExceptionOther]                                        [varchar](4000)                     NULL,
   [ExceptionOtherPct]                                     [decimal](10,2)                     NULL,
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
   CONSTRAINT [PK_#FarmEsmtSadcEligibilityTwo_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtSadcEligibilityTwo
INSERT INTO #FarmEsmtSadcEligibilityTwo
            (
			  ApplicationId
			 ,Prime
			 ,PrimeacresPct
			 ,Statewide
			 ,StatewideAcresPct
			 ,[Local]
			 ,LocalAcresPct
			 ,[Unique]
			 ,UniqueAcresPct
			 ,UniqueSoils
			 ,ListCropUniqueSoil
			 ,Other
			 ,OtherAcresPct
			 ,TotalNetAcres
			 ,TotalNetAcresPct
			 ,CroplandHarvested
			 ,CroplandHarvestedPct
			 ,CroplandPastured
			 ,CroplandPasturedPct
			 ,PermanentPasture
			 ,PermanentPasturePct
			 ,Woodlands
			 ,WoodlandsPct
			 ,ExceptionOther
			 ,ExceptionOtherPct
			 ,ExceptionTotalNetAcres
			 ,ExceptionTotalNetAcresPct
			 ,ZoningCode
			 ,MinimumLotSize
			 ,Regional
			 ,IsHighlandsRegion
			 ,IsPreservation
			 ,IsPlanningArea
			 ,CountyaverageRank
			 ,LastUpdatedBy  
			 ,LastUpdatedOn 
			)
			SELECT
	          ProjectID  
			 ,NULL AS Prime
			 ,SoilsPrimePct
			 ,NULL AS Statewide
			 ,SoilsStatewidePct
			 ,NULL AS [Local]
			 ,SoilsLocalPct
			 ,NULL AS [Unique]
			 ,NULL AS UniqueAcresPct
			 ,NULL AS UniqueSoils
			 ,NULL AS ListCropUniqueSoil
			 ,NULL AS Other
			 ,NULL AS OtherAcresPct
			 ,NetAcres
			 ,100 AS TotalNetAcresPct
			 ,NULL AS CroplandHarvested
			 ,TillableAreaCropHarvestedPct
			 ,NULL AS CroplandPastured
			 ,PastureAreaPct
			 ,NULL AS PermanentPasture
			 ,PermanentPasturePct
			 ,NULL AS Woodlands
			 ,OtherWoodlandAreaPct
			 ,NULL AS ExceptionOther
			 ,NULL AS ExceptionOtherPct
			 ,NetAcres
			 ,100 AS ExceptionTotalNetAcresPct
             ,ZoningCurrent
             ,MinimunLotSize
             ,TRY_CAST(IsHighlands AS nvarchar(256)) AS Regional
			 ,IsHighlands
			 ,CASE
			      WHEN IsHighlandsCoreArea = 1 THEN 1
				  ELSE 0
              END AS IsPreservation
			 ,CASE
			      WHEN IsHighlandsCoreArea = 0 THEN 1
				  ELSE 0
              END AS IsPlanningArea
			 ,NULL AS CountyaverageRank
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application SADC Application Eligibility2 Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH