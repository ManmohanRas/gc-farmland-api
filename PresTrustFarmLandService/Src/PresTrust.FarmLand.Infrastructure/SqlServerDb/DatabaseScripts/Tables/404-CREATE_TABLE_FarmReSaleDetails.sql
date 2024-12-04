IF OBJECT_ID('[Farm].[FarmReSaleDetails]') IS NOT NULL
BEGIN
	-- Drop Constraints
	ALTER TABLE [Farm].[FarmReSaleDetails] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmReSaleDetails];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmReSaleDetails]
GO

-- Create Table
CREATE TABLE [Farm].[FarmReSaleDetails](
[Id]                                  [integer] IDENTITY(1,1)   NOT NULL,
[FarmNumber]                          [varchar](5)                  NULL,
[ReSellDate]                          [DateTime]                    NULL,               
[ReSellPriceTotal]                    [decimal](10,2)               NULL,
[ReSellPricePerAcre]                  [decimal](10,2)               NULL,
[ReSellNotes]                         [varchar](4000)               NULL,
[CurrentDeedBook]                     [varchar](50)                 NULL,
[CurrentDeedPage]                     [varchar](50)                 NULL, 
[CurrentDeedFiled]                    [DateTime]                    NULL,
[InterestedinSelling]                 [bit]                         NULL,                
[LastUpdatedBy]					      [varchar](128)			    NULL, 
[LastUpdatedOn]					      [DateTime]				NOT NULL,
CONSTRAINT [PK_FarmReSaleDetails_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraint 
ALTER TABLE [Farm].[FarmReSaleDetails] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmReSaleDetails]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO  