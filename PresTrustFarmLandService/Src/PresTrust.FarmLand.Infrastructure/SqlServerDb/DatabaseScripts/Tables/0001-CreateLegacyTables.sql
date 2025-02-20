-- Create FarmTermApplicationLegacy
DROP TABLE IF EXISTS [Farm].[FarmTermApplicationLegacy]
GO

CREATE TABLE [Farm].[FarmTermApplicationLegacy]
(
	[LegacyApplicationId]               [integer]              NOT NULL,  
    [LegacyApplicationTitle]            [varchar](128)         NOT NULL,
    [NewFarmListId]                     [integer]              NOT NULL,                                                                                    
    [LegacyApplicationStatus]           [varchar](128)         NOT NULL,                                                                        
    [LegacyAgencyId]                    [integer]              NOT NULL,                                                                                                                                     
    [FarmApplicationId]                 [integer]              NULL,
CONSTRAINT [PK_FarmTermApplicationLegacy_Id] PRIMARY KEY CLUSTERED
(
	[LegacyApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create FarmListLegacy
DROP TABLE IF EXISTS [Farm].[FarmListLegacy]
GO

CREATE TABLE [Farm].[FarmListLegacy] (
			LegacyFarmListId    INT				NOT NULL,
			LegacyFarmName      VARCHAR(128)    NULL,
			NewFarmListId		INT             NULL,
CONSTRAINT [PK_LegacyFarmList_Id] PRIMARY KEY CLUSTERED
(
	[LegacyFarmListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO;

