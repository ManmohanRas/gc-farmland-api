IF OBJECT_ID('[Farm].[FarmEsmtAppAdminCostDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminCostDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAppAdminCostDetails];
		
	ALTER TABLE [Farm].[FarmEsmtAppAdminCostDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminCostDetails];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminCostDetails]
GO

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppAdminCostDetails](
[Id]                                  [integer] IDENTITY(1,1)   NOT NULL,
[ApplicationId]                       [integer]                 NOT NULL,
[GrossAcers]                          [decimal](10,2)               NULL,
[SADCBeforeValueAC]                   [decimal](10,2)               NULL,
[SADCAfterValueAC]                    [decimal](10,2)               NULL,
[OfferToSADC]                         [decimal](10,2)               NULL,
[SADCCostShareAC]                     [decimal](10,2)               NULL,
[SADCCostShareTotal]                  [decimal](10,2)               NULL,
[SADCCostShareAcqTotal]               [decimal](10,2)               NULL,
[NoteOfBreakdown]                     [varchar](4000)               NULL,  
[SADCCostShareofOfferPct]             [decimal](10,2)               NULL,
[SADCCertifiedEasementValuePerAcre]   [decimal](10,2)               NULL,
[SADCPctofCertifiedEaseValue]         [decimal](10,4)               NULL,
[NetAcres]                            [decimal](10,2)               NULL,
[MCOffertoLandowner]                  [decimal](10,2)               NULL,
[MCCertifiedBeforeValue]              [decimal](10,2)               NULL,
[MCCostSharePerAcre]                  [decimal](10,2)               NULL,
[OtherSource]                         [varchar](128)                NULL,
[OtherCostShare]                      [decimal](10,2)               NULL,
[MCCostSharePct]                      [decimal](10,2)               NULL,
[MCCostShareTotal]                    [decimal](10,2)               NULL,
[TotalCost]                           [decimal](10,2)               NULL,
[TotalCostPerAcre]                    [decimal](10,2)               NULL,
[LastUpdatedBy]					      [varchar](128)			    NULL, 
[LastUpdatedOn]					      [dateTime]				NOT NULL,
CONSTRAINT [PK_FarmEsmtAppAdminCostDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminCostDetails] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminCostDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmEsmtAppAdminCostDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminCostDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  