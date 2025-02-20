USE PresTrustTemp;

BEGIN TRY
   BEGIN TRANSACTION
	
	   TRUNCATE TABLE [Farm].[FarmTermApplicationLegacy];
	   INSERT INTO [Farm].[FarmTermApplicationLegacy]
			(
				LegacyApplicationId,
				LegacyApplicationTitle,
				NewFarmListId,
				LegacyApplicationStatus,
				LegacyAgencyId,
				FarmApplicationId
			)
		  SELECT 
				TL.[Id],
				TL.[ProjectName],
				ISNULL(FL.[NewFarmListID], 0) AS [FarmListID],
				TL.[Status],
				TL.[AgencyID],
				NULL AS [FarmApplicationId]
		 FROM  [Farm].[TermProgram_Legacy] TL
		 LEFT JOIN [Farm].[FarmListLegacy] FL ON TL.FarmListId = FL.LegacyFarmListId; 


         COMMIT;
         PRINT 'Term application legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);
    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;
    SELECT @ErrorMessage;
END CATCH



 