IF OBJECT_ID('[Farm].[FarmEsmtAppExceptions]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppExceptions] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppExceptions];
		
	ALTER TABLE [Farm].[FarmEsmtAppExceptions] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppExceptions];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppExceptions]
GO

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppExceptions](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[ExpectedTaxLots]				[bit]								NULL,
	[ExceptionNonServable]			[varchar](128)						NULL,
	[ExceptionTotalNonServable]		[varchar](128)						NULL,
	[ExceptionServable]				[varchar](128)						NULL,
	[ExceptionTotalServable]		[varchar](128)						NULL,
	[Acres]						    [Decimal](18,2)						NULL,
	[LastUpdatedBy]					[varchar](128)						NULL, 
	[LastUpdatedOn]					[datetime]						NOT NULL, 
CONSTRAINT [PK_FarmEsmtAppExceptions_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppExceptions] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppExceptions]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmEsmtAppExceptions] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppExceptions]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  

