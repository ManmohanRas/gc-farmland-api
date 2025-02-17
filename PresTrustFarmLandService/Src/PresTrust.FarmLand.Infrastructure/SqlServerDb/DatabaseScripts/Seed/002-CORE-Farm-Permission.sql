DELETE FROM [Core].[Permission] WHERE [Id] IN (13, 14, 15, 16);

SET IDENTITY_INSERT [Core].[Permission] ON

INSERT INTO [Core].[Permission]
	([Id],[Name],[Description],[ProgramTypeId],[IsActive]) 
	VALUES 
	(13, 'MANAGE_PROGRAM', 'Manage program sections, user management, parcels, email templates',	1,	1);
GO 

INSERT INTO [Core].[Permission]
	([Id],[Name],[Description],[ProgramTypeId],[IsActive]) 
	VALUES 
	(14, 'MANAGE_AGENCY', 'Manage agency sections like user management', 1,	1);
GO 

INSERT INTO [Core].[Permission]
	([Id],[Name],[Description],[ProgramTypeId],[IsActive]) 
	VALUES 
	(15, 'MANAGE_REPORTS', 'Generate or View reports', 1, 1);
GO 

INSERT INTO [Core].[Permission]
	([Id],[Name],[Description],[ProgramTypeId],[IsActive]) 
	VALUES 
	(16, 'FARM', 'View and/or Edit Farm Mitigation Application', 1, 1);
GO 

SET IDENTITY_INSERT [Core].[Permission] OFF

 