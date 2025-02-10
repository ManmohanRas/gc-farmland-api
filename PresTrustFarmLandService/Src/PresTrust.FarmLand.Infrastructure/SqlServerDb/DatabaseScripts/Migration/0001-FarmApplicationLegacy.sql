USE PresTrustTemp;

BEGIN TRY
   BEGIN TRANSACTION
   
	   INSERT INTO [Farm].[FarmTermApplicationLegacy]
			(
				LegacyApplicationId,
				LegacyApplicationTitle,
				LegacyFarmListId,
				LegacyApplicationStatus,
				LegacyAgencyId,
				FarmApplicationId
			)
		  SELECT 
				[Id],
				[ProjectName],
				ISNULL([FarmListID], 0) AS [FarmListID],
				[Status],
				[AgencyID],
				NULL AS [FarmApplicationId]
		 FROM  [Farm].[TermProgram_Legacy]
		 WHERE FarmListId NOT IN (116,187,271,276,277); 


         COMMIT;
         PRINT 'Term application legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);
    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;
    SELECT @ErrorMessage;
END CATCH



 