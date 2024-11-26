
use prestrusttemp
BEGIN TRY
	BEGIN TRANSACTION
						--TERM PROGRAM TABLES
	--==============================================================================================================--

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmApplicationStatus]

		-- Create Table
		CREATE TABLE [Farm].[FarmApplicationStatus](
			[Id]				[smallint] 			NOT NULL,
			[Name]				[varchar](128)		NOT NULL,
			[ApplicationTypeId] [smallint]	        NOT NULL,
	
		CONSTRAINT [PK_FarmApplicationStatus_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraints
		ALTER TABLE [Farm].[FarmApplicationStatus] ADD CONSTRAINT [FK_ApplicationTypeId_FarmApplicationStatus]  FOREIGN KEY (ApplicationTypeId) REFERENCES [Farm].FarmApplicationType(Id);
		-- Drop Constraints
		ALTER TABLE [Farm].[FarmApplicationStatus] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationStatus] 


		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmApplicationType]

		-- Create Table
		CREATE TABLE [Farm].[FarmApplicationType](
			[Id]				[smallint] 			NOT NULL,
			[Title]				[varchar](128)		NOT NULL, 
		CONSTRAINT [PK_FarmApplicationType_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmApplicationSection];

		-- Create Table
		CREATE TABLE [Farm].[FarmApplicationSection](
			[Id]				[smallint] 			NOT NULL,
			[Title]				[varchar](128)		NOT NULL,
			[Description]		[varchar](512)		NULL,
			[ApplicationTypeId] [smallint]	        NOT NULL,
		CONSTRAINT [PK_FarmApplicationSection_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraints
		ALTER TABLE [Farm].[FarmApplicationSection] WITH NOCHECK ADD  CONSTRAINT [DF_FarmApplicationSection_Description]  DEFAULT ('') FOR [Description]
		ALTER TABLE [Farm].[FarmApplicationSection] ADD CONSTRAINT [FK_ApplicationTypeId_FarmApplicationSection]  FOREIGN KEY (ApplicationTypeId) REFERENCES [Farm].FarmApplicationType(Id);

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmApplicationSection]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmApplicationSection] DROP CONSTRAINT IF EXISTS  [DF_FarmApplicationSection_Description]
	
			ALTER TABLE [Farm].[FarmApplicationSection] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationSection] 	
		END


		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmApplicationDocumentType];

		-- Create Table
		CREATE TABLE [Farm].[FarmApplicationDocumentType](
			[Id]				[smallint] 			NOT NULL,
			[Title]				[varchar](128)		NOT NULL,
			[Description]		[varchar](512)		NULL	,
			[SectionId]			[smallint]			NOT NULL,
			[ApplicationTypeId] [smallint]	        NOT NULL,
		CONSTRAINT [PK_FarmApplicationDocumentType_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraints
		ALTER TABLE [Farm].[FarmApplicationDocumentType] ADD CONSTRAINT [FK_SectionId_FarmApplicationDocumentType]  FOREIGN KEY (SectionId) REFERENCES [Farm].FarmApplicationSection(Id);
		ALTER TABLE [Farm].[FarmApplicationDocumentType] ADD CONSTRAINT [FK_ApplicationTypeId_FarmApplicationDocumentType]  FOREIGN KEY (ApplicationTypeId) REFERENCES [Farm].FarmApplicationType(Id);

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmApplicationDocumentType]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS  [FK_SectionId_FarmApplicationDocumentType]
	
			ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationDocumentType] 
		END


		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmAppCommentType];

		-- Create Table
		CREATE TABLE [Farm].[FarmAppCommentType](
			[Id]				[smallint] 			NOT NULL,
			[Title]				[varchar](128)		NOT NULL,
			[Description]		[varchar](512)		NULL,		
			[IsActive]			[bit]				NULL,
		CONSTRAINT [PK_FarmAppCommentType_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraints
		ALTER TABLE [Farm].[FarmAppCommentType] WITH NOCHECK ADD  CONSTRAINT [DF_FarmAppCommentType_Description]  DEFAULT ('') FOR [Description]
		ALTER TABLE [Farm].[FarmAppCommentType] WITH NOCHECK ADD  CONSTRAINT [DF_FarmAppCommentType_IsActive]  DEFAULT (1) FOR [IsActive]

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmAppCommentType]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmAppCommentType] DROP CONSTRAINT IF EXISTS  [DF_FarmAppCommentType_Description];
	
			ALTER TABLE [Farm].[FarmAppCommentType] DROP CONSTRAINT IF EXISTS  [DF_FarmAppCommentType_IsActive];
	
		END;

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmApplicationDocument]

		-- Create Table
		CREATE TABLE [Farm].[FarmApplicationDocument](
			[Id]						[integer] 		IDENTITY(1,1)	NOT NULL,
			[ApplicationId]				[integer]						NOT NULL,
			[DocumentTypeId]			[smallint]						NOT NULL,
			[FileName]					[varchar](128)					NOT NULL,
			[Title]						[varchar](128)					NOT NULL,
			[Description]				[varchar](256)					NULL,
			[ShowCommittee]				[bit]							NOT NULL,
			[UseInReport]				[bit]							NOT NULL,
			[HardCopy]					[bit]							NOT NULL,
			[Approved]					[bit]							NOT NULL,
			[ReviewComment]				[varchar](2000)					NULL,
			[LastUpdatedBy]				[varchar](128)					NULL,
			[LastUpdatedOn]				[datetime]						NOT NULL,

		CONSTRAINT [PK_FarmApplicationDocument_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraints
		ALTER TABLE [Farm].[FarmApplicationDocument] ADD CONSTRAINT FK_DocumentTypeId_FarmApplicationDocument  FOREIGN KEY (DocumentTypeId) REFERENCES [Farm].FarmApplicationDocumentType(Id);
		ALTER TABLE [Farm].[FarmApplicationDocument] ADD CONSTRAINT FK_ApplicationId_FarmApplicationDocument  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
		ALTER TABLE [Farm].[FarmApplicationDocument] WITH NOCHECK ADD  CONSTRAINT [DF_ShowCommittee_FarmApplicationDocument]  DEFAULT (0) FOR [ShowCommittee]
		ALTER TABLE [Farm].[FarmApplicationDocument] WITH NOCHECK ADD  CONSTRAINT [DF_UseInReport_FarmApplicationDocument]  DEFAULT (0) FOR [UseInReport]
		ALTER TABLE [Farm].[FarmApplicationDocument] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationDocument]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmApplicationDocument]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationDocument];
			ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [FK_DocumentTypeId_FarmApplicationDocument];
			ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_ShowCommittee_FarmApplicationDocument];
			ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_UseInReport_FarmApplicationDocument];
			ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationDocument];
		END;
		 
		-- Drop Table
		DROP TABLE IF EXISTS [Farm].FarmApplicationBrokenRules;
	 
		-- Create Table
		CREATE TABLE [Farm].FarmApplicationBrokenRules(
			[ApplicationId]		[integer]						NOT NULL,
			[SectionId]			[integer]						NOT NULL,
			[Message]			[varchar](1024)					NOT NULL,
			[IsApplicantFlow]	[bit]							NOT NULL,
			[LastUpdatedOn]		[datetime]						NOT NULL,
		) ON [PRIMARY]

		-- Create Constraints
		ALTER TABLE [Farm].FarmApplicationBrokenRules ADD CONSTRAINT FK_ApplicationId_FarmApplicationBrokenRules  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
		ALTER TABLE [Farm].FarmApplicationBrokenRules WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationBrokenRules]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

		-- Drop Constraint
		IF OBJECT_ID('[Farm].FarmApplicationBrokenRules') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].FarmApplicationBrokenRules DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationBrokenRules];
			ALTER TABLE [Farm].FarmApplicationBrokenRules DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationBrokenRules];
			DROP INDEX IF EXISTS [IX_FarmApplicationBrokenRules_ApplicationId_SectionId] ON [Farm].[FarmApplicationBrokenRules];
		END;

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmApplication]

		-- Create Table
		CREATE TABLE [Farm].[FarmApplication](
			[Id]						[integer] 		IDENTITY(1,1)	NOT NULL,
			[Title]						[varchar](256)					NOT NULL,
			[AgencyId]					[integer]						NOT NULL,
			[FarmListId]                [integer]						NOT NULL,
			[ApplicationTypeId]			[smallint]						NOT NULL,
			[StatusId]					[smallint]						NOT NULL,
			[CreatedByProgramUser]		[bit]							NOT NULL,
			[IsApprovedByMunicipality]	[bit]							NOT NULL,
			[CreatedOn]					[datetime]						NOT NULL,
			[CreatedBy]					[varchar](128)					NULL	,
			[IsActive]					[bit]							NULL    ,
			[IsSADC]					[bit]                           NULL    , 
			[LastUpdatedBy]				[varchar](128)					NULL	,
			[LastUpdatedOn]				[datetime]						NOT NULL,
		CONSTRAINT [PK_FarmApplication_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraints
		ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_CreatedByProgramUser_FarmApplication]  DEFAULT (0) FOR [CreatedByProgramUser]
		ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplication]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
		ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_CreatedOn_FarmApplication]  DEFAULT (GETDATE()) FOR [CreatedOn]
		ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_IsActive_FarmApplication]  DEFAULT (1) FOR [IsActive]
		ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_IsApprovedByMunicipality_FarmApplication]  DEFAULT (0) FOR [IsApprovedByMunicipality]
		ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_IsSADC_FarmApplication]  DEFAULT (0) FOR [IsSADC]

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmApplication]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_CreatedByProgramUser_FarmApplication];
			ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplication];
			ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_CreatedOn_FarmApplication];
			ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_IsActive_FarmApplication];
			ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_IsApprovedByMunicipality_FarmApplication];
			ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_IsSADC_FarmApplication];
		END;

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmApplicationStatusLog]

		-- Create Table
		CREATE TABLE [Farm].[FarmApplicationStatusLog](
			[ApplicationId]							[integer]						NOT NULL,
			[StatusId]								[integer]						NOT NULL,
			[StatusDate]							[datetime]						NULL,
			[Notes]									[varchar](max)					NULL,
			[LastUpdatedBy]							[varchar](128)					NULL,
			[LastUpdatedOn]							[datetime]						NOT NULL)

		--Add Constraint
		ALTER TABLE [Farm].[FarmApplicationStatusLog] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationStatusLog]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

		--Drop Constraint
		IF OBJECT_ID('[Farm].[FarmApplicationStatusLog]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmApplicationStatusLog] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationStatusLog];
		END;

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmApplicationComment]

		-- Create Table
		CREATE TABLE [Farm].[FarmApplicationComment](
			[Id]									[integer] 		IDENTITY(1,1)	NOT NULL,
			[ApplicationId]							[integer]						NOT NULL,
			[Comment]								[varchar](4000)					NOT NULL,
			[CommentTypeId]							[smallint]						NOT NULL,
			[LastUpdatedBy]							[varchar](128)					NULL	,
			[LastUpdatedOn]							[datetime]			   			NOT NULL,

		CONSTRAINT [PK_FarmApplicationComment_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraints
		ALTER TABLE [Farm].[FarmApplicationComment] ADD CONSTRAINT [FK_ApplicationId_FarmApplicationComment]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
		ALTER TABLE [Farm].[FarmApplicationComment] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationComment]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmApplicationComment]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmApplicationComment] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationComment];
			ALTER TABLE [Farm].[FarmApplicationComment] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationComment];
		END;

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmApplicationFeedback]

		-- Create Table
		CREATE TABLE [Farm].[FarmApplicationFeedback](
			[Id]									[integer] 		IDENTITY(1,1)	NOT NULL,
			[ApplicationId]							[integer]						NOT NULL,
			[SectionId]								[smallint]						NOT NULL,
			[Feedback]								[varchar](4000)					NOT NULL,
			[RequestForCorrection]					[bit]							NOT NULL,
			[CorrectionStatus]						[varchar](100)					NOT NULL,
			[MarkRead]								[bit]							NOT NULL, 
			[LastUpdatedBy]							[varchar](128)					NULL	,
			[LastUpdatedOn]							[datetime]						NOT NULL,

		CONSTRAINT [PK_FarmApplicationFeedback_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraints
		ALTER TABLE [Farm].[FarmApplicationFeedback] ADD CONSTRAINT [FK_ApplicationId_FarmApplicationFeedback]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
		ALTER TABLE [Farm].[FarmApplicationFeedback] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationFeedback]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmApplicationFeedback]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmApplicationFeedback] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationFeedback];
			ALTER TABLE [Farm].[FarmApplicationFeedback] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationFeedback];
		END;

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmApplicationUser]

		-- Create Table
		CREATE TABLE [Farm].[FarmApplicationUser](
			[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
			[ApplicationId]					[integer]						NOT NULL,
			[Email]							[varchar](128)					NULL	,
			[UserId]						[varchar](128)					NOT NULL,
			[UserName]						[varchar](128)					NOT NULL,
			[FirstName]						[varchar](128)					NULL,
			[LastName]						[varchar](128)					NULL,
			[Title]							[varchar](128)					NULL	,
			[PhoneNumber]					[varchar](15)					NULL	,
			[IsPrimaryContact]				[bit]							NOT NULL,
			[IsAlternateContact]			[bit]							NOT NULL,
			[LastUpdatedBy]					[varchar](128)					NULL	,
			[LastUpdatedOn]					[datetime]						NOT NULL,
		CONSTRAINT [PK_FarmRole_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraint
		ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_IsPrimaryContact_FarmApplicationUser]  DEFAULT (0) FOR [IsPrimaryContact]
		ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_IsAlternateContact_FarmApplicationUser]  DEFAULT (0) FOR [IsAlternateContact]
		ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_FirstName_FarmApplicationUser]  DEFAULT ('') FOR [FirstName];
		ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_LastName_FarmApplicationUser]  DEFAULT ('') FOR [LastName];
		ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationUser]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmApplicationUser]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS  [DF_IsPrimaryContact_FarmApplicationUser];
			ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS  [DF_IsAlternateContact_FarmApplicationUser];
			ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationUser];
			ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS   [DF_FirstName_FarmApplicationUser];  
			ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS   [DF_LastName_FarmApplicationUser];  
		END;

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmTermAppOwnerDetails]

		-- Create Table
		CREATE TABLE [Farm].[FarmTermAppOwnerDetails](
			[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
			[ApplicationId]					[integer]						NOT NULL,
			[FirstName]						[varchar](128)					NULL	,
			[LastName]						[varchar](128)					NULL	, 
			[PropertyLocation]				[varchar](128)					NULL	, 
			[MunicipalityId]			    [integer]					    NULL,
			[MailingAddress1]				[varchar](128)					NOT NULL,
			[MailingAddress2]				[varchar](128)					    NULL,
			[PhoneNumber]					[varchar](15)					NOT NULL,
			[City]							[varchar](128)					NOT NULL,
			[State]							[varchar](128)					NOT NULL,
			[ZipCode]						[integer] 					    NOT NULL,
			[LastUpdatedBy]					[varchar](128)					NULL	, 
			[LastUpdatedOn]					[datetime]						NOT NULL, 
		CONSTRAINT [PK_FarmTermAppOwnerDetails_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraints
		ALTER TABLE [Farm].[FarmTermAppOwnerDetails] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppOwnerDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
		ALTER TABLE [Farm].[FarmTermAppOwnerDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppOwnerDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmTermAppOwnerDetails]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmTermAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppOwnerDetails];
			ALTER TABLE [Farm].[FarmTermAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppOwnerDetails];
		END;

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmTermAppAdminDetails]

		-- Create Table
		CREATE TABLE [Farm].[FarmTermAppAdminDetails](
			[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
			[ApplicationId]					[integer]						NOT NULL,
			[SADCId]						[integer]							NULL,
			[MaxGrant]						[decimal](18,2)						NULL,
			[PermanentlyPreserved]			[bit]								NULL,
			[MunicipallyApproved]			[bit]								NULL,
			[EnrollmentDate]				[dateTime]							NULL,
			[RenewalDate]					[dateTime]							NULL,
			[ExpirationDate]				[dateTime]							NULL,
			[RenewalExpirationDate]			[dateTime]							NULL,
			[Comment]						[varchar](128)						Null,
			[LastUpdatedBy]					[varchar](128)						NULL,
			[LastUpdatedOn]					[datetime]							NULL,
		CONSTRAINT [PK_FarmTermAppAdminDetails_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraint
		ALTER TABLE [Farm].[FarmTermAppAdminDetails] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppAdminDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
		ALTER TABLE [Farm].[FarmTermAppAdminDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppAdminDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmTermAppAdminDetails]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmTermAppAdminDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppAdminDetails];
			ALTER TABLE [Farm].[FarmTermAppAdminDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppAdminDetails];
		END;

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmTermAppSiteCharacteristics]

		-- Create Table
		CREATE TABLE [Farm].[FarmTermAppSiteCharacteristics](
			[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
			[ApplicationId]					[integer]						NOT NULL,
			[Area]							[decimal]							NULL,--ProjectRegion or ProjectGeneralLocation or FarmLocation legacy
			[LandUse]						[varchar](4000)						NULL,
			[CropLand]						[decimal](18,2)						NULL,
			[WoodLand]						[decimal](18,2)						NULL,
			[Pasture]						[decimal](18,2)						NULL,
			[Orchard]						[decimal](18,2)						NULL,
			[Other]							[decimal](18,2)						NULL,--like this OrchardAcres, OtherAcres
			[IsEasement]			        [bit]						        NULL,
			[IsRightOfway]		        	[bit]						        NULL,
			[NoteEasementRightOfway]		[varchar](4000)						NULL,
			[IsMortgage]			        [bit]						        NULL,
			[IsLiens]					    [bit]								NULL,
			[NoteMortgageLiens]				[varchar](4000)						NULL,
			[LastUpdatedBy]					[varchar](128)						NULL,
			[LastUpdatedOn]					[datetime]						NOT NULL,
		CONSTRAINT [PK_FarmTermAppSiteCharacteristics_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraint
		ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppSiteCharacteristics]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
		ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppSiteCharacteristics]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmTermAppSiteCharacteristics]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppSiteCharacteristics];
			ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppSiteCharacteristics];
		END;

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmTermAppDeedDetails]

		-- Create Table
		CREATE TABLE [Farm].[FarmTermAppDeedDetails](
			[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
			[ApplicationId]					[integer]						NOT NULL,
			[ParcelId]						[integer]						NOT NULL,
			[OriginalBlock]					[varchar](50)					NOT NULL,
			[OriginalLot]					[varchar](50)					NOT NULL,
			[OriginalBook]					[varchar](50)					NULL,
			[OriginalPage]					[varchar](50)					NULL,
			[NOTBlock]						[varchar](50)					NULL,
			[NOTLot]						[varchar](50)					NULL,
			[NOTBook]						[varchar](50)					NULL,
			[NOTPage]						[varchar](50)					NULL,
			[RDBlock]						[varchar](50)					NULL,
			[RDLot]							[varchar](50)					NULL,
			[RDBook]						[varchar](50)					NULL,
			[RDPage]						[varchar](50)					NULL,
			[IsChecked]						[bit]							NOT NULL,
			[LastUpdatedBy]					[varchar](128)					NULL, 
			[LastUpdatedOn]					[datetime]						NOT NULL, 
		CONSTRAINT [PK_FarmTermAppDeedDetails_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraint
		ALTER TABLE [Farm].[FarmTermAppDeedDetails] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppDeedDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
		ALTER TABLE [Farm].[FarmTermAppDeedDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppDeedDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmTermAppDeedDetails]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppDeedDetails];
			ALTER TABLE [Farm].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppDeedDetails];
		END;

		--Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmTermAppAdminContact]

		--Create Table
		CREATE TABLE [Farm].[FarmTermAppAdminContact](
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
		CONSTRAINT [PK_FarmTermAppAdminContact_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		--Create Constraints
		ALTER TABLE [Farm].[FarmTermAppAdminContact] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppAdminContact]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].[FarmApplication](Id);
	    ALTER TABLE [Farm].[FarmTermAppAdminContact] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppAdminContact]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

		--Drop Constraints
		IF OBJECT_ID('[Farm].[FarmTermAppAdminContact]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmTermAppAdminContact] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmTermAppAdminContact];
			ALTER TABLE [Farm].[FarmTermAppAdminContact] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_FarmTermAppAdminContact];
		END;

		-- Drop Table
		DROP TABLE IF EXISTS [Farm].[FarmTermAppSignature]

		-- Create Table
		CREATE TABLE [Farm].[FarmTermAppSignature](
			[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
			[ApplicationId]					[integer]						NOT NULL,
			[Designation]					[varchar](128)					NULL	,
			[Title]							[varchar](128)					NULL	, 
			[SignedOn]						[DateTime]						NULL	, 
			[LastUpdatedBy]					[varchar](128)					NULL	,--SignatoryType 
			[LastUpdatedOn]					[DateTime]						NOT NULL, 
		CONSTRAINT [PK_FarmTermAppSignature_Id] PRIMARY KEY CLUSTERED 
		(
			[Id] ASC
		)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
		) ON [PRIMARY]

		-- Create Constraints
		ALTER TABLE [Farm].[FarmTermAppSignature] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppSignature]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
		ALTER TABLE [Farm].[FarmTermAppSignature] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppSignature]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

		-- Drop Constraints
		IF OBJECT_ID('[Farm].[FarmTermAppSignature]') IS NOT NULL
		BEGIN
			ALTER TABLE [Farm].[FarmTermAppSignature] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppSignature];
			ALTER TABLE [Farm].[FarmTermAppSignature] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppSignature];
		END;

	END TRY
	BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000); 

	SET   @ErrorMessage = ERROR_MESSAGE();
	ROLLBACK;

	SELECT @ErrorMessage;	
END CATCH

-- Term Tables Closed