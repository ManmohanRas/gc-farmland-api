 
IF OBJECT_ID('[Farm].[FarmApplicationStatusLog]') IS NOT NULL
BEGIN
	ALTER TABLE [Farm].[FarmApplicationStatusLog] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmApplicationStatusLog];

END;
GO
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationStatusLog]
GO

-- Create Table
CREATE TABLE [Farm].[FarmApplicationStatusLog](
	[ApplicationId]							[integer]						NOT NULL,
	[ApplicationTypeId]						[smallint]						NOT NULL,
	[StatusId]								[integer]						NOT NULL,
	[StatusDate]							[datetime]						NULL,
	[Notes]									[varchar](max)					NOT NULL,
	[LastUpdatedBy]							[varchar](128)					NULL,
	[LastUpdatedOn]							[datetime]						NOT NULL)
GO

ALTER TABLE [Farm].[FarmApplicationStatusLog] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmApplicationStatusLog]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  
