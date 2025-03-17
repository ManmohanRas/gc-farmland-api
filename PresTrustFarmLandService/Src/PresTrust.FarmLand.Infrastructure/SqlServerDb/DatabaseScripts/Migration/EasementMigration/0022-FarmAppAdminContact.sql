BEGIN TRY
BEGIN TRANSACTION

 --Drop Table
 DROP TABLE #FarmAppAdminContact

 ---Create Table
CREATE TABLE #FarmAppAdminContact
(
[Id]					[integer]			IDENTITY(1,1)	NOT NULL,
[ApplicationId]			[integer]							NOT NULL,
[ContactName]			[varchar](76)						NULL,
[Agency]				[varchar](128)						NULL,
[Email]					[varchar](128)						NULL,
[MainNumber]			[varchar](128)						NULL,
[AlternateNumber]		[varchar](128)						NULL,
[SelectContact]			[bit]								NULL,
[LastUpdatedBy]			[varchar](128)						NULL	,
[LastUpdatedOn]			[datetime]							NOT NULL,
	CONSTRAINT [PK_#FarmAppAdminContact_Id] PRIMARY KEY CLUSTERED 
	(
[Id] ASC
	)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
	) ON [PRIMARY]

----Insert Script For #FarmAppAdminContact

INSERT INTO #FarmAppAdminContact
            (
			  ApplicationId
			 ,ContactName
			 ,Agency
			 ,Email
			 ,MainNumber
			 ,AlternateNumber
			 ,SelectContact
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
            SELECT
		     ProjectID
		     ,ContactPerson
		     ,NULL AS Agency
		     ,ContactEMail
		     ,ContactPhone 
		     ,NULL AS AlternateNumber
		     ,NULL AS SelectContact
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