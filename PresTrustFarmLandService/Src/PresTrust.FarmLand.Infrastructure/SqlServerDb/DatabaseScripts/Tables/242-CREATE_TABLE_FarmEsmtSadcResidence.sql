IF OBJECT_ID('[Farm].[FarmEsmtSadcResidence]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtSadcResidence] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtSadcResidence];
	ALTER TABLE [Farm].[FarmEsmtSadcResidence] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtSadcResidence];
END;
GO
 
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtSadcResidence]
GO
 
-- Create Table
CREATE TABLE [Farm].[FarmEsmtSadcResidence](
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[IsAgriculturalLabor]			[bit]						        NULL,
	[UnitsUsedForLabor]			    [varchar](4000)						NULL,
	[Occupants]			            [int]					            NULL,
	[MonthsOccupied]			    [int]				                NULL,
	[IsOccupantsWork]				[bit]						        NULL,
	[PleaseExplain]					[varchar](4000)					    NULL,
	[IsResidencesRented]		    [bit]					            NULL,
	[RDSOsReserve]				    [varchar](4000)						NULL,
    [ExcepAcres1]                   [decimal](10,2)                     NULL,
    [NonSeverable1]                 [bit]                               NULL,
    [Severable1]                    [bit]                               NULL,
    [AdditionalComment1]           [varchar](4000)                     NULL,
    [ExcepAcres2]                   [decimal](10,2)                     NULL,
    [NonSeverable2]                 [bit]                               NULL,
    [Severable2]                    [bit]                               NULL,
    [AdditionalComment2]           [varchar](4000)                     NULL,
    [EsmtOthersText]                [varchar](4000)                     NULL,
    [IsSightTriangle]               [bit]                               NULL,
	[LastUpdatedBy]					[varchar](128)						NULL,
	[LastUpdatedOn]					[datetime]							NULL,
CONSTRAINT [PK_FarmEsmtSadcResidence_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
 
GO
 
-- Create Constraint
ALTER TABLE [Farm].[FarmEsmtSadcResidence] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtSadcResidence]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO
 
ALTER TABLE [Farm].[FarmEsmtSadcResidence] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtSadcResidence]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  