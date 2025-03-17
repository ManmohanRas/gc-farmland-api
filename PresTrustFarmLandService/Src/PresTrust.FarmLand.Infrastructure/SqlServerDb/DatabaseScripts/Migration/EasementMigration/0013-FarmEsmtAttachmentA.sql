BEGIN TRY
   BEGIN TRANSACTION
--DROP TABLE
DROP TABLE IF EXISTS #FarmEsmtAttachmentA

--CREATE TABLE
CREATE TABLE #FarmEsmtAttachmentA(
   [Id]							   [integer] 		       IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                 [integer]                              NOT NULL,
   [IsOfferPriceIndicated]	       [bit]                                  NOT NULL,
   [OfferPriceOpinion]		       [varchar](50)                              NULL, 
   [AveragePerAcre]	     	       [decimal](18,4)		                      NULL, 
   [OfferPriceComments] 		   [varchar](4000)		                      NULL, 
   [LastUpdatedBy]				   [varchar](128)		                      NULL, 
   [LastUpdatedOn]				   [datetime]			                  NOT NULL
   CONSTRAINT [PK_#FarmEsmtAttachmentA_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtAttachmentA
INSERT INTO #FarmEsmtAttachmentA
            (
              ApplicationId
             ,IsOfferPriceIndicated
             ,OfferPriceOpinion
             ,AveragePerAcre
             ,OfferPriceComments
             ,LastUpdatedBy  
			 ,LastUpdatedOn
            )
			 SELECT
			  ProjectID
			 ,0 AS IsOfferPriceIndicated
             ,NULL AS OfferPriceOpinion
             ,NULL AS AveragePerAcre
             ,NULL AS OfferPriceComments
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application AttachmentA Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH