BEGIN TRY
	BEGIN TRANSACTION
	--==============================================================================================================--
	-- Drop Constraints

	ALTER TABLE [Farm].[FarmApplicationStatus] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationStatus]; 

	ALTER TABLE [Farm].[FarmApplicationSection] DROP CONSTRAINT IF EXISTS  [DF_FarmApplicationSection_Description];

	ALTER TABLE [Farm].[FarmApplicationSection] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationSection];
	
	ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS  [FK_SectionId_FarmApplicationDocumentType];
	
	ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationDocumentType]; 

	ALTER TABLE [Farm].[FarmApplicationCommentType] DROP CONSTRAINT IF EXISTS  [DF_FarmApplicationCommentType_Description];

	ALTER TABLE [Farm].[FarmApplicationCommentType] DROP CONSTRAINT IF EXISTS  [DF_FarmApplicationCommentType_IsActive];

	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationDocument];
		
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [FK_DocumentTypeId_FarmApplicationDocument];

	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_ShowCommittee_FarmApplicationDocument];
	
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_UseInReport_FarmApplicationDocument];
	
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationDocument];

	ALTER TABLE [Farm].[FarmApplicationBrokenRules] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationBrokenRules];

	ALTER TABLE [Farm].[FarmApplicationBrokenRules] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationBrokenRules];

	DROP INDEX IF EXISTS [IX_FarmApplicationBrokenRules_ApplicationId_SectionId] ON [Farm].[FarmApplicationBrokenRules];
	
	ALTER TABLE [Farm].[FarmApplicationComment] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationComment];

	ALTER TABLE [Farm].[FarmApplicationComment] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationComment];

	ALTER TABLE [Farm].[FarmApplicationFeedback] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationFeedback];

	ALTER TABLE [Farm].[FarmApplicationFeedback] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationFeedback];

	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS  [DF_IsPrimaryContact_FarmApplicationUser];

	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS  [DF_IsAlternateContact_FarmApplicationUser];
			
	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationUser];
	
	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS   [DF_FirstName_FarmApplicationUser];  
	
	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS   [DF_LastName_FarmApplicationUser]; 

	ALTER TABLE [Farm].[FarmTermAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppOwnerDetails];
		
	ALTER TABLE [Farm].[FarmTermAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppOwnerDetails];

	ALTER TABLE [Farm].[FarmTermAppAdminDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppAdminDetails];
	
	ALTER TABLE [Farm].[FarmTermAppAdminDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppAdminDetails];

	ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppSiteCharacteristics];
	
	ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppSiteCharacteristics];
	
	ALTER TABLE [Farm].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppDeedDetails];
	
	ALTER TABLE [Farm].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppDeedDetails];

	ALTER TABLE [Farm].[FarmTermAppSignature] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppSignature];
		
	ALTER TABLE [Farm].[FarmTermAppSignature] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppSignature];

	ALTER TABLE [Farm].[FarmTermAppAdminContact] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmTermAppAdminContact];

	ALTER TABLE [Farm].[FarmTermAppAdminContact] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_FarmTermAppAdminContact];

	ALTER TABLE [Farm].[FarmTermAppLocation] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppLocation];

	ALTER TABLE [Farm].[FarmTermAppLocation] DROP CONSTRAINT IF EXISTS  [DF_IsChecked_FarmTermAppLocation];

	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [FK_ParcelId_FarmParcelHistory];

	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmParcelHistory];

	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [DF_IsActive_FarmParcelHistory];

	ALTER TABLE [Farm].[FarmEmailTemplate] DROP CONSTRAINT IF EXISTS  [DF_IsActive_FarmEmailTemplate];

	ALTER TABLE [Farm].[FarmEmailTemplate] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEmailTemplate];
	
	---------------------------------------------------------------------------------------------------------------
	-- Drop Constraints Easement
	ALTER TABLE [Farm].[FarmEsmtAppStructure] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppStructure];
		
	ALTER TABLE [Farm].[FarmEsmtAppStructure] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppStructure];
	
	ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppOwnerDetails];
		
	ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppOwnerDetails];

	ALTER TABLE [Farm].[FarmEsmtAppExceptions] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppExceptions];
		
	ALTER TABLE [Farm].[FarmEsmtAppExceptions] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppExceptions];


	--==============================================================================================================--
	--SELECT 1/0;
	COMMIT;
	print 'SUCCESS';
END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000); 

	SET   @ErrorMessage = ERROR_MESSAGE();
	ROLLBACK;

	SELECT @ErrorMessage;	
END CATCH
