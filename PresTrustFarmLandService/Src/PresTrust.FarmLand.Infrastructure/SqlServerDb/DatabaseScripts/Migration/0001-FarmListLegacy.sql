use prestrustTemp;
BEGIN TRY
   BEGIN TRANSACTION

		TRUNCATE TABLE [Farm].[FarmListLegacy];
		INSERT INTO Farm.FarmlistLegacy (LegacyFarmListId,LegacyFarmName)
		SELECT DISTINCT FarmListId,FarmName
		FROM [Farm].[OwnerPropertyLEGACY_Rev02] 

		UNION ALL

		SELECT DISTINCT FarmListId,FarmName
		FROM [Farm].[TermProgram_LEGACY]
		WHERE FarmListID NOT IN (SELECT FarmListID FROM [Farm].[OwnerPropertyLEGACY_Rev02] )

		COMMIT;
		PRINT 'FarmList legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);
    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;

    SELECT @ErrorMessage;
END CATCH
