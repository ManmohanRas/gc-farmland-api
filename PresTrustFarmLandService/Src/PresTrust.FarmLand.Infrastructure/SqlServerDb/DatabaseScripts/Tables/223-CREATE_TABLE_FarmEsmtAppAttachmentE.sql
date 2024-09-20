IF OBJECT_ID('[FARM].[FarmEsmtAppAttachmentE]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtAppAttachmentE] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAppAttachmentE];

	ALTER TABLE [Farm].[FarmEsmtAppAttachmentE] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAppAttachmentE];

END;
GO

--DROP TABLE

DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAttachmentE]
GO

--CREATE TABLE

CREATE TABLE [Farm].[FarmEsmtAppAttachmentE](

   [Id]													   [integer] 		IDENTITY(1,1)      NOT NULL,
   [ApplicationId]                                         [integer]                           NOT NULL,
   [TypeOfDevelopment]                                     [varchar](128)                          NULL,
   [PreliminaryApprovalDate]                               [dateTime]                              NULL,   
   [FinalApprovalDate]                                     [dateTime]                              NULL,   
   [ScaleofSubdivision]                                    [varchar](50)                           NULL,   
   [OtherPertinentInformation]                             [varchar](4000)                         NULL, 
   [IsOpenEnrollment]                                      [bit]                                   NULL,   
   [IsPropertyOutlined]                                    [bit]                                   NULL,   
   [IsAllExpAreasIdentified]                               [bit]                                   NULL,   
   [IsAllNonAgriEquiUsesDetailed]                          [bit]                                   NULL,   
   [IsCopyOfDeed]                                          [bit]                                   NULL,   
   [IsSignOfAllPropOwnersListed]                           [bit]                                   NULL,   
   [IsFarmLandAssReportCopy]                               [bit]                                   NULL,   
   [LastUpdatedBy]										   [varchar](128)		                   NULL, 
   [LastUpdatedOn]				                           [datetime]			                NOT NULL
   CONSTRAINT [PK_FarmEsmtAppAttachmentE_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Farm].[FarmEsmtAppAttachmentE] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAttachmentE] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO

ALTER TABLE [Farm].[FarmEsmtAppAttachmentE] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAttachmentE]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO