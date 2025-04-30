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
		
		
---------------------------Delete Table Data Before Inserting New Data -------------------------
DELETE FROM [rept].[FARMAnnualSummaryReport]

---------------------------Inserting New Data Into Table ---------------------------------------
INSERT INTO [rept].[FARMAnnualSummaryReport] 
(
    [AgencyId],
	[OriginalLandowner],
    [MunicipalityId],
    [Municipality],
	[TotalApplications],
	[TermApplications],
    [EsmtApplications],
	[ActiveTermApplication],
    [ExpiredTermApplication],
	[Petition],
	[TermPendingApplications],
	[Submitted],
	[EsmtPendingApplications],
	[PostClosing],
	[Preserved],
	[ActiveApplications],
	[RejectedApplications],
    [WithdrawnApplication],
    [TotalFarms],
	[TillableAcreage],
	[ExceptionAreaAcreage],
	[PreservedAcres],
	[PreservedAcreage],
    [FundsAwarded]
)
-- Combined Query: FarmList + Applications + Acres
SELECT
    COALESCE(FLQ.AgencyId, AQ.AgencyId, ACQ.AgencyId) AS AgencyId,
    COALESCE(FLQ.OriginalLandowner, AQ.OriginalLandowner, ACQ.OriginalLandowner) AS OriginalLandowner,
    COALESCE(FLQ.MunicipalId, AQ.MunicipalId, ACQ.MunicipalId) AS MunicipalId,
    COALESCE(FLQ.Municipality, AQ.Municipality, ACQ.Municipality) AS Municipality,

    -- Application Counts
    AQ.TotalApplications,
    AQ.TermApplications,
    AQ.EsmtApplications,
    AQ.[Active Term],
    AQ.[Expired Term],
    AQ.[Term Petition Request],
    AQ.TermPending,
    AQ.[Application submitted],
    AQ.ESMTPending,
    AQ.[Post Closing],
    AQ.Preserved,
    AQ.ActiveApplications,
    AQ.Rejected,
    AQ.Withdrawn,

	 -- FarmList Counts
    FLQ.TotalFarmLists,

    AQ.[Tillable Acreage],
    AQ.[Exception Area Acreage],

    -- Acreage / Funding
    ACQ.PreservedAcres,
    ACQ.PreservedAcreage,
    ACQ.[Funds Awarded]

FROM 
    -- FarmList Subquery
    (
        SELECT
            FL.AgencyId,
            FL.OriginalLandowner,
            MU.MunicipalId,
            MU.Municipality,
            COUNT(FL.FarmListId) AS TotalFarmLists
        FROM Farm.FarmList FL 
        LEFT JOIN Core.Municipality MU ON FL.MunicipalID = MU.MunicipalId
        GROUP BY FL.AgencyID, FL.OriginalLandowner, MU.MunicipalId, MU.Municipality
    ) FLQ

FULL OUTER JOIN 
    -- Application Subquery
    (
        SELECT
            FA.AgencyId,
            FL.OriginalLandowner,
            MU.MunicipalId,
            MU.Municipality,
            COUNT(CASE WHEN FA.StatusId IN (102,103,104,105,106,107,108,202,203,204,205,206,207,208,209,210) THEN 1 END) AS TotalApplications,
            COUNT(CASE WHEN FA.ApplicationTypeId = 1 AND FA.StatusId != 101 THEN 1 END) AS TermApplications,
            COUNT(CASE WHEN FA.ApplicationTypeId = 2 AND FA.StatusId != 201 THEN 1 END) AS EsmtApplications,
            COUNT(CASE WHEN FA.ApplicationTypeId = 1 AND FA.StatusId = 105 THEN 1 END) AS [Active Term],
            COUNT(CASE WHEN FA.ApplicationTypeId = 1 AND FA.StatusId = 106 THEN 1 END) AS [Expired Term],
            COUNT(CASE WHEN FA.ApplicationTypeId = 1 AND FA.StatusId = 102 THEN 1 END) AS [Term Petition Request],
            COUNT(CASE WHEN FA.ApplicationTypeId = 1 AND FA.StatusId IN (103, 104) THEN 1 END) AS TermPending,
            COUNT(CASE WHEN FA.ApplicationTypeId = 2 AND FA.StatusId = 202 THEN 1 END) AS [Application submitted],
            COUNT(CASE WHEN FA.ApplicationTypeId = 2 AND FA.StatusId IN (203, 204, 205, 209) THEN 1 END) AS ESMTPending,
            COUNT(CASE WHEN FA.ApplicationTypeId = 2 AND FA.StatusId = 210 THEN 1 END) AS [Post Closing],
            COUNT(CASE WHEN FA.ApplicationTypeId = 2 AND FA.StatusId = 206 THEN 1 END) AS Preserved,
            COUNT(CASE WHEN FA.StatusId IN (103,104,105,203,204,205,209,210) THEN FA.Id END) AS ActiveApplications,
            COUNT(CASE WHEN FA.StatusId IN (107, 207) THEN 1 END) AS Rejected,
            COUNT(CASE WHEN FA.StatusId IN (108,208) THEN 1 END) AS Withdrawn,
            SUM(CASE WHEN FA.StatusId = 206 THEN ET.exceptionTotalNetAcres END) AS [Tillable Acreage],
            SUM(CASE WHEN FA.StatusId = 206 THEN ER.Excep1Acres + ER.Excep2Acres + ER.Excep3Acres END) AS [Exception Area Acreage]
        FROM Farm.FarmApplication FA
        RIGHT JOIN Farm.FarmList FL ON FA.FarmListId = FL.FarmListID
        LEFT JOIN Core.Municipality MU ON FL.MunicipalID = MU.MunicipalId
        LEFT JOIN FARM.FarmEsmtSadcEligibilityTwo ET ON ET.ApplicationId = FA.Id
        LEFT JOIN Farm.FarmEsmtAppAdminExceptionRDSO ER ON FA.Id = ER.ApplicationId
        GROUP BY FA.AgencyID, FL.OriginalLandowner, MU.MunicipalId, MU.Municipality
    ) AQ
    ON FLQ.AgencyId = AQ.AgencyId AND FLQ.OriginalLandowner = AQ.OriginalLandowner AND FLQ.MunicipalId = AQ.MunicipalId

FULL OUTER JOIN 
    -- Acres Subquery
    (
        SELECT
            FA.AgencyId,
            FL.OriginalLandowner,
            MU.MunicipalId,
            MU.Municipality,
            SUM(CASE WHEN FA.StatusId IN(206,105) AND FLD.IsChecked = 1 THEN FLD.AcresToBeAcquired END) AS PreservedAcres,
            SUM(CASE WHEN FA.StatusId IN(206,105) AND FLD.IsChecked = 1 THEN FLD.AcresToBeAcquired END) AS PreservedAcreage,
            SUM(CASE WHEN FA.StatusId = 206 AND FLD.IsChecked = 1 THEN FLD.AcresToBeAcquired END) * MAX(FCD.MCCostSharePerAcre) AS [Funds Awarded]
        FROM Farm.FarmApplication FA
        RIGHT JOIN Farm.FarmList FL ON FA.FarmListId = FL.FarmListID
        LEFT JOIN Core.Municipality MU ON FL.MunicipalID = MU.MunicipalId
        LEFT JOIN Farm.FarmAppLocationDetails FLD ON FA.Id = FLD.ApplicationId AND FLD.FarmListID = FA.FarmListID
        LEFT JOIN Farm.FarmEsmtAppAdminCostDetails FCD ON FCD.ApplicationId = FA.Id
        GROUP BY FA.AgencyID, FL.OriginalLandowner, MU.MunicipalId, MU.Municipality
    ) ACQ
    ON COALESCE(FLQ.AgencyId, AQ.AgencyId) = ACQ.AgencyId
    AND COALESCE(FLQ.OriginalLandowner, AQ.OriginalLandowner) = ACQ.OriginalLandowner
    AND COALESCE(FLQ.MunicipalId, AQ.MunicipalId) = ACQ.MunicipalId
	

		-------------------------------------------------
	--** Dispose 
	-------------------------------------------------
	DISPOSE:
 
END

GO