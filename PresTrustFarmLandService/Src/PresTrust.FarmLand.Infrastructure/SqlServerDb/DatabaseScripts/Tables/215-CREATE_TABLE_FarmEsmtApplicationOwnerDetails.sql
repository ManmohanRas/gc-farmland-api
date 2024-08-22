IF OBJECT_ID('[Farm].[FarmEsmtAppOwnerDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppOwnerDetails];
		
	ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppOwnerDetails];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppOwnerDetails]
GO

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
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppOwnerDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmEsmtAppOwnerDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppOwnerDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  