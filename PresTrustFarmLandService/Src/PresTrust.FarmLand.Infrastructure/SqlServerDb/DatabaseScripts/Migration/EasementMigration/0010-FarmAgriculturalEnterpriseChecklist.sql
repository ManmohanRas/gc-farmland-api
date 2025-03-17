BEGIN TRY
   BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmAgriculturalEnterpriseChecklist

---Create Table
CREATE TABLE #FarmAgriculturalEnterpriseChecklist (
    [Id]                 [integer] IDENTITY(1,1)	NOT NULL,
    [ApplicationId]	     [integer]	                NOT NULL,
	[ActivitySubTypeId]  [integer]                  NOT NULL,
	[Title]              [varchar](256)             NOT NULL,
	[SicCode]            [varchar](128)             NOT NULL,
    [IsPrimary]          [bit]                          NULL,
    [IsSecondary]        [bit]                          NULL,
	[LastUpdatedBy]	     [varchar](128)	                NULL,
    [LastUpdatedOn]		 [DateTime]			            NULL,
CONSTRAINT [PK_#FarmAgriculturalEnterpriseChecklist_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

----Insert Scripts For #FarmAgriculturalEnterpriseChecklist

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

INSERT INTO #FarmAgriculturalEnterpriseChecklist
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

            COMMIT;
            PRINT 'Esmt application Equine Uses Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH