BEGIN TRY
	BEGIN TRANSACTION
	--==============================================================================================================--
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_CreatedByProgramUser_FarmApplication];

	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplication];
	
	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_CreatedOn_FarmApplication];

	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_IsActive_FarmApplication];

	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_IsApprovedByMunicipality_FarmApplication];

	ALTER TABLE [Farm].[FarmApplicationStatus] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationStatus]; 

	ALTER TABLE [Farm].[FarmApplicationSection] DROP CONSTRAINT IF EXISTS  [DF_FarmApplicationSection_Description];

	ALTER TABLE [Farm].[FarmApplicationSection] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationSection];
	
	ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS  [FK_SectionId_FarmApplicationDocumentType];
	
	ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationDocumentType]; 

	ALTER TABLE [Farm].[FarmApplicationCommentType] DROP CONSTRAINT IF EXISTS  [DF_FarmApplicationCommentType_Description];

	ALTER TABLE [Farm].[FarmApplicationCommentType] DROP CONSTRAINT IF EXISTS  [DF_FarmApplicationCommentType_IsActive];

	ALTER TABLE [Farm].[FarmApplicationCommentType] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationCommentType]; 

	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationDocument];
		
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [FK_DocumentTypeId_FarmApplicationDocument];

	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_ShowCommittee_FarmApplicationDocument];
	
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_UseInReport_FarmApplicationDocument];
	
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationDocument];

	ALTER TABLE [Farm].FarmApplicationBrokenRules DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationBrokenRules];

	ALTER TABLE [Farm].FarmApplicationBrokenRules DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationBrokenRules];

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
	
	ALTER TABLE [Flood].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppDeedDetails];
	
	ALTER TABLE [Flood].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppDeedDetails];

	ALTER TABLE [Farm].[FarmTermAppSignature] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppSignature];
		
	ALTER TABLE [Farm].[FarmTermAppSignature] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppSignature];

	ALTER TABLE [Farm].[FarmTermAppAdminContacts] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmTermAppAdminContacts];

	ALTER TABLE [Farm].[FarmTermAppAdminContacts] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_FarmTermAppAdminContacts];

	
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
