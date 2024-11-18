IF OBJECT_ID('[Farm].[FarmEsmtSadcHistory]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtSadcHistory] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtSadcHistory];
		
	ALTER TABLE [Farm].[FarmEsmtSadcHistory] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcHistory];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtSadcHistory]
GO

-- Create Table
CREATE TABLE [Farm].[FarmEsmtSadcHistory](
	[Id]							[integer] 		            IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					        [integer]						NOT NULL,
	[SquareFootage]					        [decimal](10,2)					        NULL,
	[PreliminaryExpiration]					[datetime]						NULL,
	[FinalExpiration]			                [datetime]					        NULL,
	[EstateWill]			                        [bit]				                        NULL,
	[TaxWaiver]				                [bit]						        NULL,
	[NoWaiver]					        [bit]   					        NULL,
	[TrustWill]				                [bit]					                NULL,
	[TrustDocuments]			                [bit]   					        NULL,
	[LastUpdatedBy]					        [varchar](128)					        NULL,
	[LastUpdatedOn]					        [datetime]					        NULL,
CONSTRAINT [PK_FarmEsmtSadcHistory_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtSadcHistory] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtSadcHistory]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmEsmtSadcHistory] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtSadcHistory]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  

