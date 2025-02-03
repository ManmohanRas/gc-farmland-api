BEGIN TRY
	BEGIN TRANSACTION

--FarmMunicipalityBlockLotParcel
IF OBJECT_ID('[Farm].[FarmMunicipalityBlockLotParcel]') IS NOT NULL
BEGIN
	-- Drop Constraints
		ALTER TABLE [Farm].[FarmMunicipalityBlockLotParcel] DROP CONSTRAINT IF EXISTS  [DF_InterestType_FarmMunicipalityBlockLotParcel];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmMunicipalityBlockLotParcel]

-- Create Table
CREATE TABLE [Farm].[FarmMunicipalityBlockLotParcel](
	[Id]					[int] IDENTITY(1,1)		 NOT NULL,
	[MunicipalityId]	    [varchar](4)			 NOT NULL,
	[FarmListID]            [int]					 NOT NULL,
	[PropertyClassCode]     [varchar](50)			 NULL,
	[DeedBook]              [varchar](50)			 NULL,			
	[DeedPage]              [varchar](50)			 NULL,			
	[DeedDate]              [date]					 NULL,					 
	[Block]                 [varchar](50)		     NULL,
	[Lot]					[varchar](50)            NULL,
	[QualificationCode]     [varchar](50)            NULL,
	[Section]               [varchar](128)           NULL,
	[Partial]               [bit]                    NULL,
	[Acres]                 [numeric](10, 3)         NULL,
	[AcresToBeAcquired]     [numeric](10, 3)         NULL,
	[ExceptionAreaAcres]    [numeric](10, 3)         NULL,
	[ExceptionArea]         [bit]                    NULL,
	[Notes]                 [varchar](max)           NULL,
	[PamsPin]               [varchar](100)           NULL,
	[IsValidFeatureId]      [bit]                    NULL,
	[IsValidPamsPin]        [bit]                    NULL,
	[InterestType]          [varchar](100)           NULL,
	[EasementId]            [varchar](100)           NULL,
	[ChangeType]            [varchar](100)           NULL,
	[ChangeDate]            [datetime]               NULL,
	[ReasonForChange]       [varchar](max)           NULL,
	[IsActive]              [bit]                    NULL,
	[Status]	            [varchar](50)            NULL,
	[IsWarning]             [bit]                    NULL,
	[CreatedByProgramUser]  [bit]                    NULL,
	[LastUpdatedOn]         [datetime]               NOT NULL,
	[LastUpdatedBy]         [varchar](256)           NOT NULL,
CONSTRAINT [PK_FarmMunicipalityBlockLotParcel_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY]

ALTER TABLE [Farm].[FarmMunicipalityBlockLotParcel] WITH NOCHECK ADD  CONSTRAINT [DF_InterestType_FarmMunicipalityBlockLotParcel]  DEFAULT('Easement') FOR [InterestType]

--Farm Application
	-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationType];

-- Create Table
CREATE TABLE [Farm].[FarmApplicationType](
	[Id]				[smallint] 			NOT NULL,
	[Title]				[varchar](128)		NOT NULL, 
CONSTRAINT [PK_FarmApplicationType_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Drop Constraints
ALTER TABLE [Farm].[FarmApplicationStatus] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationStatus]; 

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationStatus];

-- Create Table
CREATE TABLE [Farm].[FarmApplicationStatus](
	[Id]				[smallint] 			NOT NULL,
	[Name]				[varchar](128)		NOT NULL,
	[ApplicationTypeId] [smallint]	        NOT NULL,
CONSTRAINT [PK_FarmApplicationStatus_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraints
ALTER TABLE [Farm].[FarmApplicationStatus] ADD CONSTRAINT [FK_ApplicationTypeId_FarmApplicationStatus]  FOREIGN KEY (ApplicationTypeId) REFERENCES [Farm].FarmApplicationType(Id);


-- Drop Constraints
IF OBJECT_ID('[Farm].[FarmApplicationSection]') IS NOT NULL
BEGIN
	ALTER TABLE [Farm].[FarmApplicationSection] DROP CONSTRAINT IF EXISTS  [DF_FarmApplicationSection_Description]
	
	ALTER TABLE [Farm].[FarmApplicationSection] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationSection] 	
END;

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
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmApplicationSection] WITH NOCHECK ADD  CONSTRAINT [DF_FarmApplicationSection_Description]  DEFAULT ('') FOR [Description];

-- Create Constraints
ALTER TABLE [Farm].[FarmApplicationSection] ADD CONSTRAINT [FK_ApplicationTypeId_FarmApplicationSection]  FOREIGN KEY (ApplicationTypeId) REFERENCES [Farm].FarmApplicationType(Id);


-- Drop Constraints
IF OBJECT_ID('[Farm].[FarmApplicationDocumentType]') IS NOT NULL
BEGIN
	ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS  [FK_SectionId_FarmApplicationDocumentType]
	
	ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationDocumentType] 
END;

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
) ON [PRIMARY];

-- Create Constraints
ALTER TABLE [Farm].[FarmApplicationDocumentType] ADD CONSTRAINT [FK_SectionId_FarmApplicationDocumentType]  FOREIGN KEY (SectionId) REFERENCES [Farm].FarmApplicationSection(Id);

-- Create Constraints
ALTER TABLE [Farm].[FarmApplicationDocumentType] ADD CONSTRAINT [FK_ApplicationTypeId_FarmApplicationDocumentType]  FOREIGN KEY (ApplicationTypeId) REFERENCES [Farm].FarmApplicationType(Id);

-- Drop Constraints
IF OBJECT_ID('[Farm].[FarmAppCommentType]') IS NOT NULL
BEGIN
	ALTER TABLE [Farm].[FarmAppCommentType] DROP CONSTRAINT IF EXISTS  [DF_FarmAppCommentType_Description];
	
	ALTER TABLE [Farm].[FarmAppCommentType] DROP CONSTRAINT IF EXISTS  [DF_FarmAppCommentType_IsActive];
	
END;

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
) ON [PRIMARY];

-- Create Constraints
ALTER TABLE [Farm].[FarmAppCommentType] WITH NOCHECK ADD  CONSTRAINT [DF_FarmAppCommentType_Description]  DEFAULT ('') FOR [Description];
 
ALTER TABLE [Farm].[FarmAppCommentType] WITH NOCHECK ADD  CONSTRAINT [DF_FarmAppCommentType_IsActive]  DEFAULT (1) FOR [IsActive];

IF OBJECT_ID('[Farm].[FarmApplicationDocument]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationDocument];
		
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [FK_DocumentTypeId_FarmApplicationDocument];

	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_ShowCommittee_FarmApplicationDocument];
	
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_UseInReport_FarmApplicationDocument];
	
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationDocument];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationDocument];

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
) ON [PRIMARY];


-- Create Constraint
ALTER TABLE [Farm].[FarmApplicationDocument] ADD CONSTRAINT FK_DocumentTypeId_FarmApplicationDocument  FOREIGN KEY (DocumentTypeId) REFERENCES [Farm].FarmApplicationDocumentType(Id);

ALTER TABLE [Farm].[FarmApplicationDocument] ADD CONSTRAINT FK_ApplicationId_FarmApplicationDocument  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmApplicationDocument] WITH NOCHECK ADD  CONSTRAINT [DF_ShowCommittee_FarmApplicationDocument]  DEFAULT (0) FOR [ShowCommittee];

ALTER TABLE [Farm].[FarmApplicationDocument] WITH NOCHECK ADD  CONSTRAINT [DF_UseInReport_FarmApplicationDocument]  DEFAULT (0) FOR [UseInReport];

ALTER TABLE [Farm].[FarmApplicationDocument] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationDocument]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

IF OBJECT_ID('[Farm].FarmApplicationBrokenRules') IS NOT NULL
BEGIN
	-- Drop Constraint
	ALTER TABLE [Farm].FarmApplicationBrokenRules DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationBrokenRules];

	ALTER TABLE [Farm].FarmApplicationBrokenRules DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationBrokenRules];

	DROP INDEX IF EXISTS [IX_FarmApplicationBrokenRules_ApplicationId_SectionId] ON [Farm].[FarmApplicationBrokenRules];
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
) ON [PRIMARY];
 
-- Create a clustered index  
CREATE CLUSTERED INDEX IX_FarmApplicationBrokenRules_ApplicationId_SectionId ON [Farm].FarmApplicationBrokenRules(ApplicationId, SectionId); 
-- Create Constraint
ALTER TABLE [Farm].FarmApplicationBrokenRules ADD CONSTRAINT FK_ApplicationId_FarmApplicationBrokenRules  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
 
ALTER TABLE [Farm].FarmApplicationBrokenRules WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationBrokenRules]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

  
IF OBJECT_ID('[Farm].[FarmApplication]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_CreatedByProgramUser_FarmApplication];

	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplication];
	
	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_CreatedOn_FarmApplication];

	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_IsActive_FarmApplication];

	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_IsApprovedByMunicipality_FarmApplication];

	ALTER TABLE [Farm].[FarmApplication] DROP CONSTRAINT IF EXISTS  [DF_IsSADC_FarmApplication];
END;
 
 
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplication];

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
) ON [PRIMARY];

-- Create Constraints
ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_CreatedByProgramUser_FarmApplication]  DEFAULT (0) FOR [CreatedByProgramUser];

ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplication]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_CreatedOn_FarmApplication]  DEFAULT (GETDATE()) FOR [CreatedOn];

ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_IsActive_FarmApplication]  DEFAULT (1) FOR [IsActive];

ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_IsApprovedByMunicipality_FarmApplication]  DEFAULT (0) FOR [IsApprovedByMunicipality];

ALTER TABLE [Farm].[FarmApplication] WITH NOCHECK ADD  CONSTRAINT [DF_IsSADC_FarmApplication]  DEFAULT (0) FOR [IsSADC];

 
IF OBJECT_ID('[Farm].[FarmApplicationStatusLog]') IS NOT NULL
BEGIN
	ALTER TABLE [Farm].[FarmApplicationStatusLog] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationStatusLog];

END;
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationStatusLog];

-- Create Table
CREATE TABLE [Farm].[FarmApplicationStatusLog](
	[ApplicationId]							[integer]						NOT NULL,
	[StatusId]								[integer]						NOT NULL,
	[StatusDate]							[datetime]						NULL,
	[Notes]									[varchar](max)					NULL,
	[LastUpdatedBy]							[varchar](128)					NULL,
	[LastUpdatedOn]							[datetime]						NOT NULL)

ALTER TABLE [Farm].[FarmApplicationStatusLog] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationStatusLog]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--Comments
IF OBJECT_ID('[Farm].[FarmApplicationComment]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmApplicationComment] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationComment];
	
	ALTER TABLE [Farm].[FarmApplicationComment] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationComment];
END;
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationComment];

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
) ON [PRIMARY];


-- Create Constraints
ALTER TABLE [Farm].[FarmApplicationComment] ADD CONSTRAINT [FK_ApplicationId_FarmApplicationComment]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmApplicationComment] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationComment]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--Feedbacks

IF OBJECT_ID('[Farm].[FarmApplicationFeedback]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmApplicationFeedback] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationFeedback];
	
	ALTER TABLE [Farm].[FarmApplicationFeedback] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationFeedback];
END;
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationFeedback];

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
) ON [PRIMARY];

-- Create Constraints
ALTER TABLE [Farm].[FarmApplicationFeedback] ADD CONSTRAINT [FK_ApplicationId_FarmApplicationFeedback]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmApplicationFeedback] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationFeedback]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--ApplicationUsers
IF OBJECT_ID('[Farm].[FarmApplicationUser]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS  [DF_IsPrimaryContact_FarmApplicationUser];

	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS  [DF_IsAlternateContact_FarmApplicationUser];
			
	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationUser];

    ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS   [DF_FirstName_FarmApplicationUser];  

	ALTER TABLE [Farm].[FarmApplicationUser] DROP CONSTRAINT IF EXISTS   [DF_LastName_FarmApplicationUser];  
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationUser];

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
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_IsPrimaryContact_FarmApplicationUser]  DEFAULT (0) FOR [IsPrimaryContact]

ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_IsAlternateContact_FarmApplicationUser]  DEFAULT (0) FOR [IsAlternateContact]

ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_FirstName_FarmApplicationUser]  DEFAULT ('') FOR [FirstName];

ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_LastName_FarmApplicationUser]  DEFAULT ('') FOR [LastName];

ALTER TABLE [Farm].[FarmApplicationUser] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationUser]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--Farm App Location Details
IF OBJECT_ID('[Farm].[FarmAppLocationDetails]') IS NOT NULL
BEGIN
	 --Drop Constraints
	 ALTER TABLE [Farm].[FarmAppLocationDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmAppLocationDetails];

	ALTER TABLE [Farm].[FarmAppLocationDetails] DROP CONSTRAINT IF EXISTS  [DF_IsChecked_FarmAppLocationDetails];
END;
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmAppLocationDetails]

-- Create Table
CREATE TABLE [Farm].[FarmAppLocationDetails](
	[ApplicationId]							[integer]						NOT NULL,
	[ParcelId]								[integer] 						NOT NULL,
	[FarmListID]							[int]							NOT NULL,
	[PamsPin]					            [varchar](76)				    NOT NULL,
	[IsChecked]								[bit]                           NOT NULL
); 

-- Create Constraint
ALTER TABLE [Farm].[FarmAppLocationDetails] ADD CONSTRAINT [FK_ApplicationId_FarmAppLocationDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmAppLocationDetails] WITH NOCHECK ADD  CONSTRAINT [DF_IsChecked_FarmAppLocationDetails]  DEFAULT (0) FOR [IsChecked];

--TermApp Deed Location
IF OBJECT_ID('[Farm].[FarmTermAppDeedLocation]') IS NOT NULL
BEGIN
	 --Drop Constraints
	 ALTER TABLE [Farm].[FarmTermAppDeedLocation] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppDeedLocation];
		

	ALTER TABLE [Farm].[FarmTermAppDeedLocation] DROP CONSTRAINT IF EXISTS  [DF_IsChecked_FarmTermAppDeedLocation];
END;
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppDeedLocation]

-- Create Table
CREATE TABLE [Farm].[FarmTermAppDeedLocation](
	[ApplicationId]							[integer]						NOT NULL,
	[ParcelId]								[integer] 						NOT NULL,
	[DeedId]								[integer]							NULL,
	[IsChecked]								[bit]                           NOT NULL
); 

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppDeedLocation] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppDeedLocation]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmTermAppDeedLocation] WITH NOCHECK ADD  CONSTRAINT [DF_IsChecked_FarmTermAppDeedLocation]  DEFAULT (0) FOR [IsChecked];

--OwnerDetailsList
IF OBJECT_ID('[Farm].[FarmAppOwnerDetailList]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmAppOwnerDetailList] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmAppOwnerDetailList];
		
	ALTER TABLE [Farm].[FarmAppOwnerDetailList] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmAppOwnerDetailList];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmAppOwnerDetailList];

-- Create Table
CREATE TABLE [Farm].[FarmAppOwnerDetailList](
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
	[Salutation]                    [varchar](15)                   NOT NULL,
	[EmailAddress]                  [varchar](128)                  NOT NULL,
	[CurrentOwnerMailingName]       [varchar](128)                  NOT NULL,
	[LastUpdatedBy]					[varchar](128)					NULL	, 
	[LastUpdatedOn]					[datetime]						NOT NULL, 
CONSTRAINT [PK_FarmAppOwnerDetailList_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmAppOwnerDetailList] ADD CONSTRAINT [FK_ApplicationId_FarmAppOwnerDetailList]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmAppOwnerDetailList] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmAppOwnerDetailList]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--TermAdminDetails
IF OBJECT_ID('[Farm].[FarmTermAppAdminDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmTermAppAdminDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppAdminDetails];
		
	ALTER TABLE [Farm].[FarmTermAppAdminDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppAdminDetails];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppAdminDetails];

-- Create Table
CREATE TABLE [Farm].[FarmTermAppAdminDetails](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[SADCId]						[integer]							NULL,
	[MaxGrant]						[decimal](18,2)						NULL,
	[PermanentlyPreserved]			[bit]								NULL,
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
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppAdminDetails] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppAdminDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmTermAppAdminDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppAdminDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--SiteCharacteristics
IF OBJECT_ID('[Farm].[FarmTermAppSiteCharacteristics]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppSiteCharacteristics];
		
	ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppSiteCharacteristics];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppSiteCharacteristics];

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
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppSiteCharacteristics]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmTermAppSiteCharacteristics] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppSiteCharacteristics]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--Deed Details

IF OBJECT_ID('[Farm].[FarmTermAppDeedDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppDeedDetails];
		
	ALTER TABLE [Farm].[FarmTermAppDeedDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppDeedDetails];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppDeedDetails];

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
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppDeedDetails] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppDeedDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmTermAppDeedDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppDeedDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

--MunicipalTrustFundUses
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmMunicipalTrustFundPermittedUses];

-- Create Table
CREATE TABLE [Farm].[FarmMunicipalTrustFundPermittedUses](
	[Id]								[int]    IDENTITY(1,1)			 NOT NULL,
	[AgencyId]							[int]							 NOT NULL,
	[YearOfInception]					[char](4)						 NULL,
	[AcquisitionOfLands]				[bit]							 NULL,
	[AcquisitionOfFarmLands]			[bit]							 NULL,
	[DevelopmentOfLands]				[bit]							 NULL,
	[MaintenanceOfLands]				[bit]							 NULL,
	[SalariesAndBenefits]				[bit]							 NULL,
	[BondDownPayments]					[bit]							 NULL,
	[HistoricPreservation]				[bit]							 NULL,
	[OpenspaceMasterPlan]				[bit]							 NULL,
	[OpenspaceMasterPlanDate]			[datetime]						 NULL,
	[GreenAcresGrant]					[bit]							 NULL,
	[TrustFundComments]					[varchar](2000)					 NULL,
	[Other]								[varchar](2000)					 NULL,
	[LastUpdatedBy]						[varchar](128)					 NULL,
	[LastUpdatedOn]						[datetime]						 NOT NULL,
CONSTRAINT [PK_FarmMunicipalTrustFundPermittedUses_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

--Admin Contacts
IF OBJECT_ID('[Farm].[FarmAppAdminContact]') IS NOT NULL
BEGIN

	ALTER TABLE [Farm].[FarmAppAdminContact] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmAppAdminContact];

	ALTER TABLE [Farm].[FarmAppAdminContact] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_FarmAppAdminContact];
END;

DROP TABLE IF EXISTS [Farm].[FarmAppAdminContact];

CREATE TABLE [Farm].[FarmAppAdminContact](
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
CONSTRAINT [PK_FarmAppAdminContact_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

ALTER TABLE [Farm].[FarmAppAdminContact] ADD CONSTRAINT [FK_ApplicationId_FarmAppAdminContact]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].[FarmApplication](Id);

ALTER TABLE [Farm].[FarmAppAdminContact] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmAppAdminContact]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--TermAppSignature

IF OBJECT_ID('[Farm].[FarmTermAppSignature]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmTermAppSignature] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppSignature];
		
	ALTER TABLE [Farm].[FarmTermAppSignature] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppSignature];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppSignature];

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
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppSignature] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppSignature]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmTermAppSignature] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppSignature]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

--Esmt Application Structure
IF OBJECT_ID('[Farm].[FarmEsmtAppStructure]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppStructure] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppStructure];
		
	ALTER TABLE [Farm].[FarmEsmtAppStructure] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppStructure];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppStructure];

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppStructure](
	[Id]						               	[integer] 		              IDENTITY(1,1) NOT NULL,
	[ApplicationId]					            [integer]						            NOT NULL,
	[IsResipreserved]							[bit]					                        NULL,
	[StdSingleFamilyResidence]					[varchar](128)			        			    NULL, 
	[MfWithHomePermFoundation]					[varchar](128)						            NULL, 	                                                                                                                                                    
    [Duplex]		                            [varchar](128)						            NULL, 
	[MfWithOutHomePermFoundation]				[varchar](128)						            NULL,
	[ResiGarage]		                        [varchar](128)						            NULL, 
	[Dormitory]		                            [varchar](128)						            NULL, 
	[ApartmentAttachedTo]		                [varchar](128)						            NULL, 
	[CarriageHouseOrCabin]		                [varchar](128)						            NULL, 
	[ResiOther]		                            [varchar](4000)						            NULL, 
	[UnitsAgricuturalLabor]						[varchar](4000)						            NULL, 
	[UnitsRentedOrLease]		                [varchar](4000)						            NULL, 
	[IsNonResiStructure]						[bit]						                    NULL, 
	[Barn]		                                [varchar](128)						            NULL, 
	[Shed]		                                [varchar](128)						            NULL, 
	[NonResiGarage]		                        [varchar](128)						            NULL, 
	[Silo]		                                [varchar](128)						            NULL, 
	[Stable]		                            [varchar](128)						            NULL, 
	[NonResiOther]		                        [varchar](128)						            NULL, 
	[IsHistBuildingOrStructure]					[bit]						                    NULL, 
	[HistoricSignificance]		                [varchar](4000)						            NULL, 
	[LastUpdatedBy]					            [varchar](128)					                NULL, 
	[LastUpdatedOn]					            [DateTime]					               	NOT NULL, 
CONSTRAINT [PK_FarmEsmtAppStructure_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppStructure] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppStructure]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAppStructure] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppStructure]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--Esmt Owner Details
IF OBJECT_ID('[Farm].[FarmEsmtAppOwnerDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppOwnerDetails];
		
	ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppOwnerDetails];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppOwnerDetails];

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppOwnerDetails](
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
CONSTRAINT [PK_FarmEsmtAppOwnerDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppOwnerDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppOwnerDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtAppExceptions
IF OBJECT_ID('[Farm].[FarmEsmtAppExceptions]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppExceptions] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppExceptions];
		
	ALTER TABLE [Farm].[FarmEsmtAppExceptions] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppExceptions];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppExceptions];

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppExceptions](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[ExpectedTaxLots]				[bit]								NULL,
	[ExceptionNonSeverable]			[varchar](128)						NULL,
	[ExceptionTotalNonSeverable]	[varchar](128)						NULL,
	[ExceptionSeverable]			[varchar](128)						NULL,
	[ExceptionTotalSeverable]		[varchar](128)						NULL,
	[Acres]						    [Decimal](18,2)						NULL,
	[LastUpdatedBy]					[varchar](128)						NULL, 
	[LastUpdatedOn]					[datetime]						NOT NULL, 
CONSTRAINT [PK_FarmEsmtAppExceptions_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppExceptions] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppExceptions]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAppExceptions] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppExceptions]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtApp Lines
IF OBJECT_ID('[Farm].[FarmEsmtLiens]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtLiens] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtLiens];
		
	ALTER TABLE [Farm].[FarmEsmtLiens] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtLiens];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtLiens];

-- Create Table
CREATE TABLE [Farm].[FarmEsmtLiens](
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
CONSTRAINT [PK_FarmEsmtLiens_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtLiens] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtLiens]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtLiens] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtLiens]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--Esmt App Signatory
IF OBJECT_ID('[Farm].[FarmEsmtAppSignatory]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppSignatory] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppSignatory];
		
	ALTER TABLE [Farm].[FarmEsmtAppSignatory] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppSignatory];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppSignatory];

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppSignatory](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[AmountPerAcre]                 [decimal](18,4)                 NULL    ,
	[Designation]					[varchar](128)					NULL	,
	[Title]							[varchar](128)					NULL	, 
	[SignedOn]						[DateTime]						NULL	, 
	[LastUpdatedBy]					[varchar](128)					NULL	, 
	[LastUpdatedOn]					[DateTime]						NOT NULL, 
CONSTRAINT [PK_FarmEsmtAppSignatory_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppSignatory] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppSignatory]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAppSignatory] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppSignatory]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--ExistNonAgriUses
IF OBJECT_ID('FARM].[FarmEsmtExistNonAgriUses]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtExistNonAgriUses] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtExistNonAgriUses];

	ALTER TABLE [Farm].[FarmEsmtExistNonAgriUses] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtExistNonAgriUses];
END;

--DROP TABLE
DROP TABLE IF EXISTS [Farm].[FarmEsmtExistNonAgriUses];

--CREATE TABLE
CREATE TABLE [Farm].[FarmEsmtExistNonAgriUses](

   [Id]							   [integer] 		IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                 [integer]                       NOT NULL,
   [IsSubdivisionApproval]         [bit]                           NOT NULL,
   [InfoAboutPremises]             [varchar](4000)                     NULL,   
   [LastUpdatedBy]				   [varchar](128)		               NULL, 
   [LastUpdatedOn]				   [datetime]			           NOT NULL
   CONSTRAINT [PK_FarmEsmtExistNonAgriUses_ID] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

ALTER TABLE [Farm].[FarmEsmtExistNonAgriUses] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtExistNonAgriUses] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtExistNonAgriUses] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtExistNonAgriUses]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtApp AttachmentB
If OBJECT_ID('Farm].[FarmEsmtExceptionsAttachmentB]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtExceptionsAttachmentB] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtExceptionsAttachmentB];

	ALTER TABLE [Farm].[FarmEsmtExceptionsAttachmentB] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtExceptionsAttachmentB];
END;

--DROP TABLE
DROP TABLE IF EXISTS [Farm].[FarmEsmtExceptionsAttachmentB]

--CREATE TABLE
CREATE TABLE [Farm].[FarmEsmtExceptionsAttachmentB](
   [Id]                           [integer]      IDENTITY(1,1)     NOT NULL,
   [ApplicationId]                [integer]                        NOT NULL,
   [LocationOfException]          [varchar](256)                       NULL,
   [Block]                        [decimal](18,2)                      NULL,
   [Lot]                          [decimal](18,2)                      NULL,
   [ExceptionSize]                [decimal](18,2)                      NULL,
   [ReasonForException]           [varchar](256)                       NULL,
   [IsExceptionSoldFromPreserved] [bit]                                NULL,
   [IsRestrictExceptionToResiUnit][bit]                                NULL,
   [IsExceptionInNonAgriUse]      [bit]                                NULL,
   [IsResiExceptionArea]          [bit]                                NULL,
   [IsNonResiExceptionArea]       [bit]                                NULL,
   [NonAgriExceptionArea]         [varchar](256)                       NULL,
   [SingleFamilyResidence]        [integer]                            NULL,
   [ResiHomePermFoundation]       [integer]                            NULL,
   [ResiDuplex]                   [integer]                            NULL,
   [ResiHomeWithoutFoundation]    [integer]                            NULL,
   [ResidenceGarage]              [integer]                            NULL,
   [ResiDormitory]                [integer]                            NULL,
   [ResiAttachedTo]               [integer]                            NULL,
   [ResiGarriageHouse]            [integer]                            NULL,
   [NonResidentialBarn]           [integer]                            NULL,
   [NonResidentialShed]           [integer]                            NULL,
   [NonResidentialGarage]         [integer]                            NULL,
   [NonResidentialSilo]           [integer]                            NULL,
   [NonResidentialStable]         [integer]                            NULL,
   [LastUpdatedBy]				  [varchar](128)					   NULL, 
   [LastUpdatedOn]				  [datetime]					    NOT NULL

Constraint [PK_FarmEsmtExceptionsAttachmentB_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

ALTER TABLE [Farm].[FarmEsmtExceptionsAttachmentB] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtExceptionsAttachmentB] FOREIGN KEY (ApplicationId) REFERENCES [Farm].[FarmApplication](Id);

ALTER TABLE [Farm].[FarmEsmtExceptionsAttachmentB] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtExceptionsAttachmentB]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];
 
--Esmt App AttachmentC
IF OBJECT_ID('[Farm].[FarmEsmtAttachmentC]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtAttachmentC] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAttachmentC];

	ALTER TABLE [Farm].[FarmEsmtAttachmentC] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAttachmentC];
END;

--DROP TABLE
DROP TABLE IF EXISTS [Farm].[FarmEsmtAttachmentC];

--CREATE TABLE
CREATE TABLE [Farm].[FarmEsmtAttachmentC](
   [Id]							   [integer] 		       IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                 [integer]                              NOT NULL,
   [IsExceptionAreaPreserved]      [bit]                                  NOT NULL,
   [IsNonAgriPremisesPreserved]    [bit]                                  NOT NULL, 
   [DescNonAgriUses]		       [varchar](4000)		                      NULL, 
   [NonAgriAreaUtilization]		   [varchar](4000)		                      NULL, 
   [NonAgriLease]                  [varchar](4000)		                      NULL, 
   [NonAgriUseAccessParcel]		   [varchar](4000)		                      NULL,  
   [IsLeaseWithAnotherParty]	   [bit]									  NULL,
   [LastUpdatedBy]				   [varchar](128)		                      NULL, 
   [LastUpdatedOn]				   [datetime]			                  NOT NULL
   CONSTRAINT [PK_FarmEsmtAttachmentC_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

ALTER TABLE [Farm].[FarmEsmtAttachmentC] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAttachmentC] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAttachmentC] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAttachmentC]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtApp AttachmentA
IF OBJECT_ID('[Farm].[FarmEsmtAttachmentA]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtAttachmentA] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAttachmentA];

	ALTER TABLE [Farm].[FarmEsmtAttachmentA] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAttachmentA];

    ALTER TABLE [Farm].[FarmEsmtAttachmentA] DROP CONSTRAINT IF EXISTS  [DF_IsOfferPriceIndicated_FarmEsmtAttachmentA];
END;

--DROP TABLE
DROP TABLE IF EXISTS [Farm].[FarmEsmtAttachmentA];

--CREATE TABLE
CREATE TABLE [Farm].[FarmEsmtAttachmentA](
   [Id]							   [integer] 		       IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                 [integer]                              NOT NULL,
   [IsOfferPriceIndicated]	       [bit]                                  NOT NULL,
   [OfferPriceOpinion]		       [varchar](50)                              NULL, 
   [AveragePerAcre]	     	       [decimal](18,4)		                      NULL, 
   [OfferPriceComments] 		   [varchar](4000)		                      NULL, 
   [LastUpdatedBy]				   [varchar](128)		                      NULL, 
   [LastUpdatedOn]				   [datetime]			                  NOT NULL
   CONSTRAINT [PK_FarmEsmtAttachmentA_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

ALTER TABLE [Farm].[FarmEsmtAttachmentA] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAttachmentA] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
ALTER TABLE [Farm].[FarmEsmtAttachmentA] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAttachmentA]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];
ALTER TABLE [Farm].[FarmEsmtAttachmentA] WITH NOCHECK ADD  CONSTRAINT [DF_IsOfferPriceIndicated_FarmEsmtAttachmentA]  DEFAULT (0) FOR [IsOfferPriceIndicated];

--EsmtApp AttachmentE
IF OBJECT_ID('[FARM].[FarmEsmtAppAttachmentE]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtAppAttachmentE] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAppAttachmentE];

	ALTER TABLE [Farm].[FarmEsmtAppAttachmentE] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAttachmentE];
END;

--DROP TABLE
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAttachmentE];

--CREATE TABLE
CREATE TABLE [Farm].[FarmEsmtAppAttachmentE](

   [Id]													   [integer] 		IDENTITY(1,1)      NOT NULL,
   [ApplicationId]                                         [integer]                           NOT NULL,
   [TypeOfDevelopment]                                     [varchar](128)                          NULL,
   [PreliminaryApprovalDate]                               [dateTime]                              NULL,   
   [FinalApprovalDate]                                     [dateTime]                              NULL,   
   [ScaleofSubdivision]                                    [varchar](50)                           NULL,   
   [OtherPertinentInformation]                             [varchar](4000)                         NULL, 
   [IsOpenEnrollment]                                      [bit]                                   NULL,   
   [IsPropertyOutlined]                                    [bit]                                   NULL,   
   [IsAllExpAreasIdentified]                               [bit]                                   NULL,   
   [IsAllNonAgriEquiUsesDetailed]                          [bit]                                   NULL,   
   [IsCopyOfDeed]                                          [bit]                                   NULL,   
   [IsSignOfAllPropOwnersListed]                           [bit]                                   NULL,   
   [IsFarmLandAssReportCopy]                               [bit]                                   NULL,   
   [LastUpdatedBy]										   [varchar](128)		                   NULL, 
   [LastUpdatedOn]				                           [datetime]			                NOT NULL
   CONSTRAINT [PK_FarmEsmtAppAttachmentE_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

ALTER TABLE [Farm].[FarmEsmtAppAttachmentE] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAttachmentE] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAppAttachmentE] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAttachmentE]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtApp AttachmentD SourceType
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAttachmentDActivityType]

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAttachmentDActivityType](
	[Id]						[integer] 			IDENTITY(1,1)		NOT NULL,
	[Title]						[varchar](128) 							NOT NULL,
	
CONSTRAINT [PK_FarmEsmtAttachmentDActivityType_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

--EsmtApp AttachmentD
IF OBJECT_ID('[Farm].[FarmEsmtAttachmentD]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAttachmentD] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAttachmentD];
	
	ALTER TABLE [Farm].[FarmEsmtAttachmentD] DROP CONSTRAINT IF EXISTS  [FK_EquineActivityTypeId_FarmEsmtAttachmentD];

	ALTER TABLE [Farm].[FarmEsmtAttachmentD] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAttachmentD];
END;
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAttachmentD];

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAttachmentD](
	[Id]									[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]							[integer]						NOT NULL,
	[EquineActivityTypeId]                  [integer]							NULL,
	[Counts]								[decimal](18,2)						NULL,
	[Number]								[integer]							NULL,
	[NumberOfHorses]						[integer]							NULL,
	[NumberOfHorsesActivity]				[integer]							NULL,
	[NumberOfStalls]						[integer]							NULL,
	[RunInSheds]							[integer]							NULL,
	[IndoorRidingArena]						[integer]							NULL,
	[OutdoorRidingArena]					[integer]							NULL,
	[LastUpdatedBy]							[varchar](128)						NULL,
	[LastUpdatedOn]							[datetime]						NOT NULL,
		
CONSTRAINT [PK_FarmEsmtAttachmentD_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraints
ALTER TABLE [Farm].[FarmEsmtAttachmentD] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAttachmentD]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAttachmentD] ADD CONSTRAINT [FK_EquineActivityTypeId_FarmEsmtAttachmentD]  FOREIGN KEY (EquineActivityTypeId) REFERENCES [Farm].FarmEsmtAttachmentDActivityType(Id);

ALTER TABLE [Farm].[FarmEsmtAttachmentD] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAttachmentD]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

--EsmtApp AgriculturalProduction Source Type
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAgricultureProdSourceType];

-- Create Table
Create Table [Farm].[FarmEsmtAgricultureProdSourceType](
[Id]                                    [integer]                              NOT NULL,
[SicCode]								[varchar](80)						   NOT NULL,
[Title]                                 [varchar](216)			               NOT NULL,
[SortOrder]                             [smallint]                             NOT NULL,
[ActivityTypeId]						[integer]								   NULL
CONSTRAINT [PK_FarmEsmtAgricultureProdSourceType_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY];

--EsmtApp FarmAgriculturalEnterpriseChecklist
IF OBJECT_ID('[Farm].[FarmAgriculturalEnterpriseChecklist]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmAgriculturalEnterpriseChecklist];

	ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] DROP CONSTRAINT IF EXISTS  [FK_ActivitySubTypeId_FarmAgriculturalEnterpriseChecklist];

	ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmAgriculturalEnterpriseChecklist];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmAgriculturalEnterpriseChecklist]

--Create Table
CREATE TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] (
    [Id]                 [integer] IDENTITY(1,1)	NOT NULL,
    [ApplicationId]	     [integer]	                NOT NULL,
	[ActivitySubTypeId]  [integer]                  NOT NULL,
	[Title]              [varchar](256)             NOT NULL,
	[SicCode]            [varchar](128)             NOT NULL,
    [IsPrimary]          [bit]                          NULL,
    [IsSecondary]        [bit]                          NULL,
	[LastUpdatedBy]	     [varchar](128)	                NULL,
    [LastUpdatedOn]		 [DateTime]			            NULL,
CONSTRAINT [PK_FarmAgriculturalEnterpriseChecklist_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] ADD CONSTRAINT [FK_ApplicationId_FarmAgriculturalEnterpriseChecklist]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] ADD CONSTRAINT [FK_ActivitySubTypeId_FarmAgriculturalEnterpriseChecklist] FOREIGN KEY (ActivitySubTypeId) REFERENCES [Farm].FarmEsmtAgricultureProdSourceType(Id);
ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmAgriculturalEnterpriseChecklist]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtApp Agricultural And Production
IF OBJECT_ID('[Farm].[FarmEsmtAgriculturalAndProduction]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAgriculturalAndProduction] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAgriculturalAndProduction];
		
	ALTER TABLE [Farm].[FarmEsmtAgriculturalAndProduction] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAgriculturalAndProduction];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAgriculturalAndProduction];

CREATE TABLE [Farm].[FarmEsmtAgriculturalAndProduction](
            [Id]                            [integer] IDENTITY(1,1)  NOT NULL,
			[ApplicationId]				    [integer] 			     NOT NULL,
			[AverageGrossReceipts]		    [varchar](200) 		     NULL,
			[IsFullTimeFarmer]		        [bit]		             NULL,
			[HasSoilConservationPlan]       [bit]		             NULL,
			[PlanDate]                      [DateTime]               NULL,
			[ConservationPractices]         [varchar](4000)          NULL,
			[AgriculturalInvestments]       [varchar](4000)          NULL,
			[LastUpdatedBy]			        [varchar](128)	         NULL,
            [LastUpdatedOn]			        [DateTime]			     NULL,
CONSTRAINT [PK_FarmEsmtAgriculturalAndProduction_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAgriculturalAndProduction] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAgriculturalAndProduction]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAgriculturalAndProduction] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAgriculturalAndProduction]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtAppAdmin SADC
IF OBJECT_ID('[FARM].[FarmEsmtAppAdminSADC]') IS NOT NULL
BEGIN 
   --- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminSADC] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAppAdminSADC];
	ALTER TABLE [Farm].[FarmEsmtAppAdminSADC] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_FarmEsmtAppAdminSADC];
END;

--Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminSADC];

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppAdminSADC](
	[Id]                     [integer]                 IDENTITY(1,1)           NOT NULL,
	[ApplicationId]          [integer]                                         NOT NULL,
	[ProgramName]            [varchar](54)                                         NULL,
	[SADCFundingRoundYear]   [varchar](128)                                        NULL,
	[SADCQualityScore]       [decimal](18,2)                                       NULL,
	[SADCPrelimRank]         [integer]                                             NULL,
	[SADCFinalRank]          [integer]                                             NULL,
	[SADCFinalScore]	     [integer]                                             NULL,
	[LastUpdatedBy]          [varchar](128)                                        NULL,
	[LastUpdatedOn]          [datetime]                                        NOT NULL	
  CONSTRAINT [PK_FarmEsmtAppAdminSADC_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminSADC] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminSADC] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAppAdminSADC] WITH NOCHECK ADD CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminSADC] DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtAppAdmin Cost Deatils
IF OBJECT_ID('[Farm].[FarmEsmtAppAdminCostDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminCostDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminCostDetails];
		
	ALTER TABLE [Farm].[FarmEsmtAppAdminCostDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminCostDetails];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminCostDetails];

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppAdminCostDetails](
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
CONSTRAINT [PK_FarmEsmtAppAdminCostDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminCostDetails] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminCostDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAppAdminCostDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminCostDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtAppAdmin OfferCost
IF OBJECT_ID('[FARM].[FarmEsmtAppAdminOfferCost]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtAppAdminOfferCost] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAppAdminOfferCost];

	ALTER TABLE [Farm].[FarmEsmtAppAdminOfferCost] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminOfferCost];
END;

--DROP TABLE
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminOfferCost];

--CREATE TABLE
CREATE TABLE [Farm].[FarmEsmtAppAdminOfferCost](

   [Id]													   [integer] 		IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                                         [integer]                       NOT NULL,
   [CadbLandOwnerOffer]                                    [decimal](10,2)                     NULL,
   [IsOfferAccepted]                                       [bit]                               NULL,       
   [OtherSource]                                           [varchar](256)                      NULL,   
   [CostNote]                                              [varchar](4000)                     NULL,   
   [LastUpdatedBy]										   [varchar](128)		               NULL, 
   [LastUpdatedOn]										   [datetime]			           NOT NULL
   CONSTRAINT [PK_FarmEsmtAppAdminOfferCost_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

ALTER TABLE [Farm].[FarmEsmtAppAdminOfferCost] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminOfferCost] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAppAdminOfferCost] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminOfferCost]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtAppAdmin Exceptions/RDSO
IF OBJECT_ID('[Farm].[FarmEsmtAppAdminExceptionRDSO]') IS NOT NULL
BEGIN
	----Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAppAdminExceptionRDSO];
	ALTER TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_FarmEsmtAppAdminExceptionRDSO];
END;
 
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminExceptionRDSO];
 
-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] (
	[Id]						[integer] IDENTITY(1,1) NOT NULL,
	[ApplicationId]				[integer]               NOT NULL,
	[NumberofExceps]			[integer]					NULL,
	[Excep1Acres]				[decimal](18,2)				NULL,
	[X1Purpose]					[varchar](128)				NULL,
	[X1Severable]				[bit]						NULL,
	[X1IsSubdividable]			[bit]						NULL,
	[X1IsRTF]					[bit]						NULL,
	[Excep2Acres]				[decimal](18,2)             NULL,
	[X2Purpose]					[varchar](128)             NULL,
	[X2IsSeverable]				[bit]					   NULL,
	[X2IsSubdividable]			[bit] 					   NULL,
	[X2IsRTF]					[bit] 					   NULL,
	[Excep3Acres]				[decimal](18,2) 		   NULL,
	[X3Purpose]					[varchar](128)			   NULL,
	[X3IsSeverable]				[bit] 					   NULL,
	[X3IsSubdividable]			[bit] 				       NULL,
	[X3IsRTF]                   [bit]                      NULL,
	[RDSOsNum]		            [integer]				   NULL,
	[RDSOExplan]				[varchar](128)			   NULL,
	[IsRDSOExercised]			[bit]					   NULL,
	[LastUpdatedBy]				[varchar](128) 			   NULL,
	[LastUpdatedOn]				[datetime]              NOT NULL,
CONSTRAINT [PK_FarmEsmtAppAdminExceptionRDSO_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY];
 
--- Create constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminExceptionRDSO] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
 
ALTER TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] WITH NOCHECK ADD CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminExceptionRDSO] DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtAppAdmin ClosingDocs
IF OBJECT_ID('[Farm].[FarmEsmtAppAdminClosingDocStatus]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminClosingDocStatus];
		
	ALTER TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminClosingDocStatus];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminClosingDocStatus];

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus](
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
CONSTRAINT [PK_FarmEsmtAppAdminClosingDocStatus_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminClosingDocStatus]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAppAdminClosingDocStatus] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminClosingDocStatus]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtAppAdmin Appraisal Report
IF OBJECT_ID('[Farm].[FarmEsmtAppAdminAppraisalReport]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminAppraisalReport] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminAppraisalReport ];
		
	ALTER TABLE [Farm].[FarmEsmtAppAdminAppraisalReport] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminAppraisalReport ];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminAppraisalReport];

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppAdminAppraisalReport](
	[Id]												   [integer] 		IDENTITY(1,1)  NOT NULL,
	[ApplicationId]                                        [integer]                       NOT NULL,
	[AsOfDate]											   [datetime]						   NULL,
	[AppraiserName1]									   [varchar](128)		               NULL,
	[AppraiserName2]									   [varchar](128)		               NULL,
	[LowerAppraiser]									   [varchar](128)		               NULL,
	[HigherAppraiser]									   [varchar](128)		               NULL,
	[PreHLBeforeValue1]									   [decimal](18,2)					   NULL,
	[PreHLAfterValue1]									   [decimal](18,2)					   NULL,
	[PreHLEsmtValue1]									   [decimal](18,2)					   NULL,
	[PreHLBeforeValue2]									   [decimal](18,2)					   NULL,
	[PreHLAfterValue2]									   [decimal](18,2)					   NULL,
	[PreHLEsmtValue2]									   [decimal](18,2)					   NULL,
	[PostHLBeforeValue1]								   [decimal](18,2)					   NULL,
	[PostHLAfterValue1]									   [decimal](18,2)					   NULL,
	[PostHLEsmtValue1]									   [decimal](18,2)					   NULL,
	[PostHLBeforeValue2]								   [decimal](18,2)					   NULL,
	[PostHLAfterValue2]									   [decimal](18,2)					   NULL,
	[PostHLEsmtValue2]									   [decimal](18,2)					   NULL,
	[DiffInEsmtAppraisals]								   [decimal](18,2)					   NULL,
	[PostHLDifference]									   [decimal](18,2)					   NULL,
	[DiffInPreandPostHL]								   [decimal](18,2)					   NULL,
	[WithInHighlands]									   [bit]							   NULL,
	[WithInPreservationArea]							   [bit]							   NULL,
	[SADCCertifiedEsmttotal]							   [decimal](18,2)					   NULL,
	[SADCEsmtBeforePct]                                    [decimal](18,2)					   NULL,
	[AppraisedZoning]									   [varchar](128)		               NULL,
	[ApraisedZoningClass]								   [varchar](128)		               NULL,
	[AppraisalComments]									   [varchar](4000)					   NULL,
	[FreeHolderDate]									   [datetime]						   NULL,
	[CurrentZoning]										   [varchar](128)		               NULL,
	[CADBEasement]										   [decimal](18,2)					   NULL,
	[CADBBefore]										   [decimal](18,2)					   NULL,
	[CADBEaseBefore]									   [decimal](18,2)		               NULL,
	[LastUpdatedBy]										   [varchar](128)		               NULL,
	[LastUpdatedOn]										   [datetime]			           NOT NULL,
CONSTRAINT [PK_FarmEsmtAppAdminAppraisalReport _Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminAppraisalReport] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminAppraisalReport]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAppAdminAppraisalReport] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminAppraisalReport]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtApp Admin Details
IF OBJECT_ID('[Farm].[FarmEsmtAppAdminDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminDetails];
		
	ALTER TABLE [Farm].[FarmEsmtAppAdminDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminDetails];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminDetails]

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppAdminDetails](
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
CONSTRAINT [PK_FarmEsmtAppAdminDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminDetails] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAppAdminDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtApp SADC History
IF OBJECT_ID('[Farm].[FarmEsmtSadcHistory]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtSadcHistory] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtSadcHistory];
		
	ALTER TABLE [Farm].[FarmEsmtSadcHistory] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcHistory];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtSadcHistory]

-- Create Table
CREATE TABLE [Farm].[FarmEsmtSadcHistory](
	[Id]							[integer] 		      IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]							NOT NULL,
	[SquareFootage]					[decimal](10,2)					        NULL,
	[PreliminaryExpiration]		    [datetime]	        					NULL,
	[FinalExpiration]			    [datetime]	    				        NULL,
	[EstateWill]			        [bit]				                    NULL,
	[TaxWaiver]				        [bit]						            NULL,
	[NoWaiver]					    [bit]   					            NULL,
	[TrustWill]				        [bit]					                NULL,
	[TrustDocuments]			    [bit]        					        NULL,
	[LastUpdatedBy]					[varchar](128)					        NULL,
	[LastUpdatedOn]					[datetime]					            NULL,
CONSTRAINT [PK_FarmEsmtSadcHistory_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtSadcHistory] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtSadcHistory]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtSadcHistory] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtSadcHistory]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--SADC Eligibility
IF OBJECT_ID('[Farm].[FarmEsmtSadcEligibility]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtSadcEligibility] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtSadcEligibility ];
		
	ALTER TABLE [Farm].[FarmEsmtSadcEligibility] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcEligibility ];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtSadcEligibility];

-- Create Table
CREATE TABLE [Farm].[FarmEsmtSadcEligibility](
	[Id]												   [integer] 		IDENTITY(1,1)  NOT NULL,
	[ApplicationId]                                        [integer]                       NOT NULL,
	[ProjectAreaAppEl]									   [varchar](4000)		               NULL,
	[RankScore]							                   [decimal](18,2)					   NULL,
	[RankPoints]									       [decimal](18,2)		               NULL,
	[SoilPercentage]									   [decimal](18,2)		               NULL,
	[IsLandsLessThan10Ac]								   [bit]        		               NULL,
    [IsLandsGreaterThan10Ac]							   [bit]        		               NULL,
	[Is75PercentTillable]								   [bit]				        	   NULL,
	[Percent75Tillable1]								   [decimal](18,2)					   NULL,
	[Acre75Tillable]									   [decimal](18,2)					   NULL,
	[Is75PercentLand]									   [bit]        					   NULL,
	[Percent75Land]								           [decimal](18,2)					   NULL,
	[Acre75Land]								           [decimal](18,2)					   NULL,
	[Is50PercentTillable]								   [bit]					           NULL,
	[Percent50Tillable]									   [decimal](18,2)					   NULL,
	[Acre50Tillable]								       [decimal](18,2)					   NULL,
	[Is50PercentLand]								       [bit]        					   NULL,
	[Percent50Land]										   [decimal](18,2)					   NULL,
	[Acre50Land]								           [decimal](18,2)					   NULL,
	[LastUpdatedBy]										   [varchar](128)		               NULL,
	[LastUpdatedOn]										   [datetime]			           NOT NULL,
CONSTRAINT [PK_FarmEsmtSadcEligibility _Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtSadcEligibility] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtSadcEligibility]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtSadcEligibility] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtSadcEligibility]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtApp SADC Farm Info
IF OBJECT_ID('[Farm].[FarmEsmtSadcFarmInfo]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtSadcFarmInfo] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtSadcFarmInfo];

	ALTER TABLE [Farm].[FarmEsmtSadcFarmInfo] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcFarmInfo];
END;

--DROP TABLE
DROP TABLE IF EXISTS [Farm].[FarmEsmtSadcFarmInfo];

--CREATE TABLE
CREATE TABLE [Farm].[FarmEsmtSadcFarmInfo](
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
   CONSTRAINT [PK_FarmEsmtSadcFarmInfoC_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

ALTER TABLE [Farm].[FarmEsmtSadcFarmInfo] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtSadcFarmInfo] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtSadcFarmInfo] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtSadcFarmInfo]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtApp SADC EligibilityTwo
IF OBJECT_ID('[FARM].[FarmEsmtSadcEligibilityTwo]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtSadcEligibilityTwo] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtSadcEligibilityTwo];
	ALTER TABLE [Farm].[FarmEsmtSadcEligibilityTwo] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcEligibilityTwo];
END;

--DROP TABLE
DROP TABLE IF EXISTS [Farm].[FarmEsmtSadcEligibilityTwo];

--CREATE TABLE
CREATE TABLE [Farm].[FarmEsmtSadcEligibilityTwo](
   [Id]													   [integer] 		IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                                         [integer]                       NOT NULL,
   [Prime]                                                 [decimal](10,2)                      NULL,
   [PrimeacresPct]                                         [decimal](10,2)                     NULL,   
   [Statewide]                                             [decimal](10,2)                      NULL,   
   [StatewideAcresPct]                                     [decimal](10,2)                     NULL,   
   [Local]                                                 [decimal](10,2)                      NULL,
   [LocalAcresPct]                                         [decimal](10,2)                     NULL, 
   [Unique]                                                [decimal](10,2)                      NULL,   
   [UniqueAcresPct]                                        [decimal](10,2)                     NULL,
   [UniqueSoils]                                           [varchar](4000)                     NULL,   
   [ListCropUniqueSoil]                                    [varchar](4000)                     NULL,   
   [Other]                                                 [varchar](4000)                     NULL,   
   [OtherAcresPct]                                         [decimal](10,2)                     NULL,   
   [TotalNetAcres]                                         [decimal](10,2)                     NULL,   
   [TotalNetAcresPct]                                      [decimal](10,2)                     NULL,
   [CroplandHarvested]                                     [decimal](10,2)                      NULL,
   [CroplandHarvestedPct]                                  [decimal](10,2)                     NULL,
   [CroplandPastured]                                      [decimal](10,2)                      NULL,
   [CroplandPasturedPct]                                   [decimal](10,2)                     NULL,
   [PermanentPasture]                                      [decimal](10,2)                      NULL,
   [PermanentPasturePct]                                   [decimal](10,2)                     NULL,
   [Woodlands]                                             [decimal](10,2)                      NULL,
   [WoodlandsPct]                                          [decimal](10,2)                     NULL,
   [ExceptionOther]                                        [varchar](4000)                     NULL,
   [ExceptionOtherPct]                                     [decimal](10,2)                      NULL,
   [ExceptionTotalNetAcres]                                [decimal](10,2)                     NULL,
   [ExceptionTotalNetAcresPct]                             [decimal](10,2)                     NULL,
   [ZoningCode]                                            [varchar](4000)                     NULL,   
   [MinimumLotSize]                                        [decimal](10,2)                     NULL,   
   [Regional]                                              [varchar](4000)                     NULL,   
   [IsHighlandsRegion]                                     [bit]                               NULL,   
   [IsPreservation]                                        [bit]                               NULL,   
   [IsPlanningArea]                                        [bit]                               NULL,   
   [CountyaverageRank]                                     [decimal](10,2)                     NULL,     
   [LastUpdatedBy]										   [varchar](128)		               NULL, 
   [LastUpdatedOn]										   [datetime]			           NOT NULL
   CONSTRAINT [PK_FarmEsmtSadcEligibilityTwo_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];
ALTER TABLE [Farm].[FarmEsmtSadcEligibilityTwo] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtSadcEligibilityTwo] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
ALTER TABLE [Farm].[FarmEsmtSadcEligibilityTwo] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtSadcEligibilityTwo]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtApp SADC Residence
IF OBJECT_ID('[Farm].[FarmEsmtSadcResidence]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtSadcResidence] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtSadcResidence];
	ALTER TABLE [Farm].[FarmEsmtSadcResidence] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcResidence];
END;
 
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtSadcResidence];
 
-- Create Table
CREATE TABLE [Farm].[FarmEsmtSadcResidence](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[IsAgriculturalLabor]			[bit]						        NULL,
	[UnitsUsedForLabor]			    [varchar](4000)						NULL,
	[Occupants]			            [int]					            NULL,
	[MonthsOccupied]			    [int]				                NULL,
	[IsOccupantsWork]				[bit]						        NULL,
	[PleaseExplain]					[varchar](4000)					    NULL,
	[IsResidencesRented]		    [bit]					            NULL,
	[RDSOsReserve]				    [varchar](4000)						NULL,
    [ExcepAcres1]                   [decimal](10,2)                     NULL,
    [NonSeverable1]                 [bit]                               NULL,
    [Severable1]                    [bit]                               NULL,
    [AdditionalComment1]           [varchar](4000)                     NULL,
    [ExcepAcres2]                   [decimal](10,2)                     NULL,
    [NonSeverable2]                 [bit]                               NULL,
    [Severable2]                    [bit]                               NULL,
    [AdditionalComment2]           [varchar](4000)                     NULL,
    [EsmtOthersText]                [varchar](4000)                     NULL,
    [IsSightTriangle]               [bit]                               NULL,
	[LastUpdatedBy]					[varchar](128)						NULL,
	[LastUpdatedOn]					[datetime]							NULL,
CONSTRAINT [PK_FarmEsmtSadcResidence_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];
 
-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtSadcResidence] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtSadcResidence]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
 
ALTER TABLE [Farm].[FarmEsmtSadcResidence] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtSadcResidence]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--EsmtAppAdmin Structure/Non-Agri WetLands
IF OBJECT_ID('[Farm].[FarmEsmtAppAdminStructNonAgriWetlands]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminStructNonAgriWetlands];
		
	ALTER TABLE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminStructNonAgriWetlands];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminStructNonAgriWetlands];

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands](
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
CONSTRAINT [PK_FarmEsmtAppAdminStructNonAgriWetlands_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminStructNonAgriWetlands]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);

ALTER TABLE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminStructNonAgriWetlands]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--Email Template
IF OBJECT_ID('[Farm].[FarmEmailTemplate]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEmailTemplate] DROP CONSTRAINT IF EXISTS  [DF_IsActive_FarmEmailTemplate];

	ALTER TABLE [Farm].[FarmEmailTemplate] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEmailTemplate];

END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEmailTemplate]

CREATE TABLE [Farm].[FarmEmailTemplate](
[Id]				[smallint]			NOT NULL,
[TemplateCode]		[varchar](128)		NOT NULL,
[Title]				[varchar](256)		NOT NULL,
[Subject]			[varchar](512)			NULL,
[Description]		[varchar](max)		 NOT NULL,
[IsActive]			[bit]					 NULL,
[LastUpdatedBy]		[varchar](128)			 NULL,
[LastUpdatedOn]		[datetime]				 NULL,
CONSTRAINT [PK_FarmEmailTemplate_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraints
ALTER TABLE [Farm].[FarmEmailTemplate] WITH NOCHECK ADD  CONSTRAINT [DF_IsActive_FarmEmailTemplate]  DEFAULT (1) FOR [IsActive];

ALTER TABLE [Farm].[FarmEmailTemplate] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEmailTemplate]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--ParcelHistory
IF OBJECT_ID('[Farm].[FarmParcelHistory]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [FK_ParcelId_FarmParcelHistory];

	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmParcelHistory];

	ALTER TABLE [Farm].[FarmParcelHistory] DROP CONSTRAINT IF EXISTS  [DF_IsActive_FarmParcelHistory];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmParcelHistory];

-- Create Table
CREATE TABLE [Farm].[FarmParcelHistory](
	[Id]								[integer] 		IDENTITY(1,1)	NOT NULL,
	[ParcelId]							[integer] 						NOT NULL,
	[CurrentPamsPin]					[varchar](76)					NOT NULL,
	[PreviousPamsPin]					[varchar](76)					NOT NULL,
	[Section]							[varchar](128)					NULL,
	[Acres]								[decimal](18,4)					NULL,
	[AcresToBeAcquired]					[decimal](18,4)					NULL,
	[Partial]							[bit]							NULL,
	[InterestType]						[varchar](100)					NULL,
	[IsThisAnExclusionArea]				[bit]							NULL,
	[Notes]								[varchar](4000)					NULL,
	[EasementId]						[varchar](100)					NULL,
	[IsActive]							[bit]							NOT NULL,
	[ChangeType]                        [varchar](100)                  NULL,
	[ChangeDate]						[datetime]                      NULL,
	[ReasonForChange]					[varchar](4000)					NULL,
	[LastUpdatedBy]						[varchar](128)					NOT NULL,
	[LastUpdatedOn]						[datetime]						NOT NULL,
CONSTRAINT [PK_FarmParcelHistory_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraints  
ALTER TABLE [Farm].[FarmParcelHistory] ADD CONSTRAINT [FK_ParcelId_FarmParcelHistory] FOREIGN KEY (ParcelId) REFERENCES [Farm].[FarmMunicipalityBlockLotParcel](Id);

ALTER TABLE [Farm].[FarmParcelHistory] WITH NOCHECK ADD  CONSTRAINT [DF_IsActive_FarmParcelHistory]  DEFAULT (0) FOR [IsActive];

ALTER TABLE [Farm].[FarmParcelHistory] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmParcelHistory]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

--Farm ReSale Details
IF OBJECT_ID('[Farm].[FarmReSaleDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmReSaleDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmReSaleDetails];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmReSaleDetails];

-- Create Table
CREATE TABLE [Farm].[FarmReSaleDetails](
[Id]                                  [integer] IDENTITY(1,1)   NOT NULL,
[FarmNumber]                          [varchar](5)                  NULL,
[ReSellDate]                          [DateTime]                    NULL,               
[ReSellPriceTotal]                    [decimal](10,2)               NULL,
[ReSellPricePerAcre]                  [decimal](10,2)               NULL,
[ReSellNotes]                         [varchar](4000)               NULL,
[CurrentDeedBook]                     [varchar](50)                 NULL,
[CurrentDeedPage]                     [varchar](50)                 NULL, 
[CurrentDeedFiled]                    [DateTime]                    NULL,
[InterestedinSelling]                 [bit]                         NULL,                
[LastUpdatedBy]					      [varchar](128)			    NULL, 
[LastUpdatedOn]					      [DateTime]				NOT NULL,
CONSTRAINT [PK_FarmReSaleDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint 
ALTER TABLE [Farm].[FarmReSaleDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmReSaleDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn];

--Farm Monitoring Details
IF OBJECT_ID('[Farm].[FarmMonitoringDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmMonitoringDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmMonitoringDetails];
END;

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmMonitoringDetails]

-- Create Table
CREATE TABLE [Farm].[FarmMonitoringDetails](
		[Id]                                  [integer] IDENTITY(1,1)   NOT NULL,
		[FarmListId]                          [integer]                 NOT NULL,
		[FarmNumber]                          [varchar](5)                  NULL,
		[OriginalLandowner]                   [varchar](128)                NULL,
		[PresentOwner]                        [varchar](128)                NULL,
		[FarmName]                            [varchar](128)                NULL,
		[FarmerName]                          [varchar](128)                NULL,
		[IsConservationPlan]                  [bit]                         NULL,
		[ConsPlanDate]                        [varchar](128)                NULL,
		[ConsPlanComment]                     [varchar](4000)               NULL, 
		[Street1]                             [varchar](128)                NULL,
		[Street2]                             [varchar](128)                NULL,
		[FirstName]                           [varchar](128)                NULL,
		[LastName]                            [varchar](128)                NULL,
		[PhoneNumber]					      [varchar](15)				    NULL,
		[City]							      [varchar](128)			    NULL,
		[State]							      [varchar](128)				NULL,
		[ZipCode]						      [integer] 					NULL,
		[ClosingDate]                         [DateTime]                    NULL,
		[TitlePolicy]                         [varchar](128)                NULL,
		[TitleCompany]                        [varchar](128)                NULL,
		[EPDeedBook]					      [integer]					    NULL,
		[EPDeedPage]					      [integer]					    NULL,
		[EPDeedFiled]					      [datetime]				    NULL,
		[GrossAcers]                          [decimal](10,2)               NULL,
		[RDSOsNum]		                      [integer]				        NULL,
		[RDSOExplan]				          [varchar](128)			    NULL,
		[IsRDSOExercised]			          [bit]					        NULL,
		[ImprovRes]	         				  [varchar](4000)			    NULL,
		[ImprovAg]                            [varchar](4000)	            NULL,
		[AreNonAgUses]				          [bit]					        NULL,
		[NonAgExplan]				          [varchar](4000)			    NULL,
		[FirstInspect]                        [DateTime]                    NULL,
		[PreviousInspect]                     [DateTime]                    NULL,
		[LastInspect]                         [DateTime]                    NULL,
		[ChangesSinceLastInspect]             [varchar](4000)               NULL,
		[IssuesImpactingFarm]                 [varchar](128)                NULL,
		[IsInCompliance]                      [bit]                         NULL,
		[NonComplianceExplan]                 [varchar](4000)               NULL,
		[InspectionComments]                  [varchar](4000)               NULL,
		[CurrentDeedBook]                     [varchar](50)                 NULL,
		[CurrentDeedPage]                     [varchar](50)                 NULL, 
		[CurrentDeedFiled]                    [DateTime]                    NULL,
		[LastUpdatedBy]					      [varchar](128)			    NULL, 
		[LastUpdatedOn]					      [DateTime]				NOT NULL,
CONSTRAINT [PK_FarmMonitoringDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY];

-- Create Constraint 
ALTER TABLE [Farm].[FarmMonitoringDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmMonitoringDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]

--FarmAnnualSummaryREPORT

IF OBJECT_ID('[rept].[FARMAnnualSummaryReport]') IS NOT NULL
BEGIN
	-- Delete Constraint
	ALTER TABLE [rept].[FARMAnnualSummaryReport] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedBy_ReptFARMAnnualSummaryReport];

	ALTER TABLE [rept].[FARMAnnualSummaryReport] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_ReptFARMAnnualSummaryReport];

END;

-- Drop Table
DROP TABLE IF EXISTS [rept].[FARMAnnualSummaryReport];

-- Create Table
CREATE TABLE [rept].[FARMAnnualSummaryReport](
		[AgencyId]								INT					NULL,
		[MunicipalityId]						INT                 NULL,
		[Municipality]							VARCHAR(128)		NULL,
        [TotalFarms]							INT                 NULL,
        [Submitted]								INT                 NULL,
        [EsmtPendingApplications]				INT                 NULL,
        [PostClosing]							INT                 NULL,
        [Preserved]								INT                 NULL,
        [Petition]								INT                 NULL,
        [FundsAwarded]							DECIMAL(18, 2)      NULL,
        [OriginalLandowner]						VARCHAR(128)        NULL,
        [TotalApplications]						INT                 NULL,
        [ActiveApplications]					INT                 NULL,
        [TermApplications]						INT                 NULL,
		[EsmtApplications]						INT					NULL, 
        [ExceptionAreaAcreage]					DECIMAL(18, 2)      NULL,
        [PreservedAcreage]						DECIMAL(18, 2)      NULL,
        [TillableAcreage]						DECIMAL(18, 2)      NULL,
        [UnPreservedAcreage]					DECIMAL(18, 2)      NULL,
		[TermPendingApplications]				INT                 NULL,
		[RejectedApplications]					INT                 NULL,
		[WithdrawnApplication]					INT                 NULL,
        [ActiveTermApplication]                 INT                 NULL,
	    [ExpiredTermApplication]                INT                 NULL,
		[PreservedAcres]						DECIMAL(18, 2)      NULL,
		[LastUpdatedBy]							VARCHAR(128)		NULL,
		[LastUpdatedOn]							[datetime]			NULL
) ON [PRIMARY];

ALTER TABLE [rept].[FARMAnnualSummaryReport] ADD  CONSTRAINT [DF_LastUpdatedBy_ReptFARMAnnualSummaryReport]  DEFAULT ('SQL Job') FOR [LastUpdatedBy];

ALTER TABLE [rept].[FARMAnnualSummaryReport] ADD  CONSTRAINT [DF_LastUpdatedOn_ReptFARMAnnualSummaryReport]  DEFAULT (getdate()) FOR [LastUpdatedOn];

--================================================================================================================================================

	--SELECT 1/0;
	COMMIT;
	PRINT 'SUCCESS';
END TRY
BEGIN CATCH
	DECLARE @ErrorMessage NVARCHAR(4000); 

	SET   @ErrorMessage = ERROR_MESSAGE();
	ROLLBACK;

	SELECT @ErrorMessage;
END CATCH


