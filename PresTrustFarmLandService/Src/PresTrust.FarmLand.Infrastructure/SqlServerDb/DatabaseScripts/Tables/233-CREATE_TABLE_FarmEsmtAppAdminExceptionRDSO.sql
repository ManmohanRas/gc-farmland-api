use prestrust_dev
IF OBJECT_ID('[Farm].[FarmEsmtAppAdminExceptionRDSO]') IS NOT NULL
BEGIN
	----Drop Constraints
	ALTER TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAppAdminExceptionRDSO];
	ALTER TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] DROP CONSTRAINT IF EXISTS [DF_LastUpdatedOn_FarmEsmtAppAdminExceptionRDSO];
END;
GO

-- Drop Table
DROP TABLE IF EXISTS [Farm].[FarmEsmtAppAdminExceptionRDSO]
GO

-- Create Table
CREATE TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] (
	[Id]                       [integer]           IDENTITY(1,1)      NOT NULL,
	[ApplicationId]            [integer]                              NOT NULL,
	[NumberofExceps]           [integer]                                  NULL,
	[Excep1Acres]              [integer]                                  NULL,
	[X1Purpose]                [varchar](128)                             NULL,
	[X1Severable]              [bit]                                      NULL,
	[X1IsSubdividable]         [bit]                                      NULL,
	[X1IsRTF]                  [bit]                                      NULL,
	[Excep2Acres]              [integer]                                  NULL,
	[X2Purpose]                [varchar](128)                             NULL,
	[X2IsSeverable]            [bit]                                      NULL,
	[X2IsSubdividable]         [bit] 									  NULL,
	[X2IsRTF]                  [bit]									  NULL,
	[Excep3Acres]              [integer] 				                  NULL,
	[X3Purpose]                [varchar](128)                             NULL,
	[X3IsSeverable]            [bit] 				                      NULL,
	[X3IsSubdividable]         [bit]   				                      NULL,
	[X3IsRTF]                  [bit]                                      NULL,
	[RDSOsNum]		           [integer]                                  NULL,
	[RDSOExplan]               [varchar](128)                             NULL,
	[IsRDSOExercised]          [bit]                                      NULL,
	[LastUpdatedBy]            [varchar](128) 			                  NULL,
	[LastUpdatedOn]			   [datetime]                                 NOT NULL,
   CONSTRAINT [PK_FarmEsmtAppAdminExceptionRDSO_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

--- Create constraint
ALTER TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAppAdminExceptionRDSO] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO

ALTER TABLE [Farm].[FarmEsmtAppAdminExceptionRDSO] WITH NOCHECK ADD CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAppAdminExceptionRDSO] DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO
