
-- Drop Constraints
ALTER TABLE [Farm].[FarmApplicationStatus] DROP CONSTRAINT IF EXISTS  [FK_ApplicationTypeId_FarmApplicationStatus] 
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmApplicationStatus]
GO

-- Create Table
CREATE TABLE [Farm].[FarmApplicationStatus](
	[Id]				[smallint] 			NOT NULL,
	[Name]				[varchar](128)		NOT NULL,
	[ApplicationTypeId] [smallint]	        NOT NULL,
	
CONSTRAINT [PK_FarmApplicationStatus_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

-- Create Constraints
ALTER TABLE [Farm].[FarmApplicationStatus] ADD CONSTRAINT [FK_ApplicationTypeId_FarmApplicationStatus]  FOREIGN KEY (ApplicationTypeId) REFERENCES [Farm].FarmApplicationType(Id);
GO
