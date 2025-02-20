BEGIN TRY
   BEGIN TRANSACTION
   
-------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------


	DECLARE		 @v_LEGACY_RECORD_COUNT	AS INT
				,@v_LEGACY_RECORD_INDEX AS INT;

	DROP TABLE IF EXISTS #temp_application_legacy;
	CREATE TABLE #temp_application_legacy (Id INT IDENTITY(1,1), LegacyApplicationId INTEGER)

	INSERT INTO		#temp_application_legacy (LegacyApplicationId)
	SELECT		LegacyApplicationId
	FROM		[Farm].[FarmTermApplicationLegacy]
	WHERE		ISNULL(FarmApplicationId,0) = 0;

	SET	@v_LEGACY_RECORD_COUNT = @@ROWCOUNT;
	SET	@v_LEGACY_RECORD_INDEX = 1;

	WHILE (@v_LEGACY_RECORD_INDEX <= @v_LEGACY_RECORD_COUNT)
	BEGIN
			DECLARE		@v_LEGACY_APPLICATION_ID AS INT,
						@v_NEW_APPLICATION_ID AS INT;

			SELECT		@v_LEGACY_APPLICATION_ID = LegacyApplicationId 
			FROM		#temp_application_legacy
			WHERE		ID = @v_LEGACY_RECORD_INDEX;



	 INSERT INTO [Farm].[FarmApplication]
				(	
					[Title],
					[AgencyId],
					[FarmListId],
					[ApplicationTypeId],
					[StatusId],
					[CreatedByProgramUser],
					[IsApprovedByMunicipality] ,
					[CreatedOn],
					[CreatedBy],
					[IsActive],
					[IsSADC],
					[LastUpdatedBy],
					[LastUpdatedOn]
					)
					SELECT 
					   TL.[ProjectName] AS [Title], -- [ID]
					   TL.[AgencyId],
					   AL.NewFarmListId,
					   '1' AS [ApplicationTypeId],
					   CASE WHEN TL.[Status] = '5 Expired' THEN 106
					   	 WHEN TL.[Status] = '4 Current' THEN 105
					   	 WHEN TL.[Status] = '2 Petition Approved' THEN 103
					   	 END AS [StatusId],
					   1 AS [CreatedByProgramUser],
					   TL.[Municipally Approved?],
					   '01-01-1900' AS [CreatedOn],
					   NULL AS [CreatedBy],
					    1 AS [IsActive],
					   NULL AS [IsSADC],
					   NULL AS LastUpdatedBy,
					   GetDate()
			FROM  [Farm].[TermProgram_Legacy] TL
			 JOIN [Farm].[FarmListLegacy] AL ON TL.FarmListID = AL.LegacyFarmListId 
		WHERE ID = @v_LEGACY_APPLICATION_ID 

		
			SET @v_NEW_APPLICATION_ID = SCOPE_IDENTITY();

			UPDATE	[Farm].[FarmTermApplicationLegacy]
			SET FarmApplicationId = @v_NEW_APPLICATION_ID
			WHERE	LegacyApplicationId = @v_LEGACY_APPLICATION_ID;

			 SET @v_LEGACY_RECORD_INDEX = @v_LEGACY_RECORD_INDEX + 1;

END;
						

            COMMIT;
            PRINT 'Application table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH