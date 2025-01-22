IF OBJECT_ID('[Farm].[FarmAppLocationDetails]') IS NOT NULL
BEGIN
	 --Drop Constraints
	 ALTER TABLE [Farm].[FarmAppLocationDetails] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmAppLocationDetails];
		

	ALTER TABLE [Farm].[FarmAppLocationDetails] DROP CONSTRAINT IF EXISTS  [DF_IsChecked_FarmAppLocationDetails];
END;
GO
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmAppLocationDetails]
GO

-- Create Table
CREATE TABLE [Farm].[FarmAppLocationDetails](
	[ApplicationId]							[integer]						NOT NULL,
	[ParcelId]								[integer] 						NOT NULL,
	[FarmListID]							[int]							NOT NULL,
	[PamsPin]					            [varchar](76)				    NOT NULL,
	[IsChecked]								[bit]                           NOT NULL
) 

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmAppLocationDetails] ADD CONSTRAINT [FK_ApplicationId_FarmAppLocationDetails]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO   

ALTER TABLE [Farm].[FarmAppLocationDetails] WITH NOCHECK ADD  CONSTRAINT [DF_IsChecked_FarmAppLocationDetails]  DEFAULT (0) FOR [IsChecked]
GO

