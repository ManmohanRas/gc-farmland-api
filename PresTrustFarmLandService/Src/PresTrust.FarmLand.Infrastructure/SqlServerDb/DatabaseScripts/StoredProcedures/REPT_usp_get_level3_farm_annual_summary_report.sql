IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[rept].[usp_get_level3_farm_annual_summary_report]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE IF EXISTS [rept].usp_get_level3_farm_annual_summary_report
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [rept].[usp_get_level3_farm_annual_summary_report]

AS

--<flowerbox>
/***********************************************************************************
-- <summary>
-- This sproc populates updates farm dashboard level 3 details
-- </summary>
--
-- <remarks>
- </remarks>
--
-- <syntax>
	
	EXEC	[rept].[usp_get_level3_farm_annual_summary_report]
												
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
		 [AgencyId]
		,[MunicipalityId]
		,[Municipality]
		,[TotalFarms]
		,[Submitted]
		,[EsmtPendingApplications]
		,[PostClosing]
		,[Preserved]
		,[Petition]
		,[FundsAwarded]
		,[OriginalLandowner]
		,[TotalApplications]
		,[TermApplications]
		,[EsmtApplications]
		,[ExceptionAreaAcreage]
		,[TillableAcreage]
		,[TermPendingApplications]
		,[RejectedApplications]
		,[WithdrawnApplication]
		,[ExpiredTermApplication]
		,[PreservedAcres]
		,[ActiveTermApplication]
	FROM [rept].[FARMAnnualSummaryReport];		

	-------------------------------------------------
	--** Dispose 
	-------------------------------------------------
	DISPOSE:
 
END

GO