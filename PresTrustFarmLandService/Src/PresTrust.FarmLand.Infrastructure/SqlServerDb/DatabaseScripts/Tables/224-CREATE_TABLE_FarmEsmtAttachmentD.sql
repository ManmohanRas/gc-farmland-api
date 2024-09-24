IF OBJECT_ID('[Farm].[FarmEsmtAttachmentD]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAttachmentD] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmEsmtAttachmentD];
	
	ALTER TABLE [Farm].[FarmEsmtAttachmentD] DROP CONSTRAINT IF EXISTS  [FK_EquineActivityTypeId_FarmEsmtAttachmentD];

	ALTER TABLE [Farm].[FarmEsmtAttachmentD] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAttachmentD];
END;
GO
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAttachmentD]
GO

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAttachmentD](
	[Id]									[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]							[integer]						NOT NULL,
	[EquineActivityTypeId]                  [integer]							NULL,
	[Counts]								[decimal](18,2)						NULL,
	[Number]								[integer]							NULL,
	[NumberOfHorses]						[integer]							NULL,
	[NumberOfHorsesActivity]				[integer]							NULL,
	[NumberOfStalls]						[integer]							NULL,
	[RunInSheds]							[integer]							NULL,
	[IndoorRidingArena]						[integer]							NULL,
	[OutdoorRidingArena]					[integer]							NULL,
	[LastUpdatedBy]							[varchar](128)						NULL,
	[LastUpdatedOn]							[datetime]						NOT NULL,
		
CONSTRAINT [PK_FarmEsmtAttachmentD_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraints
ALTER TABLE [Farm].[FarmEsmtAttachmentD] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAttachmentD]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO

ALTER TABLE [Farm].[FarmEsmtAttachmentD] ADD CONSTRAINT [FK_EquineActivityTypeId_FarmEsmtAttachmentD]  FOREIGN KEY (EquineActivityTypeId) REFERENCES [Farm].FarmEsmtAttachmentDActivityType(Id);
GO

ALTER TABLE [Farm].[FarmEsmtAttachmentD] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAttachmentD]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  
