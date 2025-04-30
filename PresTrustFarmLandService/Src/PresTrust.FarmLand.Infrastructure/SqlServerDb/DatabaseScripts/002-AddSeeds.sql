
BEGIN TRY
	BEGIN TRANSACTION
	--=================================================================================

	--001
	UPDATE CORE.ProgramType 
    SET IsActive = 1
    WHERE Id = 1;

	--002
	DELETE FROM [Core].[Permission] WHERE [Id] IN (13, 14, 15, 16);

    SET IDENTITY_INSERT [Core].[Permission] ON

    INSERT INTO [Core].[Permission]
	([Id],[Name],[Description],[ProgramTypeId],[IsActive]) 
	VALUES 
	(13, 'MANAGE_PROGRAM', 'Manage program sections, user management, parcels, email templates',	1,	1);
		 
		INSERT INTO [Core].[Permission]
			([Id],[Name],[Description],[ProgramTypeId],[IsActive]) 
			VALUES 
			(14, 'MANAGE_AGENCY', 'Manage agency sections like user management', 1,	1);
		 
		INSERT INTO [Core].[Permission]
			([Id],[Name],[Description],[ProgramTypeId],[IsActive]) 
			VALUES 
			(15, 'MANAGE_REPORTS', 'Generate or View reports', 1, 1);
		 
		INSERT INTO [Core].[Permission]
			([Id],[Name],[Description],[ProgramTypeId],[IsActive]) 
			VALUES 
			(16, 'FARM', 'View and/or Edit Farm Mitigation Application', 1, 1);
		 

	SET IDENTITY_INSERT [Core].[Permission] OFF;


   ---003
   /*
========== ========== ========== ========== ==========
		No new users - Old users are sufficient
========== ========== ========== ========== ==========
*/

 --004
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


	-- 005
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
		

		INSERT INTO [Core].[NavigationItem]
		(
			[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly],  [ProgramTypeId],[IsActive]
		) 
		VALUES 
		(
			29, 0, 'Create An Application','farm/chooseapp', 'flaticon2-add-1', 2,0, 1, 1
		);
		

		INSERT INTO [Core].[NavigationItem]
		(
			[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly],  [ProgramTypeId],[IsActive]
		) 
		VALUES 
		(
			30, 0, 'Manage Applications','farm/applications', 'flaticon-squares-4', 3,0, 1, 1
		);
		

		INSERT INTO [Core].[NavigationItem]
		(
			[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly],  [ProgramTypeId],[IsActive]
		) 
		VALUES 
		(
			31, 0, 'Program Manager','farm-manageprogram', 'flaticon2-layers-2', 4,0, 1, 1
		);
		

		INSERT INTO [Core].[NavigationItem]
		(
			[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly], [ProgramTypeId], [IsActive]
		) 
		VALUES 
		(
			32, 0, 'Reports','reports/rptdashboard', 'flaticon2-document', 5,0, 1, 1
		);
		

		INSERT INTO [Core].[NavigationItem]
		(
			[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly],  [ProgramTypeId],[IsActive]
		) 
		VALUES 
		(
			33, 0, 'Manage Agency Users','farm-manageagency', 'flaticon2-layers-2', 4,0, 1, 1
		);
		

		INSERT INTO [Core].[NavigationItem]
		(
			[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly], [ProgramTypeId], [IsActive]
		) 
		VALUES 
		(
			34, 0, 'Admin','#', 'flaticon2-calendar-3', 7,0, 1, 1
		);
		

		INSERT INTO [Core].[NavigationItem]
		(
			[Id], [ParentId], [Title], [RouterLink], [Icon], [SortOrder], [IsViewOnly], [ProgramTypeId], [IsActive]
		) 
		VALUES 
		(
			35, 0, 'How To','howto', 'flaticon-questions-circular-button', 8,0, 1, 1
		);
		
		SET IDENTITY_INSERT [Core].[NavigationItem] OFF

	-- 006
	-- delete previous records
       DELETE FROM [Core].[NavigationItemUserRole] WHERE NavigationItemId IN (28,29,30,31,32,33,34,35);
       
       -- Dashboard
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (28, 1);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (28, 3);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (28, 4);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (28, 5);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (28, 6);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (28, 7);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (28, 8);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (28, 9);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (28, 10);
       
       -- Create An Application
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (29, 3);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (29, 4);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (29, 7);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (29, 8);
       
       
       -- Manage Project Areas
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (30, 1);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (30, 3);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (30, 4);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (30, 5);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (30, 6);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (30, 7);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (30, 8);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (30, 9);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (30, 10);
       
       -- Program Manager
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (31, 1);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (31, 3);
       
       -- Reports
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (32, 1);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (32, 3);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (32, 4);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (32, 5);
       
       -- Manage Agency Users
       --INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (33, 3);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (33, 7);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (33, 8);
       
       -- Admin
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (34, 1);
       
       -- howto
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (35, 1);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (35, 3);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (35, 4);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (35, 5);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (35, 6);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (35, 7);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (35, 8);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (35, 9);
       INSERT INTO [Core].[NavigationItemUserRole]([NavigationItemId], [UserRoleId]) VALUES (35, 10);

       --- 007
	   DELETE FROM [Core].[ReportItemUserRole] WHERE ReportItemId IN (SELECT  Id FROM [CORE].[ReportItem] WHERE ProgramTypeId = 1);

	   DELETE FROM [Core].[ReportItem] WHERE [Id] IN (SELECT  Id FROM [CORE].[ReportItem] WHERE ProgramTypeId = 1);


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
       VALUES (55, 'Summary of Farmland Preservation Pending Project', 'FarmSumOfFarmLandPresPendingProject', 'Summary of Farmland Preservation Pending Project', 'description', 20, 1, 1);
       
       INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
       VALUES (56, 'Farm Easement Summary of Preserved Farms', 'FarmEsmtSummaryOfPreservedFarms', 'Farm Easement Summary of Preserved Farms', 'description', 21, 1, 1);
       
       INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
       VALUES (57, 'Targeted Farm Eligibility', 'FarmEsmtTargetedFarmEligibilityReport', 'Targeted Farm Eligibility', 'description', 22, 1, 0);
       
       INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
       VALUES (58, 'Morris County Municipal Land Area and Farmland Acreage', 'FarmEsmtMCMuniLandAreaandFarmlandAcreageReport', 'Morris County Municipal Land Area and Farmland Acreage', 'description', 23, 1, 1);
       
       INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
       VALUES (59, 'Farm Easement EXHIBIT A', 'FarmEsmtEXHIBITA', 'Farm Easement EXHIBIT A', 'description', 24, 1, 1); 
       
       INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
       VALUES (60, 'Re-Sale Info of Preserved Farms', 'FarmEsmtReSaleInfoOfPreservedFarmsReport', 'Re-Sale Info of Preserved Farms', 'description', 25, 1, 1); 

       INSERT INTO [Core].[ReportItem] ([Id], Title, ReportUrl, [Description], Icon, SortOrder, ProgramTypeId, IsActive)
       VALUES (61, 'Monitoring Inspection Report for year – All Farms', 'FarmEsmtMonitoringInspectionReport', 'Monitoring Inspection Report for year – All Farms', 'description', 26, 1, 1); 
       
       SET IDENTITY_INSERT [Core].[ReportItem] OFF

	   -- 008
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (36, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (36, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (36, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (36, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (37, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (37, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (37, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (37, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (38, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (38, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (38, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (38, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (39, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (39, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (39, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (39, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (40, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (40, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (40, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (40, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (41, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (41, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (41, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (41, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (42, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (42, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (42, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (42, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (43, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (43, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (43, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (43, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (44, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (44, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (44, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (44, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (45, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (45, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (45, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (45, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (46, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (46, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (46, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (46, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (47, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (47, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (47, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (47, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (48, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (48, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (48, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (48, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (49, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (49, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (49, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (49, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (50, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (50, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (50, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (50, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (51, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (51, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (51, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (51, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (52, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (52, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (52, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (52, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (53, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (53, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (53, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (53, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (54, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (54, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (54, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (54, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (55, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (55, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (55, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (55, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (56, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (56, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (56, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (56, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (57, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (57, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (57, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (57, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (58, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (58, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (58, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (58, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (59, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (59, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (59, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (59, 5);
       
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (60, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (60, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (60, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (60, 5);

       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (61, 1);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (61, 3);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (61, 4);
       INSERT INTO [Core].[ReportItemUserRole]([ReportItemId], [UserRoleId]) VALUES (61, 5);

	   --101

	   DELETE FROM [Farm].[FarmApplicationType];

	   INSERT INTO [Farm].[FarmApplicationType] ([Id], [Title])  VALUES (1, 'TERM');
	   INSERT INTO [Farm].[FarmApplicationType] ([Id], [Title])  VALUES (2, 'EASEMENT');

	   --102
	   DELETE FROM [Farm].[FarmApplicationStatus];

       --TERM STATUS

       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (101,'PETITION_DRAFT',1);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (102,'PETITION_REQUEST',1);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (103,'PETITION_APPROVED',1);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (104,'AGREEMENT_APPROVED',1);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (105,'ACTIVE',1);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (106,'EXPIRED',1);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (107,'REJECTED',1);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (108,'WITHDRAWN',1);
       
       
       --ESMT STATUS
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (201,'DRAFT_APPLICATION',2);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (202,'APPLICATION_SUBMITTED',2);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (203,'IN_REVIEW',2);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (204,'PENDING',2);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (205,'ACTIVE',2);	
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (206,'PRESERVED',2);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (207,'REJECTED',2);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (208,'WITHDRAWN',2);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (209,'CLOSING',2);
       
       INSERT INTO [Farm].[FarmApplicationStatus] ([Id],[Name],[ApplicationTypeId]) VALUES (210,'POST_CLOSING',2);

	   ---103
	   DELETE FROM [Farm].[FarmApplicationSection];

       --TERM SECTION

       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (0, 'NONE', '', 1);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (101, 'LOCATION', 'Location', 1);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (102, 'OWNER_DETAILS', 'Owner Details', 1);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (103, 'ROLES', 'Roles', 1);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (104, 'SITE_CHARECTERISTICS', 'Site Charecteristics', 1);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (105, 'SIGNATORY', 'Signatory', 1);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (106, 'OTHER_DOCUMENTS', 'Other Documents', 1);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (107, 'ADMIN_DOCUMENT_CHECKLIST', 'Admin Document Checklist', 1);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (108, 'ADMIN_DETAILS', 'Admin Details', 1);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (109, 'DEED_DETAILS', 'Deed Details', 1);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (110, 'CONTACTS', 'Contacts', 1);
       
       --EASEMENT SECTION
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (201, 'LOCATION', 'Location', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (202, 'OWNER_DETAILS', 'Owner Details', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (203, 'ROLES', 'Roles', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (204, 'EXCEPTIONS', 'Easement Exceptions', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (205, 'RESI_NON_RESI_STRUCTURES', 'Residence and Non Residence Structures', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (206, 'LIENS_EASEMENT_ROW', 'Liens Easement Right of Way', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (207, 'EXIS_NON_AGRI_USES', 'Existing Non Agri Uses', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (208, 'AGRICULTURAL_USE_PRODUCTION', 'Agricultural Use and Production', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (209, 'EQUINE_USES', 'Equine Uses', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (210, 'OTHER_DOCUMENTS', 'Other Documents', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (211, 'SIGNATORY', 'Signatory', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (212, 'ADMIN_DOCUMENT_CHECK_LIST', 'Admin Document Checklist', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (213, 'ADMIN_COST_DETAILS', 'Admin Cost Details', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (214, 'ADMIN_APPRAISAL_REPORTS', 'Admin Appraisal Reports', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (215, 'ADMIN_OFFER_COSTS', 'Admin Offer Costs', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (216, 'ADMIN_STRUCTURES', 'Admin Structures', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (217, 'ADMIN_EXCEPTIONS', 'Admin Exceptions', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (218, 'ADMIN_SADC', 'Admin SADC', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (219, 'ADMIN_CLOSING_DOCS', 'Admin Closing Docs', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (220, 'ADMIN_CONTACTS', 'Admin Contacts', 2);

       --SADC tabs
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (301, 'SADC_FARM_INFORMATION', 'SADC Farm Information', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (302, 'SADC_RESI_ON_ESMT_AREA', 'SADC Resi on ESMT Area', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (303, 'SADC_FARM_HISTORY', 'SADC Farm History', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (304, 'SADC_APP_ELIGIBILITY_I', 'SADC Application Eligibility I', 2);
       
       INSERT INTO [Farm].[FarmApplicationSection] ([Id], [Title], [Description], [ApplicationTypeId]) VALUES (305, 'SADC_APP_ELIGIBILITY_II', 'SADC Application Eligibility II', 2);

	   ---104
	   DELETE FROM  [Farm].[FarmApplicationDocumentType];

       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (1, 'CADB_PETITION', 'CADB PETITION document', 106 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (2, 'DEED', 'DEED document', 106 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (3, 'TAX_MAP', 'TAX MAP document', 106 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (4, 'MAFPP_STEPS_TO_APPROVAL', 'MAFPP STEPS TO APPROVAL document', 106 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (5, 'CO_NOTICE_OF_TERMINATION', 'CO NOTICE OF TERMINATION document', 106 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (6, 'RENEWAL_TERMINATION_BULLETS', 'RENEWAL TERMINATION BULLETS document', 106 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (7, 'LANDOWNER_SIGNATURE', 'Land Owner Signature', 106 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (8, 'MUNICIPAL_ORDINANCE', 'MUNICIPAL ORDINANCE document', 108 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (9, 'MAFPP_AGREEMENT', 'MAFPP AGREEMENT document', 108 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (10, 'COUNTY_RESOLUTION', 'COUNTY RESOLUTION document', 108 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (11, 'SADC_APPROVAL_LETTER', 'SADC APPROVAL LETTER document', 108 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (12, 'RECEIPT_OF_CERTIFICATION', 'RECEIPT OF CERTIFICATION document', 108 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (13, 'NOTIFICATION_OF_TERMINATION', 'NOTIFICATION OF TERMINATION document', 108 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (14, 'TRUE_COPY_OF_DEED', 'TRUE COPY OF DEED document', 109 , 1);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (15, 'COPY_OF_OWNER_OF_LAST_RECORD_SEARCH', 'COPY OF OWNER OF LAST RECORD SEARCH document', 109 , 1);
       
       ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
       --Easement OtherDocuments Need To Refactor Before Final Release
       ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (16, 'COUNTY_APPLICATION', 'County Application', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (17, 'ESMT_DEED', 'Esmt Deed', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (18, 'TAX_MAP', 'Tax Map', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (19, 'EXCEPTION_AREA_DOCUMENT_ATTACHMENT_B ', 'Exception Area Document Attachment B', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (20, ' POLICY_8', ' Policy 8', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (21, 'ADOPTED_PRELIMINARY_RESOLUTION ', 'Adopted Preliminary Resolution ', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (22, 'NOTICE_TO_PROCEED_OR_WITHDRAW ', 'Notice To Proceed Or Withdraw ', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (23, 'REQUEST_FOR_APPLICATION_FEE ', 'Request For Application Fee ', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (24, 'APPLICATION_FOR_FRAMLAND_PRESERVATION_SADC', 'Application for Farmland Preservation SADC', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (25, 'CONTRACT', 'Contract', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (26, 'COUNTY_COMMISSIONER_RESOLUTION_APPROVING_CONTRACT', 'County Commissioner Resolution Approving Contract', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (27, 'COPY_OF_TITLE_COMMITMENT', 'Copy Of Title Commitment', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (28, 'FINAL_SURVEY', 'Final Survey', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (29, 'DEED_WITHOUT_EXCEPTIONS', 'Deed With Out Exceptions', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (30, 'DEED_WITH_EXCEPTIONS', 'Deed With Exceptions', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (31, 'FINAL_CADB_APPROVAL', 'Final CADB Approval', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (32, 'PRELIMINARY_APPROVAL', 'Preliminary Approval Document', 218 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (33, 'ORDER_CHECKLIST', 'Order Checklist SADC Only', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (34, 'DEED_WITH_EXCEPTIONS_SADC', 'Deed With Exception SADC', 218 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (35, 'DEED_WITHOUT_EXCEPTION_SADC', 'Deed Without Exception SADC', 218 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (36, 'FINAL_APPROVAL_WITH_SADC', 'Final Approval With SADC', 218 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (37, 'ESMT_OTHER_DOCUMENTS', 'Esmt Other Documents', 218 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (38, 'DEED_SIGNED_BY_ALL_PARTIES', 'Deed Signed By All Parties', 210 , 2); 
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (39, 'ESMT_DEED_RECORDED', 'Deed Recorded', 210 , 2); 
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (40, 'ESMT_DEED_PRESERVED', 'Preserved Deed', 219 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (41, 'ESMT_TITLE_POLICY', 'Title Policy', 219 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (42, 'ESMT_PRESERVED_SURVEY', 'Preserved Survey', 219 , 2); 
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (43, 'ESMT_LANDOWNER_SIGNATURE', 'Easement LandOwner Signature', 210 , 2); 
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (44, 'ATTACHMENT_F', 'Attachment_F', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (45, 'ATTACHMENT_G', 'Attachment_G', 210 , 2); 
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (46, 'ATTACHMENT_H', 'Attachment_H', 210 , 2); 
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (47, 'CONTRACT_REQUEST', 'Contract_Request', 210 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (48, 'SPECIAL_PREMISES', 'Special Premises', 207 , 2);
       ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
       --Easement Admin Tabs Documents
       ----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (49, 'CLOSING_DEED', 'Closing Deed', 212 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (50, 'CLOSING_TITLE_POLICY', 'Closing Title Policy', 212 , 2);
       
       INSERT INTO [Farm].[FarmApplicationDocumentType]([Id], [Title], [Description], [SectionId], [ApplicationTypeId]) VALUES (51, 'CLOSING_SERVVEY', 'Closing Survey', 212 , 2);
       

	   ---105
	   INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
	 1, 
 'CHANGE_STATUS_FROM_AGREEMENT_APPROVED_TO_ACTIVE', 
 'Change status from Agreement Approved to Active', 
 'Term Program - {{FarmName}}', 

'<p>Dear {{PrimaryContactName}},</p>
<p>Please take notice that the following property has been enrolled in a Farmland Preservation Program for a period of sixteen years:</p>
 <p>LandOwner: {{OwnerFirst}}, {{OwnerLast}} </p>
 <p>Municipality: {{Municipality}}</p>
 <p>Block/Lots: {{Block}}, {{Lot}}</p>
 <p> Deed Book/Page: {{DeedBook}}, {{DeedPage}}</p>
 <p>A copy of the Agreement is enclosed for your records.</p>
 <p>If you have any questions, please contact me at (973) 829 8120 or at kcoyle@co.morris.nj.us.<br>
 <p>Per N.J.A.C. 2:76-3.8, the Notice is also being forwarded to:
<p> Landowner</p>
<p> Morris County Board of Chosen Freeholders</p>
<p> Morris County Planning Board</p>
<p> Municipal verning Body</p>
<p> Municipal Planning Board</p>
<p> Municipal Tax Assessor</p>
<p> Morris County Soil Conservation District</p>
 <br>
<p>Sincerely,</p>
<p>{{ProgramAdmin}}<br>

<p>Director</p>
Morris County Agriculture Development Board<br>
Morris County Office of Planning & Preservation<br>
P.O. Box 900<br>
Morristown, NJ 07963-0900<br>
Phone: (973) 829-8120
Fax: (973) 326-9025<br>
E-Mail: kcoyle@co.morris.nj.us<br>
Website: https://www.morriscountynj.v/agriculture </p>', 
    1);


INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
   2, 'TRIGER_THE_EMAIL_WHEN_SADC_IS_ENABLED',
		'Triger The Email When SADC is Eanbled',
		' Term Program - {{Block}}, {{Lot}}, {{Municipality}}', 

		'<P>Dear {{SADCContact}},</P>
		<P>Pursuant to N.J.A.C. 2:76-3.6, the Morris County Agriculture Development Board (Morris CADB) 
		hereby submits a request for Certification of a Farmland Preservation Program (Term-Year Program) 
		for the above referenced property.</P>
		<p>Petition;</p>
		<p>Signed original copy of the Agreement;</p>
		<p>Morris CADB resolution;</p>
		<p>Copy of owner of last record search.</p>
		<p>If you have any questions or require additional information, please contact me.</p>
		<br>
		<p>Sincerely,</p>
		<p>{{ProgramAdmin}}<br>

		<p>Director</p>
		Morris County Agriculture Development Board<br>
		Morris County Office of Planning & Preservation<br>
		P.O. Box 900<br>
		Morristown, NJ 07963-0900<br>
		Phone: (973) 829-8120
		Fax: (973) 326-9025<br>
		E-Mail: kcoyle@co.morris.nj.us<br>
		Website: https://www.morriscountynj.v/agriculture </p>', 

2);


INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
   3,	'CHANGE_STATUS_FROM_REQUESTED_TO_APPROVED', 
		'Change status from Requested to Approved', 
		'Term Program - {{FarmName}}', 

		'<P>Dear {{PrimaryContactName}},</P>
		<P>I am pleased to forward to you the Term Farmland Preservation Program Agreement for your property.</p> 
		<p>Please sign the document before a witness (notary public) and have the witness attest the signature. Once signed, please return the document to me</p>
		<p>I will then present the document for signature to the Morris County Agriculture Development Board (CADB) and to the State Agriculture Development Committee (SADC) for certification. Lastly, the County will record the document in the Hall of Records.</p>
		<p>If you have any questions or require additional information, please contact me.</p>
		<br>
		<p>Sincerely,</p>
		<p>{{ProgramAdmin}}<br>

		<p>Director</p>
		Morris County Agriculture Development Board<br>
		Morris County Office of Planning & Preservation<br>
		P.O. Box 900<br>
		Morristown, NJ 07963-0900<br>
		Phone: (973) 829-8120
		Fax: (973) 326-9025<br>
		E-Mail: kcoyle@co.morris.nj.us<br>
		Website: https://www.morriscountynj.v/agriculture </p>', 

3);


INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
   4,	'CHANGE_STATUS_FROM_DRAFT_TO_REQUESTED', 
		'Change status from Draft to Requested', 
		'Term Program - {{FarmName}}',
		'<p>Dear {{PrimaryContactName}},</p>
		<P>I am in receipt of your Petition document and have added this item to the Morris CADB?s next meeting agenda. The board will discuss the matter and if found acceptable, will direct staff to prepare a resolution approving the Petition.</p> 
		<p>Approval of the Petition by the CADB and creation of the farmland preservation program will be signified by an agreement between you and the CADB to retain the land in agricultural production for an agreed upon number of years.</p>
		<p>I will keep you posted of the progress. If you have any questions, please contact me.</p>
		<br>
		<p>Sincerely,</p>
		<p>{{ProgramAdmin}}<br>
 
		<p>Director</p>
		Morris County Agriculture Development Board<br>
		Morris County Office of Planning & Preservation<br>
		P.O. Box 900<br>
		Morristown, NJ 07963-0900<br>
		Phone: (973) 829-8120
		Fax: (973) 326-9025<br>
		E-Mail: kcoyle@co.morris.nj.us<br>
		Website: https://www.morriscountynj.v/agriculture </p>', 

4);



--Easement 
INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
5,		'CHANGE_STATUS_FROM_CREATE_TO_DRAFT_APPLICATION', 
		'Change status From Create to Draft Application',
		'Easement Purchase Program - {{FarmName}}', 

		'<p>Dear {{PrimaryContactName}},</p>
		 <p>Thank you for your interest in the Morris County Farmland Preservation Program. Please complete and submit the application. I am happy to provide help with completing the application by phone, e-mail or in person. </p>
		 <p>I look forward to working with you and welcome any questions you may have.</p>
		 <br>
		  <p>Best regards,</p>
	     <p>{{ProgramAdmin}}<br>

		 <p>Director</p>
		 Morris County Agriculture Development Board<br>
		 Morris County Office of Planning & Preservation<br>
		 P.O. Box 900<br>
		 Morristown, NJ 07963-0900<br>
		 Phone: (973) 829-8120
		 Fax: (973) 326-9025<br>
		 E-Mail: kcoyle@co.morris.nj.us<br>
		 Website: https://www.morriscountynj.v/agriculture </p>', 
1);


INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
6,		'CHANGE_STATUS_FROM_DRAFT_APPLICATION_TO_APPLICATION_SUBMITTED', 
		'Change status From Draft Application to Application Submitted',
		'Easement Purchase Program - {{FarmName}}.',
		'<p>Dear {{PrimaryContactName}},</p>
		 <p>Thank you for submitting your application. we will review the application and, if any additional information is needed, we will contact you. </p>
		 <p>I look forward to working with you and welcome any questions you may have.</p>
		 <br>
		  <p>Best regards,</p>
	     <p>{{ProgramAdmin}}<br>
		 <p>Director</p>
		 Morris County Agriculture Development Board<br>
		 Morris County Office of Planning & Preservation<br>
		 P.O. Box 900<br>
		 Morristown, NJ 07963-0900<br>
		 Phone: (973) 829-8120
		 Fax: (973) 326-9025<br>
		 E-Mail: kcoyle@co.morris.nj.us<br>
		 Website: https://www.morriscountynj.v/agriculture </p>', 
1);


INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
7,		'CHANGE_STATUS_FROM_IN_REVIEW_TO_PENDING', 
		'Change status From In_Review to Pending',
		'Easement Purchase Program - {{FarmName}}',
		'<p>Congratulations, {{PrimaryContactName}}!</p>
		<p>At its {{PreviousMeetingDate}} meeting, the Morris County Agriculture Development Board (CADB) granted preliminary approval of your application to sell a development easement. A copy of the resolution is enclosed.</p>
		<p>Also enclosed you will find &ldquo;Notice to Proceed&rdquo; and &ldquo;Notice of Withdrawal&rdquo; forms. Please complete the appropriate form and return it to the Morris CADB before (insert due date).</p>
		<p>If you wish to continue with the preservation process, please also include your $1,000 application fee (see enclosed Morris CADB Policy P-3). A check for the application fee should be made out to &ldquo;Treasurer of Morris County.&rdquo; The application fee will be refunded upon successful sale of the development easement, or if the Morris CADB decides against purchase of the development easement. The $1,000 application fee will be forfeited if you decide to withdraw at any point prior to the closing of the development easement purchase.</p>
         <p>The Morris CADB looks forward to working with you to see your farm permanently preserved. If you have any questions, please contact Ms. Katherine Coyle at (973) 829-8120 or via e-mail at kcoyle@co.morris.nj.us.</p>
		  <p>Sincerely</p>
	     <p>{{ProgramAdmin}}<br>
		 <p>Director</p>
		 Morris County Agriculture Development Board<br>
		 Morris County Office of Planning & Preservation<br>
		 P.O. Box 900<br>
		 Morristown, NJ 07963-0900<br>
		 Phone: (973) 829-8120
		 Fax: (973) 326-9025<br>
		 E-Mail: kcoyle@co.morris.nj.us<br>
		 Website: https://www.morriscountynj.v/agriculture </p>', 
1);


INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
8,		'CHANGE_STATUS_FROM_IN_REVIEW_TO_REJECTED', 
		'Change status From In_Review to Rejected',
		'Easement Purchase Program - {{FarmName}}',
		'<p>Dear {{PrimaryContactName}}:</p>

<p>At its {{PreviousMeetingDate}} meeting, the Morris County Agriculture Development Board (CADB) reviewed your application for the sale of development easement.</p>

<p> Although the merit of your application is worthwhile, I must regretfully inform you that your application was not selected. Applications are selected for a combination of reasons including: significance and financial viability of the agricultural operation, soils, amount of tillable acreage, stewardship of the land, asking price, total acquisition cost, the likelihood the property would be sold in the near future for development, the location to other preserved lands, as well as the location within Morris County.</p>

<p> The board thanks you for your continued interest in supporting preservation of farmland in our county. If you have any questions, please do not hesitate to contact Ms. Katherine Coyle at (973) 829-8120 or via e-mail at kcoyle@co.morris.nj.us.</p>
		 <br>
		  <p>Best regards,</p>
	     <p>{{ProgramAdmin}}<br>

		 <p>Director</p>
		 Morris County Agriculture Development Board<br>
		 Morris County Office of Planning & Preservation<br>
		 P.O. Box 900<br>
		 Morristown, NJ 07963-0900<br>
		 Phone: (973) 829-8120
		 Fax: (973) 326-9025<br>
		 E-Mail: kcoyle@co.morris.nj.us<br>
		 Website: https://www.morriscountynj.v/agriculture </p>', 
1);


INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
9,		'CHANGE_STATUS_PENDING_TO_ACTIVE', 
		'Change status Pending to Active',
		 'Easement Purchase Program - {{FarmName}}',
		 '<p>Dear {{PrimaryContactName}},</p>
		 <p>The Morris CADB has reviewed the appraisals of your farm and agreed on an offer amount. An offer letter will be sent to you via regular mail.</p>
		 <p>I look forward to working with you and welcome any questions you may have.</p>
		 <br>
		  <p>Best regards,</p>
	     <p>{{ProgramAdmin}}<br>
		 <p>Director</p>
		 Morris County Agriculture Development Board<br>
		 Morris County Office of Planning & Preservation<br>
		 P.O. Box 900<br>
		 Morristown, NJ 07963-0900<br>
		 Phone: (973) 829-8120
		 Fax: (973) 326-9025<br>
		 E-Mail: kcoyle@co.morris.nj.us<br>
		 Website: https://www.morriscountynj.v/agriculture </p>', 
1);


INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
10,		'CHANGE_STATUS_FROM_CLOSING_TO_POST_CLOSING', 
		'Change status From Closing to Post Closing',
		'Easement Purchase Program - {{FarmName}}',

		'<p>Date: {{TodaysDate}}</p>
		 <p>Enclosed are copies of the following closing documents for the {{ProjectName}}:</p>
		 <p>Recorded Deed of Easement</P>
		 <p>Affidavit of Title</P>
		 <p>Title Closing Statement</P>
		 <p>Title Insurance Policy</P>

		 <p>If you have any questions, please contact me.</p>
		 <p>Re: Post Closing Documents: {{OwnerLast}}, {{OwnerFirst}} </p>
		 <p>SADC # {{SADCNumber}} </p>
		 <p>{{Block}}, {{Lot}} </p>
		 <p>{{Municipality}} </p>
		 <p>County PIG Easement Purchase </p>

		 <p> Date: {{TodaysDate}}</p>

		 <p>Enclosed are copies of the following closing documents for the Williams Farm:</p>

		 <p>Recorded Deed of Easement</P>
		 <p>Affidavit of Title</P>
		 <p>Title Closing Statement</P>
		 <p>Title Insurance Policy</P>

		 <p>If you have any questions, please contact me. </p>
		 <p>{{ProgramAdmin}} </p>
	
		 <p>Director</p>
		 Morris County Agriculture Development Board<br>
		 Morris County Office of Planning & Preservation<br>
		 P.O. Box 900<br>
		 Morristown, NJ 07963-0900<br>
		 Phone: (973) 829-8120
		 Fax: (973) 326-9025<br>
		 E-Mail: kcoyle@co.morris.nj.us<br>
		 Website: https://www.morriscountynj.v/agriculture </p>', 
1);


INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
11,		'CHANGE_STATUS_FROM_IN_POST_CLOSING_TO_PRESERVED', 
		'Change status From Post_Closing to Preserved', 
		'Easement Purchase Program - {{FarmName}}',
		'<p>Re: Morris County Agriculture Development Board</p>

		 <p>NOTICE OF PURCHASE OF DEVELOPMENT EASEMENT</p>

		 <p>Please take notice that the following property has been permanently preserved with funding from the Morris County Open Space, 
		   Recreation, Farmland and Historic Preservation Trust through the Morris County Agriculture Development Board:</p>
		
		<p>Landowner: {{OwnerFirst}} {{OwnerLast}} </p>
		<p> Municipality: {{Municipality}}</p>
		<p>Block/Lot: {{Block}}/{{Lot}} </p>
		<p>Acres Preserved: {{Acres}} </p>

		<p> The Deed has been filed at the Morris County Hall of Records in Deed Book {{DeedBook}} at Page {{DeedPage}}. A copy is enclosed. If you have any questions regarding this matter please contact me at (973) 829 8120 or at kcoyle@co.morris.nj.us. </p>

		<p>Per N.J.A.C. 2:76-6.13(d)2, the Notice of Development Easement Purchase is also being forwarded to: </p>
		<p>Morris County Planning Board </p>
		<p>Municipal verning Body </p>
		<p>Municipal Tax Assessor </p>
		<p>Municipal Planning Board </p>
		<p>Morris County Soil Conservation District </p>', 
1);


INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
12,		'FEEDBACK_RECEIVED_EMAIL', 
		'Feedback Received Email',
		'Farm Preservation Application - {{FarmName}}',
		 '<p>Dear {{PrimaryContactName}},</p>
		 <p>You have received the feedback for the {{ApplicationName}} application from the Morris County Farm Program.</p>
		 <p>Kindly login to Morris County Preservation Trust and select the application to view feedback.</p>
		 <br>
		  Sincerely,</p>
	     <p>{{ProgramAdmin}</p>
		 <p>Farm Preservation Program Coordinator</p>', 
1);


--RAS
INSERT INTO [Farm].[FarmEmailTemplate] ([Id] , [TemplateCode], [Title], [Subject], [Description], [IsActive]) VALUES  (
		 13,		
		'FARM_MONITORING', 
		'Farm Monitoring',
		'Farm Land Monitoring',
		'<p>Dear {{PrimaryContactName}},</p>
<p>It is time for our annual monitoring.The State Agriculture Development Committee''s (SADC?s) Regulation N.J.A.C. 2:76-6.18A(d) requires the Morris County Agriculture Development Board (Morris CADB) to perform annual onsite inspections of all permanently preserved farms. The purpose of the inspection is to ensure that each farm is in compliance with the terms of the Deed of Easement. </p>
<br>
<p>Morris CADB staff will be performing a site inspection of your farm between {{MonitoringDateStart}} and {{MonitoringDateEnd}}. We may utilize a drone to help us inspect the farm in a more time-efficient manner. Your presence is not required. We are unable to give you an exact date as to when we will be on your specific property. If, however, you require a set time for the inspection, please contact our office at your earliest convenience. In addition, if access to the property is blocked (locked gates), please contact our office to schedule an appointment so that we may access the farm. Upon completion, an inspection report will be mailed to you for your review.</p>
<p>Thank you for your anticipated cooperation with the monitoring process and for supporting the Farmland Preservation Program.</p><br>
		Sincerely,</p>
<p>{{ProgramAdmin}}<br>
 
		<p>Director</p>
		Morris County Agriculture Development Board<br>
		Morris County Office of Planning & Preservation<br>
		P.O. Box 900<br>
		Morristown, NJ 07963-0900<br>
		Phone: (973) 829-8120
		Fax: (973) 326-9025<br>
		E-Mail: kcoyle@co.morris.nj.us<br>
		Website: https://www.morriscountynj.v/Departments/County-Agriculture-Development-Board </p>', 
1);



		---106
		DELETE FROM  [Farm].[FarmAppCommentType];

        INSERT INTO [Farm].[FarmAppCommentType]([Id], [Title]) VALUES (1, 'General Comment');
        
        INSERT INTO [Farm].[FarmAppCommentType]([Id], [Title]) VALUES (2, 'Staff Comment');
        
        INSERT INTO [Farm].[FarmAppCommentType]([Id], [Title]) VALUES (3, 'Application Comment');

		---201
		DELETE FROM [Farm].[FarmEsmtAttachmentDActivityType]

        SET IDENTITY_INSERT [Farm].[FarmEsmtAttachmentDActivityType] ON;
        
        INSERT INTO [Farm].[FarmEsmtAttachmentDActivityType] ([Id],[Title]) VALUES (1,'BREEDING');
        
        INSERT INTO [Farm].[FarmEsmtAttachmentDActivityType] ([Id],[Title]) VALUES (2,'BOARDING');
        
        INSERT INTO [Farm].[FarmEsmtAttachmentDActivityType] ([Id],[Title]) VALUES (3,'TRAINING');
        
        INSERT INTO [Farm].[FarmEsmtAttachmentDActivityType] ([Id],[Title]) VALUES (4,'RIDING_AND_OR_DRIVING_LESSIONS');
        
        INSERT INTO [Farm].[FarmEsmtAttachmentDActivityType] ([Id],[Title]) VALUES (5,'REHABILITATION');
        
        INSERT INTO [Farm].[FarmEsmtAttachmentDActivityType] ([Id],[Title]) VALUES (6,'CLINICS');
        
        INSERT INTO [Farm].[FarmEsmtAttachmentDActivityType] ([Id],[Title]) VALUES (7,'OPEN_HOUSES');
        
        INSERT INTO [Farm].[FarmEsmtAttachmentDActivityType] ([Id],[Title]) VALUES (8,'DEMONSTRATIONS');
        
        INSERT INTO [Farm].[FarmEsmtAttachmentDActivityType] ([Id],[Title]) VALUES (9,'EDUCATIONAL_CAMPS');
        
        INSERT INTO [Farm].[FarmEsmtAttachmentDActivityType] ([Id],[Title]) VALUES (10,'FARM_EVENTS');
        
        INSERT INTO [Farm].[FarmEsmtAttachmentDActivityType] ([Id],[Title]) VALUES (11,'COMPETITIONS');
        
        INSERT INTO [Farm].[FarmEsmtAttachmentDActivityType] ([Id],[Title]) VALUES (12,'RODEOS');

		---202
		DELETE FROM [Farm].[FarmEsmtAgricultureProdSourceType];

        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (1,'0111','WHEAT_CASH_GRAIN_FARMS', 1, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (2,'0112','RICE_CASH_GRAIN_FARMS', 2, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (3,'0115','CORN_CASH_GRAIN_FARMS', 3, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (4,'0116','SOYBEANS_CASH_GRAIN_FARMS', 4, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (5,'0119','CASH_GRAIN_NEC', 5, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (6,'0134','IRISH_POTATOES_FIELD_CROP_FARMS', 6, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (7,'0139','FIELD_CROPS_EXCEPT_CASH_GRAINS', 7, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (8,'0161','VEGETABLES_AND_MELON_FARMS', 8, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (9,'0171','BERRY_FARMS', 9, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (10,'0174','CITRUS_FRUIT_FARMS', 10, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (11,'0175','DECIDUOUS_TREE_FRUIT_FARMS', 11, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (12,'0179','FRUIT_AND_TREE_NUT_FARM_NEC', 12, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (13,'0181','ORNAMENT_NURSERY_PRODUCTS', 13, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (14,'0182','FOOD_CROPS_GROWN_UNDERCOVER', 14, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (15,'0189','HORTICULTURE_SPECIALTIES', 15, 1);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (16,'0191A','GENERAL_FARMING_NEC', 16, 1); 
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (17,'0211','BEEF_CATTLE_FEEDLOTS', 17, 2);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (18,'0212','BEEF_CATTLE_EXCEPT_FEEDLOTS', 18, 2);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (19,'0213','HOGS', 19, 2);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (20,'0214','SHEEP_AND_GOATS', 20, 2);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (21,'0219','GENERAL_LIVESTOCK_NEC', 21, 2);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (22,'0241','DAIRY_FARMS', 22, 2);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (23,'0251','FOWLS_BROILERS_AND_FRYERS', 23, 2);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (24,'0252','CHICKEN_EGGS', 24, 2);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (25,'0253','TURKEYS_AND_TURKEY_EGGS', 25, 2);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (26,'0259','POULTRY_AND_EGGS_NEC', 26, 2);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (27,'0272','HORSE_AND_OTHER_EQUINE', 27, 2);
        
        INSERT INTO [Farm].[FarmEsmtAgricultureProdSourceType] ([Id],[SicCode],[Title], [SortOrder], [ActivityTypeId]) VALUES (28,'0291','GENERAL_FARM_LIVESTOCK', 28, 2);


			--==============================================================================================================--
	--SELECT 1/0;
	COMMIT;
	print 'SUCCESS';
END TRY
BEGIN CATCH
    DECLARE @ErrorMessage NVARCHAR(4000); 

	SET   @ErrorMessage = ERROR_MESSAGE();
	ROLLBACK;

	SELECT @ErrorMessage;	
END CATCH