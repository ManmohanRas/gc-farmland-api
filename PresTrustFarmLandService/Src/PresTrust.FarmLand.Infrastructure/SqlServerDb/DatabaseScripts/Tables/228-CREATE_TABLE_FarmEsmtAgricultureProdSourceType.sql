-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAgricultureProdSourceType];
GO

-- Create Table
Create Table [Farm].[FarmEsmtAgricultureProdSourceType](
[Id]                                    [integer]                              NOT NULL,
[SicCode]								[varchar](80)						   NOT NULL,
[Title]                                 [varchar](216)			               NOT NULL,
[SortOrder]                             [smallint]                             NOT NULL,
[ActivityTypeId]						[integer]								   NULL
CONSTRAINT [PK_FarmEsmtAgricultureProdSourceType_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY]

GO