IF OBJECT_ID('[FARM].[FarmEsmtAppAdminSADC]') IS NOT NULL
BEGIN 
   --- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminSADC] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAppAdminSADC];
	ALTER TABLE [Farm].[FarmEsmtAppAdminSADC] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_FarmEsmtAppAdminSADC];
END;
GO

--Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminSADC]
GO

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
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminSADC] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminSADC] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO

ALTER TABLE [Farm].[FarmEsmtAppAdminSADC] WITH NOCHECK ADD CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminSADC] DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO