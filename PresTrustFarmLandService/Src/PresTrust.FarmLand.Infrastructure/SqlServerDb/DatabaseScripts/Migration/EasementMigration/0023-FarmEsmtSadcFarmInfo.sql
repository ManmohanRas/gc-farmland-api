BEGIN TRY
BEGIN TRANSACTION

--DROP TABLE
DROP TABLE IF EXISTS #FarmEsmtSadcFarmInfo

--CREATE TABLE
CREATE TABLE #FarmEsmtSadcFarmInfo(
   [Id]							   [integer] 		       IDENTITY(1,1)   NOT NULL,
   [ApplicationId]                 [integer]                               NOT NULL,
   [AlternatePhoneNumber]          [varchar](15)                               NULL,
   [County]                        [varchar](128)                              NULL,
   [TotalFarmAcreage]              [decimal](10,2)                             NULL,
   [Acres]                         [decimal](10,2)                             NULL,
   [IsContactSame]                 [bit]                                       NULL,
   [IsOtherContact]                [bit]                                       NULL,
   [OtherPrimaryFirstName]         [varchar](128)                              NULL,
   [OtherPrimaryRelation]          [varchar](128)                              NULL,
   [OtherPrimaryPhoneNumber]       [varchar](15)                               NULL,
   [OtherPrimaryEmail]             [varchar](128)                              NULL,
   [OtherPrimaryAddress]           [varchar](128)                              NULL,
   [IsVisitPrimaryContact]         [bit]                                       NULL,
   [IsVisitLandOwner]              [bit]                                       NULL,
   [IsVisitOther]                  [bit]                                       NULL,
   [VisitName]                     [varchar](128)                              NULL,
   [VisitRelation]                 [varchar](128)                              NULL,
   [VisitPhoneNumber]              [varchar](15)                               NULL,
   [VisitEmail]                    [varchar](128)                              NULL,
   [VisitSADCID]                   [int]                                       NULL,
   [VisitDateRecieved]             [datetime]                                  NULL,
   [IsImmediateCurrentMember]      [bit]                                       NULL,
   [Position]                      [varchar](128)                              NULL,
   [Term]                          [varchar](128)                              NULL,
   [LastUpdatedBy]				   [varchar](128)		                       NULL, 
   [LastUpdatedOn]				   [datetime]			                   NOT NULL
   CONSTRAINT [PK_#FarmEsmtSadcFarmInfoC_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

----Insert Script For #FarmEsmtSadcFarmInfo
INSERT INTO #FarmEsmtSadcFarmInfo
            (
			  ApplicationId
			 ,AlternatePhoneNumber
			 ,County
			 ,TotalFarmAcreage
			 ,Acres
			 ,IsContactSame
			 ,IsOtherContact
			 ,OtherPrimaryFirstName
			 ,OtherPrimaryRelation
			 ,OtherPrimaryPhoneNumber
			 ,OtherPrimaryEmail
			 ,OtherPrimaryAddress
			 ,IsVisitPrimaryContact
			 ,IsVisitLandOwner
			 ,IsVisitOther
			 ,VisitName
			 ,VisitRelation
			 ,VisitPhoneNumber
			 ,VisitEmail
			 ,VisitSADCID
			 ,VisitDateRecieved
			 ,IsImmediateCurrentMember
			 ,Position
			 ,Term
			 ,LastUpdatedBy 
			 ,LastUpdatedOn
			)
            SELECT 
	          ProjectID 
		     ,NULL AS AlternatePhoneNumber
		     ,'Morris'
		     ,GrossAcres
		     ,NULL AS Acres
		     ,NULL AS IsContactSame
		     ,NULL AS IsOtherContact
		     ,NULL AS OtherPrimaryFirstName
		     ,NULL AS OtherPrimaryRelation
		     ,NULL AS OtherPrimaryPhoneNumber
		     ,NULL AS OtherPrimaryEmail
		     ,NULL AS OtherPrimaryAddress
		     ,NULL AS IsVisitPrimaryContact
		     ,NULL AS IsVisitLandOwner
		     ,NULL AS IsVisitOther
		     ,NULL AS VisitName
		     ,NULL AS VisitRelation
		     ,NULL AS VisitPhoneNumber
		     ,NULL AS VisitEmail
		     ,NULL AS VisitSADCID
		     ,NULL AS VisitDateRecieved
		     ,NULL AS IsImmediateCurrentMember
		     ,NULL AS Position
		     ,NULL AS Term
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application SADC Farm Info Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH