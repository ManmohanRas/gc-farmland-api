IF OBJECT_ID('[Farm].[FarmTermAppDeedLocation]') IS NOT NULL
BEGIN
	 --Drop Constraints
	 ALTER TABLE [Farm].[FarmTermAppDeedLocation] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppDeedLocation];
		

	ALTER TABLE [Farm].[FarmTermAppDeedLocation] DROP CONSTRAINT IF EXISTS  [DF_IsChecked_FarmTermAppDeedLocation];
END;
GO
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppDeedLocation]
GO

-- Create Table
CREATE TABLE [Farm].[FarmTermAppDeedLocation](
	[ApplicationId]							[integer]						NOT NULL,
	[ParcelId]								[integer] 						NOT NULL,
	[DeedId]								[integer]							NULL,
	[IsChecked]								[bit]                           NOT NULL
) 

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppDeedLocation] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppDeedLocation]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO   

ALTER TABLE [Farm].[FarmTermAppDeedLocation] WITH NOCHECK ADD  CONSTRAINT [DF_IsChecked_FarmTermAppDeedLocation]  DEFAULT (0) FOR [IsChecked]
GO