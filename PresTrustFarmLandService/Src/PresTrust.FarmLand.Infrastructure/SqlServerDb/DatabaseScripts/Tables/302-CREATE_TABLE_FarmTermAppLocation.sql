IF OBJECT_ID('[Farm].[FarmTermAppLocation]') IS NOT NULL
BEGIN
	 --Drop Constraints
	 ALTER TABLE [Farm].[FarmTermAppLocation] DROP CONSTRAINT IF EXISTS  [FK_ApplicationId_FarmTermAppLocation];
		
	ALTER TABLE [Farm].[FarmTermAppLocation] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmTermAppLocation];
END;
GO
  
-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmTermAppLocation]
GO

-- Create Table
CREATE TABLE [Farm].[FarmTermAppLocation](
	[Id]									[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]							[integer]						NOT NULL,
	[ParcelId]								[integer] 						NOT NULL,
	[PamsPin]					            [varchar](76)				    NOT NULL,
	[FarmListID]							[int]							NOT NULL,
	[MunicipalityId]						[varchar](4)                    NOT NULL,
	[Block]									[varchar](50)						NULL,
    [Lot]									[varchar](50)						NULL,
    [QualificationCode]						[varchar](50)						NULL,
	[DeedBook]								[varchar](50)                       NULL,			
    [DeedPage]                              [varchar](50)                       NULL,
	[IsWarning]								[bit]								NULL,
	[CreatedByProgramUser]					[bit]								NULL,
	[LastUpdatedBy]							[varchar](128)					NOT NULL,
	[LastUpdatedOn]							[datetime]						NOT NULL,
CONSTRAINT [PK_FarmTermAppLocation_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint
ALTER TABLE [Farm].[FarmTermAppLocation] ADD CONSTRAINT [FK_ApplicationId_FarmTermAppLocation]  FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO 

ALTER TABLE [Farm].[FarmTermAppLocation] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmTermAppLocation]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  

