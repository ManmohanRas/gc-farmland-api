
 BEGIN TRY
	BEGIN TRANSACTION

	--===================================================================================================================================================
-- Drop Table
DROP TABLE IF EXISTS #FarmTermAppDeedDetails


-- Create Table
CREATE TABLE [Farm].[#FarmTermAppDeedDetails](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[ParcelId]						[integer]						NOT NULL,
	[NOTBook]						[varchar](50)					NULL,
	[NOTPage]						[varchar](50)					NULL,
	[RDBook]						[varchar](50)					NULL,
	[RDPage]						[varchar](50)					NULL,
	[IsChecked]						[bit]							NOT NULL,
	[LastUpdatedBy]					[varchar](128)					NULL, 
	[LastUpdatedOn]					[datetime]						NOT NULL, 
CONSTRAINT [PK_#FarmTermAppSiteCharacteristics_Id] PRIMARY KEY CLUSTERED
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


	   INSERT INTO [Farm].[FarmTermAppDeedDetails]
		(
			[ApplicationId],
			[ParcelId],
			[MunicipalityId],
			[QualificationCode],
			[Municipality],
			[OriginalBlock],
			[OriginalLot],
			[OriginalBook],	
			[OriginalPage],
			[NOTBook],
			[NOTPage],
			[RDBook],
			[RDPage],
			[IsChecked],
			[LastUpdatedBy],
			[LastUpdatedOn]
			)

	 SELECT 
			TL.[ID],
			DL.ParcelId AS [ParcelId],
			MBL.MunicipalityId,
			MBL.QualificationCode,
			CM.Municipality,
			MBL.Block,
			MBL.Lot,
			TL.[Orig Book],
			TL.[Orig Page],
			TL.[N-O-T Book] AS [NOTBook],
			TL.[N-O-T Page] AS [NOTPage],
			TL.[Renew Book] AS [RDBook],
			TL.[Renew Page] AS [RDPage],
			'1' AS [IsChecked],
			SUSER_NAME() AS [LastUpdatedBy],
			GetDate() AS [LastUpdatedOn]
		FROM  [Farm].[TermProgram_Legacy] TL
		LEFT JOIN Farm.FarmTermApplicationLegacy TAL ON TAL.LegacyApplicationId = TL.Id
		LEFT JOIN [Farm].[FarmTermAppDeedLocation] DL ON TAL.FarmApplicationId = DL.ApplicationId
		LEFT JOIN [Farm].FarmMunicipalityBlockLotParcel MBL ON MBL.Id = DL.ParcelId AND MBL.FarmListID = TAL.NewFarmListId
		LEFT JOIN [Core].[Municipality] CM ON (MBL.MunicipalityId = CM.MunicipalId AND CM.InCounty = 1)
	 WHERE MBL.Block IS NOT NULL AND MBL.LOT IS NOT NULL; 
            COMMIT;
            PRINT 'Term App Admin Deed details table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH