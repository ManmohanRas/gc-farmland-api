Use PresTrustTemp;

BEGIN TRY
	BEGIN TRANSACTION

--===================================================================================================================================================

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

	--Farm Application

INSERT INTO Farm.FarmApplication
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
			[ProjectName] AS [Title], -- [ID]
			[AgencyId],
			AL.[NewFarmListID],
			'1' AS [ApplicationTypeId],
			CASE WHEN [Status] = '5 Expired' THEN 106
				 WHEN [Status] = '4 Current' THEN 105
				 WHEN [Status] = '2 Petition Approved' THEN 103
				 END AS [StatusId],
			1 AS [CreatedByProgramUser],
			[Municipally Approved?],
			'01-01-1900' AS [CreatedOn],
			NULL AS [CreatedBy],
			1 AS [IsActive],
			NULL AS [IsSADC],
			SUSER_SNAME() AS LastUpdatedBy,
			GetDate()
        FROM  [Farm].[TermProgram_Legacy] TL
	   JOIN [Farm].[FarmListLegacy] AL ON TL.FarmListID = AL.LegacyFarmListId 
		WHERE ID = @v_LEGACY_APPLICATION_ID

		
			SET @v_NEW_APPLICATION_ID = SCOPE_IDENTITY();

			UPDATE	[Farm].[FarmTermApplicationLegacy]
			SET FarmApplicationId = @v_NEW_APPLICATION_ID
			WHERE	LegacyApplicationId = @v_LEGACY_APPLICATION_ID;
			
		---Farm owner details 
		-- Insert From Legacy Table

		INSERT INTO [Farm].[FarmAppOwnerDetailList]
		(
			[ApplicationId],
			[FirstName],                                                                                                                                            
			[LastName],                                                                                    
			[MunicipalityId],                                                                                                                                                        
			[MailingAddress1],                   
			[MailingAddress2],                   
			[PhoneNumber],                       
			[City],                             
			[State],                            
			[ZipCode],
			[Salutation],
			[EmailAddress],
			[CurrentOwnerMailingName],
			[LastUpdatedBy],
			[LastUpdatedOn]
			)
			SELECT 
					@v_NEW_APPLICATION_ID,
					[FirstName],
					[LastName],
					[MunicipalID],
					ISNULL([Address1],' ') AS [MailingAddress1],
					ISNULL([Address2],' ') AS [MailingAddress2],
					[Phone] AS [PhoneNumber],
					ISNULL([Town],' ') AS [City], 
					ISNULL([State],' '),
					ISNULL([Zip Code],0),
					[Salutation],  
					[Email], 
					CONCAT([FirstName],' ',[LastName]) AS  [CurrentOwnerMailingName],  
					NULL AS [LastUpdatedBy],
					GetDate()
				FROM  [Farm].[TermProgram_Legacy]
				WHERE [Id] = @v_LEGACY_APPLICATION_ID;

	--			--Site Characteristics Tab

				INSERT INTO [Farm].[FarmTermAppSiteCharacteristics]
			(
				[ApplicationId],
				[Area],  		
				[LandUse],     
				[CropLand],    
				[WoodLand],    
				[Pasture],     
				[Orchard],     
				[Other],       
				[IsEasement],  
				[IsRightOfway],
				[NoteEasementRightOfway],
				[IsMortgage],       
				[IsLiens],          
				[NoteMortgageLiens]
				)
				SELECT 
						@v_NEW_APPLICATION_ID,
						NULL AS [Area],
						NULL AS [LandUse],
						NULL AS [CropLand],
						NULL AS [WoodLand],
						NULL AS [Pasture],
						NULL AS [Orchard],
						NULL AS [Other],
						NULL AS [IsEasement],
						NULL AS [IsRightOfway],
						NULL AS [NoteEasementRightOfway],
						NULL AS [IsMortgage],
						NULL AS [IsLines],
						NULL AS  [NoteMortgageLines]
					FROM  [Farm].[TermProgram_Legacy] 
					WHERE [Id] = @v_LEGACY_APPLICATION_ID;

	--	--Signatory Tab
		
		INSERT INTO [Farm].[FarmTermAppSignature](
					[ApplicationId],
					[Designation],
					[Title],
					[SignedOn],
					[LastUpdatedBy],
					[LastUpdatedOn]
					)
			SELECT	@v_NEW_APPLICATION_ID 
					, ISNULL(FirstName, '') + ' ' + ISNULL(LastName, '')
					, ISNULL(ProjectName,'')  
					, ISNULL([Renewal Date],[Enrollment Date]) 
					, 'mc-support' 
					, GETDATE()
					FROM	[Farm].[TermProgram_LEGACY]
					WHERE [Id] = @v_LEGACY_APPLICATION_ID

	--		--Admin Details
		INSERT INTO [Farm].[FarmTermAppAdminDetails]
					(
						[ApplicationId],						                                                                                                                                             
						[SADCId],	                                                                                    
						[MaxGrant],                                                                                               
						[PermanentlyPreserved],                                                                                                                                                                
						[EnrollmentDate],                      
						[RenewalDate],                         
						[ExpirationDate],                       
						[RenewalExpirationDate],                 
						[Comment],                         
						[LastUpdatedBy],	
						[LastUpdatedOn]
			        )
		 SELECT 
						@v_NEW_APPLICATION_ID,
						[SADC ID#] AS [SADCId], -- [ID]
						[Max Grant $] AS [MaxGrant],
						[Permanently Preserved?] AS [PermanentlyPreserved],
						[Enrollment Date] AS [EnrollmentDate],
						[Renewal Date] AS [RenewalDate],
						[Expiration Date] AS [ExpirationDate],
						[Renew Expir Date] AS [RenewalExpirationDate],
						[Comment],
						NULL AS LastUpdatedBy,
						GetDate() AS [LastUpdatedOn]
					  FROM  [Farm].[TermProgram_Legacy] 
					  WHERE [Id] = @v_LEGACY_APPLICATION_ID;

	--			

	--	--Admin Contacts
		 INSERT INTO [Farm].[FarmAppAdminContact]
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
				@v_NEW_APPLICATION_ID,
				NULL AS [ContactName],
				NULL AS [Agency],
				NULL AS [Email],
				NULL AS [MainNumber],
				NULL AS [AlternateNumber],
				NULL AS [SelectContact],
				NULL AS [LastUpdatedBy],
				GetDate() AS [LastUpdatedOn]
         FROM  [Farm].[TermProgram_Legacy] 
		 WHERE [Id] = @v_LEGACY_APPLICATION_ID;
		 
		 -------------------------------------------------------


		   SET @v_LEGACY_RECORD_INDEX = @v_LEGACY_RECORD_INDEX + 1;
END ;
		
		DROP TABLE IF EXISTS #temp_application_legacy;

	--Select 1/0 ;  -- To avoid accidental runs

	COMMIT;
	PRINT 'Legacy data migration has been completed.';
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000); 

	SET   @ErrorMessage = ERROR_MESSAGE() + ' ' + cast(@v_LEGACY_APPLICATION_ID as varchar);
	ROLLBACK;

	SELECT @ErrorMessage;
END CATCH