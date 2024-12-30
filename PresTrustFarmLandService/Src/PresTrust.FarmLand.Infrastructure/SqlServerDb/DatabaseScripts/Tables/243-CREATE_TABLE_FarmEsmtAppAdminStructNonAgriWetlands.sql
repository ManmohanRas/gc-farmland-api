IF OBJECT_ID('[Farm].[FarmEsmtAppAdminStructNonAgriWetlands]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminStructNonAgriWetlands];
		
	ALTER TABLE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminStructNonAgriWetlands];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminStructNonAgriWetlands]
GO

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
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminStructNonAgriWetlands]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmEsmtAppAdminStructNonAgriWetlands] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminStructNonAgriWetlands]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  

