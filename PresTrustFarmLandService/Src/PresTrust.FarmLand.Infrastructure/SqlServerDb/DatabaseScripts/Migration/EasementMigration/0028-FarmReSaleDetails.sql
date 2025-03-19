BEGIN TRY
BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmReSaleDetails

-- Create Table
CREATE TABLE #FarmReSaleDetails(
[Id]                                  [integer] IDENTITY(1,1)   NOT NULL,
[FarmNumber]                          [varchar](5)                  NULL,
[ReSellDate]                          [DateTime]                    NULL,               
[ReSellPriceTotal]                    [decimal](10,2)               NULL,
[ReSellPricePerAcre]                  [decimal](10,2)               NULL,
[ReSellNotes]                         [varchar](4000)               NULL,
[CurrentDeedBook]                     [varchar](50)                 NULL,
[CurrentDeedPage]                     [varchar](50)                 NULL, 
[CurrentDeedFiled]                    [DateTime]                    NULL,
[InterestedinSelling]                 [bit]                         NULL,                
[LastUpdatedBy]					      [varchar](128)			    NULL, 
[LastUpdatedOn]					      [DateTime]				NOT NULL,
CONSTRAINT [PK_#FarmReSaleDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmReSaleDetails
INSERT INTO #FarmReSaleDetails
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

            COMMIT;
            PRINT 'Program Manager ReSale Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH