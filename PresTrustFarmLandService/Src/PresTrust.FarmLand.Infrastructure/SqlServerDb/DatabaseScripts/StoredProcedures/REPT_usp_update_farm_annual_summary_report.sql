IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[rept].[usp_update_farm_annual_summary_report]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE IF EXISTS [rept].[usp_update_farm_annual_summary_report]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rept].[usp_update_farm_annual_summary_report]

AS

--<flowerbox>
/***********************************************************************************
-- <summary>
-- This sproc populates updates ostf dashboard level 1 details
-- </summary>
--
-- <remarks>
- </remarks>
--
-- <syntax>
	
	EXEC	[rept].[usp_update_farm_annual_summary_report]
												
-- </syntax>
--
-- <author> 
-- <name>
-- VINAY ADARSH 
-- </name>
-- </author>
-- 
-- <template version="1.0" name="PresTrustSprocTemplate.sql" />
************************************************************************************
-- <historylog>
--  <log build="" revision="1.0" date="2025/01/16" GitWorkItem="">
--      Created 
--  </log>
--  <log build="" revision="1.0" date="" GitWorkItem="" DefectID="" email="">
--		 
--  </log>
-- </historylog>
***********************************************************************************/
--</flowerbox>

SET NOCOUNT ON;
BEGIN

	-------------------------------------------------
	--** DECLARE Variables
	-------------------------------------------------
	DECLARATION:
	
	-------------------------------------------------
	--** Initialize Standard Variables
	-------------------------------------------------
	INIT_ROUTINE:
		 
	-------------------------------------------------
	--** Main Procedure Logic
	-------------------------------------------------
	MAIN_ROUTINE:
	
	----------------------------------------------------------------------------------------------
	--** Populate BatchJobDetail for the given Job_Code.
	----------------------------------------------------------------------------------------------


		SELECT 
		    FA.AgencyId,
		    FL.MunicipalID,
		    MAX(FCD.MCCostSharePerAcre) AS MCCostSharePerAcre 
		INTO #CTE_TempMCCostShare
		FROM 
		    Farm.FarmApplication FA
		LEFT JOIN 
		    Farm.FarmEsmtAppAdminCostDetails FCD ON FCD.ApplicationId = FA.Id
		LEFT JOIN 
		    Farm.FarmList FL ON FL.AgencyID = FA.AgencyID AND FL.FarmListID = FA.FarmListId
		GROUP BY 
		    FL.MunicipalID, FA.AgencyId;
		
		SELECT 
		    FA.AgencyId,
		    FL.OriginalLandowner,
		    SUM(ER.Excep1Acres + ER.Excep2Acres + ER.Excep3Acres) / 100 AS "Exception Area Acreage",
		    SUM(ET.TotalNetAcresPct) AS "Tillable Acreage",
		    MAX("Preserved Acreage") AS "Preserved Acreage",
		    MAX("UnPreserved Acreage") AS "UnPreserved Acreage"
		INTO #CTE_TempApplicationDetails
		FROM 
		    Farm.FarmApplication FA
		LEFT JOIN 
		    Farm.FarmEsmtAppAdminExceptionRDSO ER ON FA.Id = ER.ApplicationId
		LEFT JOIN 
		    Farm.FarmEsmtSadcEligibilityTwo ET ON FA.Id = ET.ApplicationId
		LEFT JOIN 
		    Farm.FarmList FL ON FL.AgencyID = FA.AgencyId AND FL.FarmListID = FA.FarmListId
		LEFT JOIN 
		    (
		        SELECT 
		            FA.AgencyId,
		            MBL.FarmListID,
		            FL.OriginalLandowner,
		            SUM(MBL.Acres) / 100 AS "Preserved Acreage" 
		        FROM 
		            Farm.FarmApplication FA
		        LEFT JOIN 
		            Farm.FarmAppLocationDetails FTA ON FTA.ApplicationId = FA.Id
		        LEFT JOIN 
		            Farm.FarmList FL ON FL.AgencyID = FA.AgencyId AND FL.FarmListID = FA.FarmListId
		        LEFT JOIN 
		            Farm.FarmMunicipalityBlockLotParcel MBL ON MBL.FarmListID = FA.FarmListID 
		        WHERE 
		            FTA.IsChecked = 1 AND FA.StatusId = 206
		        GROUP BY 
		            FA.AgencyId, FL.OriginalLandowner, MBL.FarmListID
		    ) MBL ON MBL.FarmListID = FA.FarmListID AND MBL.OriginalLandowner = FL.OriginalLandowner AND MBL.AgencyId = FL.AgencyID
		LEFT JOIN 
		    (
		        SELECT 
		            FL.AgencyID,
		            FL.FarmListID,
		            FL.OriginalLandowner,
		            SUM(MBL.Acres) / 100 AS "UnPreserved Acreage" 
		        FROM 
		            Farm.FarmList FL
		        LEFT JOIN 
		            Farm.FarmMunicipalityBlockLotParcel MBL ON MBL.FarmListID = FL.FarmListID 
		        WHERE 
		            FL.OriginalLandowner IS NOT NULL
		        GROUP BY 
		            FL.AgencyID, FL.OriginalLandowner, FL.FarmListID
		    ) UA ON UA.FarmListID = FL.FarmListID
		WHERE 
		    FL.OriginalLandowner IS NOT NULL
		GROUP BY 
		    FL.OriginalLandowner, FA.AgencyId;
		
		---------------------------Delete Table Data Before Inserting New Data -------------------------
		DELETE FROM [rept].[FARMAnnualSummaryReport]
		
		---------------------------Inserting New Data Into Table ---------------------------------------
		INSERT INTO [rept].[FARMAnnualSummaryReport] 
		(
		    [AgencyId],
		    [MunicipalityId],
		    [Municipality],
		    [TotalFarms],
		    [Submitted],
		    [EsmtPendingApplications],
		    [PostClosing],
		    [Preserved],
		    [Petition],
		    [FundsAwarded],
		    [OriginalLandowner],
		    [TotalApplications],
		    [ActiveApplications],
		    [TermApplications],
		    [EsmtApplications],
		    [ExceptionAreaAcreage],
		    [PreservedAcreage],
		    [TillableAcreage],
		    [UnPreservedAcreage],
		    [TermPendingApplications],
		    [RejectedApplications],
		    [WithdrawnApplication],
		    [ActiveTermApplication],
		    [ExpiredTermApplication],
		    [PreservedAcres]
		)
		SELECT
		    FL.AgencyID,
		    MBL.MunicipalityId,
		    MU.Municipality,
		    COUNT(DISTINCT FL.FarmListID) AS TotalFarms,
		    COUNT(CASE WHEN FA.ApplicationTypeId = 2 AND FA.StatusId = 202 THEN 1 END) AS "Application submitted",
		    COUNT(CASE WHEN FA.ApplicationTypeId = 2 AND FA.StatusId IN (203, 204, 205, 209) THEN 1 END) AS ESMTPending,
		    COUNT(CASE WHEN FA.ApplicationTypeId = 2 AND FA.StatusId = 210 THEN 1 END) AS "Post Closing",
		    COUNT(CASE WHEN FA.ApplicationTypeId = 2 AND FA.StatusId = 206 THEN 1 END) AS Preserved,
		    COUNT(CASE WHEN FA.ApplicationTypeId = 1 AND FA.StatusId = 101 THEN 1 END) AS Petition,
		    SUM(MBL.AcresToBeAcquired) * MAX(DEF.MCCostSharePerAcre) AS "Funds Awarded",
		    FL.OriginalLandowner,
		    COUNT(DISTINCT FA.Id) AS "TotalApplications",
		    COUNT(DISTINCT CASE WHEN FA.StatusId IN (105, 205) THEN FA.Id END) AS ActiveApplications,
		    COUNT(DISTINCT CASE WHEN FA.ApplicationTypeId = 1 THEN FA.Id END) AS TermApplications,
		    COUNT(DISTINCT CASE WHEN FA.ApplicationTypeId = 2 THEN FA.Id END) AS PreservationApplications,
		    ABC.[Exception Area Acreage],
		    ABC.[Preserved Acreage],
		    ABC.[Tillable Acreage],
		    ABC.[UnPreserved Acreage],
		    COUNT(CASE WHEN FA.ApplicationTypeId = 1 AND FA.StatusId IN (103, 104) THEN 1 END) AS TermPending,
		    COUNT(CASE WHEN FA.StatusId IN (107, 207) THEN 1 END) AS "Rejected",
		    COUNT(CASE WHEN FA.StatusId IN (108,208) THEN 1 END) AS "Withdrawn",
		    COUNT(CASE WHEN FA.ApplicationTypeId = 1 AND FA.StatusId = 105 THEN 1 END) AS "Active Term",
		    COUNT(CASE WHEN FA.ApplicationTypeId = 1 AND FA.StatusId = 106 THEN 1 END) AS "Expired Term",
		    SUM(MBL.Acres) AS "PreservedAcres"
		FROM 
		    Farm.FarmList FL
		LEFT JOIN 
		    Farm.FarmApplication FA ON FL.AgencyID = FA.AgencyId AND FL.FarmListID = FA.FarmListId
		LEFT JOIN 
		    Farm.FarmAppLocationDetails AL ON FA.Id = AL.ApplicationId AND FA.FarmListId = AL.FarmListID
		LEFT JOIN 
		    Farm.FarmMunicipalityBlockLotParcel MBL ON MBL.Id = AL.ParcelId
		LEFT JOIN #CTE_TempMCCostShare DEF ON DEF.MunicipalID = MBL.MunicipalityId AND DEF.AgencyId = FL.AgencyID
		LEFT JOIN Core.Municipality MU ON MU.MunicipalId = MBL.MunicipalityId
		LEFT JOIN #CTE_TempApplicationDetails ABC ON ABC.OriginalLandowner = FL.OriginalLandowner AND FL.AgencyID = FA.AgencyId
		WHERE 
		    FL.AgencyID IS NOT NULL
		GROUP BY 
		    MBL.MunicipalityId,
		    MU.Municipality,
		    FL.AgencyID,
		    FL.OriginalLandowner,
		    ABC.[Exception Area Acreage],
		    ABC.[Preserved Acreage],
		    ABC.[Tillable Acreage],
		    ABC.[UnPreserved Acreage];
		
		-- Clean up temporary tables
		DROP TABLE #CTE_TempMCCostShare;
		DROP TABLE #CTE_TempApplicationDetails;
		-------------------------------------------------
	--** Dispose 
	-------------------------------------------------
	DISPOSE:
 
END

GO