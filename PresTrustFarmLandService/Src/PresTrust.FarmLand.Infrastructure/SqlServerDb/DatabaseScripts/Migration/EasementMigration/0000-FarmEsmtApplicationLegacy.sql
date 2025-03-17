USE PresTrustTemp;

BEGIN TRY
   BEGIN TRANSACTION
       TRUNCATE TABLE [Farm].[FarmEsmtApplicationLegacy]
	   INSERT INTO [Farm].[FarmEsmtApplicationLegacy]
			(
				LegacyApplicationId,
				LegacyApplicationTitle,
				NewFarmListId,
				LegacyApplicationStatus,
				LegacyAgencyId,
				FarmApplicationId
			)
		  SELECT 
				OW.[ProjectId],
				ISNULL(OW.[ProjectName], ''),
				ISNULL(FL.[NewFarmListID], 0) AS [FarmListID],
				OW.[Status],
				ISNULL(OW.AgencyID,0) AS AgencyID,
				NULL AS [FarmApplicationId]
		 FROM   [Farm].[OwnerPropertyLEGACY_Rev02] OW
		 LEFT JOIN [Farm].[FarmListLegacy] FL ON OW.FarmListId = FL.LegacyFarmListId
		 WHERE OW.[Status] IS NOT NULL AND OW.[Status] != 'Targeted'


         COMMIT;
         PRINT 'Esmt application legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);
    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;
    SELECT @ErrorMessage;
END CATCH



 