BEGIN TRY
   BEGIN TRANSACTION

   --Drop Table
   DROP TABLE #FarmAppAdminContact

	CREATE TABLE #FarmAppAdminContact
	(
		[Id]					[integer]			IDENTITY(1,1)	NOT NULL,
		[ApplicationId]			[integer]							NOT NULL,
		[ContactName]			[varchar](76)						NULL,
		[Agency]				[varchar](128)						NULL,
		[Email]					[varchar](128)						NULL,
		[MainNumber]			[varchar](128)						NULL,
		[AlternateNumber]		[varchar](128)						NULL,
		[SelectContact]			[bit]								NULL,
		[LastUpdatedBy]			[varchar](128)						NULL	,
		[LastUpdatedOn]			[datetime]							NOT NULL,
	CONSTRAINT [PK_FarmAppAdminContact_Id] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

  
		-- Insert From Legacy Table

        INSERT INTO #FarmAppAdminContact
		(
			 [ApplicationId]			
			,[ContactName]			
			,[Agency]				
			,[Email]					
			,[MainNumber]			
			,[AlternateNumber]		
			,[SelectContact]			
			,[LastUpdatedBy]			
			,[LastUpdatedOn]			
			)
            SELECT 
					[Id],
					NULL AS [ContactName],
					NULL AS [Agency],
					NULL AS [Email],
					NULL AS [MainNumber],
					NULL AS [AlternateNumber],
					NULL AS [SelectContact],
					SUSER_NAME() AS [LastUpdatedBy],
					GetDate() AS [LastUpdatedOn]
                FROM  [Farm].[TermProgram_Legacy]  

            COMMIT;
            PRINT 'Term application contacts legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH

