DELETE FROM  [Farm].[FarmApplicationCommentType];

INSERT INTO [Farm].[FarmApplicationCommentType]([Id], [Title], [ApplicationTypeId]) VALUES (1, 'General Comment', 1);
GO

INSERT INTO [Farm].[FarmApplicationCommentType]([Id], [Title],  [ApplicationTypeId]) VALUES (2, 'Staff Comment', 1);
GO

INSERT INTO [Farm].[FarmApplicationCommentType]([Id], [Title], [ApplicationTypeId]) VALUES (3, 'Application Comment', 1);