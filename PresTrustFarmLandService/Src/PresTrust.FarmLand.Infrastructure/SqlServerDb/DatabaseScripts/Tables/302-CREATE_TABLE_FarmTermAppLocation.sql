IF OBJECT_ID('[Farm].[FarmTermAppLocation]') IS NOT NULL
BEGIN
	 --Drop Constraints
	 ALTER TABLE [Farm].[FarmTermAppLocation] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppLocation];
		

	ALTER TABLE [Farm].[FarmTermAppLocation] DROP CONSTRAINT IF EXISTS  [DF_IsChecked_FarmTermAppLocation];
END;
GO
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppLocation]
GO

-- Create Table
CREATE TABLE [Farm].[FarmTermAppLocation](
	[ApplicationId]							[integer]						NOT NULL,
	[ParcelId]								[integer] 						NOT NULL,
	[FarmListID]							[int]							NOT NULL,
	[PamsPin]					            [varchar](76)				    NOT NULL,
	[IsChecked]								[bit]                           NOT NULL
) 

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppLocation] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppLocation]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO   

ALTER TABLE [Farm].[FarmTermAppLocation] WITH NOCHECK ADD  CONSTRAINT [DF_IsChecked_FarmTermAppLocation]  DEFAULT (0) FOR [IsChecked]
GO

