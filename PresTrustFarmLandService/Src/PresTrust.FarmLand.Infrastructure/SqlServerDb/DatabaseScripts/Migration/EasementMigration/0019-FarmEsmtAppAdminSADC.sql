BEGIN TRY
BEGIN TRANSACTION

--Drop Table
DROP TABLE IF EXISTS #FarmEsmtAppAdminSADC

-- Create Table
CREATE TABLE #FarmEsmtAppAdminSADC(
	[Id]                     [integer]                 IDENTITY(1,1)           NOT NULL,
	[ApplicationId]          [integer]                                         NOT NULL,
	[ProgramName]            [varchar](54)                                         NULL,
	[SADCFundingRoundYear]   [varchar](128)                                        NULL,
	[SADCQualityScore]       [decimal](18,2)                                       NULL,
	[SADCPrelimRank]         [integer]                                             NULL,
	[SADCFinalRank]          [integer]                                             NULL,
	[SADCFinalScore]	     [integer]                                             NULL,
	[LastUpdatedBy]          [varchar](128)                                        NULL,
	[LastUpdatedOn]          [datetime]                                        NOT NULL	

  CONSTRAINT [PK_#FarmEsmtAppAdminSADC_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtAppAdminSADC
INSERT INTO #FarmEsmtAppAdminSADC
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
		      ProjectID
		     ,WhichEPP
			 ,REPLACE(SADCFundingRoundYear, 'n/a', '0') AS SADCFundingRoundYear
             ,REPLACE(SADCQualityScore, 'n/a',0) AS SADCQualityScore
		     ,REPLACE(REPLACE(SADCPrelimRank,'n/a',0),'xxx',0) AS SADCPrelimRank
		     ,REPLACE(SADCFinalRank, 'n/a',0) AS SADCFinalRank
		     ,TRY_CAST(REPLACE(SADCFinalScore, 'n/a',0) AS decimal(10,2)) AS SADCFinalScore
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application Admin Actions SADC Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH