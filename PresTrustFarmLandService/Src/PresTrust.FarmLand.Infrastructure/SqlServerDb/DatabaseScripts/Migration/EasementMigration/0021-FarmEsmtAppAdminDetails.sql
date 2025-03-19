BEGIN TRY
BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmEsmtAppAdminDetails

-- Create Table
CREATE TABLE #FarmEsmtAppAdminDetails(
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[FarmerName]				    [varchar](128)					    NULL,
	[FarmerPhone]					[varchar](15)						NULL,
	[FarmerContactInfo]			    [varchar](128)						NULL,
	[FarmFeatures]			        [varchar](4000)						NULL,
	[AgreestoHaveSign]				[bit]    							NULL,
	[ConsPlanDate]					[varchar](128) 						NULL, -- dateTime field
	[ConsPlanComment]				[varchar](4000)						NULL,
	[DroppedProjectWhy]			    [varchar](4000)						NULL,
	[ImperviousPercentage]			[decimal](10,2)						NULL,
	[ImperviousSurfaceAcreage]		[decimal](10,2)						NULL,
	[InterestedinSADCSign]          [bit]                               NULL,
	[IsConservationPlan]            [bit]                               NULL,
	[PossibleClosingDate]           [varchar](128)                      NULL, --datetime field
	[PreservedOrder]                [decimal](10,2)                     NULL,
	[SADCSignLocation]              [varchar](4000)                     NULL,
	[StaffComments]                 [varchar](4000)                     NULL,
	[ZoningJan12004]                [varchar](128)                      NULL,
	[RFPIsAppraisal]                [bit]                               NULL,
	[RFPIsSurvey]                   [bit]                               NULL,
	[RFPIsWetlands]                 [bit]                               NULL,
	[CADBAppYear]                   [integer]                           NULL,
	[ProjectYear]                   [integer]                           NULL,
	[OriginalDeed]					[varchar](128)                      NULL,
	[OriginalPage]					[varchar](128)                      NULL,
	[SmallOrLargeSign]				[varchar](128)                      NULL,
	[AdYear]						[datetime]							NULL,
	[LastUpdatedBy]					[varchar](128)						NULL,
	[LastUpdatedOn]					[datetime]							NULL,
CONSTRAINT [PK_#FarmEsmtAppAdminDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtAppAdminDetails
INSERT INTO #FarmEsmtAppAdminDetails
           (
		      ApplicationId
			 ,FarmerName
			 ,FarmerPhone
			 ,FarmerContactInfo
			 ,FarmFeatures
			 ,AgreestoHaveSign
			 ,ConsPlanDate
			 ,ConsPlanComment
			 ,DroppedProjectWhy
			 ,ImperviousPercentage
			 ,ImperviousSurfaceAcreage
			 ,InterestedinSADCSign
			 ,IsConservationPlan
			 ,PossibleClosingDate
			 ,PreservedOrder
			 ,SADCSignLocation
			 ,StaffComments
			 ,ZoningJan12004
			 ,RFPIsAppraisal
			 ,RFPIsSurvey
			 ,RFPIsWetlands
			 ,CADBAppYear
			 ,ProjectYear
			 ,OriginalDeed
			 ,OriginalPage
			 ,SmallOrLargeSign
			 ,AdYear
			 ,LastUpdatedBy
			 ,LastUpdatedOn
		   )
           SELECT
		      ProjectID
		     ,FarmerName
              ,CASE 
               WHEN CHARINDEX(',', FarmerPhone) > 0 
              THEN LEFT(FarmerPhone, CHARINDEX(',', FarmerPhone) - 1) 
              ELSE FarmerPhone 
              END AS FarmerPhone
             ,FarmerContactInfo
		     ,FarmFeatures
		     ,AgreestoHaveSign
		     ,ConsPlanDate 
		     ,ConsPlanComment
		     ,DroppedProjectWhy
		     ,ImperviousPercentage
		     ,ImperviousSurfaceAcreage
		     ,InterestedinSADCSign
			 ,IsConservationPlan
		     ,PossibleClosingDate
		     ,PreservedOrder
		     ,SADCSignLocation
		     ,StaffComments
		     ,ZoningJan12004
		     ,RFPIsAppraisal
		     ,RFPIsSurvey
		     ,RFPIsWetlands
		     ,CADBAppYear
		     ,ProjectYear
		     ,EPDeedBook
		     ,EPDeedPage
		     ,SmallOrLargeSign
		     ,NULL AS AdYear
		     ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application Admin Actions Admin Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH