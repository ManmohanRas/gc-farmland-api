IF OBJECT_ID('[Farm].[FarmAgriculturalEnterpriseChecklist]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmAgriculturalEnterpriseChecklist];

	ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] DROP CONSTRAINT IF EXISTS  [FK_ActivitySubTypeId_FarmAgriculturalEnterpriseChecklist];

	ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmAgriculturalEnterpriseChecklist];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmAgriculturalEnterpriseChecklist]
GO


CREATE TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] (
    [Id]                 [integer] IDENTITY(1,1)	NOT NULL,
    [ApplicationId]	     [integer]	                NOT NULL,
	[ActivitySubTypeId]  [integer]                  NOT NULL,
	[Title]              [varchar](256)             NOT NULL,
	[SicCode]            [varchar](128)             NOT NULL,
    [IsPrimary]          [bit]                          NULL,
    [IsSecondary]        [bit]                          NULL,
	[LastUpdatedBy]	     [varchar](128)	                NULL,
    [LastUpdatedOn]		 [DateTime]			            NULL,
CONSTRAINT [PK_FarmAgriculturalEnterpriseChecklist_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] ADD CONSTRAINT [FK_ApplicationId_FarmAgriculturalEnterpriseChecklist]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] ADD CONSTRAINT [FK_ActivitySubTypeId_FarmAgriculturalEnterpriseChecklist] FOREIGN KEY (ActivitySubTypeId) REFERENCES [Farm].FarmEsmtAgricultureProdSourceType(Id);
GO
 
ALTER TABLE [Farm].[FarmAgriculturalEnterpriseChecklist] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmAgriculturalEnterpriseChecklist]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO 
