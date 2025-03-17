BEGIN TRY
   BEGIN TRANSACTION

   -- Drop Table
DROP TABLE IF EXISTS #FarmEsmtAppAdminCostDetails

-- Create Table
CREATE TABLE #FarmEsmtAppAdminCostDetails(
[Id]                                  [integer] IDENTITY(1,1)   NOT NULL,
[ApplicationId]                       [integer]                 NOT NULL,
[GrossAcers]                          [decimal](10,2)               NULL,
[SADCBeforeValueAC]                   [decimal](10,2)               NULL,
[SADCAfterValueAC]                    [decimal](10,2)               NULL,
[OfferToSADC]                         [decimal](10,2)               NULL,
[SADCCostShareAC]                     [decimal](10,2)               NULL,
[SADCCostShareTotal]                  [decimal](10,2)               NULL,
[SADCCostShareAcqTotal]               [decimal](10,2)               NULL,
[NoteOfBreakdown]                     [varchar](4000)               NULL,  
[SADCCostShareofOfferPct]             [decimal](10,2)               NULL,
[SADCCertifiedEasementValuePerAcre]   [decimal](10,2)               NULL,
[SADCPctofCertifiedEaseValue]         [decimal](10,4)               NULL,
[NetAcres]                            [decimal](10,2)               NULL,
[MCOffertoLandowner]                  [decimal](10,2)               NULL,
[MCCertifiedBeforeValue]              [decimal](10,2)               NULL,
[MCCostSharePerAcre]                  [decimal](10,2)               NULL,
[OtherSource]                         [varchar](128)                NULL,
[OtherCostShare]                      [decimal](10,2)               NULL,
[MCCostSharePct]                      [decimal](10,2)               NULL,
[MCCostShareTotal]                    [decimal](10,2)               NULL,
[TotalCost]                           [decimal](10,2)               NULL,
[TotalCostPerAcre]                    [decimal](10,2)               NULL,
[CountyFunds]                         [varchar](128)                NULL,
[LastUpdatedBy]					      [varchar](128)			    NULL, 
[LastUpdatedOn]					      [DateTime]				NOT NULL,
CONSTRAINT [PK_#FarmEsmtAppAdminCostDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtAppAdminCostDetails
INSERT INTO #FarmEsmtAppAdminCostDetails
            (
              ApplicationId
             ,GrossAcers
             ,SADCBeforeValueAC                   
             ,SADCAfterValueAC                    
             ,OfferToSADC                     
             ,SADCCostShareAC                     
             ,SADCCostShareTotal                  
             ,SADCCostShareAcqTotal               
             ,NoteOfBreakdown                
             ,SADCCostShareofOfferPct            
             ,SADCCertifiedEasementValuePerAcre   
             ,SADCPctofCertifiedEaseValue    
             ,NetAcres          
             ,MCOffertoLandowner                  
             ,MCCertifiedBeforeValue              
             ,MCCostSharePerAcre               
             ,OtherSource                   
             ,OtherCostShare                      
             ,MCCostSharePct                      
             ,MCCostShareTotal                    
             ,TotalCost                     
             ,TotalCostPerAcre
             ,CountyFunds
             ,LastUpdatedBy
			 ,LastUpdatedOn
           )
			SELECT
			  ProjectID
			 ,GrossAcres
			 ,SADCBeforeValuePerAcre
			 ,SADCAfterValuePerAcre
			 ,NULL AS OfferToSADC
			 ,SADCCostSharePerAcre
			 ,SADCCostShareTotal
			 ,TRY_CAST(REPLACE(SADCCostShareofAcqTotalPct, '%', '') AS decimal(10,2)) AS SADCCostShareofAcqTotalPct
			 ,CostNote
			 ,TRY_CAST(REPLACE(SADCCostShareofOfferPct, '%', '') AS decimal(10,2)) AS SADCCostShareofOfferPct
			 ,SADCCertifiedEasementValuePerAcre
			 ,SADCPctofCertifiedEaseValue
			 ,NetAcres
			 ,MCOffertoLandowner
			 ,MCCertifiedBeforeValue
			 ,MCCostSharePerAcre
			 ,OtherFundingSource
			 ,OtherCostShareTotal
			 ,TRY_CAST(REPLACE(MCCostSharePct, '%', '') AS decimal(10,2)) AS MCCostSharePct
			 ,MCCostShareTotal
			 ,TotalCost
			 ,TotalCostPerAcre
			 ,CASE
			      WHEN CountyFunds = 'Cap Ord' THEN 'CapOrd'
			      WHEN CountyFunds = 'SADC-County' THEN 'SADCCounty'
			      WHEN CountyFunds = 'TF' THEN 'TF'
			      ELSE NULL
			  END AS CountyFunds
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application Admin Actions Cost Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH
