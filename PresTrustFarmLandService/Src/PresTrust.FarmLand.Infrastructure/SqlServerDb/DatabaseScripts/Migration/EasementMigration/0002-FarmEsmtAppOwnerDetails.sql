BEGIN TRY
   BEGIN TRANSACTION

   ---Drop Table
   DROP TABLE IF EXISTS #FarmEsmtAppOwnerDetails

   -- Create Table
CREATE TABLE #FarmEsmtAppOwnerDetails(
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[SoleProprietor]				[bit]								NULL,
	[ProprirtorPartnership]			[bit]								NULL,
	[MultiProprietor]				[bit]								NULL,
	[ExecutorEstate]				[bit]								NULL,
	[CPFeeSimple]					[bit]								NULL,
	[CPEasement]					[bit]								NULL,
	[MunicipalityCurrentEO]			[bit]								NULL,
	[ConservationOrg]				[bit]								NULL,
	[FarmName]						[varchar](128)						NULL,
	[ResidentName]					[varchar](128)						NULL, 
	[AttarneyName]					[varchar](128)						NULL, 
	[AtMailingAddress]				[varchar](128)						NULL,
	[ATFirmName]					[varchar](128)						NULL,
	[ResiPhoneNumber]				[varchar](15)						NULL,
	[PdStreetAddress]				[varchar](128)						NULL,
	[OwnedContinuesly]				[bit]								NULL,
	[SubjectProperty]				[bit]								NULL,
	[LastUpdatedBy]					[varchar](128)						NULL, 
	[LastUpdatedOn]					[datetime]						NOT NULL, 
CONSTRAINT [PK_#FarmEsmtAppOwnerDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


---Insert Script for FarmEsmtAppOwnerDetails

INSERT INTO #FarmEsmtAppOwnerDetails
            (
              ApplicationId
             ,SoleProprietor
             ,ProprirtorPartnership
             ,MultiProprietor
             ,ExecutorEstate
             ,CPFeeSimple
             ,CPEasement
             ,MunicipalityCurrentEO
             ,ConservationOrg
             ,FarmName
             ,ResidentName
             ,AttarneyName
             ,AtMailingAddress
             ,ATFirmName
             ,ResiPhoneNumber
             ,PdStreetAddress
             ,OwnedContinuesly
             ,SubjectProperty
             ,LastUpdatedBy
             ,LastUpdatedOn
            )
			SELECT
			  ProjectID
			 ,0 AS SoleProprietor
             ,0 AS ProprirtorPartnership
             ,0 AS MultiProprietor
             ,0 AS ExecutorEstate
             ,0 AS CPFeeSimple
             ,0 AS CPEasement
             ,0 AS MunicipalityCurrentEO
             ,0 AS ConservationOrg
			 ,FarmName
			 ,NULL AS ResidentName
			 ,ISNULL(Attorney,'') AS  AttarneyName
			 ,ISNULL(AttorneyContactInfo,'') AS AtMailingAddress
			 ,ISNULL(AttorneyContactInfo,'') AS ATFirmName
			 ,NULL AS ResiPhoneNumber
			 ,ISNULL(CONCAT(FarmLocation,' ', Municipality),'') AS PdStreetAddress
			 ,0 AS OwnedContinuesly
             ,0 AS SubjectProperty
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM [FARM].[OwnerPropertyLEGACY_Rev02]

            COMMIT;
            PRINT 'Esmt application Owner Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH