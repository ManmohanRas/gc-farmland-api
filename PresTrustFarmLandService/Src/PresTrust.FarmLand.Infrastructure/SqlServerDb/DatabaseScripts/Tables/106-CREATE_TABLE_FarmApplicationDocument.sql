IF OBJECT_ID('[Farm].[FarmApplicationDocument]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationDocument];
		
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [FK_DocumentTypeId_FarmApplicationDocument];

	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_ShowCommittee_FarmApplicationDocument];
	
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_UseInReport_FarmApplicationDocument];
	
	ALTER TABLE [Farm].[FarmApplicationDocument] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationDocument];


END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationDocument]
GO

-- Create Table
CREATE TABLE [Farm].[FarmApplicationDocument](
	[Id]						[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]				[integer]						NOT NULL,
	[DocumentTypeId]			[smallint]						NOT NULL,
	[FileName]					[varchar](128)					NOT NULL,
	[Title]						[varchar](128)					NOT NULL,
	[Description]				[varchar](256)					NULL,
	[ShowCommittee]				[bit]							NOT NULL,
	[UseInReport]				[bit]							NOT NULL,
	[HardCopy]					[bit]							NOT NULL,
	[Approved]					[bit]							NOT NULL,
	[ReviewComment]				[varchar](2000)					NULL,
	[LastUpdatedBy]				[varchar](128)					NULL,
	[LastUpdatedOn]				[datetime]						NOT NULL,

CONSTRAINT [PK_FarmApplicationDocument_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmApplicationDocument] ADD CONSTRAINT FK_DocumentTypeId_FarmApplicationDocument  FOREIGN KEY (DocumentTypeId) REFERENCES [Farm].FarmApplicationDocumentType(Id);
GO 

ALTER TABLE [Farm].[FarmApplicationDocument] ADD CONSTRAINT FK_ApplicationId_FarmApplicationDocument  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO  

ALTER TABLE [Farm].[FarmApplicationDocument] WITH NOCHECK ADD  CONSTRAINT [DF_ShowCommittee_FarmApplicationDocument]  DEFAULT (0) FOR [ShowCommittee]
GO  

ALTER TABLE [Farm].[FarmApplicationDocument] WITH NOCHECK ADD  CONSTRAINT [DF_UseInReport_FarmApplicationDocument]  DEFAULT (0) FOR [UseInReport]
GO  

ALTER TABLE [Farm].[FarmApplicationDocument] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationDocument]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  


 