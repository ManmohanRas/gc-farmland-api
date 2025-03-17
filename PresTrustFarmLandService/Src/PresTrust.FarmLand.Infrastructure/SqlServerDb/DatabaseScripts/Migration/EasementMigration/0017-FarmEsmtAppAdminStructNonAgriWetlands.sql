BEGIN TRY
BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmEsmtAppAdminStructNonAgriWetlands

-- Create Table
CREATE TABLE #FarmEsmtAppAdminStructNonAgriWetlands(
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[IsResidenceOnPresLand]         [bit]                               NULL,
	[ImprovRes]					    [varchar](4000)					    NULL,	
	[AreNonAgUses]				    [bit]					            NULL,	 
	[NonAgExplan]				    [varchar](4000)					    NULL,	
	[IsFarmMarket]                  [bit]                               NULL, 
	[ImprovAg]                      [varchar](4000)	                    NULL,
	[WetlandsSurveyor]              [varchar](2000)                     NULL,
	[DateofDelineation]             [datetime]                          NULL,
	[AcresofWetlands]               [decimal](10,2)                     NULL,
	[AcresofTransitionArea]         [decimal](10,2)                     NULL,
	[WetlandsClassification]        [varchar](128)                      NULL,
	[LastUpdatedBy]					[varchar](128)					    NULL,	
	[LastUpdatedOn]					[datetime]						NOT NULL, 
CONSTRAINT [PK_#FarmEsmtAppAdminStructNonAgriWetlands_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

----Insert Script For #FarmEsmtAppAdminStructNonAgriWetlands
INSERT INTO #FarmEsmtAppAdminStructNonAgriWetlands
            (
			  ApplicationId
			 ,IsResidenceOnPresLand
			 ,ImprovRes
			 ,AreNonAgUses
			 ,NonAgExplan
			 ,IsFarmMarket
			 ,ImprovAg
			 ,WetlandsSurveyor
			 ,DateofDelineation
			 ,AcresofWetlands
			 ,AcresofTransitionArea
			 ,WetlandsClassification
			 ,LastUpdatedBy  
			 ,LastUpdatedOn
			)
		    SELECT 
		      ProjectID
		     ,IsResidenceOnPresLand
		     ,ImprovRes
		     ,CASE 
			      WHEN AreNonAgUses = 'Yes' THEN 1
				  WHEN AreNonAgUses = 'No' THEN 0
				  ELSE NULL
				  END AS AreNonAgUses
		     ,NonAgExplan
		     ,IsFarmMarket
		     ,ImprovAg
		     ,WetlandsSurveyor
		     ,DateofDelineation 
		     ,AcresofWetlands
		     ,AcresofTransitionArea
		     ,WetlandsClassification
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application Admin Actions StructNonAgriWetlands Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH