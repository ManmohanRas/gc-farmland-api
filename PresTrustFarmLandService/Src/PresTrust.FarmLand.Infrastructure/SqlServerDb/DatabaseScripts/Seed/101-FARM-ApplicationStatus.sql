DELETE FROM [Farm].[FarmApplicationStatus];

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (1,'CREATE_APPLICATION',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (2,'DRAFT_APPLICATION',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (3,'APPLICATION_REQUESTED',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (4,'APPLICATION_APPROVED',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (5,'REJECTED',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (6,'AGREEMENT_APPROVED',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (7,'ACTIVE',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (8,'EXPIRED',1);
GO