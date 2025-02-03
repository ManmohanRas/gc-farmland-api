BEGIN TRY
   BEGIN TRANSACTION

		TRUNCATE TABLE [Farm].[FarmListLegacy];
		INSERT INTO [Farm].[FarmListLegacy]
		(
			LegacyFarmListId,
			LegacyFarmName			
		)
		SELECT DISTINCT 
			FarmListId,
			ISNULL(FarmName, '')
		FROM [PresTrust_DEV].[Farm].[OwnerPropertyLEGACY_Rev02]
		WHERE ISNULL(FarmName,'') <> '' AND FarmlistID NOT IN (199, 95, 105)
		ORDER BY FarmListID;
		COMMIT;
		PRINT 'FarmList legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);
    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;

    SELECT @ErrorMessage;
END CATCH

