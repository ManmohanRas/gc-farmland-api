
 BEGIN TRY
	BEGIN TRANSACTION

	--===================================================================================================================================================

	DROP TABLE IF EXISTS Farm.#FarmList;

	CREATE TABLE Farm.#FarmList(
		  [Id]                 [int]                    NOT NULL
		 ,[FarmListID]         [int]                    NOT NULL
		 ,[ProjectID]          [int]                    NULL
		 ,[FarmNumber]         [varchar](5)             NULL
		 ,[TermID]             [int]                    NULL
		 ,[FarmName]           [varchar](128)           NULL
		 ,[ProjectName]        [varchar](128)           NULL
		 ,[Status]			   [varchar](50)            NULL
		 ,[AgencyID]           [int]                    NULL
		 ,[OriginalLandowner]  [varchar](128)           NULL
		 ,[Address1]           [varchar](256)           NULL
		 ,[Address2]           [varchar](128)           NULL
		 ,[MunicipalID]        [varchar](4)             NULL 
		 ,[LastUpdatedBy]	   [varchar](128)			NULL 
		 ,[LastUpdatedOn]	   [Datetime]				NOT NULL,    
	);

	        INSERT INTO Farm.#FarmList
		(
			[FarmListId],						                                                                                                                                             
			[ProjectID],	                                                                                    
			[FarmNumber],                                                                                               
			[TermID],                                                                                                                                                                
			[FarmName],                        
			[ProjectName],                      
			[Status],                         
			[AgencyID],                       
			[OriginalLandowner],                 
			[Address1],                         
			[Address2],	
			[MunicipalId],
			[LastUpdatedBy],
			[LastUpdatedOn]
			)
            SELECT 
					TP.[FarmListID],
					NULL AS [ProjectID], -- [ID]
					NULL AS [FarmNumber],
					TP.[ID] AS [TermID],
					TP.[FarmName],
					TP.[ProjectName],
					OP.[StatusId],
					ISNULL(TP.[AgencyID],0) AS [AgencyID],
					OP.[OriginalLandowner],
					[Address1],
					[Address2],
					[MunicipalId],
					NULL AS [LastUpdatedBy],
					GetDate() AS [LastUpdatedOn]
                FROM  [Farm].[TermProgram_Legacy] TP
				LEFT JOIN [Farm].[OwnerProperty_Legacy] OP ON TP.FarmListId = OP.FarmListId

            COMMIT;
            PRINT 'Term application FarmList legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH