BEGIN TRY
   BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmEsmtLiens

-- Create Table
CREATE TABLE #FarmEsmtLiens(
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[PremisePreserved]				[bit]								NULL,
	[BankruptcyJudgment]			[bit]								NULL,
	[PowerLines]					[bit]								NULL,
	[WaterLines]					[bit]								NULL,
	[Sewer]							[bit]								NULL,
	[Bridge]						[bit]								NULL,
	[FloodRightWay]					[bit]								NULL,
	[TelephoneLines]				[bit]								NULL,
	[GasLines]						[bit]								NULL,
	[Other]							[bit]								NULL,
	[AccessEasement]				[bit]								NULL,
	[AccessDescribe]				[varchar](4000)						NULL,
	[ConservationEasement]			[bit]								NULL,
	[ConservationDescribe]			[varchar](4000)						NULL,
	[FederalProgram]				[bit]								NULL,
	[FederalDescribe]				[varchar](4000)						NULL,
	[SolarWindBiomass]				[bit]								NULL,
	[BiomassDescribe]				[varchar](4000)						NULL,
	[DateInstallation]				[datetime]							NULL,
	[PropertySale]					[bit]								NULL,
	[EstateSituation]				[bit]								NULL,
	[Bankruptcy]					[bit]								NULL,
	[ForeClosure]					[bit]								NULL,
	[LastUpdatedBy]					[varchar](128)						NULL, 
	[LastUpdatedOn]					[datetime]						NOT NULL, 
CONSTRAINT [PK_#FarmEsmtLiens_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

----Insert Script For #FarmEsmtLiens
INSERT INTO #FarmEsmtLiens
            (
              ApplicationId
             ,PremisePreserved				
             ,BankruptcyJudgment			
             ,PowerLines					
             ,WaterLines					
             ,Sewer							
             ,Bridge						
             ,FloodRightWay					
             ,TelephoneLines				
             ,GasLines						
             ,Other							
             ,AccessEasement				
             ,AccessDescribe				
             ,ConservationEasement			
             ,ConservationDescribe			
             ,FederalProgram				
             ,FederalDescribe				
             ,SolarWindBiomass				
             ,BiomassDescribe				
             ,DateInstallation				
             ,PropertySale					
             ,EstateSituation				
             ,Bankruptcy	
             ,ForeClosure
             ,LastUpdatedBy
             ,LastUpdatedOn
            )
			 SELECT
			 ProjectID
			 ,NULL AS PremisePreserved				
             ,NULL AS BankruptcyJudgment			
             ,NULL AS PowerLines					
             ,NULL AS WaterLines					
             ,NULL AS Sewer							
             ,NULL AS Bridge						
             ,NULL AS FloodRightWay					
             ,NULL AS TelephoneLines				
             ,NULL AS GasLines						
             ,NULL AS Other							
             ,NULL AS AccessEasement				
             ,NULL AS AccessDescribe				
             ,NULL AS ConservationEasement			
             ,NULL AS ConservationDescribe			
             ,NULL AS FederalProgram				
             ,NULL AS FederalDescribe				
             ,NULL AS SolarWindBiomass				
             ,NULL AS BiomassDescribe				
             ,NULL AS DateInstallation				
             ,NULL AS PropertySale					
             ,NULL AS EstateSituation				
             ,NULL AS Bankruptcy	
             ,NULL AS ForeClosure
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Term application Owner Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH