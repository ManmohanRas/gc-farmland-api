BEGIN TRY
   BEGIN TRANSACTION

   --Drop Table
   DROP TABLE #FarmApplication

  CREATE TABLE #FarmApplication
(
	[Id]								 [integer]              NOT NULL,                                                                                                                                            
    [Title]								 [varchar](256)         NOT NULL,                                                                                    
    [AgencyId]							 [integer]              NOT NULL,                                                                        
    [FarmListId]                         [integer]              NOT NULL,                                                                                                                                     
    [ApplicationTypeId]                  [integer]              NOT NULL,
	[StatusId]                           [integer]              NOT NULL, 
	[CreatedByProgramUser]               [bit]					NOT NULL,
	[IsApprovedByMunicipality]           [bit]					NOT NULL,
	[CreatedOn]                          [Datetime]             NOT NULL,
	[CreatedBy]                          [varchar](128)         NULL,    
	[IsActive]                           [bit]                  NULL,
	[IsSADC]                             [bit]                  NULL,
	[LastUpdatedBy]						 [varchar](128)		    NULL, 
	[LastUpdatedOn]						 [Datetime]				NOT NULL, 
CONSTRAINT [PK_#FarmApplication_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


		-- Insert From Legacy Table

        INSERT INTO #FarmApplication
		(
			[Id] ,
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
					[Id],
					[ProjectName] AS [Title], -- [ID]
					[AgencyId],
					[FarmListID],
					'1' AS [ApplicationTypeId],
					CASE WHEN [Status] = '5 Expired' THEN 106
						 WHEN [Status] = '4 Current' THEN 105
						 WHEN [Status] = '2 Petition Approved' THEN 103
						 END AS [StatusId],
					NULL AS [CreatedByProgramUser],
					[Municipally Approved?],
					NULL AS [CreatedOn],
					NULL AS [CreatedBy],
					1 AS [IsActive],
					NULL AS [IsSADC],
					NULL AS LastUpdatedBy,
					GetDate()
                FROM  [Farm].[TermProgram_Legacy] ;

-------------------------------------------------------------------------------------------------------
-------------------------------------------------------------------------------------------------------


	DECLARE		 @v_LEGACY_RECORD_COUNT	AS INT
				,@v_LEGACY_RECORD_INDEX AS INT;

	DROP TABLE IF EXISTS #temp_application_legacy;
	CREATE TABLE #temp_application_legacy (Id INT IDENTITY(1,1), LegacyApplicationId INTEGER)

	INSERT INTO		#temp_application_legacy (LegacyApplicationId)
	SELECT		LegacyApplicationId
	FROM		[Farm].[FarmApplicationLegacy]
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
					   AL.[ProjectName] AS [Title], -- [ID]
					   AL.[AgencyId],
					   AL.[FarmListID],
					   '1' AS [ApplicationTypeId],
					   CASE WHEN [AL.Status] = '5 Expired' THEN 106
					   	 WHEN [AL.Status] = '4 Current' THEN 105
					   	 WHEN [AL.Status] = '2 Petition Approved' THEN 103
					   	 END AS [StatusId],
					   NULL AS [CreatedByProgramUser],
					   [TL.Municipally Approved?],
					   NULL AS [CreatedOn],
					   NULL AS [CreatedBy],
					    1 AS [IsActive],
					   NULL AS [IsSADC],
					   NULL AS LastUpdatedBy,
					   GetDate()
			FROM  [Farm].[TermProgram_Legacy] TL
			LEFT JOIN [Farm].[FarmApplicationLegacy] AL ON TL.ID = AL.LegacyApplicationId 
			WHERE ID = @v_LEGACY_APPLICATION_ID

		
			SET @v_NEW_APPLICATION_ID = @@IDENTITY;

			UPDATE	[Farm].[FarmApplicationLegacy]
			SET FarmApplicationId = @v_NEW_APPLICATION_ID
			WHERE	LegacyApplicationId = @v_LEGACY_APPLICATION_ID;

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