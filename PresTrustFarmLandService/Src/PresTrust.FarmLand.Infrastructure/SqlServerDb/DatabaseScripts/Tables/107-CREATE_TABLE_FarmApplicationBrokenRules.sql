IF OBJECT_ID('[Farm].FarmApplicationBrokenRules') IS NOT NULL
BEGIN
	-- Drop Constraint
	ALTER TABLE [Farm].FarmApplicationBrokenRules DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmApplicationBrokenRules];

	ALTER TABLE [Farm].FarmApplicationBrokenRules DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationBrokenRules];

	DROP INDEX IF EXISTS [IX_FarmApplicationBrokenRules_ApplicationId_SectionId] ON [Farm].[FarmApplicationBrokenRules];
END
GO
 
 
-- Drop Table
DROP TABLE IF EXISTS [Farm].FarmApplicationBrokenRules;
GO
 
-- Create Table
CREATE TABLE [Farm].FarmApplicationBrokenRules(
	[ApplicationId]		[integer]						NOT NULL,
	[SectionId]			[integer]						NOT NULL,
	[Message]			[varchar](1024)					NOT NULL,
	[IsApplicantFlow]	[bit]							NOT NULL,
	[LastUpdatedOn]		[datetime]						NOT NULL,
) ON [PRIMARY]
 
GO
 
-- Create a clustered index  
CREATE CLUSTERED INDEX IX_FarmApplicationBrokenRules_ApplicationId_SectionId ON [Farm].FarmApplicationBrokenRules(ApplicationId, SectionId); 
GO
-- Create Constraint
ALTER TABLE [Farm].FarmApplicationBrokenRules ADD CONSTRAINT FK_ApplicationId_FarmApplicationBrokenRules  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO  
 
ALTER TABLE [Farm].FarmApplicationBrokenRules WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationBrokenRules]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO