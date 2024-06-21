DELETE FROM [Core].[NavigationItem] WHERE [Id] IN (28,29,30,31,32,33,34,35);

SET IDENTITY_INSERT [Core].[NavigationItem] ON

INSERT INTO [Core].[NavigationItem]
(
	[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly], [ProgramTypeId], [IsActive]
) 
VALUES 
(
	28, 0, 'Dashboard','dashboard', 'flaticon2-protection', 1,0, 1, 1
);
GO

INSERT INTO [Core].[NavigationItem]
(
	[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly],  [ProgramTypeId],[IsActive]
) 
VALUES 
(
	29, 0, 'Create An Application','farm/chooseapp', 'flaticon2-add-1', 2,0, 1, 1
);
GO

INSERT INTO [Core].[NavigationItem]
(
	[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly],  [ProgramTypeId],[IsActive]
) 
VALUES 
(
	30, 0, 'Manage Applications','farm/applications', 'flaticon-squares-4', 3,0, 1, 1
);
GO

INSERT INTO [Core].[NavigationItem]
(
	[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly],  [ProgramTypeId],[IsActive]
) 
VALUES 
(
	31, 0, 'Program Manager','farm-manageprogram', 'flaticon2-layers-2', 4,0, 1, 1
);
GO

INSERT INTO [Core].[NavigationItem]
(
	[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly], [ProgramTypeId], [IsActive]
) 
VALUES 
(
	32, 0, 'Reports','reports/rptdashboard', 'flaticon2-document', 5,0, 1, 1
);
GO

INSERT INTO [Core].[NavigationItem]
(
	[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly],  [ProgramTypeId],[IsActive]
) 
VALUES 
(
	33, 0, 'Manage Agency Users','farm-manageagency', 'flaticon2-layers-2', 4,0, 1, 1
);
GO

INSERT INTO [Core].[NavigationItem]
(
	[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly], [ProgramTypeId], [IsActive]
) 
VALUES 
(
	34, 0, 'Admin','#', 'flaticon2-calendar-3', 7,0, 1, 1
);
GO

INSERT INTO [Core].[NavigationItem]
(
	[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly], [ProgramTypeId], [IsActive]
) 
VALUES 
(
	35, 0, 'How To','howto', 'flaticon-questions-circular-button', 8,0, 1, 1
);
GO

SET IDENTITY_INSERT [Core].[NavigationItem] OFF