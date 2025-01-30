
 BEGIN TRY
	BEGIN TRANSACTION

	--===================================================================================================================================================

		DROP TABLE IF EXISTS #FarmList;
		CREATE TABLE #FarmList(
				[FarmListId]			[integer]			NOT NULL,
				[FarmNumber]		    [varchar](5)		NULL,                                                                                               
				[FarmName]				[varchar](50)		NULL,                        
				[Status]                [varchar](128)      NULL,                         
				[AgencyID]              [integer]           NULL,                       
				[OriginalLandowner]		[varchar](128)      NULL,                 
				[Address1]              [varchar](128)      NULL,                         
				[Address2]				[varchar](128)      NULL,	
				[MunicipalId]			[varchar](4)        NULL,
				[LastUpdatedBy]         [varchar](50)       NULL,
				[LastUpdatedOn]			[dateTime]          NOT NULL
		CONSTRAINT [PK_#FarmList_Id] PRIMARY KEY CLUSTERED
		(
			[FarmListId] ASC
		)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]
		  

		  INSERT INTO	#FarmList (
							[LegacyFarmListId],
							[FarmNumber],                                                                                               
							[FarmName],                        
							[Status],                         
							[AgencyID],                       
							[OriginalLandowner],                 
							[Address1],                         
							[Address2],	
							[MunicipalId],
							[LastUpdatedBy],
							[LastUpdatedOn]
							)
			SELECT		FarmListId,
						NULL AS [FarmNumber],
						TP.[FarmName],
						OP.[StatusId],
						ISNULL(TP.[AgencyID],0) AS [AgencyID],
						OP.[OriginalLandowner],
						[Address1],
						[Address2],
						[MunicipalId],
						NULL AS [LastUpdatedBy],
						GetDate() AS [LastUpdatedOn]
			    FROM  [Farm].[TermProgram_Legacy] TP
				LEFT JOIN [Farm].[OwnerProperty_Legacy] OP ON TP.FarmListId = OP.FarmListId;


				SET IDENTITY_INSERT [Farm].[FarmList] ON

				INSERT INTO Farm.FarmList
					(	[FarmListId],
						[FarmNumber],                                                                                               
						[FarmName],                        
						[Status],                         
						[AgencyID],                       
						[OriginalLandowner],                 
						[Address1],                         
						[Address2],	
						[MunicipalId],
						[LastUpdatedBy],
						[LastUpdatedOn]
					)
			    SELECT  [FarmListId],
						NULL AS [FarmNumber],
						TP.[FarmName],
						OP.[StatusId],
						ISNULL(TP.[AgencyID],0) AS [AgencyID],
						OP.[OriginalLandowner],
						[Address1],
						[Address2],
						[MunicipalId],
						NULL AS [LastUpdatedBy],
						GetDate() AS [LastUpdatedOn]
			         FROM  #FarmList;

					 SET IDENTITY_INSERT [Farm].[FarmList] OFF;

		
            COMMIT;
            PRINT 'Term application FarmList legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH