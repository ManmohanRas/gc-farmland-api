IF OBJECT_ID('[rept].[FARMAnnualSummaryReport]') IS NOT NULL
BEGIN
	-- Delete Constraint
	ALTER TABLE [rept].[FARMAnnualSummaryReport] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedBy_ReptFARMAnnualSummaryReport];

	ALTER TABLE [rept].[FARMAnnualSummaryReport] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_ReptFARMAnnualSummaryReport];

END;
Go

-- Drop Table
DROP TABLE IF EXISTS [rept].[FARMAnnualSummaryReport]
GO

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
) ON [PRIMARY]
GO

ALTER TABLE [rept].[FARMAnnualSummaryReport] ADD  CONSTRAINT [DF_LastUpdatedBy_ReptFARMAnnualSummaryReport]  DEFAULT ('SQL Job') FOR [LastUpdatedBy]
GO

ALTER TABLE [rept].[FARMAnnualSummaryReport] ADD  CONSTRAINT [DF_LastUpdatedOn_ReptFARMAnnualSummaryReport]  DEFAULT (getdate()) FOR [LastUpdatedOn]
GO