-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationType]
GO

-- Create Table
CREATE TABLE [Farm].[FarmApplicationType](
	[Id]				[smallint] 			NOT NULL,
	[Title]				[varchar](128)		NOT NULL, 
CONSTRAINT [PK_FarmApplicationType_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
