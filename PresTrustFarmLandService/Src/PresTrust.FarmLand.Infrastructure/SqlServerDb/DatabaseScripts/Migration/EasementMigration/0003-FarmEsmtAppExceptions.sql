BEGIN TRY
   BEGIN TRANSACTION

   ---Drop Table
   DROP TABLE IF EXISTS #FarmEsmtAppExceptions

   -- Create Table
   CREATE TABLE #FarmEsmtAppExceptions(
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[ExpectedTaxLots]				[bit]								NULL,
	[ExceptionNonSeverable]			[varchar](128)						NULL,
	[ExceptionTotalNonSeverable]	[varchar](128)						NULL,
	[ExceptionSeverable]			[varchar](128)						NULL,
	[ExceptionTotalSeverable]		[varchar](128)						NULL,
	[Acres]						    [Decimal](18,2)						NULL,
	[LastUpdatedBy]					[varchar](128)						NULL, 
	[LastUpdatedOn]					[datetime]						NOT NULL, 
CONSTRAINT [PK_#FarmEsmtAppExceptions_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


---Insert Script For [FarmEsmtAppExceptions]
INSERT INTO #FarmEsmtAppExceptions
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
			 ProjectID
			 ,CASE 
			      WHEN NumberofExceps = 0 THEN 0
			      ELSE 1
			  END AS ExpectedTaxLots
			 ,NULL AS ExceptionNonSeverable
             ,NULL AS ExceptionTotalNonSeverable
             ,NULL AS ExceptionSeverable
             ,NULL AS ExceptionTotalSeverable
			 ,ISNULL(NetAcres,'') AS Acres
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application Exceptions Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH