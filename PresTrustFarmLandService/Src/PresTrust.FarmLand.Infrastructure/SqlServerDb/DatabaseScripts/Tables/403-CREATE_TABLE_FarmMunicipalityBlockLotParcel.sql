IF OBJECT_ID('[Farm].[FarmMunicipalityBlockLotParcel]') IS NOT NULL
BEGIN
	-- Drop Constraints
		ALTER TABLE [Farm].[FarmMunicipalityBlockLotParcel] DROP CONSTRAINT IF EXISTS  [DF_InterestType_FarmMunicipalityBlockLotParcel];


END;
GO


-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmMunicipalityBlockLotParcel]
GO

-- Create Table
CREATE TABLE [Farm].[FarmMunicipalityBlockLotParcel](
[Id] [int] IDENTITY(1,1) NOT NULL,
	[MunicipalityId] [varchar](4) NOT NULL,
	[FarmListID] [int] NOT NULL,
	[PropertyClassCode]  [varchar](50) NULL,
	[DeedBook] [varchar](50) NULL,			
	[DeedPage] [varchar](50) NULL,			
	[DeedDate] [date] NULL,					 
	[Block] [varchar](50) NULL,
	[Lot] [varchar](50) NULL,
	[QualificationCode] [varchar](50) NULL,
	[Section] [varchar](128) NULL,
	[Partial] [bit] NULL,
	[Acres] [numeric](10, 3) NULL,
	[AcresToBeAcquired] [numeric](10, 3) NULL,
	[ExceptionAreaAcres] [numeric](10, 3) NULL,
	[ExceptionArea] [bit] NULL,
	[Notes] [varchar](max) NULL,
	[PamsPin] [varchar](100) NULL,
	[IsValidFeatureId] [bit] NULL,
	[IsValidPamsPin] [bit] NULL,
	[InterestType] [varchar](100) NULL,
	[EasementId] [varchar](100) NULL,
	[ChangeType] [varchar](100) NULL,
	[ChangeDate] [datetime] NULL,
	[ReasonForChange] [varchar](max) NULL,
	[IsActive] [bit] NULL,
	[Status]	                            [varchar](50)                       NULL,
	[IsWarning]  [bit] NULL,
	[CreatedByProgramUser]  [bit] NULL,
	[LastUpdatedOn] [datetime] NULL,
	[LastUpdatedBy] [varchar](256) NULL,
CONSTRAINT [PK_FarmMunicipalityBlockLotParcel_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY]

GO

ALTER TABLE [Farm].[FarmMunicipalityBlockLotParcel] WITH NOCHECK ADD  CONSTRAINT [DF_InterestType_FarmMunicipalityBlockLotParcel]  DEFAULT('Easement') FOR [InterestType]
GO  

