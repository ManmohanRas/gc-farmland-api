IF OBJECT_ID('[Farm].[FarmEsmtAgriculturalAndProduction]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAgriculturalAndProduction] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAgriculturalAndProduction];
		
	ALTER TABLE [Farm].[FarmEsmtAgriculturalAndProduction] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAgriculturalAndProduction];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAgriculturalAndProduction]
GO

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
		) ON [PRIMARY]

		GO

		-- Create Constraint
		ALTER TABLE [Farm].[FarmEsmtAgriculturalAndProduction] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAgriculturalAndProduction]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
		GO 

		ALTER TABLE [Farm].[FarmEsmtAgriculturalAndProduction] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAgriculturalAndProduction]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
		GO