DELETE FROM [Farm].[FarmApplicationStatus];

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (1,'PETITION_DRAFT',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (2,'PETITION_REQUEST',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (3,'PETITION_APPROVED',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (4,'AGREEMENT_APPROVED',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (5,'ACTIVE',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (6,'EXPIRED',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (7,'REJECTED',1);
GO

INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (8,'WITHDRAWN',1);
GO