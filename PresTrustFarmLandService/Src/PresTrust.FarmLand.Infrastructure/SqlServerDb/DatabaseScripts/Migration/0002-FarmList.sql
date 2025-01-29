
 BEGIN TRY
	BEGIN TRANSACTION

	--===================================================================================================================================================

		

		DROP TABLE IF EXISTS [Farm].[LegacyFarmList];

		CREATE TABLE [Farm].[LegacyFarmList] (
			LegacyFarmListId    INT,
			LegacyFarmName      VARCHAR(128),
			NewFarmListId		INT,
		);

		INSERT INTO [Farm].[LegacyFarmList]
		(
			LegacyFarmListId,
			LegacyFarmName
		)
		SELECT
			LegacyFarmListId,
			LegacyFarmName
		FROM [Farm].[TermProgram_LEGACY];


		DECLARE
			@v_LEGACY_RECORD_COUNT INT,
			@v_LEGACY_RECORD_INDEX INT;

		DROP TABLE IF EXISTS #FarmList;
		CREATE TABLE #FarmList(
		  Id				   INTEGER IDENTITY(1,1), 
		  LegacyFarmListId     INTEGER
		  )

		  INSERT INTO		#FarmList (LegacyFarmListId)
SELECT		LegacyFarmListId
FROM		[Farm].[LegacyFarmList]
WHERE		ISNULL(NewFarmListId,0) = 0;

		

		--SET	@v_LEGACY_RECORD_COUNT = @@ROWCOUNT;
		--SET	@v_LEGACY_RECORD_INDEX = 1;

		--WHILE (@v_LEGACY_RECORD_INDEX <= @v_LEGACY_RECORD_COUNT)
		--BEGIN

		--	DECLARE
		--		@v_LEGACY_FARMLIST_ID INT,
		--		@v_NEW_FARMLIST_ID INT;

		--	SELECT
		--		@v_LEGACY_FARMLIST_ID = LegacyFarmListId 
		--	FROM		[LegacyFarmList]
		--	WHERE		ID = @v_LEGACY_RECORD_INDEX;


	

	 --       INSERT INTO Farm.FarmList
		--(
		--	[FarmNumber],                                                                                               
		--	[FarmName],                        
		--	[Status],                         
		--	[AgencyID],                       
		--	[OriginalLandowner],                 
		--	[Address1],                         
		--	[Address2],	
		--	[MunicipalId],
		--	[LastUpdatedBy],
		--	[LastUpdatedOn]
		--	)
  --          SELECT 
		--			NULL AS [FarmNumber],
		--			TP.[FarmName],
		--			OP.[StatusId],
		--			ISNULL(TP.[AgencyID],0) AS [AgencyID],
		--			OP.[OriginalLandowner],
		--			[Address1],
		--			[Address2],
		--			[MunicipalId],
		--			NULL AS [LastUpdatedBy],
		--			GetDate() AS [LastUpdatedOn]
  --              FROM  [Farm].[TermProgram_Legacy] TP
		--		LEFT JOIN [Farm].[OwnerProperty_Legacy] OP ON TP.FarmListId = OP.FarmListId;

		--	SET @v_NEW_FARMLIST_ID = @@IDENTITY;

		--	UPDATE	[Farm].[LegacyFarmList]
		--	SET   NewFarmListId  = @v_NEW_FarmList_ID
		--	WHERE	LegacyFarmListId = @v_LEGACY_FARMLIST_ID;
				


			END;
            COMMIT;
            PRINT 'Term application FarmList legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH