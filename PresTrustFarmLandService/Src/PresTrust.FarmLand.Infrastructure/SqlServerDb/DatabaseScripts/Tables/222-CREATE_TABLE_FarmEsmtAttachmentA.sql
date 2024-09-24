IF OBJECT_ID('[Farm].[FarmEsmtAttachmentA]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtAttachmentA] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAttachmentA];

	ALTER TABLE [Farm].[FarmEsmtAttachmentA] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAttachmentA];

    ALTER TABLE [Farm].[FarmEsmtAttachmentA] DROP CONSTRAINT IF EXISTS  [DF_IsOfferPriceIndicated_FarmEsmtAttachmentA];


END;
GO

--DROP TABLE

DROP TABLE IF EXISTS [Farm].[FarmEsmtAttachmentA]
GO

--CREATE TABLE

CREATE TABLE [Farm].[FarmEsmtAttachmentA](
   [Id]							   [integer] 		       IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                 [integer]                              NOT NULL,
   [IsOfferPriceIndicated]	       [bit]                                  NOT NULL,
   [OfferPriceOpinion]		       [varchar](50)                              NULL, 
   [AveragePerAcre]	     	       [integer]		                          NULL, 
   [OfferPriceComments] 		   [varchar](4000)		                      NULL, 
   [LastUpdatedBy]				   [varchar](128)		                      NULL, 
   [LastUpdatedOn]				   [datetime]			                  NOT NULL
   CONSTRAINT [PK_FarmEsmtAttachmentA_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Farm].[FarmEsmtAttachmentA] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAttachmentA] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO

ALTER TABLE [Farm].[FarmEsmtAttachmentA] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAttachmentA]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO

ALTER TABLE [Farm].[FarmEsmtAttachmentA] WITH NOCHECK ADD  CONSTRAINT [DF_IsOfferPriceIndicated_FarmEsmtAttachmentA]  DEFAULT (0) FOR [IsOfferPriceIndicated]
GO 
