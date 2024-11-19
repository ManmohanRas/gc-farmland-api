IF OBJECT_ID('[Farm].[FarmEsmtSadcFarmInfo]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtSadcFarmInfo] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtSadcFarmInfo];

	ALTER TABLE [Farm].[FarmEsmtSadcFarmInfo] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcFarmInfo];

END;
GO

--DROP TABLE

DROP TABLE IF EXISTS [Farm].[FarmEsmtSadcFarmInfo]
GO

--CREATE TABLE

CREATE TABLE [Farm].[FarmEsmtSadcFarmInfo](
   [Id]							   [integer] 		       IDENTITY(1,1)   NOT NULL,
   [ApplicationId]                 [integer]                               NOT NULL,
   [AlternatePhoneNumber]          [varchar](15)                               NULL,
   [County]                        [varchar](128)                              NULL,
   [TotalFarmAcreage]              [decimal]                                   NULL,
   [Acres]                         [decimal]                                   NULL,
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
) ON [PRIMARY]

GO

ALTER TABLE [Farm].[FarmEsmtSadcFarmInfo] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtSadcFarmInfo] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO

ALTER TABLE [Farm].[FarmEsmtSadcFarmInfo] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtSadcFarmInfo]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO

