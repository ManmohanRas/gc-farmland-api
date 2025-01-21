DELETE FROM [Core].[ReportItem] WHERE [Id] IN (36, 37,38,39, 40,41, 42, 43, 44, 45, 46, 47, 48);

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
 
 INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (48, 'Permanently Preserved Farms with TF Info', 'FarmEsmtPermPresFarmsWithTFInfo', 'Permanently Preserved Farms with TF Info', 'description', 13, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (49, 'All pending Farmland Preservation Projects', 'FarmEsmtAllPendingFarmPreservationProject', 'All pending Farmland Preservation Projects', 'description', 14, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (50, 'Summary of Permanently Preserved Farmlands Whose Owners May Be Interested in Selling', 'FarmEsmtSummPermntlyPresFarmsInSelling', 'Summary of Permanently Preserved Farmlands Whose Owners May Be Interested in Selling', 'description', 15, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (51, 'EXHIBIT A – Property Surveys', 'FarmEsmtExhibitAPropertySurveysReport', 'EXHIBIT A – Property Surveys', 'description', 16, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (52, 'Targeted Farm Eligibility', 'FarmEsmtTargetedFarmEligibilityReport', 'Targeted Farm Eligibility', 'description', 17, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (53, 'Preserved Farms with Signs Installed', 'FarmPreservedFarmswithSignsInstalled', 'Preserved Farms with Signs Installed', 'description', 18, 1, 1);


INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (54, 'Farm Easement Permanently Preserved Farms In Morris County', 'FarmEsmtPermanentlyPreservedFarmsInMorrisCounty', 'Farm Easement Permanently Preserved Farms In Morris County', 'description', 19, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (55, 'Summary of Farmland Preservation Pending Project', 'FarmEsmtSumOfFarmLandPreservationPendingProject', 'Summary of Farmland Preservation Pending Project', 'description', 20, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (56, 'Farm Easement Summary of Preserved Farms', 'FarmEsmtSummaryOfPreservedFarms', 'Farm Easement Summary of Preserved Farms', 'description', 21, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (57, 'Targeted Farm Eligibility', 'FarmEsmtTargetedFarmEligibilityReport', 'Targeted Farm Eligibility', 'description', 22, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (58, 'Morris County Municipal Land Area and Farmland Acreage', 'FarmEsmtMCMuniLandAreaandFarmlandAcreageReport', 'Morris County Municipal Land Area and Farmland Acreage', 'description', 23, 1, 1);

INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
VALUES (59, 'Farm Easement EXHIBIT A', 'FarmEsmtEXHIBITA', 'Farm Easement EXHIBIT A', 'description', 24, 1, 1); 

SET IDENTITY_INSERT [Core].[ReportItem] OFF



