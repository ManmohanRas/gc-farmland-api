BEGIN TRY
BEGIN TRANSACTION

--DROP TABLE
DROP TABLE IF EXISTS #FarmEsmtAppAdminOfferCost

--CREATE TABLE
CREATE TABLE #FarmEsmtAppAdminOfferCost(

   [Id]													   [integer] 		IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                                         [integer]                       NOT NULL,
   [CadbLandOwnerOffer]                                    [decimal](10,2)                     NULL,
   [IsOfferAccepted]                                       [bit]                               NULL,       
   [OtherSource]                                           [varchar](256)                      NULL,   
   [CostNote]                                              [varchar](4000)                     NULL,   
   [LastUpdatedBy]										   [varchar](128)		               NULL, 
   [LastUpdatedOn]										   [datetime]			           NOT NULL
   CONSTRAINT [PK_#FarmEsmtAppAdminOfferCost_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtAppAdminOfferCost
INSERT INTO #FarmEsmtAppAdminOfferCost
            (
			  ApplicationId
			 ,CadbLandOwnerOffer
			 ,IsOfferAccepted
			 ,OtherSource
			 ,CostNote
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
		    SELECT 
		      ProjectID
		     ,LandownerOfferPerAcre
		     ,CASE 
			      WHEN MCWasOfferAccepted = 'Yes' THEN 1
				  WHEN MCWasOfferAccepted = 'No' THEN 0
				  ELSE NULL
				  END AS MCWasOfferAccepted
		     ,OtherFundingSource
		     ,CostNote
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application Admin Actions Offer & Cost Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH