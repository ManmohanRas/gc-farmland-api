IF OBJECT_ID('FARM].[FarmEsmtExistNonAgriUses]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtExistNonAgriUses] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtExistNonAgriUses];

	ALTER TABLE [Farm].[FarmEsmtExistNonAgriUses] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtExistNonAgriUses];

END;
GO

--DROP TABLE

DROP TABLE IF EXISTS [Farm].[FarmEsmtExistNonAgriUses]
GO

--CREATE TABLE

CREATE TABLE [Farm].[FarmEsmtExistNonAgriUses](

   [Id]							   [integer] 		IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                  [integer]                       NOT NULL,
   [IsSubdivisionApproval]         [bit]                           NOT NULL,
   [InfoAboutPremises]             [varchar](4000)                     NULL,   
   [LastUpdatedBy]				   [varchar](128)		               NULL, 
   [LastUpdatedOn]				   [datetime]			           NOT NULL
   CONSTRAINT [PK_FarmEsmtExistNonAgriUses_ID] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Farm].[FarmEsmtExistNonAgriUses] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtExistNonAgriUses] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO

ALTER TABLE [Farm].[FarmEsmtExistNonAgriUses] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtExistNonAgriUses]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO
