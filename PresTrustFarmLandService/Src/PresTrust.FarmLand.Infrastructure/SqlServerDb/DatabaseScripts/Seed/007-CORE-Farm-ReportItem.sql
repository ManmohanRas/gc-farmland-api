DELETE FROM [Core].[ReportItem] WHERE [Id] IN (36, 37);

SET IDENTITY_INSERT [Core].[ReportItem] ON

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (36, 'Farm Term Program Book Index Report', 'FarmTermProgramBookIndexReport', 'Farm Land Term Program Book Index Report', 'description', 1, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (37, 'Farm Term Program Report', 'FarmTermProgramReport', 'Farm Land Term Program Report', 'description', 2, 1, 1);

--Easment reports
INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (38, 'Farm Esmt Program Permanently Preserved Farms Report', 'FarmEsmtPermanentlyPreservedFarmsReport', 'Farm Land Esmt Program Permanently Preserved Farms Report', 'description', 3, 1, 1);

SET IDENTITY_INSERT [Core].[ReportItem] OFF



