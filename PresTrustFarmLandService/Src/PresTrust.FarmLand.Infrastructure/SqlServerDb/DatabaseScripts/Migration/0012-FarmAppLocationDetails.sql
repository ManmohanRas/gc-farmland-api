BEGIN TRY
   BEGIN TRANSACTION

		TRUNCATE TABLE [Farm].[FarmAppLocationDetails];
		INSERT INTO Farm.FarmAppLocationDetails (
		ApplicationId,
		ParcelId,
		FarmListId,
		PamsPin,
		IsChecked
		)
		
		SELECT 
			FA.Id AS ApplicationId,
			MBL.Id AS ParcelId,
			FA.FarmListId AS FarmListId,
			MBL.PamsPin AS PamsPin,
			1 AS IsChecked
			FROM 
			 [Farm].[FarmMunicipalityBlockLotParcel] MBL
			JOIN   [Farm].[FarmApplication] FA ON(MBL.FarmListId = FA.FarmListId)
			Where FA.ApplicationTypeId = 1
			ORDER BY FA.Id
			

		COMMIT;
		PRINT 'Farm Location table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);
    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;

    SELECT @ErrorMessage;
END CATCH