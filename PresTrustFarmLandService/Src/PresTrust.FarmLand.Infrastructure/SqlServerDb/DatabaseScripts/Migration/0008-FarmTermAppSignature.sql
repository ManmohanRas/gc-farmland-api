BEGIN TRY
	BEGIN TRANSACTION

		-- Drop Table
		DROP TABLE IF EXISTS Farm.#FarmTermAppSignature


		-- Create Table
		CREATE TABLE Farm.#FarmTermAppSignature(
			[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
			[ApplicationId]					[integer]						NOT NULL,
			[Designation]					[varchar](128)					NULL	,
			[Title]							[varchar](128)					NULL	, 
			[SignedOn]						[DateTime]						NULL	, 
			[LastUpdatedBy]					[varchar](128)					NULL	,--SignatoryType 
			[LastUpdatedOn]					[DateTime]						NOT NULL,
			
			);


		-- Certify
		INSERT INTO Farm.#FarmTermAppSignature([ApplicationId],[Designation],[Title], [SignedOn],[LastUpdatedBy],[LastUpdatedOn])
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

  
  