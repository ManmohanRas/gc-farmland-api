BEGIN TRY
BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmEsmtSadcHistory

-- Create Table
CREATE TABLE #FarmEsmtSadcHistory(
	[Id]							[integer] 		            IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]					                NOT NULL,
	[SquareFootage]					[decimal](10,2)					                NULL,
	[PreliminaryExpiration]		    [datetime]						                NULL,
	[FinalExpiration]			    [datetime]					                    NULL,
	[EstateWill]			        [bit]				                            NULL,
	[TaxWaiver]				        [bit]						                    NULL,
	[NoWaiver]					    [bit]   					                    NULL,
	[TrustWill]				        [bit]					                        NULL,
	[TrustDocuments]			    [bit]   					                    NULL,
	[LastUpdatedBy]					[varchar](128)					                NULL,
	[LastUpdatedOn]				    [datetime]					                    NULL,
CONSTRAINT [PK_#FarmEsmtSadcHistory_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtSadcHistory
INSERT INTO #FarmEsmtSadcHistory
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
		      ProjectID
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

            COMMIT;
            PRINT 'Esmt application SADC History Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH