BEGIN TRY
BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmEsmtAppAdminAppraisalReport

-- Create Table
CREATE TABLE #FarmEsmtAppAdminAppraisalReport(
	[Id]												   [integer] 		IDENTITY(1,1)  NOT NULL,
	[ApplicationId]                                        [integer]                       NOT NULL,
	[AsOfDate]											   [datetime]						   NULL,
	[AppraiserName1]									   [varchar](128)		               NULL,
	[AppraiserName2]									   [varchar](128)		               NULL,
	[LowerAppraiser]									   [varchar](128)		               NULL,
	[HigherAppraiser]									   [varchar](128)		               NULL,
	[PreHLBeforeValue1]									   [decimal](18,2)					   NULL,
	[PreHLAfterValue1]									   [decimal](18,2)					   NULL,
	[PreHLEsmtValue1]									   [decimal](18,2)					   NULL,
	[PreHLBeforeValue2]									   [decimal](18,2)					   NULL,
	[PreHLAfterValue2]									   [decimal](18,2)					   NULL,
	[PreHLEsmtValue2]									   [decimal](18,2)					   NULL,
	[PostHLBeforeValue1]								   [decimal](18,2)					   NULL,
	[PostHLAfterValue1]									   [decimal](18,2)					   NULL,
	[PostHLEsmtValue1]									   [decimal](18,2)					   NULL,
	[PostHLBeforeValue2]								   [decimal](18,2)					   NULL,
	[PostHLAfterValue2]									   [decimal](18,2)					   NULL,
	[PostHLEsmtValue2]									   [decimal](18,2)					   NULL,
	[DiffInEsmtAppraisals]								   [decimal](18,2)					   NULL,
	[PostHLDifference]									   [decimal](18,2)					   NULL,
	[DiffInPreandPostHL]								   [decimal](18,2)					   NULL,
	[WithInHighlands]									   [bit]							   NULL,
	[WithInPreservationArea]							   [bit]							   NULL,
	[SADCCertifiedEsmttotal]							   [decimal](18,2)					   NULL,
	[SADCEsmtBeforePct]                                    [decimal](18,2)					   NULL,
	[AppraisedZoning]									   [varchar](128)		               NULL,
	[ApraisedZoningClass]								   [varchar](128)		               NULL,
	[AppraisalComments]									   [varchar](4000)					   NULL,
	[FreeHolderDate]									   [datetime]						   NULL,
	[CurrentZoning]										   [varchar](128)		               NULL,
	[CADBEasement]										   [decimal](18,2)					   NULL,
	[CADBBefore]										   [decimal](18,2)					   NULL,
	[CADBEaseBefore]									   [decimal](18,2)		               NULL,
	[LastUpdatedBy]										   [varchar](128)		               NULL,
	[LastUpdatedOn]										   [datetime]			           NOT NULL,
CONSTRAINT [PK_#FarmEsmtAppAdminAppraisalReport _Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

----Insert Script For #FarmEsmtAppAdminAppraisalReport
INSERT INTO #FarmEsmtAppAdminAppraisalReport
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
		      ProjectID
		     ,CASE WHEN ISDATE(AppraisalAsofDate) = 1 THEN CAST(AppraisalAsofDate AS DATE) ELSE NULL END AS AsOfDate 
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
			 ,CASE WHEN ISDATE(MCExecutesContract) = 1 THEN CAST(MCExecutesContract AS DATE) ELSE NULL END AS FreeHolderDate 
		     ,ZoningCurrent
		     ,MCOffertoLandowner
		     ,MCCertifiedBeforeValue
		     ,TRY_CAST(REPLACE(MCCertifiedPctEaseofBeforeValue, '%','') AS decimal(18,2)) AS CADBEaseBefore
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application Admin Actions AppraisalReport legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH
