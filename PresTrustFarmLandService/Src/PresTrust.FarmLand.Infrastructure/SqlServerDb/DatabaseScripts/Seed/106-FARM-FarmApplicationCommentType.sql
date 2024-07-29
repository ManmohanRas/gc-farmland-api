DELETE FROM  [Farm].[FarmAppCommentType];

INSERT INTO [Farm].[FarmAppCommentType]([Id], [Title]) VALUES (1, 'General Comment');
GO

INSERT INTO [Farm].[FarmAppCommentType]([Id], [Title]) VALUES (2, 'Staff Comment');
GO

INSERT INTO [Farm].[FarmAppCommentType]([Id], [Title]) VALUES (3, 'Application Comment');