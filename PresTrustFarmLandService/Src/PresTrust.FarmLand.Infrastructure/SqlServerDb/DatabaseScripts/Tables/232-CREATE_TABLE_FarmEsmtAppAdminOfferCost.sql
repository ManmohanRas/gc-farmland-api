IF OBJECT_ID('[FARM].[FarmEsmtAppAdminOfferCost]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtAppAdminOfferCost] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAppAdminOfferCost];

	ALTER TABLE [Farm].[FarmEsmtAppAdminOfferCost] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAdminOfferCost];

END;
GO

--DROP TABLE

DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminOfferCost]
GO

--CREATE TABLE

CREATE TABLE [Farm].[FarmEsmtAppAdminOfferCost](

   [Id]													   [integer] 		IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                                         [integer]                       NOT NULL,
   [CadbLandOwnerOffer]                                    [decimal](10,2)                     NULL,
   [IsOfferAccepted]                                       [bit]                               NULL,   
   [TotalCostPerAcre]                                      [decimal](10,2)                     NULL,   
   [TotalCost]                                             [decimal](10,2)                     NULL,   
   [MCCostSharePct]                                        [decimal](10,2)                     NULL,
   [McCountyCostShareTotal]                                [decimal](10,2)                     NULL, 
   [SADCCostSharePct]                                      [decimal](10,2)                     NULL,   
   [SADCCostShareTotal]                                    [decimal](10,2)                     NULL,
   [OtherCostShareTotal]                                   [decimal](10,2)                     NULL,   
   [OtherSource]                                           [decimal](10,2)                     NULL,   
   [CostNote]                                              [varchar](4000)                     NULL,   
   [LastUpdatedBy]										   [varchar](128)		               NULL, 
   [LastUpdatedOn]										   [datetime]			           NOT NULL
   CONSTRAINT [PK_FarmEsmtAppAdminOfferCost_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Farm].[FarmEsmtAppAdminOfferCost] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminOfferCost] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO

ALTER TABLE [Farm].[FarmEsmtAppAdminOfferCost] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminOfferCost]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO