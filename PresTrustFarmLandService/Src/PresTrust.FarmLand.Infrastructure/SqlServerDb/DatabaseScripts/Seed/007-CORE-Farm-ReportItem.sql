DELETE FROM [Core].[ReportItem] WHERE [Id] IN (36, 37);

SET IDENTITY_INSERT [Core].[ReportItem] ON

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (36, 'Farm Term Program Book Index Report', 'FarmTermProgramBookIndexReport', 'Farm Land Term Program Book Index Report', 'description', 1, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (37, 'Farm Term Program Report', 'FarmTermProgramReport', 'Farm Land Term Program Report', 'description', 2, 1, 1);

--Easment reports
INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (38, 'Farm Esmt Program Permanently Preserved Farms Report', 'FarmEsmtPermanentlyPreservedFarmsReport', 'Farm Land Esmt Program Permanently Preserved Farms Report', 'description', 3, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (39, 'Farm Esmt Program Purchase Breakdown Report', 'FarmEasementPurchaseBreakdownReport', 'Farm Land Esmt Purchase Breakdown Report', 'description', 4, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (40, 'Morris CADB Easement Purchase Program – SADC Appraised Values', 'FarmEsmtCADBPurchPrgmSADCAppraisedReport', 'Morris CADB Easement Purchase Program – SADC Appraised Values', 'description', 5, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (41, 'Preserved Farms in Morris County', 'FarmEsmtPreservedFarmsInMorrisCounty', 'Preserved Farms in Morris County Report', 'description', 6, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (42, 'Permanently Preserved Farms with a Residence on Preserved Ground', 'FarmEsmtPermPresFarmsWithResiOnPresGround', 'Permanently Preserved Farms with a Residence on Preserved Ground', 'description', 7, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (43, 'Permanently Preserved Farms – Town Summaries', 'FarmEsmtPermPresFarmsTownSummaries', 'Permanently Preserved Farms Town Summaries', 'description', 8, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (44, 'Permanently Preserved Farms with Farm Name', 'FarmEsmtPermPresFarmsWithFarmName', 'Permanently Preserved Farms with Farm Name', 'description', 9, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive) 
VALUES (45, 'RDSO’s on Preserved Farms', 'FarmEsmtRdsoPresFarmsReport', 'RDSO on Preserved Farms', 'description', 10, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (46, 'Preserved Farms – Exception Areas', 'FarmEsmtPresFarmsExceptionAreaReport', 'Preserved Farms – Exception Areas', 'description', 11, 1, 1);
 
INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (47, 'Permanently Preserved Farms with Severable Exceptions', 'FarmPremPresFarmsWithServableExceptionsReport', 'Permanently Preserved Farms with Severable Exceptions', 'description', 12, 1, 1);
 

SET IDENTITY_INSERT [Core].[ReportItem] OFF



