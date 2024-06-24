-- Drop Constraints
IF OBJECT_ID('[Farm].[FarmApplicationDocumentType]') IS NOT NULL
BEGIN
	ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS  [FK_SectionId_FarmApplicationDocumentType]
	
	ALTER TABLE [Farm].[FarmApplicationDocumentType] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationDocumentType] 
END
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationDocumentType];
GO

-- Create Table
CREATE TABLE [Farm].[FarmAppDocumentType](
	[Id]				[smallint] 			NOT NULL,
	[Title]				[varchar](128)		NOT NULL,
	[Description]		[varchar](512)		NULL	,
	[SectionId]			[smallint]			NOT NULL,
	[ApplicationTypeId] [smallint]	        NOT NULL,
CONSTRAINT [PK_FarmApplicationDocumentType_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraints
ALTER TABLE [Farm].[FarmApplicationDocumentType] ADD CONSTRAINT [FK_SectionId_FarmApplicationDocumentType]  FOREIGN KEY (SectionId) REFERENCES [Farm].FarmApplicationSection(Id);
GO

-- Create Constraints
ALTER TABLE [Farm].[FarmApplicationDocumentType] ADD CONSTRAINT [FK_ApplicationTypeId_FarmApplicationDocumentType]  FOREIGN KEY (ApplicationTypeId) REFERENCES [Farm].FarmApplicationType(Id);
GO 
