DELETE FROM [Farm].[FarmApplicationStatus];

--TERM STATUS

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (101,'PETITION_DRAFT',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (102,'PETITION_REQUEST',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (103,'PETITION_APPROVED',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (104,'AGREEMENT_APPROVED',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (105,'ACTIVE',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (106,'EXPIRED',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (107,'REJECTED',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (108,'WITHDRAWN',1);
GO


--ESMT STATUS

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (201,'DRAFT_APPLICATION',2);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (202,'APPLICATION_SUBMITTED',2);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (203,'IN_REVIEW',2);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (204,'PENDING',2);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (205,'ACTIVE',2);	
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (206,'PRESERVED',2);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (207,'REJECTED',2);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (208,'WITHDRAWN',2);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (209,'CLOSING',2);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (210,'POST_CLOSING',2);
GO


