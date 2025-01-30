BEGIN TRY
	BEGIN TRANSACTION

		-- Drop Table
		DROP TABLE IF EXISTS #FarmTermAppSignature


		-- Create Table
		CREATE TABLE #FarmTermAppSignature(
			[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
			[ApplicationId]					[integer]						NOT NULL,
			[Designation]					[varchar](128)					NULL	,
			[Title]							[varchar](128)					NULL	, 
			[SignedOn]						[DateTime]						NULL	, 
			[LastUpdatedBy]					[varchar](128)					NULL	,--SignatoryType 
			[LastUpdatedOn]					[DateTime]						NOT NULL,
CONSTRAINT [PK_#FarmTermAppSiteCharacteristics_Id] PRIMARY KEY CLUSTERED
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]



		-- Certify
		INSERT INTO #FarmTermAppSignature([ApplicationId],[Designation],[Title], [SignedOn],[LastUpdatedBy],[LastUpdatedOn])
		SELECT		  [Id] 
					, ISNULL(FirstName, '') + ' ' + ISNULL(LastName, '')
					, ISNULL(ProjectName,'')  
					, ISNULL([Renewal Date],[Enrollment Date]) 
					, 'CERTIFY_APPLICATION'
					, 'mc-support' 
					, GETDATE()
		FROM		[Farm].[TermProgram_LEGACY];


	COMMIT;
	PRINT 'Data Migrated successfully in Term Signature Table';
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000); 

	SET   @ErrorMessage = ERROR_MESSAGE();
	ROLLBACK;

	SELECT @ErrorMessage;
END CATCH

  
  