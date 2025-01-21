BEGIN TRY
	BEGIN TRANSACTION
	--==============================================================================================================--
	-- Drop Constraints

	ALTER TABLE [Farm].[FarmApplicationType] DROP CONSTRAINT IF EXISTS  [PK_FarmApplicationType_Id];

	ALTER TABLE [Farm].[FarmApplicationStatus] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationStatus]; 
	ALTER TABLE [Farm].[FarmApplicationStatus] DROP CONSTRAINT IF EXISTS  [PK_FarmApplicationStatus_Id];


	ALTER TABLE [Farm].[FarmApplicationSection] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationSection];
	ALTER TABLE [Farm].[FarmApplicationSection] DROP CONSTRAINT IF EXISTS  [PK_FarmApplicationSection_Id];
	
	ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS  [FK_SectionId_FarmApplicationDocumentType];
	ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS [PK_FarmApplicationDocumentType_Id];
	ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationDocumentType]; 
	

	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationDocument];
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS [PK_FarmApplicationDocument_Id];
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [FK_DocumentTypeId_FarmApplicationDocument];



	ALTER TABLE [Farm].[FarmApplicationComment] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationComment];
	ALTER TABLE [Farm].[FarmApplicationComment] DROP CONSTRAINT IF EXISTS  [PK_FarmApplicationComment_Id];
	ALTER TABLE [Farm].[FarmAppCommentType] DROP CONSTRAINT IF EXISTS [PK_FarmAppCommentType_Id];

	ALTER TABLE [Farm].[FarmApplicationFeedback] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationFeedback];
	ALTER TABLE [Farm].[FarmApplicationFeedback] DROP CONSTRAINT IF EXISTS [PK_FarmApplicationFeedback_Id];

	ALTER TABLE [Farm].[FarmTermAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppOwnerDetails];
	ALTER TABLE [Farm].[FarmTermAppOwnerDetails] DROP CONSTRAINT IF EXISTS [PK_FarmTermAppOwnerDetails_Id];
		

	ALTER TABLE [Farm].[FarmTermAppAdminDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppAdminDetails];
	ALTER TABLE [Farm].[FarmTermAppAdminDetails] DROP CONSTRAINT IF EXISTS [PK_FarmTermAppAdminDetails_Id];
	

	ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppSiteCharacteristics];
	ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] DROP CONSTRAINT IF EXISTS [PK_FarmTermAppSiteCharacteristics_Id];
	
	
	ALTER TABLE [Farm].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppDeedDetails];
	ALTER TABLE [Farm].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS [PK_FarmTermAppDeedDetails_Id];
	

	ALTER TABLE [Farm].[FarmTermAppSignature] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppSignature];
	ALTER TABLE [Farm].[FarmTermAppSignature] DROP CONSTRAINT IF EXISTS [PK_FarmTermAppSignature_Id];
		

	ALTER TABLE [Farm].[FarmTermAppAdminContact] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmTermAppAdminContact];
	ALTER TABLE [Farm].[FarmTermAppAdminContact] DROP CONSTRAINT IF EXISTS [PK_FarmTermAppAdminContact_Id];

	ALTER TABLE [Farm].[FarmTermAppLocation] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppLocation];
	ALTER TABLE [Farm].[FarmTermAppLocation] DROP CONSTRAINT IF EXISTS  [DF_IsChecked_FarmTermAppLocation];



	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [FK_ParcelId_FarmParcelHistory];
	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS [PK_FarmParcelHistory_Id]


	ALTER TABLE [Farm].[FarmApplicationBrokenRules] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationBrokenRules];

	---------------------------------------------------------------------------------------------------------------
	-- Drop Constraints Easement
	ALTER TABLE [Farm].[FarmEsmtAppStructure] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppStructure];
	ALTER TABLE [Farm].[FarmEsmtAppStructure] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppStructure];
	ALTER TABLE [Farm].[FarmEsmtAppStructure] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAppStructure_Id];
		
	
	ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppOwnerDetails];
	ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppOwnerDetails];
	ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAppOwnerDetails_Id];

		

	ALTER TABLE [Farm].[FarmEsmtAppExceptions] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppExceptions];
	ALTER TABLE [Farm].[FarmEsmtAppExceptions] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppExceptions];
	ALTER TABLE [Farm].[FarmEsmtAppExceptions] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAppExceptions_Id];
		

	ALTER TABLE [Farm].[FarmEsmtLiens] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtLiens];
	ALTER TABLE [Farm].[FarmEsmtLiens] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtLiens];
	ALTER TABLE [Farm].[FarmEsmtLiens] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtLiens_Id];


	ALTER TABLE [Farm].[FarmEsmtAppSignatory] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAppSignatory_Id];
	ALTER TABLE [Farm].[FarmEsmtAppSignatory] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppSignatory];
	ALTER TABLE [Farm].[FarmEsmtAppSignatory] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppSignatory];

	ALTER TABLE [Farm].[FarmEsmtExistNonAgriUses] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtExistNonAgriUses_Id];
	ALTER TABLE [Farm].[FarmEsmtExistNonAgriUses] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtExistNonAgriUses];
	ALTER TABLE [Farm].[FarmEsmtExistNonAgriUses] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtExistNonAgriUses];


	ALTER TABLE [Farm].[FarmEsmtExceptionsAttachmentB] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtExceptionsAttachmentB_Id];
	ALTER TABLE [Farm].[FarmEsmtExceptionsAttachmentB] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtExceptionsAttachmentB];
	ALTER TABLE [Farm].[FarmEsmtExceptionsAttachmentB] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtExceptionsAttachmentB];

	ALTER TABLE [Farm].[FarmEsmtAttachmentC] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAttachmentC_Id];
	ALTER TABLE [Farm].[FarmEsmtAttachmentC] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAttachmentC];
	ALTER TABLE [Farm].[FarmEsmtAttachmentC] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAttachmentC];

	ALTER TABLE [Farm].[FarmEsmtAttachmentA] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAttachmentA_Id];
	ALTER TABLE [Farm].[FarmEsmtAttachmentA] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAttachmentA];
    ALTER TABLE [Farm].[FarmEsmtAttachmentA] DROP CONSTRAINT IF EXISTS  [DF_IsOfferPriceIndicated_FarmEsmtAttachmentA];
	ALTER TABLE [Farm].[FarmEsmtAttachmentA] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAttachmentA];

	ALTER TABLE [Farm].[FarmEsmtAppAttachmentE] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAppAttachmentE_Id];
	ALTER TABLE [Farm].[FarmEsmtAppAttachmentE] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAttachmentE];
	ALTER TABLE [Farm].[FarmEsmtAppAttachmentE] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAppAttachmentE];

	ALTER TABLE [Farm].[FarmEsmtAttachmentD] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAttachmentD];
	ALTER TABLE [Farm].[FarmEsmtAttachmentD] DROP CONSTRAINT IF EXISTS  [FK_EquineActivityTypeId_FarmEsmtAttachmentD];
	ALTER TABLE [Farm].[FarmEsmtAttachmentD] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAttachmentD];
	ALTER TABLE [Farm].[FarmEsmtAttachmentD] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAttachmentD_Id];

	ALTER TABLE [Farm].[FarmEsmtAttachmentDActivityType] DROP CONSTRAINT IF EXISTS [PK_FarmEsmtAttachmentDActivityType_Id];

	ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmAgriculturalEnterpriseChecklist];
	ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] DROP CONSTRAINT IF EXISTS  [FK_ActivitySubTypeId_FarmAgriculturalEnterpriseChecklist];
	ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmAgriculturalEnterpriseChecklist];
	ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] DROP CONSTRAINT IF EXISTS  [PK_FarmAgriculturalEnterpriseChecklist_Id];

	ALTER TABLE [Farm].[FarmEsmtAgriculturalAndProduction] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAgriculturalAndProduction];
	ALTER TABLE [Farm].[FarmEsmtAgriculturalAndProduction] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAgriculturalAndProduction];
	ALTER TABLE [Farm].[FarmEsmtAgriculturalAndProduction] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAgriculturalAndProduction_Id];

	ALTER TABLE [Farm].[FarmEsmtAgricultureProdSourceType] DROP CONSTRAINT IF EXISTS [PK_FarmEsmtAgricultureProdSourceType_Id];

	ALTER TABLE [Farm].[FarmEsmtAppAdminSADC] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAppAdminSADC];
	ALTER TABLE [Farm].[FarmEsmtAppAdminSADC] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_FarmEsmtAppAdminSADC];
	ALTER TABLE [Farm].[FarmEsmtAppAdminSADC] DROP CONSTRAINT IF EXISTS [PK_FarmEsmtAppAdminSADC_Id];

	ALTER TABLE [Farm].[FarmTermAppDeedLocation] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppDeedLocation];
	ALTER TABLE [Farm].[FarmTermAppDeedLocation] DROP CONSTRAINT IF EXISTS  [DF_IsChecked_FarmTermAppDeedLocation];

	ALTER TABLE [Farm].[FarmEsmtAppAdminOfferCost] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAppAdminOfferCost];
	ALTER TABLE [Farm].[FarmEsmtAppAdminOfferCost] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminOfferCost];
	ALTER TABLE [Farm].[FarmEsmtAppAdminOfferCost] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAppAdminOfferCost_Id];

	ALTER TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAppAdminExceptionRDSO];
	ALTER TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_FarmEsmtAppAdminExceptionRDSO];
	ALTER TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] DROP CONSTRAINT IF EXISTS [PK_FarmEsmtAppAdminExceptionRDSO_Id];

	ALTER TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminClosingDocStatus];
	ALTER TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminClosingDocStatus];
	ALTER TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAppAdminClosingDocStatus_Id];

	ALTER TABLE [Farm].[FarmEsmtAppAdminCostDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminCostDetails];
	ALTER TABLE [Farm].[FarmEsmtAppAdminCostDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminCostDetails];
	ALTER TABLE [Farm].[FarmEsmtAppAdminCostDetails] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAppAdminCostDetails_Id];

	ALTER TABLE [Farm].[FarmEsmtAppAdminAppraisalReport] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminAppraisalReport ];
	ALTER TABLE [Farm].[FarmEsmtAppAdminAppraisalReport] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminAppraisalReport ];
	ALTER TABLE [Farm].[FarmEsmtAppAdminAppraisalReport] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAppAdminAppraisalReport _Id];

	ALTER TABLE [Farm].[FarmEsmtAppAdminDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminDetails];
	ALTER TABLE [Farm].[FarmEsmtAppAdminDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminDetails];
	ALTER TABLE [Farm].[FarmEsmtAppAdminDetails] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAppAdminDetails_Id];

	ALTER TABLE [Farm].[FarmEsmtSadcHistory] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtSadcHistory];
	ALTER TABLE [Farm].[FarmEsmtSadcHistory] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcHistory];
	ALTER TABLE [Farm].[FarmEsmtSadcHistory] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtSadcHistory_Id];
	
	ALTER TABLE [Farm].[FarmEsmtSadcEligibility] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtSadcEligibility ];
	ALTER TABLE [Farm].[FarmEsmtSadcEligibility] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcEligibility ];
	ALTER TABLE [Farm].[FarmEsmtSadcEligibility] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtSadcEligibility _Id];

	ALTER TABLE [Farm].[FarmEsmtSadcFarmInfo] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtSadcFarmInfo];
	ALTER TABLE [Farm].[FarmEsmtSadcFarmInfo] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcFarmInfo];
	ALTER TABLE [Farm].[FarmEsmtSadcFarmInfo] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtSadcFarmInfoC_Id];

	ALTER TABLE [Farm].[FarmEsmtSadcEligibilityTwo] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtSadcEligibilityTwo];
	ALTER TABLE [Farm].[FarmEsmtSadcEligibilityTwo] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcEligibilityTwo];
	ALTER TABLE [Farm].[FarmEsmtSadcEligibilityTwo] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtSadcEligibilityTwo_Id];

	ALTER TABLE [Farm].[FarmEsmtSadcResidence] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtSadcResidence];
	ALTER TABLE [Farm].[FarmEsmtSadcResidence] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcResidence];
	ALTER TABLE [Farm].[FarmEsmtSadcResidence] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtSadcResidence_Id];

	ALTER TABLE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminStructNonAgriWetlands];
	ALTER TABLE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminStructNonAgriWetlands];
	ALTER TABLE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands] DROP CONSTRAINT IF EXISTS  [PK_FarmEsmtAppAdminStructNonAgriWetlands_Id];

	ALTER TABLE [Farm].[FarmEmailTemplate] DROP CONSTRAINT IF EXISTS  [DF_IsActive_FarmEmailTemplate];
	ALTER TABLE [Farm].[FarmEmailTemplate] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEmailTemplate];
	ALTER TABLE [Farm].[FarmEmailTemplate] DROP CONSTRAINT IF EXISTS  [PK_FarmEmailTemplate_Id];
	
	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [FK_ParcelId_FarmParcelHistory];
	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmParcelHistory];
	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [DF_IsActive_FarmParcelHistory];
	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [PK_FarmParcelHistory_Id];

	ALTER TABLE [Farm].[FarmMunicipalityBlockLotParcel] DROP CONSTRAINT IF EXISTS  [DF_InterestType_FarmMunicipalityBlockLotParcel];
	ALTER TABLE [Farm].[FarmMunicipalityBlockLotParcel] DROP CONSTRAINT IF EXISTS  [PK_FarmMunicipalityBlockLotParcel_Id];

	ALTER TABLE [Farm].[FarmReSaleDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmReSaleDetails];
	ALTER TABLE [Farm].[FarmReSaleDetails] DROP CONSTRAINT IF EXISTS  [PK_FarmReSaleDetails_Id];

	ALTER TABLE [Farm].[FarmMonitoringDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmMonitoringDetails];
	ALTER TABLE [Farm].[FarmMonitoringDetails] DROP CONSTRAINT IF EXISTS  [PK_FarmMonitoringDetails_Id];


		
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
