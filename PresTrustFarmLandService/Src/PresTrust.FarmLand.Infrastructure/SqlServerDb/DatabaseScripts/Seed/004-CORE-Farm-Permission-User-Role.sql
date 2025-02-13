-- delete previous records
DELETE FROM [Core].[PermissionUserRole] WHERE PermissionId IN (13, 14, 15, 16);


-- manage_program
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (13, 1);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (13, 3);

-- manage_agency
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (14, 1);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (14, 7);

-- manage_reports
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (15, 1);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (15, 2);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (15, 3);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (15, 4);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (15, 6);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (15, 7);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (15, 8);

-- farm mitigation view edit
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (16, 1);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (16, 3);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (16, 4);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (16, 5);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (16, 6);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (16, 7);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (16, 8);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (16, 9);
INSERT INTO [Core].[PermissionUserRole]([PermissionId], [UserRoleId]) VALUES (16, 10);
