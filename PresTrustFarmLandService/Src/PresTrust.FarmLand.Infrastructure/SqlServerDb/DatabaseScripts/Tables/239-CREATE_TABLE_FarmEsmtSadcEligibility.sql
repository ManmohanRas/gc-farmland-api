IF OBJECT_ID('[Farm].[FarmEsmtSadcEligibility]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtSadcEligibility] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtSadcEligibility ];
		
	ALTER TABLE [Farm].[FarmEsmtSadcEligibility] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcEligibility ];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtSadcEligibility]
GO

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
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtSadcEligibility] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtSadcEligibility]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmEsmtSadcEligibility] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtSadcEligibility]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  