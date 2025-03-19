BEGIN TRY
BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmEsmtAppAdminClosingDocStatus

-- Create Table
CREATE TABLE #FarmEsmtAppAdminClosingDocStatus(
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[ProjectStatus]					[varchar](128)						NULL,
	[EPDeedBook]					[integer]							NULL,
	[EPDeedPage]					[integer]							NULL,
	[EPDeedFiled]					[datetime]							NULL,
	[EPDeedClerkID]					[varchar](128)						NULL,
	[CountyAttorney]				[varchar](128)						NULL,
	[CountyAttorneyInfo]			[varchar](4000)						NULL,
	[SurveyDate]					[datetime]							NULL,
	[Surveyor]						[varchar](128)						NULL,
	[TitleCompany]					[varchar](128)						NULL,
	[TitlePolicy]					[varchar](128)						NULL,
	[ClosingDate]					[datetime]							NULL,
	[EndorsementDates]				[varchar](4000)						NULL,
	[LastUpdatedBy]					[varchar](128)						NULL,
	[LastUpdatedOn]					[datetime]						NOT NULL,
CONSTRAINT [PK_#FarmEsmtAppAdminClosingDocStatus_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtAppAdminClosingDocStatus
INSERT INTO #FarmEsmtAppAdminClosingDocStatus
            (
			  ApplicationId
			 ,ProjectStatus
			 ,EPDeedBook
			 ,EPDeedPage
			 ,EPDeedFiled
			 ,EPDeedClerkID
			 ,CountyAttorney
			 ,CountyAttorneyInfo
			 ,SurveyDate
			 ,Surveyor
			 ,TitleCompany
			 ,TitlePolicy
			 ,ClosingDate
			 ,EndorsementDates
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
            SELECT
		      ProjectID
			  ,CASE 
			       WHEN [Status] = 'Dropped' THEN 'REJECTED'
	               WHEN [Status] = 'Fee Simple Purchase' THEN 'PRESERVED'
	               WHEN [Status] = 'Ineligible' THEN 'WITHDRAW'
	         	   WHEN [Status] = 'Pending' THEN 'PENDING'
	         	   WHEN [Status] = 'Preserved' THEN 'PRESERVED'
	               END AS ProjectStatus
		     ,EPDeedBook
             ,EPDeedPage
             ,EPDeedFiled
		     ,EPDeedClerkID
		     ,Attorney
             ,AttorneyContactInfo
		     ,SurveyDate
             ,Surveyor
		     ,TitleCompany
             ,TitlePolicyNumber
		     ,ClosingDate
		     ,EndorsementDates
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application Admin Actions ClosingDocStatus Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH