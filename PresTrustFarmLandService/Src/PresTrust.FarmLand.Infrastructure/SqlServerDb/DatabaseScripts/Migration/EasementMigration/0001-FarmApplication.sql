BEGIN TRY
	BEGIN TRANSACTION

--===================================================================================================================================================

DECLARE		 @v_LEGACY_RECORD_COUNT	AS INT
			,@v_LEGACY_RECORD_INDEX AS INT;

DROP TABLE IF EXISTS #temp_application_legacyEsmt;
CREATE TABLE #temp_application_legacyEsmt (Id INT IDENTITY(1,1), LegacyApplicationId INTEGER)

INSERT INTO		#temp_application_legacyEsmt (LegacyApplicationId)
SELECT		LegacyApplicationId
FROM		[Farm].[FarmEsmtApplicationLegacy]
WHERE		ISNULL(FarmApplicationId,0) = 0;

SET	@v_LEGACY_RECORD_COUNT = @@ROWCOUNT;
SET	@v_LEGACY_RECORD_INDEX = 1;

WHILE (@v_LEGACY_RECORD_INDEX <= @v_LEGACY_RECORD_COUNT)
BEGIN
		DECLARE		@v_LEGACY_APPLICATION_ID AS INT,
					@v_NEW_APPLICATION_ID AS INT;

		SELECT		@v_LEGACY_APPLICATION_ID = LegacyApplicationId 
		FROM		#temp_application_legacyEsmt
		WHERE		ID = @v_LEGACY_RECORD_INDEX;

	--Farm Application
INSERT INTO Farm.FarmApplication
			(
			  Title
			 ,AgencyId
			 ,FarmListId
			 ,ApplicationTypeId
			 ,StatusId
			 ,CreatedByProgramUser
			 ,IsApprovedByMunicipality
			 ,CreatedOn
			 ,CreatedBy
			 ,IsActive
			 ,IsSADC
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
	        SELECT 
	          ISNULL(OW.ProjectName,'') AS ProjectName
	         ,ISNULL(OW.AgencyID,0) AS AgencyID
	         ,FL.NewFarmListID
	         ,2 AS ApplicationTypeId
	         ,CASE WHEN OW.Status = 'Dropped' THEN 207
	               WHEN OW.Status = 'Fee Simple Purchase' THEN 206
	               WHEN OW.Status = 'Ineligible' THEN 208
	         	   WHEN OW.Status = 'Pending' THEN 204
	         	   WHEN OW.Status = 'Preserved' THEN 206
				   --WHEN OW.STATUS = 'Transferred to MCPC' THEN   --- MAY BE CHANGE IN FUTURE
				   ELSE  0
	               END AS StatusId
             ,1 AS CreatedByProgramUser
	         ,0 AS IsApprovedByMunicipality
	         ,'01-01-1900' AS [CreatedOn]
	         ,NULL AS CreatedBy
	         ,1 AS IsActive
	         ,1 AS [IsSADC]
             ,SUSER_SNAME() AS LastUpdatedBy
             ,GetDate()
	         FROM [FARM].[OwnerPropertyLEGACY_Rev02] OW
	         JOIN [Farm].[FarmListLegacy] FL ON OW.FarmListID = FL.LegacyFarmListId 
	         WHERE OW.ProjectID = @v_LEGACY_APPLICATION_ID AND OW.[Status] IS NOT NULL 
			 AND OW.[Status] != 'Targeted'

			 SET @v_NEW_APPLICATION_ID = SCOPE_IDENTITY(); 
			 UPDATE	[Farm].[FarmEsmtApplicationLegacy]
             SET FarmApplicationId = @v_NEW_APPLICATION_ID
             WHERE	LegacyApplicationId = @v_LEGACY_APPLICATION_ID;


 SET @v_LEGACY_RECORD_INDEX = @v_LEGACY_RECORD_INDEX + 1;
END ;
		
		DROP TABLE IF EXISTS #temp_application_legacyEsmt;

	--Select 1/0 ;  -- To avoid accidental runs

	COMMIT;
	PRINT 'Legacy data migration has been completed.';
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000),@ErrorLine INT; 

	SET   @ErrorMessage = ERROR_MESSAGE() + ' ' + cast(@v_LEGACY_APPLICATION_ID as varchar);
	SET @ErrorLine = ERROR_LINE();
	ROLLBACK;

	SELECT @ErrorMessage AS ErrorMessage, @ErrorLine AS ErrorLine;
END CATCH