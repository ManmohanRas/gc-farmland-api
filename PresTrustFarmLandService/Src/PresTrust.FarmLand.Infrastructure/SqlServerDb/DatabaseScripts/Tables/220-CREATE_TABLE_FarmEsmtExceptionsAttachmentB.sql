If OBJECT_ID('Farm].[FarmEsmtExceptionsAttachmentB]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtExceptionsAttachmentB] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtExceptionsAttachmentB];

	ALTER TABLE [Farm].[FarmEsmtExceptionsAttachmentB] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtExceptionsAttachmentB];
END;
GO

--DROP TABLE

DROP TABLE IF EXISTS [Farm].[FarmEsmtExceptionsAttachmentB]
GO

--CREATE TABLE

CREATE TABLE [Farm].[FarmEsmtExceptionsAttachmentB](
   [Id]                           [integer]      IDENTITY(1,1)     NOT NULL,
   [ApplicationId]                [integer]                        NOT NULL,
   [LocationOfException]          [varchar](256)                       NULL,
   [Block]                        [integer]                            NULL,
   [Lot]                          [integer]                            NULL,
   [ExceptionSize]                [decimal](18,2)                      NULL,
   [ReasonForException]           [varchar](256)                       NULL,
   [IsExceptionSoldFromPreserved] [bit]                                NULL,
   [IsRestrictExceptionToResiUnit][bit]                                NULL,
   [IsExceptionInNonAgriUse]      [bit]                                NULL,
   [IsResiExceptionArea]          [bit]                                NULL,
   [IsNonResiExceptionArea]       [bit]                                NULL,
   [NonAgriExceptionArea]         [varchar](256)                       NULL,
   [SingleFamilyResidence]        [integer]                            NULL,
   [ResiHomePermFoundation]       [integer]                            NULL,
   [ResiDuplex]                   [integer]                            NULL,
   [ResiHomeWithoutFoundation]    [integer]                            NULL,
   [ResidenceGarage]              [integer]                            NULL,
   [ResiDormitory]                [integer]                            NULL,
   [ResiAttachedTo]               [integer]                            NULL,
   [ResiGarriageHouse]            [integer]                            NULL,
   [NonResidentialBarn]           [integer]                            NULL,
   [NonResidentialShed]           [integer]                            NULL,
   [NonResidentialGarage]         [integer]                            NULL,
   [NonResidentialSilo]           [integer]                            NULL,
   [NonResidentialStable]         [integer]                            NULL,
   [LastUpdatedBy]				  [varchar](128)					   NULL, 
   [LastUpdatedOn]				  [datetime]					    NOT NULL

Constraint [PK_FarmEsmtExceptionsAttachmentB_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Farm].[FarmEsmtExceptionsAttachmentB] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtExceptionsAttachmentB] FOREIGN KEY (ApplicationId) REFERENCES [Farm].[FarmApplication](Id);
GO

ALTER TABLE [Farm].[FarmEsmtExceptionsAttachmentB] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtExceptionsAttachmentB]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  

  

