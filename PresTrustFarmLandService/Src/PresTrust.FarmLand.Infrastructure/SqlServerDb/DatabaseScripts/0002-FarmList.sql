
 BEGIN TRY
	BEGIN TRANSACTION

	--===================================================================================================================================================

	DROP TABLE IF EXISTS [Farm].[#FarmList];

	CREATE TABLE [Farm].[#FarmList](
		  [Id]                 INT                     NOT NULL
		 ,[FarmListID]         INT                     NOT NULL
		 ,[ProjectID]          INT                     NULL
		 ,[FarmNumber]         VARCHAR(5)              NULL
		 ,[TermID]             INT                     NULL
		 ,[FarmName]           VARCHAR(128)            NULL
		 ,[ProjectName]        VARCHAR(128)            NULL
		 ,[Status]			   VARCHAR(50)             NULL
		 ,[AgencyID]           INT                     NULL
		 ,[OriginalLandowner]  VARCHAR(128)            NULL
		 ,[Address1]           VARCHAR(256)            NULL
		 ,[Address2]           VARCHAR(128)            NULL
		 ,[MunicipalID]        VARCHAR(4)              NULL 
	);

	        INSERT INTO [Farm].[#FarmList]
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
			[MunicipalId]				  
			)
            SELECT 
					[FarmListID],
					NULL AS [ProjectID], -- [ID]
					NULL AS [FarmNumber],
					NULL AS [TermID],
					[FarmName],
					NULL AS [ProjectName],
					[Status],
					ISNULL([AgencyID],0) AS [AgencyID],
					NULL AS [OriginalLandowner],
					[Address1],
					[Address2],
					[MunicipalId]
                FROM  [Farm].[TermProgram_Legacy]  

            COMMIT;
            PRINT 'Term application FarmList legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH