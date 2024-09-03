DELETE FROM [Farm].[FarmApplicationSection];

--TERM SECTION

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (0, 'NONE', '', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (101, 'LOCATION', 'Location', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (102, 'OWNER_DETAILS', 'Owner Details', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (103, 'ROLES', 'Roles', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (104, 'SITE_CHARECTERISTICS', 'Site Charecteristics', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (105, 'SIGNATORY', 'Signatory', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (106, 'OTHER_DOCUMENTS', 'Other Documents', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (107, 'ADMIN_DOCUMENT_CHECKLIST', 'Admin Document Checklist', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (108, 'ADMIN_DETAILS', 'Admin Details', 1);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (109, 'DEED_DETAILS', 'Deed Details', 1);
GO


--EASEMENT SECTION
INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (201, 'LOCATION', 'Location', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (202, 'OWNER_DETAILS', 'Owner Details', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (203, 'ROLES', 'Roles', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (204, 'EXCEPTIONS', 'Easement Exceptions', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (205, 'RESI_NON_RESI_STRUCTURES', 'Residence and Non Residence Structures', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (206, 'LIENS_EASEMENT_ROW', 'Liens Easement Right of Way', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (207, 'EXIS_NON_AGRI_USES', 'Existing Non Agri Uses', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (208, 'AGRICULTURAL_USE_PRODUCTION', 'Agricultural Use and Production', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (209, 'EQUINE_USES', 'Equine Uses', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (210, 'OTHER_DOCUMENTS', 'Other Documents', 2);
GO

INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (211, 'SIGNATORY', 'Signatory', 2);
GO