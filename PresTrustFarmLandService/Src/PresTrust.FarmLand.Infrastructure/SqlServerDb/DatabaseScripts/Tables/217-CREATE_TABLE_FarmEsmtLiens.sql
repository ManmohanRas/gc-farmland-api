IF OBJECT_ID('[Farm].[FarmEsmtLiens]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtLiens] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtLiens];
		
	ALTER TABLE [Farm].[FarmEsmtLiens] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtLiens];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtLiens]
GO

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
	[AvvessEasement]				[bit]								NULL,
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
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtLiens] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtLiens]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmEsmtLiens] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtLiens]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  