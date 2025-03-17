BEGIN TRY
	BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmEsmtAppSignatory

-- Create Table
CREATE TABLE #FarmEsmtAppSignatory(
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[AmountPerAcre]                 [decimal](18,4)                 NULL    ,
	[Designation]					[varchar](128)					NULL	,
	[Title]							[varchar](128)					NULL	, 
	[SignedOn]						[DateTime]						NULL	, 
	[LastUpdatedBy]					[varchar](128)					NULL	, 
	[LastUpdatedOn]					[DateTime]						NOT NULL, 
CONSTRAINT [PK_#FarmEsmtAppSignatory_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtAppSignatory
INSERT INTO #FarmEsmtAppSignatory
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
			  ProjectID
			 ,AskingPricePerAcre
			 ,NULL AS Designation
			 ,NULL AS Title
			 ,NULL AS SignedOn
			 ,'mc-support'  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application Signatory Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH