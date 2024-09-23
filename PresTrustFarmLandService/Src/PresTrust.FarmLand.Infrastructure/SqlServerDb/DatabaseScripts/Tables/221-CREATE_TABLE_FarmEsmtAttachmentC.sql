IF OBJECT_ID('[Farm].[FarmEsmtAttachmentC]') IS NOT NULL
BEGIN
	--DROP CONSTRAINTS
	ALTER TABLE [Farm].[FarmEsmtAttachmentC] DROP CONSTRAINT IF EXISTS [FK_ApplicationId_FarmEsmtAttachmentC];

	ALTER TABLE [Farm].[FarmEsmtAttachmentC] DROP CONSTRAINT IF EXISTS  [DF_LastUpdatedOn_FarmEsmtAttachmentC];

END;
GO

--DROP TABLE

DROP TABLE IF EXISTS [Farm].[FarmEsmtAttachmentC]
GO

--CREATE TABLE

CREATE TABLE [Farm].[FarmEsmtAttachmentC](
   [Id]							   [integer] 		       IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                 [integer]                              NOT NULL,
   [IsExceptionAreaPreserved]      [bit]                                  NOT NULL,
   [IsNonAgriPremisesPreserved]    [bit]                                  NOT NULL, 
   [DescNonAgriUses]		       [varchar](4000)		                      NULL, 
   [NonAgriAreaUtilization]		   [varchar](4000)		                      NULL, 
   [NonAgriLease]                  [varchar](4000)		                      NULL, 
   [NonAgriUseAccessParcel]		   [varchar](4000)		                      NULL,  
   [IsLeaseWithAnotherParty]	   [bit]									  NULL,
   [LastUpdatedBy]				   [varchar](128)		                      NULL, 
   [LastUpdatedOn]				   [datetime]			                  NOT NULL
   CONSTRAINT [PK_FarmEsmtAttachmentC_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [Farm].[FarmEsmtAttachmentC] ADD CONSTRAINT [FK_ApplicationId_FarmEsmtAttachmentC] FOREIGN KEY (ApplicationId) REFERENCES [Farm].FarmApplication(Id);
GO

ALTER TABLE [Farm].[FarmEsmtAttachmentC] WITH NOCHECK ADD  CONSTRAINT [DF_LastUpdatedOn_FarmEsmtAttachmentC]  DEFAULT (GETDATE()) FOR [LastUpdatedOn]
GO

