DELETE FROM [Farm].[FarmApplicationSection];

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (0, 'NONE', '', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (1, 'LOCATION', 'Location', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (2, 'OWNER_DETAILS', 'Owner Details', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (3, 'ROLES', 'Roles', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (4, 'SITE_CHARECTERISTICS', 'Site Charecteristics', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (5, 'SIGNATORY', 'Signatory', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (6, 'OTHER_DOCUMENTS', 'Other Documents', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (7, 'ADMIN_DOCUMENT_CHECKLIST', 'Admin Document Checklist', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (8, 'ADMIN_DETAILS', 'Admin Details', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (9, 'DEED_DETAILS', 'Deed Details', 1);
GO


--TEMP EASEMENT
INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (204, 'ESMT_EXCEPTIONS', 'Easement Exceptions', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (205, 'ESMT_RESI_NON_RESI_STRUCTURES', 'Residence and Non Residence Structures', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (206, 'ESMT_LIENS_EASEMENT_ROW', 'Liens Easement Right of Way', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (207, 'ESMT_EXIS_NON_AGRI_USES', 'Existing Non Agri Uses', 2);
GO