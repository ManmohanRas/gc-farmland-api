
BEGIN TRY
   BEGIN TRANSACTION

   --Drop Table
   TRUNCATE TABLE #FarmTermAppSiteCharacteristics

CREATE TABLE #FarmTermAppSiteCharacteristics
(
	[ApplicationId]						[integer]				    NOT NULL,                                                                                                                                            
    [Area]  							[varchar](50)               NULL,
	[LandUse]                           [varchar](128)              NULL,
    [CropLand]                          [varchar](50)               NULL,                                                                        
    [WoodLand]                          [varchar](50)               NULL,                                                                                                                                     
    [Pasture]                           [varchar](50)               NULL,
	[Orchard]                           [varchar](50)               NULL,
	[Other]                             [varchar](50)               NULL,
	[IsEasement]                        [bit]                       NULL,
	[IsRightOfway]                      [bit]                       NULL,
	[NoteEasementRightOfway]            [varchar](256)              NULL,
	[IsMortgage]                        [bit]                       NULL,
	[IsLines]                           [bit]                       NULL,
	[NoteMortgageLines]                 [varchar](256)              NULL,
	[LastUpdatedBy]					    [varchar](128)				NULL,
	[LastUpdatedOn]					    [datetime]					NULL,

CONSTRAINT [PK_#FarmTermAppSiteCharacteristics_Id] PRIMARY KEY CLUSTERED
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


--script to migrate legacy term application into bridge table FarmTermApplicationLegacy

  
		-- Insert From Legacy Table

        INSERT INTO #FarmTermAppSiteCharacteristics
		(
			[ApplicationId],
			[Area],  		
			[LandUse],     
			[CropLand],    
			[WoodLand],    
			[Pasture],     
			[Orchard],     
			[Other],       
			[IsEasement],  
			[IsRightOfway],
			[NoteEasementRightOfway],
			[IsMortgage],       
			[IsLines],          
			[NoteMortgageLines],
			[LastUpdatedBy],
			[LastUpdatedOn]
			)
            SELECT 
					[Id],
					LP.Acres AS [Area],
					NULL AS [LandUse],
					NULL AS [CropLand],
					NULL AS [WoodLand],
					NULL AS [Pasture],
					NULL AS [Orchard],
					NULL AS [Other],
					NULL AS [IsEasement],
					NULL AS [IsRightOfway],
					NULL AS [NoteEasementRightOfway],
					NULL AS [IsMortgage],
					NULL AS [IsLines],
					NULL AS  [NoteMortgageLines],
					SUSER_NAME() AS [LastUpdatedBy],
					GetDate() AS [LastUpdatedOn]
                FROM  [Farm].[TermProgram_Legacy]  TL
				LEFT JOIN
			   (
			    SELECT L.ApplicationId, SUM(MBL.AcresToBeAcquired) AS Acres
				FROM [Farm].[FarmMunicipalityBlockLotParcel]  AS MBL
			  LEFT JOIN [Farm].[FarmAppLocationDetails] AS L ON (MBL.Id = L.ParcelId AND L.Ischecked = 1)
			  GROUP BY L.ApplicationId
			   ) AS LP ON (TL.Id = LP.ApplicationId)

            COMMIT;
            PRINT 'Term application SiteCharacteristics legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH

