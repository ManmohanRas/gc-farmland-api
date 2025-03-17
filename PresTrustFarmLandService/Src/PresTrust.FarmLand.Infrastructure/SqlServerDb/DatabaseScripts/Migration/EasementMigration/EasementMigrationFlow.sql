Use PresTrustTemp;

BEGIN TRY
	BEGIN TRANSACTION

--===================================================================================================================================================

DECLARE		 @v_LEGACY_RECORD_COUNT	AS INT
			,@v_LEGACY_RECORD_INDEX AS INT;

DROP TABLE IF EXISTS #temp_application_legacyEsmt;
CREATE TABLE #temp_application_legacyEsmt (Id INT IDENTITY(1,1), LegacyApplicationId INTEGER)

INSERT INTO		#temp_application_legacyEsmt (LegacyApplicationId)
SELECT		LegacyApplicationId
FROM		[Farm].[FarmEsmtApplicationLegacy]
WHERE		ISNULL(FarmApplicationId,0) = 0;

SET	@v_LEGACY_RECORD_COUNT = @@ROWCOUNT;
SET	@v_LEGACY_RECORD_INDEX = 1;

WHILE (@v_LEGACY_RECORD_INDEX <= @v_LEGACY_RECORD_COUNT)
BEGIN
		DECLARE		@v_LEGACY_APPLICATION_ID AS INT,
					@v_NEW_APPLICATION_ID AS INT;

		SELECT		@v_LEGACY_APPLICATION_ID = LegacyApplicationId 
		FROM		#temp_application_legacyEsmt
		WHERE		ID = @v_LEGACY_RECORD_INDEX;

	--Farm Application
INSERT INTO Farm.FarmApplication
			(
			  Title
			 ,AgencyId
			 ,FarmListId
			 ,ApplicationTypeId
			 ,StatusId
			 ,CreatedByProgramUser
			 ,IsApprovedByMunicipality
			 ,CreatedOn
			 ,CreatedBy
			 ,IsActive
			 ,IsSADC
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
	        SELECT 
	          ISNULL(OW.ProjectName,'') AS ProjectName
	         ,ISNULL(OW.AgencyID,0) AS AgencyID
	         ,FL.NewFarmListID
	         ,2 AS ApplicationTypeId
	         ,CASE WHEN OW.Status = 'Dropped' THEN 207
	               WHEN OW.Status = 'Fee Simple Purchase' THEN 206
	               WHEN OW.Status = 'Ineligible' THEN 208
	         	   WHEN OW.Status = 'Pending' THEN 204
	         	   WHEN OW.Status = 'Preserved' THEN 206
				   --WHEN OW.STATUS = 'Transferred to MCPC' THEN   --- MAY BE CHANGE IN FUTURE
				   ELSE  0
	               END AS StatusId
             ,1 AS CreatedByProgramUser
	         ,0 AS IsApprovedByMunicipality
	         ,'01-01-1900' AS [CreatedOn]
	         ,NULL AS CreatedBy
	         ,1 AS IsActive
	         ,1 AS [IsSADC]
             ,SUSER_SNAME() AS LastUpdatedBy
             ,GetDate()
	         FROM [FARM].[OwnerPropertyLEGACY_Rev02] OW
	         JOIN [Farm].[FarmListLegacy] FL ON OW.FarmListID = FL.LegacyFarmListId 
	         WHERE OW.ProjectID = @v_LEGACY_APPLICATION_ID AND OW.[Status] IS NOT NULL 
			 AND OW.[Status] != 'Targeted' 

			 SET @v_NEW_APPLICATION_ID = SCOPE_IDENTITY(); 
			 UPDATE	[Farm].[FarmEsmtApplicationLegacy]
             SET FarmApplicationId = @v_NEW_APPLICATION_ID
             WHERE	LegacyApplicationId = @v_LEGACY_APPLICATION_ID;


INSERT INTO [Farm].[FarmEsmtAppOwnerDetails]
            (
              ApplicationId
             ,SoleProprietor
             ,ProprirtorPartnership
             ,MultiProprietor
             ,ExecutorEstate
             ,CPFeeSimple
             ,CPEasement
             ,MunicipalityCurrentEO
             ,ConservationOrg
             ,FarmName
             ,ResidentName
             ,AttarneyName
             ,AtMailingAddress
             ,ATFirmName
             ,ResiPhoneNumber
             ,PdStreetAddress
             ,OwnedContinuesly
             ,SubjectProperty
             ,LastUpdatedBy
             ,LastUpdatedOn
            )
			SELECT
			  @v_NEW_APPLICATION_ID
			 ,0 AS SoleProprietor
             ,0 AS ProprirtorPartnership
             ,0 AS MultiProprietor
             ,0 AS ExecutorEstate
             ,0 AS CPFeeSimple
             ,0 AS CPEasement
             ,0 AS MunicipalityCurrentEO
             ,0 AS ConservationOrg
			 ,FarmName
			 ,NULL AS ResidentName
			 ,ISNULL(Attorney,'') AS  AttarneyName
			 ,ISNULL(AttorneyContactInfo,'') AS AtMailingAddress
			 ,ISNULL(AttorneyContactInfo,'') AS ATFirmName
			 ,NULL AS ResiPhoneNumber
			 ,ISNULL(CONCAT(FarmLocation,' ', Municipality),'') AS PdStreetAddress
			 ,0 AS OwnedContinuesly
             ,0 AS SubjectProperty
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM [FARM].[OwnerPropertyLEGACY_Rev02]
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtAppExceptions]
            (
              ApplicationId
             ,ExpectedTaxLots
             ,ExceptionNonSeverable
             ,ExceptionTotalNonSeverable
             ,ExceptionSeverable
             ,ExceptionTotalSeverable
             ,Acres
             ,LastUpdatedBy  
			 ,LastUpdatedOn
            )
			SELECT 
			 @v_NEW_APPLICATION_ID
			 ,CASE 
			      WHEN NumberofExceps = 0 THEN 0
			      ELSE 1
			  END AS ExpectedTaxLots
			 ,NULL AS ExceptionNonSeverable
             ,NULL AS ExceptionTotalNonSeverable
             ,NULL AS ExceptionSeverable
             ,NULL AS ExceptionTotalSeverable
			 ,ISNULL(NetAcres,0) AS Acres
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [FARM].[FarmEsmtExceptionsAttachmentB]
            (
              ApplicationId
             ,LocationOfException
             ,Block
             ,Lot
             ,ExceptionSize
             ,ReasonForException
             ,IsExceptionSoldFromPreserved
             ,IsRestrictExceptionToResiUnit
             ,IsExceptionInNonAgriUse
             ,IsResiExceptionArea
             ,IsNonResiExceptionArea
             ,NonAgriExceptionArea
             ,SingleFamilyResidence
             ,ResiHomePermFoundation
             ,ResiDuplex
             ,ResiHomeWithoutFoundation
             ,ResidenceGarage
             ,ResiDormitory
             ,ResiAttachedTo
             ,ResiGarriageHouse
             ,NonResidentialBarn
             ,NonResidentialShed 
             ,NonResidentialGarage 
             ,NonResidentialSilo 
             ,NonResidentialStable
             ,LastUpdatedBy  
			 ,LastUpdatedOn
            )
			 SELECT
			  @v_NEW_APPLICATION_ID
			 ,NULL AS LocationOfException
			 ,NULL AS Block
             ,NULL AS Lot
			 ,(Excep1Acres + Excep2Acres + Excep3Acres) AS ExceptionSize
			 ,NULL AS ReasonForException
			 ,CASE 
			      WHEN X1Severable ='Yes' THEN 1
			      WHEN X2IsSeverable = 'Yes' THEN 1
			      WHEN X3IsSeverable = 'Yes' THEN 1
			      ELSE 0
			  END AS IsExceptionSoldFromPreserved
			 ,NULL AS IsRestrictExceptionToResiUnit
			 ,CASE 
			      WHEN AreNonAgUses ='Yes' THEN 1
			      ELSE 0
			  END AS IsExceptionInNonAgriUse
			 ,NULL AS IsResiExceptionArea
			 ,NULL AS IsNonResiExceptionArea
             ,TRY_CAST(NonAgExplan AS NVARCHAR(MAX)) AS NonAgriExceptionArea -- NEED TO CHANGE DATA SIZE
			 ,NULL AS SingleFamilyResidence
             ,NULL AS ResiHomePermFoundation
             ,NULL AS ResiDuplex
             ,NULL AS ResiHomeWithoutFoundation
             ,NULL AS ResidenceGarage
             ,NULL AS ResiDormitory
             ,NULL AS ResiAttachedTo
             ,NULL AS ResiGarriageHouse
             ,NULL AS NonResidentialBarn
             ,NULL AS NonResidentialShed 
             ,NULL AS NonResidentialGarage 
             ,NULL AS NonResidentialSilo 
             ,NULL AS NonResidentialStable
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [FARM].[FarmEsmtAppStructure]
            (
              ApplicationId
             ,IsResipreserved							
             ,StdSingleFamilyResidence					
             ,MfWithHomePermFoundation				
             ,Duplex
             ,MfWithOutHomePermFoundation		                            
             ,ResiGarage               
             ,Dormitory		                            
             ,ApartmentAttachedTo		                
             ,CarriageHouseOrCabin		                
             ,ResiOther		                            
             ,UnitsAgricuturalLabor						
             ,UnitsRentedOrLease	                
             ,IsNonResiStructure						
             ,Barn		                                
             ,Shed		                                
             ,NonResiGarage		                        
             ,Silo	                                
             ,Stable		                            
             ,NonResiOther	                        
             ,IsHistBuildingOrStructure				
             ,HistoricSignificance		                
             ,LastUpdatedBy					            
             ,LastUpdatedOn
            )
			 SELECT
			  @v_NEW_APPLICATION_ID
			 ,IsResidenceOnPresLand
			 ,NULL AS StdSingleFamilyResidence					
             ,NULL AS MfWithHomePermFoundation				
             ,NULL AS Duplex
             ,NULL AS MfWithOutHomePermFoundation		                            
             ,NULL AS ResiGarage               
             ,NULL AS Dormitory		                            
             ,NULL AS ApartmentAttachedTo		                
             ,NULL AS CarriageHouseOrCabin		                
             ,NULL AS ResiOther		                            
             ,NULL AS UnitsAgricuturalLabor						
             ,NULL AS UnitsRentedOrLease	                
             ,NULL AS IsNonResiStructure						
             ,NULL AS Barn		                                
             ,NULL AS Shed		                                
             ,NULL AS NonResiGarage		                        
             ,NULL AS Silo	                                
             ,NULL AS Stable		                            
             ,NULL AS NonResiOther	                        
             ,NULL AS IsHistBuildingOrStructure				
             ,NULL AS HistoricSignificance
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtLiens]
            (
              ApplicationId
             ,PremisePreserved				
             ,BankruptcyJudgment			
             ,PowerLines					
             ,WaterLines					
             ,Sewer							
             ,Bridge						
             ,FloodRightWay					
             ,TelephoneLines				
             ,GasLines						
             ,Other							
             ,AccessEasement				
             ,AccessDescribe				
             ,ConservationEasement			
             ,ConservationDescribe			
             ,FederalProgram				
             ,FederalDescribe				
             ,SolarWindBiomass				
             ,BiomassDescribe				
             ,DateInstallation				
             ,PropertySale					
             ,EstateSituation				
             ,Bankruptcy	
             ,ForeClosure
             ,LastUpdatedBy
             ,LastUpdatedOn
            )
			 SELECT
			 @v_NEW_APPLICATION_ID
			 ,NULL AS PremisePreserved				
             ,NULL AS BankruptcyJudgment			
             ,NULL AS PowerLines					
             ,NULL AS WaterLines					
             ,NULL AS Sewer							
             ,NULL AS Bridge						
             ,NULL AS FloodRightWay					
             ,NULL AS TelephoneLines				
             ,NULL AS GasLines						
             ,NULL AS Other							
             ,NULL AS AccessEasement				
             ,NULL AS AccessDescribe				
             ,NULL AS ConservationEasement			
             ,NULL AS ConservationDescribe			
             ,NULL AS FederalProgram				
             ,NULL AS FederalDescribe				
             ,NULL AS SolarWindBiomass				
             ,NULL AS BiomassDescribe				
             ,NULL AS DateInstallation				
             ,NULL AS PropertySale					
             ,NULL AS EstateSituation				
             ,NULL AS Bankruptcy	
             ,NULL AS ForeClosure
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtExistNonAgriUses]
            (                              
              ApplicationID                  
             ,IsSubdivisionApproval         
             ,InfoAboutPremises                
             ,LastUpdatedBy	   
             ,LastUpdatedOn
            )
			SELECT
			  @v_NEW_APPLICATION_ID
			 ,0 AS IsSubdivisionApproval   --- Taking 0 By default       
             ,NULL AS InfoAboutPremises
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			  FROM FARM.OwnerPropertyLEGACY_Rev02
			  WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtAttachmentC]
            (                 
              ApplicationId                                        
             ,IsExceptionAreaPreserved                              
             ,IsNonAgriPremisesPreserved
             ,IsLeaseWithAnotherParty
             ,DescNonAgriUses
             ,NonAgriAreaUtilization			 	           
             ,NonAgriLease				    
             ,NonAgriUseAccessParcel				             
             ,LastUpdatedBy				         
             ,LastUpdatedOn
            )
			SELECT
			  @v_NEW_APPLICATION_ID
			 ,0 AS IsExceptionAreaPreserved  -- Taking 0 by default
			 ,CASE 
			       WHEN AreNonAgUses ='Yes' THEN 1
			       ELSE 0
			   END AS IsNonAgriPremisesPreserved
             ,NULL AS IsLeaseWithAnotherParty
			 ,NonAgExplan
			 ,NULL AS NonAgriAreaUtilization			 	           
             ,NULL AS NonAgriLease				    
             ,NULL AS NonAgriUseAccessParcel
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			  FROM FARM.OwnerPropertyLEGACY_Rev02
			  WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtAppAttachmentE] 
            (  
			  ApplicationId
             ,TypeOfDevelopment
             ,PreliminaryApprovalDate
             ,FinalApprovalDate
             ,ScaleofSubdivision
             ,OtherPertinentInformation
             ,IsOpenEnrollment
             ,IsPropertyOutlined
             ,IsAllExpAreasIdentified
             ,IsAllNonAgriEquiUsesDetailed
             ,IsCopyOfDeed
             ,IsSignOfAllPropOwnersListed
             ,IsFarmLandAssReportCopy
             ,LastUpdatedBy
             ,LastUpdatedOn
            )
			SELECT
			  @v_NEW_APPLICATION_ID
			 ,NULL AS TypeOfDevelopment
             ,NULL AS PreliminaryApprovalDate
             ,NULL AS FinalApprovalDate
             ,NULL AS ScaleofSubdivision
             ,NULL AS OtherPertinentInformation
             ,NULL AS IsOpenEnrollment
             ,NULL AS IsPropertyOutlined
             ,NULL AS IsAllExpAreasIdentified
             ,NULL AS IsAllNonAgriEquiUsesDetailed
             ,NULL AS IsCopyOfDeed
             ,NULL AS IsSignOfAllPropOwnersListed
             ,NULL AS IsFarmLandAssReportCopy
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,1 AS ActivitySubTypeId
              ,'WHEAT_CASH_GRAIN_FARMS' AS Title
			  ,'0111' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'WHEAT_CASH_GRAIN_FARMS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'WHEAT_CASH_GRAIN_FARMS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,2 AS ActivitySubTypeId
              ,'RICE_CASH_GRAIN_FARMS' AS Title
			  ,'0112' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'RICE_CASH_GRAIN_FARMS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'RICE_CASH_GRAIN_FARMS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,3 AS ActivitySubTypeId
              ,'CORN_CASH_GRAIN_FARMS' AS Title
			  ,'0115' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'CORN_CASH_GRAIN_FARMS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'CORN_CASH_GRAIN_FARMS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,4 AS ActivitySubTypeId
              ,'SOYBEANS_CASH_GRAIN_FARMS' AS Title
			  ,'0116' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'SOYBEANS_CASH_GRAIN_FARMS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'SOYBEANS_CASH_GRAIN_FARMS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,5 AS ActivitySubTypeId
              ,'CASH_GRAIN_NEC' AS Title
			  ,'0119' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'CASH_GRAIN_NEC' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'CASH_GRAIN_NEC' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,6 AS ActivitySubTypeId
              ,'IRISH_POTATOES_FIELD_CROP_FARMS' AS Title
			  ,'0134' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'IRISH_POTATOES_FIELD_CROP_FARMS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'IRISH_POTATOES_FIELD_CROP_FARMS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,7 AS ActivitySubTypeId
              ,'FIELD_CROPS_EXCEPT_CASH_GRAINS' AS Title
			  ,'0139' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'FIELD_CROPS_EXCEPT_CASH_GRAINS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'FIELD_CROPS_EXCEPT_CASH_GRAINS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,8 AS ActivitySubTypeId
              ,'VEGETABLES_AND_MELON_FARMS' AS Title
			  ,'0161' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'VEGETABLES_AND_MELON_FARMS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'VEGETABLES_AND_MELON_FARMS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,9 AS ActivitySubTypeId
              ,'BERRY_FARMS' AS Title
			  ,'0171' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'BERRY_FARMS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'BERRY_FARMS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,10 AS ActivitySubTypeId
              ,'CITRUS_FRUIT_FARMS' AS Title
			  ,'0174' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'CITRUS_FRUIT_FARMS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'CITRUS_FRUIT_FARMS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,11 AS ActivitySubTypeId
              ,'DECIDUOUS_TREE_FRUIT_FARMS' AS Title
			  ,'0175' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'DECIDUOUS_TREE_FRUIT_FARMS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'DECIDUOUS_TREE_FRUIT_FARMS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,12 AS ActivitySubTypeId
              ,'FRUIT_AND_TREE_NUT_FARM_NEC' AS Title
			  ,'0179' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'FRUIT_AND_TREE_NUT_FARM_NEC' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'FRUIT_AND_TREE_NUT_FARM_NEC' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,13 AS ActivitySubTypeId
              ,'ORNAMENT_NURSERY_PRODUCTS' AS Title
			  ,'0181' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'ORNAMENT_NURSERY_PRODUCTS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'ORNAMENT_NURSERY_PRODUCTS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,14 AS ActivitySubTypeId
              ,'FOOD_CROPS_GROWN_UNDERCOVER' AS Title
			  ,'0182' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'FOOD_CROPS_GROWN_UNDERCOVER' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'FOOD_CROPS_GROWN_UNDERCOVER' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,15 AS ActivitySubTypeId
              ,'HORTICULTURE_SPECIALTIES' AS Title
			  ,'0189' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'HORTICULTURE_SPECIALTIES' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'HORTICULTURE_SPECIALTIES' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,16 AS ActivitySubTypeId
              ,'GENERAL_FARMING_NEC' AS Title
			  ,'0191A' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'GENERAL_FARMING_NEC' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'GENERAL_FARMING_NEC' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,17 AS ActivitySubTypeId
              ,'BEEF_CATTLE_FEEDLOTS' AS Title
			  ,'0211' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'BEEF_CATTLE_FEEDLOTS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'BEEF_CATTLE_FEEDLOTS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,18 AS ActivitySubTypeId
              ,'BEEF_CATTLE_EXCEPT_FEEDLOTS' AS Title
			  ,'0212' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'BEEF_CATTLE_EXCEPT_FEEDLOTS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'BEEF_CATTLE_EXCEPT_FEEDLOTS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,19 AS ActivitySubTypeId
              ,'HOGS' AS Title
			  ,'0213' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'HOGS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'HOGS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,20 AS ActivitySubTypeId
              ,'SHEEP_AND_GOATS' AS Title
			  ,'0214' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'SHEEP_AND_GOATS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'SHEEP_AND_GOATS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,21 AS ActivitySubTypeId
              ,'GENERAL_LIVESTOCK_NEC' AS Title
			  ,'0219' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'GENERAL_LIVESTOCK_NEC' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'GENERAL_LIVESTOCK_NEC' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,22 AS ActivitySubTypeId
              ,'DAIRY_FARMS' AS Title
			  ,'0241' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'DAIRY_FARMS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'DAIRY_FARMS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,23 AS ActivitySubTypeId
              ,'FOWLS_BROILERS_AND_FRYERS' AS Title
			  ,'0251' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'FOWLS_BROILERS_AND_FRYERS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'FOWLS_BROILERS_AND_FRYERS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,24 AS ActivitySubTypeId
              ,'CHICKEN_EGGS' AS Title
			  ,'0252' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'CHICKEN_EGGS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'CHICKEN_EGGS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,25 AS ActivitySubTypeId
              ,'TURKEYS_AND_TURKEY_EGGS' AS Title
			  ,'0253' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'TURKEYS_AND_TURKEY_EGGS' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'TURKEYS_AND_TURKEY_EGGS' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,26 AS ActivitySubTypeId
              ,'POULTRY_AND_EGGS_NEC' AS Title
			  ,'0259' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'POULTRY_AND_EGGS_NEC' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'POULTRY_AND_EGGS_NEC' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,27 AS ActivitySubTypeId
              ,'HORSE_AND_OTHER_EQUINE' AS Title
			  ,'0272' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'HORSE_AND_OTHER_EQUINE' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'HORSE_AND_OTHER_EQUINE' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAgriculturalEnterpriseChecklist]
            (
               ApplicationId
              ,ActivitySubTypeId
              ,Title
              ,SicCode
              ,IsPrimary
              ,IsSecondary
              ,LastUpdatedBy
              ,LastUpdatedOn
            )
            SELECT
              @v_NEW_APPLICATION_ID
              ,28 AS ActivitySubTypeId
              ,'GENERAL_FARM_LIVESTOCK' AS Title
			  ,'0291' AS SicCode
              ,CASE 
                   WHEN PrimaryCrop = 'GENERAL_FARM_LIVESTOCK' THEN 1 
                   ELSE 0 
               END AS IsPrimary
              ,CASE 
                   WHEN SecondaryCrop = 'GENERAL_FARM_LIVESTOCK' THEN 1 
                   ELSE 0 
               END AS IsSecondary
              ,SUSER_SNAME()  AS LastUpdatedBy
              ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtAttachmentD]
            (
              ApplicationId
             ,EquineActivityTypeId
             ,Counts
             ,Number
             ,NumberOfHorses
             ,NumberOfHorsesActivity
             ,NumberOfStalls
             ,RunInSheds
             ,IndoorRidingArena
             ,OutdoorRidingArena
             ,LastUpdatedBy
             ,LastUpdatedOn
           )
		   SELECT
			  @v_NEW_APPLICATION_ID
			 ,NULL AS EquineActivityTypeId
             ,NULL AS Counts
             ,NULL AS Number
             ,NULL AS NumberOfHorses
             ,NULL AS NumberOfHorsesActivity
             ,NULL AS NumberOfStalls
             ,NULL AS RunInSheds
             ,NULL AS IndoorRidingArena
             ,NULL AS OutdoorRidingArena
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtAppSignatory]
            (
			  ApplicationId
			 ,AmountPerAcre
			 ,Designation
			 ,Title	
			 ,SignedOn
			 ,LastUpdatedBy  
			 ,LastUpdatedOn
			)
			SELECT
			  @v_NEW_APPLICATION_ID
			 ,AskingPricePerAcre
			 ,NULL AS Designation
			 ,NULL AS Title
			 ,NULL AS SignedOn
			 ,'mc-support'  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [FARM].[FarmEsmtAttachmentA]
            (
              ApplicationId
             ,IsOfferPriceIndicated
             ,OfferPriceOpinion
             ,AveragePerAcre
             ,OfferPriceComments
             ,LastUpdatedBy  
			 ,LastUpdatedOn
            )
			 SELECT
			  @v_NEW_APPLICATION_ID
			 ,0 AS IsOfferPriceIndicated
             ,NULL AS OfferPriceOpinion
             ,NULL AS AveragePerAcre
             ,NULL AS OfferPriceComments
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

----- Admin Actions Tabs

INSERT INTO [Farm].[FarmEsmtAppAdminCostDetails]
            (
              ApplicationId
             ,GrossAcers
             ,SADCBeforeValueAC                   
             ,SADCAfterValueAC                    
             ,OfferToSADC                     
             ,SADCCostShareAC                     
             ,SADCCostShareTotal                  
             ,SADCCostShareAcqTotal               
             ,NoteOfBreakdown                
             ,SADCCostShareofOfferPct            
             ,SADCCertifiedEasementValuePerAcre   
             ,SADCPctofCertifiedEaseValue    
             ,NetAcres          
             ,MCOffertoLandowner                  
             ,MCCertifiedBeforeValue              
             ,MCCostSharePerAcre               
             ,OtherSource                   
             ,OtherCostShare                      
             ,MCCostSharePct                      
             ,MCCostShareTotal                    
             ,TotalCost                     
             ,TotalCostPerAcre
             ,CountyFunds
             ,LastUpdatedBy
			 ,LastUpdatedOn
           )
			SELECT
			  @v_NEW_APPLICATION_ID
			 ,GrossAcres
			 ,SADCBeforeValuePerAcre
			 ,SADCAfterValuePerAcre
			 ,NULL AS OfferToSADC
			 ,SADCCostSharePerAcre
			 ,SADCCostShareTotal
			 ,TRY_CAST(REPLACE(SADCCostShareofAcqTotalPct, '%', '') AS decimal(10,2)) AS SADCCostShareofAcqTotalPct
			 ,CostNote
			 ,TRY_CAST(REPLACE(SADCCostShareofOfferPct, '%', '') AS decimal(10,2)) AS SADCCostShareofOfferPct
			 ,SADCCertifiedEasementValuePerAcre
			 ,SADCPctofCertifiedEaseValue
			 ,NetAcres
			 ,MCOffertoLandowner
			 ,MCCertifiedBeforeValue
			 ,MCCostSharePerAcre
			 ,OtherFundingSource
			 ,OtherCostShareTotal
			 ,TRY_CAST(REPLACE(MCCostSharePct, '%', '') AS decimal(10,2)) AS MCCostSharePct
			 ,MCCostShareTotal
			 ,TotalCost
			 ,TotalCostPerAcre
			 ,CASE
			      WHEN CountyFunds = 'Cap Ord' THEN 'CapOrd'
			      WHEN CountyFunds = 'SADC-County' THEN 'SADCCounty'
			      WHEN CountyFunds = 'TF' THEN 'TF'
			      ELSE NULL
			  END AS CountyFunds
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02	
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtAppAdminAppraisalReport]
            (
			  ApplicationId
			 ,AsOfDate
			 ,AppraiserName1
			 ,AppraiserName2
			 ,LowerAppraiser
			 ,HigherAppraiser
			 ,PreHLBeforeValue1
			 ,PreHLAfterValue1
			 ,PreHLEsmtValue1
			 ,PreHLBeforeValue2
			 ,PreHLAfterValue2
			 ,PreHLEsmtValue2
			 ,PostHLBeforeValue1
			 ,PostHLAfterValue1
			 ,PostHLEsmtValue1
			 ,PostHLBeforeValue2
			 ,PostHLAfterValue2
			 ,PostHLEsmtValue2
			 ,DiffInEsmtAppraisals
			 ,PostHLDifference
			 ,DiffInPreandPostHL
			 ,WithInHighlands
			 ,WithInPreservationArea
			 ,SADCCertifiedEsmttotal
			 ,SADCEsmtBeforePct
			 ,AppraisedZoning
			 ,ApraisedZoningClass
			 ,AppraisalComments
			 ,FreeHolderDate 
			 ,CurrentZoning
			 ,CADBEasement
			 ,CADBBefore
			 ,CADBEaseBefore
			 ,LastUpdatedBy
			 ,LastUpdatedOn
		    )
		    SELECT 
		      @v_NEW_APPLICATION_ID
		     ,CASE WHEN ISDATE(AppraisalAsofDate) = 1 THEN CAST(AppraisalAsofDate AS DATE) ELSE NULL END AS AsOfDate  ------ Date format not correct 
		     ,Appraiser1
		     ,Appraiser2
		     ,LowerAppraiser
		     ,HigherAppraiser
		     ,BeforeValue1PerAcre
		     ,AfterValue1PerAcre
		     ,EasementValue1PerAcre
		     ,BeforeValue2PerAcre
             ,AfterValue2PerAcre
             ,EasementValue2PerAcre
		     ,PostHLBeforeValue1PerAcre
		     ,PostHLAfterValue1PerAcre
		     ,PostHLEasementValue1PerAcre
		     ,PostHLBeforeValue2PerAcre
		     ,PostHLAfterValue2PerAcre
		     ,PostHLEasementValue2PerAcre
		     ,DifferenceinEasementAppraisals
		     ,PostHLDifferenceinEasementAppraisals
             ,DifferenceinPreandPostHLEasementPct
		     ,IsHighlands
			 ,IsHighlandsCoreArea AS WithInPreservationArea
		     ,SADCCertifiedEasementValuetotal
		     ,SADCEasementPctofBefore
		     ,AppraisedZoning
             ,ApraisedZoningClass
		     ,AppraisalRFPComments
			 ,CASE WHEN ISDATE(MCExecutesContract) = 1 THEN CAST(MCExecutesContract AS DATE) ELSE NULL END AS FreeHolderDate  ------ Date format not correct 
		     ,ZoningCurrent
		     ,MCOffertoLandowner
		     ,MCCertifiedBeforeValue
		     ,TRY_CAST(REPLACE(MCCertifiedPctEaseofBeforeValue, '%','') AS decimal(18,2)) AS CADBEaseBefore
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtAppAdminOfferCost]
            (
			  ApplicationId
			 ,CadbLandOwnerOffer
			 ,IsOfferAccepted
			 ,OtherSource
			 ,CostNote
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
		    SELECT 
		      @v_NEW_APPLICATION_ID
		     ,LandownerOfferPerAcre
			 ,CASE 
			      WHEN MCWasOfferAccepted = 'Yes' THEN 1
				  WHEN MCWasOfferAccepted = 'No' THEN 0
				  ELSE NULL
				  END AS MCWasOfferAccepted
		     ,OtherFundingSource
		     ,CostNote
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtAppAdminStructNonAgriWetlands]
            (
			  ApplicationId
			 ,IsResidenceOnPresLand
			 ,ImprovRes
			 ,AreNonAgUses
			 ,NonAgExplan
			 ,IsFarmMarket
			 ,ImprovAg
			 ,WetlandsSurveyor
			 ,DateofDelineation
			 ,AcresofWetlands
			 ,AcresofTransitionArea
			 ,WetlandsClassification
			 ,LastUpdatedBy  
			 ,LastUpdatedOn
			)
		    SELECT 
		      @v_NEW_APPLICATION_ID
		     ,IsResidenceOnPresLand
		     ,ImprovRes
			 ,CASE 
			      WHEN AreNonAgUses = 'Yes' THEN 1
				  WHEN AreNonAgUses = 'No' THEN 0
				  ELSE NULL
				  END AS AreNonAgUses
		     ,NonAgExplan
		     ,IsFarmMarket
		     ,ImprovAg
		     ,WetlandsSurveyor
		     ,DateofDelineation ----multiple dates in legacy table
		     ,AcresofWetlands
		     ,AcresofTransitionArea
		     ,WetlandsClassification
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtAppAdminExceptionRDSO]
            (
			  ApplicationId
			 ,NumberofExceps           
			 ,Excep1Acres              
			 ,X1Purpose   --- Need to Increase data size
			 ,X1Severable            
			 ,X1IsSubdividable         
			 ,X1IsRTF                  
			 ,Excep2Acres              
			 ,X2Purpose       --- Need to Increase data size         
			 ,X2IsSeverable            
			 ,X2IsSubdividable        
			 ,X2IsRTF                  
			 ,Excep3Acres              
			 ,X3Purpose          --- Need to Increase data size      
			 ,X3IsSeverable            
			 ,X3IsSubdividable         
			 ,X3IsRTF                  
			 ,RDSOSNum		   
			 ,RDSOExplan             --- Need to Increase data size  
			 ,IsRDSOExercised          
			 ,LastUpdatedBy            
			 ,LastUpdatedOn
			)
            SELECT 
		      @v_NEW_APPLICATION_ID
		     ,NumberofExceps
		     ,Excep1Acres
		     ,TRY_CAST(X1Purpose AS nvarchar(max)) AS X1Purpose
		     ,CASE 
			      WHEN X1Severable = 'Yes' THEN 1
				  WHEN X1Severable = 'No' THEN 0
				  ELSE NULL
				  END AS X1Severable   
             ,CASE 
			      WHEN X1IsSubdividable = 'Yes' THEN 1
				  WHEN X1IsSubdividable = 'No' THEN 0
				  ELSE NULL
				  END AS X1IsSubdividable 
			 ,CASE 
			      WHEN X1IsRTF = 'Yes' THEN 1
				  WHEN X1IsRTF = 'No' THEN 0
				  ELSE NULL
				  END AS X1IsRTF 	  
		     ,Excep2Acres
		     ,TRY_CAST(X2Purpose AS nvarchar(max)) AS X2Purpose
		     ,CASE 
			      WHEN X2IsSeverable = 'Yes' THEN 1
				  WHEN X2IsSeverable = 'No' THEN 0
				  ELSE NULL
				  END AS X2IsSeverable   
             ,CASE 
			      WHEN X2IsSubdividable = 'Yes' THEN 1
				  WHEN X2IsSubdividable = 'No' THEN 0
				  ELSE NULL
				  END AS X2IsSubdividable 
			 ,CASE 
			      WHEN X2IsRTF = 'Yes' THEN 1
				  WHEN X2IsRTF = 'No' THEN 0
				  ELSE NULL
				  END AS X2IsRTF
		     ,Excep3Acres
		     ,TRY_CAST(X3Purpose AS nvarchar(max)) AS X3Purpose
		     ,CASE 
			      WHEN X3IsSeverable = 'Yes' THEN 1
				  WHEN X3IsSeverable = 'No' THEN 0
				  ELSE NULL
				  END AS X3IsSeverable   
             ,CASE 
			      WHEN X3IsSubdividable = 'Yes' THEN 1
				  WHEN X3IsSubdividable = 'No' THEN 0
				  ELSE NULL
				  END AS X3IsSubdividable 
			 ,CASE 
			      WHEN X3IsRTF = 'Yes' THEN 1
				  WHEN X3IsRTF = 'No' THEN 0
				  ELSE NULL
				  END AS X3IsRTF
		     ,RDSOsNum
		     ,TRY_CAST(RDSOExplan AS nvarchar(max))
			 ,CASE 
			      WHEN IsRDSOExercised = 'Yes' THEN 1
				  WHEN IsRDSOExercised = 'No' THEN 0
				  ELSE NULL
				  END AS IsRDSOExercised
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtAppAdminSADC]
            (
			  ApplicationId
			 ,ProgramName
			 ,SADCFundingRoundYear
			 ,SADCQualityScore
			 ,SADCPrelimRank
			 ,SADCFinalRank
			 ,SADCFinalScore
			 ,LastUpdatedBy  
			 ,LastUpdatedOn
			)
            SELECT
		      @v_NEW_APPLICATION_ID
		     ,WhichEPP
			 ,REPLACE(SADCFundingRoundYear, 'n/a', '0') AS SADCFundingRoundYear
             ,REPLACE(SADCQualityScore, 'n/a',0) AS SADCQualityScore
		     ,REPLACE(REPLACE(SADCPrelimRank,'n/a',0),'xxx',0) AS SADCPrelimRank
		     ,REPLACE(SADCFinalRank, 'n/a',0) AS SADCFinalRank
		     ,TRY_CAST(REPLACE(SADCFinalScore, 'n/a',0) AS decimal(10,2)) AS SADCFinalScore
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtAppAdminClosingDocStatus]
            (
			  ApplicationId
			 ,ProjectStatus
			 ,EPDeedBook
			 ,EPDeedPage
			 ,EPDeedFiled
			 ,EPDeedClerkID
			 ,CountyAttorney
			 ,CountyAttorneyInfo
			 ,SurveyDate
			 ,Surveyor
			 ,TitleCompany
			 ,TitlePolicy
			 ,ClosingDate
			 ,EndorsementDates
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
            SELECT
		      @v_NEW_APPLICATION_ID
		     ,CASE 
			       WHEN [Status] = 'Dropped' THEN 'REJECTED'
	               WHEN [Status] = 'Fee Simple Purchase' THEN 'PRESERVED'
	               WHEN [Status] = 'Ineligible' THEN 'WITHDRAW'
	         	   WHEN [Status] = 'Pending' THEN 'PENDING'
	         	   WHEN [Status] = 'Preserved' THEN 'PRESERVED'
	               END AS ProjectStatus
		     ,EPDeedBook
             ,EPDeedPage
             ,EPDeedFiled
		     ,EPDeedClerkID
		     ,Attorney
             ,AttorneyContactInfo
		     ,SurveyDate -- multiple dates in legacy table
             ,Surveyor
		     ,TitleCompany
             ,TitlePolicyNumber
		     ,ClosingDate
		     ,EndorsementDates
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtAppAdminDetails]
           (
		      ApplicationId
			 ,FarmerName
			 ,FarmerPhone
			 ,FarmerContactInfo
			 ,FarmFeatures
			 ,AgreestoHaveSign
			 ,ConsPlanDate
			 ,ConsPlanComment
			 ,DroppedProjectWhy
			 ,ImperviousPercentage
			 ,ImperviousSurfaceAcreage
			 ,InterestedinSADCSign
			 ,IsConservationPlan
			 ,PossibleClosingDate
			 ,PreservedOrder
			 ,SADCSignLocation
			 ,StaffComments
			 ,ZoningJan12004
			 ,RFPIsAppraisal
			 ,RFPIsSurvey
			 ,RFPIsWetlands
			 ,CADBAppYear
			 ,ProjectYear
			 ,OriginalDeed
			 ,OriginalPage
			 ,SmallOrLargeSign
			 ,AdYear
			 ,LastUpdatedBy
			 ,LastUpdatedOn
		   )
           SELECT
		      @v_NEW_APPLICATION_ID
		     ,FarmerName
              ,CASE 
               WHEN CHARINDEX(',', FarmerPhone) > 0 
              THEN LEFT(FarmerPhone, CHARINDEX(',', FarmerPhone) - 1) 
              ELSE FarmerPhone 
              END AS FarmerPhone
             ,FarmerContactInfo
		     ,FarmFeatures
		     ,AgreestoHaveSign
		     ,ConsPlanDate -- does not having date format in legacy table
		     ,ConsPlanComment
		     ,DroppedProjectWhy
		     ,ImperviousPercentage
		     ,ImperviousSurfaceAcreage
		     ,InterestedinSADCSign
			 ,IsConservationPlan
		     ,PossibleClosingDate
		     ,PreservedOrder
		     ,SADCSignLocation
		     ,StaffComments
		     ,ZoningJan12004
		     ,RFPIsAppraisal
		     ,RFPIsSurvey
		     ,RFPIsWetlands
		     ,CADBAppYear
		     ,ProjectYear
		     ,EPDeedBook
		     ,EPDeedPage
		     ,SmallOrLargeSign
		     ,NULL AS AdYear
		     ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmAppAdminContact]
            (
			  ApplicationId
			 ,ContactName
			 ,Agency
			 ,Email
			 ,MainNumber
			 ,AlternateNumber
			 ,SelectContact
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
            SELECT
		     @v_NEW_APPLICATION_ID
		     ,ContactPerson
		     ,NULL AS Agency
		     ,ContactEMail
		     ,ContactPhone -- ensure having 10 numbers 
		     ,NULL AS AlternateNumber
		     ,NULL AS SelectContact
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;


		   ------------------------------------------------------------------------------------------------------------
		   -------------------------------------------------------------------------------------------------------------
--SADC TABS
INSERT INTO [Farm].[FarmEsmtSadcFarmInfo]
            (
			  ApplicationId
			 ,AlternatePhoneNumber
			 ,County
			 ,TotalFarmAcreage
			 ,Acres
			 ,IsContactSame
			 ,IsOtherContact
			 ,OtherPrimaryFirstName
			 ,OtherPrimaryRelation
			 ,OtherPrimaryPhoneNumber
			 ,OtherPrimaryEmail
			 ,OtherPrimaryAddress
			 ,IsVisitPrimaryContact
			 ,IsVisitLandOwner
			 ,IsVisitOther
			 ,VisitName
			 ,VisitRelation
			 ,VisitPhoneNumber
			 ,VisitEmail
			 ,VisitSADCID
			 ,VisitDateRecieved
			 ,IsImmediateCurrentMember
			 ,Position
			 ,Term
			 ,LastUpdatedBy 
			 ,LastUpdatedOn
			)
            SELECT 
	          @v_NEW_APPLICATION_ID 
		     ,NULL AS AlternatePhoneNumber
		     ,'Morris'
		     ,GrossAcres
		     ,NULL AS Acres
		     ,NULL AS IsContactSame
		     ,NULL AS IsOtherContact
		     ,NULL AS OtherPrimaryFirstName
		     ,NULL AS OtherPrimaryRelation
		     ,NULL AS OtherPrimaryPhoneNumber
		     ,NULL AS OtherPrimaryEmail
		     ,NULL AS OtherPrimaryAddress
		     ,NULL AS IsVisitPrimaryContact
		     ,NULL AS IsVisitLandOwner
		     ,NULL AS IsVisitOther
		     ,NULL AS VisitName
		     ,NULL AS VisitRelation
		     ,NULL AS VisitPhoneNumber
		     ,NULL AS VisitEmail
		     ,NULL AS VisitSADCID
		     ,NULL AS VisitDateRecieved
		     ,NULL AS IsImmediateCurrentMember
		     ,NULL AS Position
		     ,NULL AS Term
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtSadcResidence]
            (
			  ApplicationId
			 ,IsAgriculturalLabor
			 ,UnitsUsedForLabor
			 ,Occupants
			 ,MonthsOccupied
			 ,IsOccupantsWork
			 ,PleaseExplain
			 ,IsResidencesRented
			 ,RDSOsReserve
			 ,ExcepAcres1
			 ,NonSeverable1
			 ,Severable1
			 ,AdditionalComment1
			 ,ExcepAcres2
			 ,NonSeverable2
			 ,Severable2
			 ,AdditionalComment2
			 ,EsmtOthersText
			 ,IsSightTriangle
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
            SELECT
		      @v_NEW_APPLICATION_ID
			 ,NULL AS IsAgriculturalLabor
			 ,NULL AS UnitsUsedForLabor
			 ,NULL AS Occupants
			 ,NULL AS MonthsOccupied
			 ,NULL AS IsOccupantsWork
			 ,NULL AS PleaseExplain
			 ,NULL AS IsResidencesRented
			 ,NULL AS RDSOsReserve
			 ,Excep1Acres
			 ,CASE 
			      WHEN X1Severable = 'No' THEN 1
				  WHEN X1Severable = 'Yes' THEN 0
			      ELSE NULL
			   END AS NonSeverable1
			 ,CASE 
			      WHEN X1Severable = 'Yes' THEN 1
				  WHEN X1Severable = 'No' THEN 0
				  ELSE NULL
              END AS Severable1
			 ,X1Purpose
			 ,Excep2Acres
			 ,CASE
			      WHEN X2IsSeverable = 'No' THEN 1
				  WHEN X2IsSeverable = 'Yes' THEN 0
				  ELSE NULL
              END AS NonSeverable2
			 ,CASE 
			      WHEN X2IsSeverable = 'Yes' THEN 1
				  WHEN X2IsSeverable = 'No' THEN 0
				  ELSE NULL
              END AS Severable2
			 ,X2Purpose
			 ,NULL AS EsmtOthersText
			 ,NULL AS IsSightTriangle
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtSadcHistory]
            (
			  ApplicationId
			 ,SquareFootage
			 ,PreliminaryExpiration
			 ,FinalExpiration
			 ,EstateWill
			 ,TaxWaiver
			 ,NoWaiver
			 ,TrustWill
			 ,TrustDocuments
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
		    SELECT
		      @v_NEW_APPLICATION_ID
			 ,NULL AS SquareFootage
			 ,NULL AS PreliminaryExpiration
			 ,NULL AS FinalExpiration
			 ,NULL AS EstateWill
			 ,NULL AS TaxWaiver
			 ,NULL AS NoWaiver
			 ,NULL AS TrustWill
			 ,NULL AS TrustDocuments
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtSadcEligibility]
            (
			  ApplicationId          
			 ,ProjectAreaAppEl       
			 ,RankScore              
			 ,RankPoints             
			 ,SoilPercentage         
			 ,IsLandsLessThan10Ac    
			 ,IsLandsGreaterThan10Ac 
			 ,Is75PercentTillable    
			 ,Percent75Tillable1     
			 ,Acre75Tillable         
			 ,Is75PercentLand        
			 ,Percent75Land          
			 ,Acre75Land             
			 ,Is50PercentTillable    
			 ,Percent50Tillable      
			 ,Acre50Tillable         
			 ,Is50PercentLand        
			 ,Percent50Land          
			 ,Acre50Land             
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
	        SELECT
	          @v_NEW_APPLICATION_ID      
			 ,ProjectRegion
			 ,NULL AS RankScore              
			 ,NULL AS RankPoints             
			 ,NULL AS SoilPercentage         
			 ,NULL AS IsLandsLessThan10Ac    
			 ,NULL AS IsLandsGreaterThan10Ac 
			 ,NULL AS Is75PercentTillable  
			 ,NULL AS Percent75Tillable1     
			 ,NULL AS Acre75Tillable      
			 ,NULL AS Is75PercentLand        
			 ,NULL AS Percent75Land         
			 ,NULL AS Acre75Land           
			 ,NULL AS Is50PercentTillable    
			 ,NULL AS Percent50Tillable     
			 ,NULL AS Acre50Tillable       
			 ,NULL AS Is50PercentLand        
			 ,NULL AS Percent50Land         
			 ,NULL AS Acre50Land
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

INSERT INTO [Farm].[FarmEsmtSadcEligibilityTwo]
            (
			  ApplicationId
			 ,Prime
			 ,PrimeacresPct
			 ,Statewide
			 ,StatewideAcresPct
			 ,[Local]
			 ,LocalAcresPct
			 ,[Unique]
			 ,UniqueAcresPct
			 ,UniqueSoils
			 ,ListCropUniqueSoil
			 ,Other
			 ,OtherAcresPct
			 ,TotalNetAcres
			 ,TotalNetAcresPct
			 ,CroplandHarvested
			 ,CroplandHarvestedPct
			 ,CroplandPastured
			 ,CroplandPasturedPct
			 ,PermanentPasture
			 ,PermanentPasturePct
			 ,Woodlands
			 ,WoodlandsPct
			 ,ExceptionOther
			 ,ExceptionOtherPct
			 ,ExceptionTotalNetAcres
			 ,ExceptionTotalNetAcresPct
			 ,ZoningCode
			 ,MinimumLotSize
			 ,Regional
			 ,IsHighlandsRegion
			 ,IsPreservation
			 ,IsPlanningArea
			 ,CountyaverageRank
			 ,LastUpdatedBy  
			 ,LastUpdatedOn 
			)
			SELECT
	          @v_NEW_APPLICATION_ID  
			 ,NULL AS Prime
			 ,SoilsPrimePct
			 ,NULL AS Statewide
			 ,SoilsStatewidePct
			 ,NULL AS [Local]
			 ,SoilsLocalPct
			 ,NULL AS [Unique]
			 ,NULL AS UniqueAcresPct
			 ,NULL AS UniqueSoils
			 ,NULL AS ListCropUniqueSoil
			 ,NULL AS Other
			 ,NULL AS OtherAcresPct
			 ,NetAcres
			 ,100 AS TotalNetAcresPct
			 ,NULL AS CroplandHarvested
			 ,TillableAreaCropHarvestedPct
			 ,NULL AS CroplandPastured
			 ,PastureAreaPct
			 ,NULL AS PermanentPasture
			 ,PermanentPasturePct
			 ,NULL AS Woodlands
			 ,OtherWoodlandAreaPct
			 ,NULL AS ExceptionOther
			 ,NULL AS ExceptionOtherPct
			 ,NetAcres
			 ,100 AS ExceptionTotalNetAcresPct
             ,ZoningCurrent
             ,MinimunLotSize
             ,TRY_CAST(IsHighlands AS nvarchar(256)) AS Regional
			 ,IsHighlands
			 ,CASE
			      WHEN IsHighlandsCoreArea = 1 THEN 1
				  ELSE 0
              END AS IsPreservation
			 ,CASE
			      WHEN IsHighlandsCoreArea = 0 THEN 1
				  ELSE 0
              END AS IsPlanningArea
			 ,NULL AS CountyaverageRank
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE ProjectID = @v_LEGACY_APPLICATION_ID;

-----------------------------------------------------------------

		   SET @v_LEGACY_RECORD_INDEX = @v_LEGACY_RECORD_INDEX + 1;
END ;
		
		DROP TABLE IF EXISTS #temp_application_legacyEsmt;

	--Select 1/0 ;  -- To avoid accidental runs

	COMMIT;
	PRINT 'Legacy data migration has been completed.';
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000),@ErrorLine INT; 

	SET   @ErrorMessage = ERROR_MESSAGE() + ' ' + cast(@v_LEGACY_APPLICATION_ID as varchar);
	SET @ErrorLine = ERROR_LINE();
	ROLLBACK;

	SELECT @ErrorMessage AS ErrorMessage, @ErrorLine AS ErrorLine;
END CATCH

-------PROGRAM MANAGER -------------
INSERT INTO [Farm].[FarmReSaleDetails]
            (
			  FarmNumber
			 ,ReSellDate
			 ,ReSellPriceTotal
			 ,ReSellPricePerAcre
			 ,ReSellNotes
			 ,CurrentDeedBook
			 ,CurrentDeedPage
			 ,CurrentDeedFiled
			 ,InterestedinSelling
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
            SELECT 
			  FarmNumber
			 ,ReSellDate
			 ,ReSellPriceTotal
			 ,ReSellPricePerAcre
			 ,ReSellNotes
			 ,CurrentDeedBook
			 ,CurrentDeedPage
			 ,CurrentDeedFiled
			 ,InterestedinSelling
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02
			 WHERE [Status] IN ('Preserved','Fee Simple Purchase')

INSERT INTO [Farm].[FarmMonitoringDetails]
            (
			  FarmListId --- need to get Farmlist table, 
			 ,FirstInspect              
			 ,PreviousInspect            
			 ,LastInspect    
			 ,ChangesSinceLastInspect    
			 ,IssuesImpactingFarm        
			 ,IsInCompliance              
			 ,NonComplianceExplan         
			 ,InspectionComments         
			 ,CurrentDeedBook            
			 ,CurrentDeedPage             
			 ,CurrentDeedFiled
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
            SELECT 
			  FL.NewFarmListID
		     ,CASE WHEN ISDATE(OW.FirstInspect) = 1 THEN CAST(OW.FirstInspect AS DATE) ELSE NULL END AS FirstInspect
	         ,CASE WHEN ISDATE(OW.PreviousInspect) = 1 THEN CAST(OW.PreviousInspect AS DATE) ELSE NULL END AS PreviousInspect
	         ,CASE WHEN ISDATE(OW.LastInspect) = 1 THEN CAST(OW.LastInspect AS DATE) ELSE NULL END AS LastInspect
			 ,OW.ChangesSinceLastInspect    
			 ,OW.IssuesImpactingFarm  
			 ,CASE 
			      WHEN OW.IsInCompliance = 'Yes' THEN 1
				  WHEN OW.IsInCompliance = 'No' THEN 0
				  ELSE NULL
				  END AS IsInCompliance         
			 ,OW.NonComplianceExplan         
			 ,OW.InspectionComments        
			 ,OW.CurrentDeedBook          
			 ,OW.CurrentDeedPage             
			 ,OW.CurrentDeedFiled
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02 OW
			 JOIN [Farm].[FarmListLegacy] FL ON OW.FarmListID = FL.LegacyFarmListId 
			 WHERE OW.[Status] IN ('Preserved','Fee Simple Purchase')




