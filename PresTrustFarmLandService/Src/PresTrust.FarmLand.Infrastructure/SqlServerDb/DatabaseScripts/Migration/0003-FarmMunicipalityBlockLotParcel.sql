
 BEGIN TRY
	BEGIN TRANSACTION

	--===================================================================================================================================================
DROP TABLE IF EXISTS #FarmMunicipalityBlockLotParcel


-- Create Table
CREATE TABLE #FarmMunicipalityBlockLotParcel(
	[Id]					[int] IDENTITY(1,1)		 NOT NULL,
	[MunicipalityId]	    [varchar](4)			 NOT NULL,
	[FarmListID]            [int]					 NOT NULL,
	[PropertyClassCode]     [varchar](50)			 NULL,
	[DeedBook]              [varchar](50)			 NULL,			
	[DeedPage]              [varchar](50)			 NULL,			
	[DeedDate]              [date]					 NULL,					 
	[Block]                 [varchar](50)		     NULL,
	[Lot]					[varchar](50)            NULL,
	[QualificationCode]     [varchar](50)            NULL,
	[Section]               [varchar](128)           NULL,
	[Partial]               [bit]                    NULL,
	[Acres]                 [numeric](10, 3)         NULL,
	[AcresToBeAcquired]     [numeric](10, 3)         NULL,
	[ExceptionAreaAcres]    [numeric](10, 3)         NULL,
	[ExceptionArea]         [bit]                    NULL,
	[Notes]                 [varchar](max)           NULL,
	[PamsPin]               [varchar](100)           NULL,
	[IsValidFeatureId]      [bit]                    NULL,
	[IsValidPamsPin]        [bit]                    NULL,
	[InterestType]          [varchar](100)           NULL,
	[EasementId]            [varchar](100)           NULL,
	[ChangeType]            [varchar](100)           NULL,
	[ChangeDate]            [datetime]               NULL,
	[ReasonForChange]       [varchar](max)           NULL,
	[IsActive]              [bit]                    NULL,
	[Status]	            [varchar](50)            NULL,
	[IsWarning]             [bit]                    NULL,
	[CreatedByProgramUser]  [bit]                    NULL,
	[LastUpdatedOn]         [datetime]               NOT NULL,
	[LastUpdatedBy]         [varchar](256)           NOT NULL,
CONSTRAINT [PK_FarmMunicipalityBlockLotParcel_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
)ON [PRIMARY]


	   INSERT INTO [Farm].[FarmMunicipalityBlockLotParcel]
		(
			 [MunicipalityId]	    
			,[FarmListID]            
			,[PropertyClassCode]     
			,[DeedBook]              
			,[DeedPage]              
			,[DeedDate]              
			,[Block]                 
			,[Lot]					
			,[QualificationCode]     
			,[Section]               
			,[Partial]               
			,[Acres]                 
			,[AcresToBeAcquired]     
			,[ExceptionAreaAcres]    
			,[ExceptionArea]         
			,[Notes]                 
			,[PamsPin]               
			,[IsValidFeatureId]      
			,[IsValidPamsPin]        
			,[InterestType]          
			,[EasementId]            
			,[ChangeType]            
			,[ChangeDate]            
			,[ReasonForChange]       
			,[IsActive]              
			,[Status]	            
			,[IsWarning]             
			,[CreatedByProgramUser]  
			,[LastUpdatedOn]         
			,[LastUpdatedBy]         
			)
            VALUES
			(1418,252,'3A',22792,428,'2015-09-28','1401','7',NULL, 
		     0,0,0,7.5,0,0,NULL,'1418_1401_7',NULL,NULL,
		     NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
			 
			 (1438,248,NULL,0,0,NULL,'32.02','2',NULL,
			 0,0,0,8,0,0,NULL,'1438_32.02_2',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

			(1438,248,'3A',3760,93,NULL,'32.02','3',NULL,
			0,0,0,8,0,0,NULL,'1438_32.03_3',NULL,NULL,
			NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
			 
			 (1438,175,'3A',0,0,NULL,'20.10','44',NULL,
		 0,0,0,55.54,0,0,NULL,'1438_20.10_44',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),'') ,
		 
		 (1407,127,NULL,0,0,NULL,'46.01','35',NULL,
		 0,0,0,26,0,0,NULL,'1407_46.01_35',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

		  (1407,127,NULL,0,0,NULL,'33','113.01',NULL,
		 0,0,0,26,0,0,NULL,'1407_33_113.01',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

		 (1407,127,'3A',23057,532,'2016-10-28','33','113.02',NULL,
		 0,0,0,26,0,0,NULL,'1407_33_113.02',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1407,127,NULL,0,0,NULL,'6000','4',NULL,
		 0,0,0,26,0,0,NULL,'1407_6000_4',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1407,113,NULL,0,0,NULL,'15','24',NULL,
		 0,0,0,59.833,0,0,NULL,'1407_15_24',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1407,113,NULL,0,0,NULL,'15','28',NULL,
		 0,0,0,59.833,0,0,NULL,'1407_15_28',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

		 (1407,113,NULL,0,0,NULL,'15','33',NULL,
		 0,0,0,59.833,0,0,NULL,'1407_15_33',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

		 (1407,113,NULL,0,0,NULL,'15','34',NULL,
		 0,0,0,59.833,0,0,NULL,'1407_15_34',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

		 (1407,113,NULL,0,0,NULL,'15','26',NULL,
		 0,0,0,59.833,0,0,NULL,'1407_15_26',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

		 (1407,113,NULL,0,0,NULL,'19','11',NULL,
		 0,0,0,59.833,0,0,NULL,'1407_19_11',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1407,108,'3A',6191,46,'2004-10-20','17','33',NULL, 
		 0,0,0,16.501,0,0,NULL,'1407_17_33',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

		  (1407,108,NULL,0,0,NULL,'17','50',NULL, 
		 0,0,0,16.501,0,0,NULL,'1407_17_50',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

		 (1407,77,NULL,0,0,NULL,'15','42HL',NULL,
		 0,0,0,60.6,0,0,NULL,'1407_15_42HL',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

		 (1438,54,NULL,0,0,NULL,'34','37',NULL, 
		 0,0,0.00,0,0,0,NULL,'1438_34_37',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,53,'3A',2759,726,NULL,'55','15',NULL,
		 0,0,0,12.10,0,0,NULL,'1438_55_15',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,46,'3A',24696,185,'2023-12-14','28','4',NULL,
		 0,0,0,10,0,0,NULL,'1438_28_4',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

		  (1438,43,NULL,0,0,NULL,'34','39',NULL,
		 0,0,0,59,0,0,NULL,'1438_34_39',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1430,30,NULL,0,0,NULL,'194','6',NULL,
		 0,0,0.00,0,0,0,NULL,'1430_194_6',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1430,30,NULL,0,0,NULL,'194','6.1',NULL,
		 0,0,0.00,0,0,0,NULL,'1430_194_6.1',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1430,30,NULL,0,0,NULL,'194','41',NULL,
		 0,0,0.00,0,0,0,NULL,'1430_194_41',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		  (1430,30,NULL,0,0,NULL,'225','11',NULL,
		 0,0,0.00,0,0,0,NULL,'1430_225_11',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		(1430,30,NULL,0,0,NULL,'225','12',NULL,
		 0,0,0.00,0,0,0,NULL,'1430_225_12',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1430,30,NULL,0,0,NULL,'225','10.01',NULL,
		 0,0,0.00,0,0,0,NULL,'1430_225_10.01',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		(1430,30,NULL,0,0,NULL,'225','13',NULL,
		 0,0,0.00,0,0,0,NULL,'1430_225_13',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,29,NULL,0,0,NULL,'55','6',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_55_6',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,29,NULL,0,0,NULL,'55','8',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_55_8',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,29,NULL,0,0,NULL,'55','28',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_55_28',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,28,NULL,0,0,NULL,'33','70',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_33_70',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,27,NULL,0,0,NULL,'55','20',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_55_20',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,26,'3A',3021,344,NULL,'55','14',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_55_14',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		  (1438,26,NULL,0,0,NULL,'55','14.1',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_55_14.1',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,22,NULL,0,0,NULL,'28','16',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_28_16',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,22,NULL,0,0,NULL,'28','16.1',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_28_16.1',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		(1438,22,NULL,0,0,NULL,'28','16.2',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_28_16.2',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,22,'3A',24322,453,'2021-11-09','36','41',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_36_41',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,21,NULL,0,0,NULL,'33','51',NULL,
		 0,0,0,39.5,0,0,NULL,'1438_33_51',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,21,'3A',22579,198,'2014-08-12','34','50',NULL,
		 0,0,0,39.5,0,0,NULL,'1438_34_50',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,20,'2',5486,16,'2001-10-04','34','38',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_34_38',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		  (1438,17,NULL,0,0,NULL,'62','6',NULL,
		 0,0,0,9.63,0,0,NULL,'1438_62_6',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		  (1438,14,NULL,0,0,NULL,'55','4.07',NULL,
		 0,0,0,20.28,0,0,NULL,'1438_55_4.07',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

		  (1438,11,NULL,0,0,NULL,'46','6',NULL,
		 0,0,0,11.993,0,0,NULL,'1438_46_6',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,11,NULL,0,0,NULL,'46','6.1',NULL,
		 0,0,0,11.993,0,0,NULL,'1438_46_6.1',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,11,NULL,0,0,NULL,'46','7',NULL,
		 0,0,0,11.993,0,0,NULL,'1438_46_7',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,10,NULL,0,0,NULL,'2','27',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_2_27',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,10,NULL,0,0,NULL,'2','28.1',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_2_28.1',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		(1438,10,NULL,0,0,NULL,'2','28.2',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_2_28.2',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1438,6,'3A',23571,1494,'2019-06-20','37','26',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_37_26',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		  (1438,6,NULL,0,0,NULL,'37','39',NULL,
		 0,0,0.00,0,0,0,NULL,'1438_37_39',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 (1407,254,'15C',5323,124,'2001-01-22','10','52',NULL,
		 0,0,0,79,0,0,NULL,'1407_10_52',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		(1407,254,'15C',5695,76,'2002-08-15','10','107',NULL,
		 0,0,0,79.0,0,0,NULL,'1407_10_107',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
		 
		 
		(1407,255,'2',22994,62,'2016-07-27','16.01','1',NULL,
		 0,0,0.00,89,0,0,NULL,'1407_16.01_1',NULL,NULL,
		 NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

		 ------------------------------------------------------------
		 -----------      ESMT Parcels  ----------------------------
		 ------------------------------------------------------------

		 (1438,1,'1',23497,782,'2019-02-13','22','8',NULL,
         0,0,0,22,0,0,NULL,'1438_22_8',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,1,'3A',23376,1604,'2018-06-06','22','28',NULL,	
          0,0,0,22,0,0,NULL,'1438_22_28',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,1,'3B',NULL,NULL,NULL,'22','28','QFARM',	
          0,0,0,22,0,0,NULL,'1438_22_28_QFARM',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,2,'3A',2913,141,'1986-12-12','20','46',NULL,
          0,0,0,40,0,0,NULL,'1438_20_46',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,3,'3A',24818,975,'2024-10-01','60','20',NULL,
          0,0,0,18,0,0,NULL,'1438_60_20',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1427,4,'3A',3546,56,'1992-01-21','900','3',NULL,
          0,0,0,23.70,0,0,NULL,'1427_900_3',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,5,NULL,NULL,NULL,NULL,'60','1',NULL,
          0,0,0,29.05,0,0,NULL,'1438_60_1',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,5,NULL,NULL,NULL,NULL,'60','5',NULL,
          0,0,0,29.05,0,0,NULL,'1438_60_5',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,6,'3A',23571,1494,'2019-06-20','37','26',NULL,
          0,0,0,32.56,0,0,NULL,'1438_37_26',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,6,'3A',23571,1494,'2019-06-20','37','26.03',NULL,	
          0,0,0,32.56,0,0,NULL,'1438_37_26.03',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,6,'3A',23571,1494,'2019-06-20','37','26.04',NULL,	
          0,0,0,32.56,0,0,NULL,'1438_37_26.04',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,7,'3A',23874,1624,'2020-08-13','55','10',NULL,
          0,0,0,53.13,0,0,NULL,'1438_55_10',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,8,'3A',22745,1756,'2015-04-28','55','11',NULL,
          0,0,0,78.90,0,0,NULL,'1438_55_11',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,9,'3A',20983,1418,'2007-12-14','34','40',NULL,
          0,0,0,65.58,0,0,NULL,'1438_34_40',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,10,NULL,NULL,NULL,NULL,'22','27.01',NULL,
          0,0,0,6.33,0,0,NULL,'1438_27_01',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,10,NULL,NULL,NULL,NULL,'22','28.03',NULL,
          0,0,0,6.33,0,0,NULL,'1438_28_03',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,11,'3A',23348,650,'2018-05-09','46','6.01',NULL,
          0,0,0,16.42,0,0,NULL,'1438_46_6.01',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,11,NULL,NULL,NULL,NULL,'46','7',NULL,
          0,0,0,16.42,0,0,NULL,'1438_46_7',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,12,NULL,NULL,NULL,NULL,'34','41',NULL,
          0,0,0,78.09,0,0,NULL,'1438_34_41',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,13,'3A',21907,710,'2011-11-14','34','42',NULL,
          0,0,0,78.09,0,0,NULL,'1438_34_42',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,12,NULL,NULL,NULL,NULL,'34','45',NULL,
          0,0,0,78.09,0,0,NULL,'1438_34_45',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,12,NULL,NULL,NULL,'2011-11-14','34','46.02',NULL,
          0,0,0,78.09,0,0,NULL,'1438_34_46.02',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,13,'3A',22959,123,'2016-07-21','60','19',NULL,
          0,0,0,29.05,0,0,NULL,'1438_60_19',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,14,NULL,NULL,NULL,NULL,'55','4.07',NULL,
          0,0,0,20.28,0,0,NULL,'1438_55_4.07',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,15,'2',24764,933,'2024-05-31','43','66',NULL,
          0,0,0,135.69,0,0,NULL,'1438_43_66',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,16,'3A',20888,930,'2007-07-10','43','54',NULL,
          0,0,0,86.40,0,0,NULL,'1438_43_54',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,17,'3A',23462,1448,'2018-12-05','42.03','23',NULL,	
          0,0,0,14.51,0,0,NULL,'1438_42.03_23',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,17,NULL,NULL,NULL,NULL,'62','6',NULL,
          0,0,0,14.51,0,0,NULL,'1438_62_6',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,18,NULL,NULL,NULL,NULL,'60','15.02',NULL,
          0,0,0,28.01,0,0,NULL,'1438_60_15.02',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1408,19,'2',24553,1766,'2022-12-20','21101','2',NULL,
          0,0,0,19.86,0,0,NULL,'1408_21101_2',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,20,'2',5486,16,'2001-10-04','34','38',NULL,	
          0,0,0,14,0,0,NULL,'1438_34_38',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,21,NULL,NULL,NULL,NULL,'33','51',NULL,
          0,0,0,39.6,0,0,NULL,'1438_33_51',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,21,'3A',22579,198,'2014-08-12','34','50',NULL,	
          0,0,0,39.6,0,0,NULL,'1438_34_50',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,22,NULL,NULL,NULL,NULL,'28','16',NULL,
          0,0,0,27.78,0,0,NULL,'1438_28_16',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,22,'3A',24322,453,'2021-11-09','28','16.01',NULL,	
          0,0,0,27.78,0,0,NULL,'1438_28_16.01',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,22,NULL,NULL,NULL,NULL,'28','16.02',NULL,
          0,0,0,27.78,0,0,NULL,'1438_28_16.02',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,22,'3A',24322,453,'2021-11-09','36','41',NULL,	
          0,0,0,27.78,0,0,NULL,'1438_36_41',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,23,'3A',24491,1835,NULL,'29','18',NULL,
          0,0,0,57.04,0,0,NULL,'1438_29_18',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,23,NULL,NULL,NULL,NULL,'29','18.01',NULL,
          0,0,0,57.04,0,0,NULL,'1438_29_18.01',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,24,'3A',4452,195,'1996-09-24','34','35',NULL,
          0,0,0,57.25,0,0,NULL,'1438_34_35',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,24,NULL,NULL,NULL,NULL,'34','36',NULL,
          0,0,0,57.25,0,0,NULL,'1438_34_36',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,25,NULL,NULL,NULL,NULL,'22','27',NULL,
          0,0,0,15.39,0,0,NULL,'1438_22_27',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,25,NULL,NULL,NULL,NULL,'22','28.01',NULL,
          0,0,0,15.39,0,0,NULL,'1438_22_28.01',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,25,'3A',22426,83,'2013-08-05','22','28.02',NULL,	
          0,0,0,15.39,0,0,NULL,'1438_22_28.02',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,26,'3A',3021,344,NULL,'55','14',NULL,	
          0,0,0,37.45,0,0,NULL,'1438_55_14',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,26,NULL,NULL,NULL,NULL,'55','14.01',NULL,
          0,0,0,37.45,0,0,NULL,'1438_55_14.01',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,27,NULL,NULL,NULL,NULL,'55','20',NULL,
          0,0,0,59.04,0,0,NULL,'1438_55_20',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,28,NULL,NULL,NULL,NULL,'33','70',NULL,
          0,0,0,25.76,0,0,NULL,'1438_33_70',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,29,NULL,NULL,NULL,NULL,'55','6',NULL,
          0,0,0,25.82,0,0,NULL,'1438_55_6',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,29,NULL,NULL,NULL,NULL,'55','8',NULL,
          0,0,0,25.82,0,0,NULL,'1438_55_8',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,29,NULL,NULL,NULL,NULL,'55','28',NULL,
          0,0,0,25.82,0,0,NULL,'1438_55_28',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1430,30,NULL,NULL,NULL,NULL,'194','31',NULL,
          0,0,0,7.64,0,0,NULL,'1438_194_31',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1430,30,NULL,NULL,NULL,NULL,'194','31.01',NULL,
          0,0,0,7.64,0,0,NULL,'1438_194_31.01',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1430,30,NULL,NULL,NULL,NULL,'194','41',NULL,
          0,0,0,7.64,0,0,NULL,'1438_194_41',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1430,32,NULL,NULL,NULL,NULL,'225','11',NULL,
          0,0,0,7.64,0,0,NULL,'1438_225_11',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1430,30,NULL,NULL,NULL,NULL,'225','12',NULL,
          0,0,0,7.64,0,0,NULL,'1438_225_12',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1430,30,NULL,NULL,NULL,NULL,'225','12.01',NULL,
          0,0,0,7.64,0,0,NULL,'1438_225_12.01',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1430,30,NULL,NULL,NULL,NULL,'225','13',NULL,
          0,0,0,7.64,0,0,NULL,'1438_225_13',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1421,31,'3A',5600,10,'2002-03-20','32','28',NULL,
          0,0,0,26.93,0,0,NULL,'1421_32_28',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,32,'4A',6015,153,'2003-12-19','35','6',NULL,
          0,0,0,56.45,0,0,NULL,'1438_35_6',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,32,NULL,NULL,NULL,NULL,'35','8',NULL,
          0,0,0,56.45,0,0,NULL,'1438_35_8',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1427,33,'3A',5413,128,'2001-06-27','8300','13',NULL,
          0,0,0,51.03,0,0,NULL,'1427_8300_13',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,34,'3A',5925,168,'2003-08-18','12','37.03',NULL,
          0,0,0,77.54,0,0,NULL,'1438_12_37.03',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
         (1438,35,'3A',24399,1641,'2022-02-22','30','35',NULL,
          0,0,0,115.31,0,0,NULL,'1438_30_35',NULL,NULL,
         NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),

        (1438,36,'3B',NULL,NULL,NULL,'21','2','QFARM',
         0,0,0,16.67,0,0,NULL,'1438_21_2_QFARM',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,36,'15D',NULL,NULL,NULL,'30','30',NULL,
         0,0,0,16.67,0,0,NULL,'1438_30_30',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,36,'15D',NULL,NULL,NULL,'30','34',NULL,
         0,0,0,16.67,0,0,NULL,'1438_30_34',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,36,'15D',2599,245,'1981-07-21','30','34.02',NULL,
         0,0,0,16.67,0,0,NULL,'1438_30_34.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,36,'3B',2643,888,'1982-10-01','30','34.03',NULL,
         0,0,0,16.67,0,0,NULL,'1438_30_34.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,36,'15D',2599,245,'1981-07-21','30','42',NULL,
         0,0,0,16.67,0,0,NULL,'1438_30_42',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,37,'4A',NULL,NULL,NULL,'20','9',NULL,
         0,0,0,18.29,0,0,NULL,'1432_20_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,38,'3A',4602,13,'1997-07-15','60','15',NULL,
         0,0,0,69.42,0,0,NULL,'1438_60_15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1402,39,'3A',23449,865,'2018-10-29','40101','1',NULL,
         0,0,0,57,0,0,NULL,'1402_40101_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,40,NULL,NULL,NULL,NULL,'34','13',NULL,
         0,0,55.04,0,0,0,NULL,'1438_34_13',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,40,NULL,NULL,NULL,NULL,'34','28',NULL,
         0,0,0,55.04,0,0,NULL,'1438_34_28',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,40,NULL,NULL,NULL,NULL,'34','29',NULL,
         0,0,0,55.04,0,0,NULL,'1438_34_29',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,40,NULL,NULL,NULL,NULL,'34','43',NULL,
         0,0,0,55.04,0,0,NULL,'1438_34_43_QFARM',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,40,'3A',21948,1220,'2011-12-28','34','44',NULL,
         0,0,0,55.04,0,0,NULL,'1438_34_44',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,40,'4A',6005,284,'2003-12-30','34','46',NULL,
         0,0,0,55.04,0,0,NULL,'1438_34_46',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,40,NULL,NULL,NULL,NULL,'34','46.01',NULL,
         0,0,0,55.04,0,0,NULL,'1438_34_46.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1402,41,NULL,NULL,NULL,NULL,'21601','17',NULL,
         0,0,0,36.19,0,0,NULL,'1402_21601_17',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,42,'3A',22682,1,'2015-02-25','12','1.01',NULL,	
         0,0,0,12.65,0,0,NULL,'1407_12_1.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,42,'3A',22682,8,'2015-02-25','12','3.02',NULL,	
         0,0,0,12.65,0,0,NULL,'1407_12_3.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,43,NULL,NULL,NULL,NULL,'34','39',NULL,
         0,0,0,56.85,0,0,NULL,'1438_34_39',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,44,'2',21149,1362,'2008-07-01','54','29',NULL,
         0,0,0,43.92,0,0,NULL,'1438_54_29',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,45,'3A',21094,604,'2008-05-13','33','2.01',NULL,	
         0,0,0,25.30,0,0,NULL,'1407_33_2.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,46,'3A',24696,185,'2023-12-14','28','4',NULL,	
         0,0,0,25.20,0,0,NULL,'1438_28_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,47,'3A',5240,113,'2000-08-16','28','63',NULL,
         0,0,0,23.51,0,0,NULL,'1438_28_63',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,47,NULL,NULL,NULL,NULL,'28','63.01',NULL,
         0,0,0,23.51,0,0,NULL,'1438_28_63.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1408,48,NULL,NULL,NULL,NULL,'5003','2',NULL,
         0,0,0,3.75,0,0,NULL,'1438_5003_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1408,48,NULL,NULL,NULL,NULL,'5003','2','QFarm',
         0,0,0,3.75,0,0,NULL,'1438_5003_2_QFarm',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,49,'3A',22639,1885,'2014-11-29','107','44',NULL,
         0,0,0,27.46,0,0,NULL,'1419_107_44',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,49,NULL,NULL,NULL,NULL,'107','45',NULL,	
         0,0,0,27.46,0,0,NULL,'1419_107_45',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,50,NULL,NULL,NULL,NULL,'55','5.03',NULL,	
         0,0,0,10.12,0,0,NULL,'1438_55_5.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,50,NULL,NULL,NULL,NULL,'55','5.04',NULL,	
         0,0,0,10.12,0,0,NULL,'1438_55_5.04',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,51,NULL,NULL,NULL,NULL,'52','1',NULL,
         0,0,0,40.05,0,0,NULL,'1438_52_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,52,'3A',21140,858,'2008-06-20','51','2',NULL,
         0,0,0,153.21,0,0,NULL,'1438_51_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,53,'3A',2759,726,NULL,'55','15',NULL,	
         0,0,0,12.10,0,0,NULL,'1438_55_15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,54,NULL,NULL,NULL,NULL,'34','37',NULL,
         0,0,0,24.71,0,0,NULL,'1438_34_37',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,55,'3A',22216,809,'2012-12-18','16.02','5',NULL,
         0,0,0,21.14,0,0,NULL,'407_16.02_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,56,'3A',21040,931,'2008-03-05','15','9',NULL,
         0,0,0,50.75,0,0,NULL,'1407_15_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,57,NULL,NULL,NULL,NULL,'28','4.01',NULL,	
         0,0,0,44.43,0,0,NULL,'1438_28_4.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,58,'3A',5343,143,'2001-01-30','12','1.03',NULL,
         0,0,0,48.33,0,0,NULL,'1407_12_1.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,59,NULL,NULL,NULL,NULL,'114','4',NULL,
         0,0,0,26.71,0,0,NULL,'1407_114_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,59,NULL,NULL,NULL,NULL,'114','15',NULL,
         0,0,0,26.71,0,0,NULL,'1407_114_15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,60,NULL,NULL,NULL,NULL,'13','7',NULL,
         0,0,0,61.58,0,0,NULL,'1407_13_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,60,NULL,NULL,NULL,NULL,'13','8',NULL,
         0,0,0,61.58,0,0,NULL,'1407_13_8',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,60,'3A',23118,582,'2017-04-03','15','45',NULL,	
         0,0,0,61.58,0,0,NULL,'1407_15_45',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,63,NULL,NULL,NULL,NULL,'82','39',NULL,	
         0,0,0,20.8,0,0,NULL,'1432_82_39',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,61,'4A',NULL,NULL,NULL,'119','114',NULL,	
         0,0,0,20.8,0,0,NULL,'1432_119_114',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,62,'3A',NULL,NULL,NULL,'12.01','59',NULL,
         0,0,0,3.81,0,0,NULL,'1438_12.01_59',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,62,NULL,NULL,NULL,NULL,'12.01','60.03',NULL,	
         0,0,0,3.81,0,0,NULL,'1438_12.01_60.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,62,NULL,NULL,NULL,NULL,'12.01','61',NULL,	
         0,0,0,3.81,0,0,NULL,'1438_12.01_61',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,63,'15B',23129,588,'2017-05-11','51','22.02',NULL,
         0,0,0,58.76,0,0,NULL,'1438_51_22.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,64,'3A',NULL,NULL,NULL,'52','3',NULL,
         0,0,0,93.96,0,0,NULL,'1438_52_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,65,'3A',6504,121,'2005-12-08','55','3',NULL,
         0,0,0,64.40,0,0,NULL,'1438_55_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,66,'3A',5423,84,'2001-06-13','28','17.03',NULL,
         0,0,0,11.72,0,0,NULL,'1438_28_17.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,67,'3A',22028,1789,'2012-04-20','8300','3',NULL,
         0,0,0,23.14,0,0,NULL,'1427_8300_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,67,NULL,NULL,NULL,NULL,'8300','4',NULL,	
         0,0,0,23.14,0,0,NULL,'1427_8300_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,67,NULL,NULL,NULL,'2012-04-20','900','1',NULL,	
         0,0,0,23.14,0,0,NULL,'1427_900_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,68,'3A',24357,778,'2022-02-01','8','2',NULL,	
         0,0,0,3.25,0,0,NULL,'1413_8_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,68,NULL,NULL,NULL,NULL,'8','2.01',NULL,
         0,0,0,3.25,0,0,NULL,'1413_8_2.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,68,NULL,NULL,NULL,NULL,'8','2.02',NULL,
         0,0,0,3.25,0,0,NULL,'1413_8_2.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,69,NULL,NULL,NULL,NULL,'45','1.01',NULL,	
         0,0,0,3.72,0,0,NULL,'1432_45_1.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,70,NULL,NULL,NULL,NULL,'55','15.01',NULL,	
         0,0,0,11.62,0,0,NULL,'1438_55_15.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,71,NULL,NULL,NULL,NULL,'51','14',NULL,	
         0,0,0,20.50,0,0,NULL,'1438_51_14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,71,NULL,NULL,NULL,NULL,'51','15',NULL,	
         0,0,0,20.50,0,0,NULL,'1438_51_15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,71,NULL,NULL,NULL,NULL,'51','16',NULL,	
         0,0,0,20.50,0,0,NULL,'1438_51_16',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,71,NULL,NULL,NULL,NULL,'51','17',NULL,	
         0,0,0,20.50,0,0,NULL,'1438_51_17',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,71,NULL,NULL,NULL,NULL,'51','19',NULL,	
         0,0,0,20.50,0,0,NULL,'1438_51_19',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,72,NULL,NULL,NULL,NULL,'36','20',NULL,	
         0,0,0,20.44,0,0,NULL,'1438_36_20',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,72,NULL,NULL,NULL,NULL,'36','17',NULL,	
         0,0,0,20.44,0,0,NULL,'1438_36_17',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,72,NULL,NULL,NULL,NULL,'36','19',NULL,	
         0,0,0,20.44,0,0,NULL,'1438_36_19',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,72,NULL,NULL,NULL,NULL,'36','21',NULL,	
         0,0,0,20.44,0,0,NULL,'1438_36_21',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,72,'3A',6011,48,'2003-12-31','37','22',NULL,	
         0,0,0,20.44,0,0,NULL,'1438_37_22',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,72,'3A',24472,1940,'2022-07-22','37','17',NULL,	
         0,0,0,20.44,0,0,NULL,'1438_37_17',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,72,NULL,NULL,NULL,NULL,'37','15.01',NULL,	
         0,0,0,20.44,0,0,NULL,'1438_37_15.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,72,NULL,NULL,NULL,NULL,'37','23.02',NULL,	
         0,0,0,20.44,0,0,NULL,'1438_37_23.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,72,NULL,NULL,NULL,NULL,'37','28',NULL,	
         0,0,0,20.44,0,0,NULL,'1438_37_28',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,73,NULL,NULL,NULL,NULL,'28','18',NULL,	
         0,0,0,37.91,0,0,NULL,'1438_28_18',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,74,NULL,NULL,NULL,NULL,'35','50',NULL,	
         0,0,0,9.23,0,0,NULL,'1432_35_50',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,74,NULL,NULL,NULL,NULL,'35','50.16',NULL,
         0,0,0,9.23,0,0,NULL,'1432_35_50.16',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,74,'3A',5110,266,'1999-12-23','35','52',NULL,	
         0,0,0,9.23,0,0,NULL,'1432_35_52',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,74,'3A',NULL,NULL,NULL,'40','1',NULL,	
         0,0,0,9.23,0,0,NULL,'1432_40_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,74,'3A',23133,1580,'2017-03-20','40','2',NULL,	
         0,0,0,9.23,0,0,NULL,'1432_40_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,74,NULL,NULL,NULL,NULL,'40','3',NULL,	
         0,0,0,9.23,0,0,NULL,'1432_40_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,74,'3A',24863,1749,'2024-11-21','51','18',NULL,	
         0,0,0,9.23,0,0,NULL,'1432_51_18',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,74,'3A',4898,55,'1998-12-22','51','19',NULL,	
         0,0,0,9.23,0,0,NULL,'1432_51_19',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,75,NULL,NULL,NULL,NULL,'56','4.02',NULL,	
         0,0,0,4.89,0,0,NULL,'1438_56_4.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,75,NULL,NULL,NULL,NULL,'56','4.03',NULL, 
         0,0,0,4.89,0,0,NULL,'1438_56_4.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,75,'2',23329,771,'2018-04-12','56','7',NULL,	
         0,0,0,4.89,0,0,NULL,'1438_56_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,76,'3A',24607,1148,'2023-05-13','7','17.02',NULL,	
         0,0,0,59.51,0,0,NULL,'1407_7_17.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,77,'3A',6263,81,'2004-12-30','15','42.01',NULL,	
         0,0,0,27.06,0,0,NULL,'1407_15_42.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,77,'3A',6263,81,'2004-12-30','15','42.02',NULL,	
         0,0,0,27.06,0,0,NULL,'1407_15_42.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,78,'3A',5423,84,'2001-06-13','28','17.03',NULL,	
         0,0,0,10,0,0,NULL,'1438_28_17.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,79,'3A',4373,273,'1996-05-10','51','22',NULL,	
         0,0,0,27.96,0,0,NULL,'1438_51_22',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,80,'3A',6385,212,'2005-07-15','62','12',NULL,
         0,0,0,61.31,0,0,NULL,'1438_62_12',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,81,'3A',20979,515,'2007-12-03','25.02','10.01',NULL,	
         0,0,0,19.69,0,0,NULL,'1413_25.02_10.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,82,'3A',20939,1162,'2007-10-09','29','19',NULL,	
         0,0,0,38.36,0,0,NULL,'1438_29_19',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,83,NULL,NULL,NULL,NULL,'44','5',NULL,	
         0,0,0,6.75,0,0,NULL,'1407_44_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,83,'3A',21428,640,'2009-11-02','44','6',NULL,	
         0,0,0,6.75,0,0,NULL,'1407_44_6',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,83,'3A',21428,640,'2009-11-02','44','7',NULL,	
         0,0,0,6.75,0,0,NULL,'1407_44_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,83,NULL,NULL,NULL,NULL,'6600','7',NULL,	
         0,0,0,6.75,0,0,NULL,'1407_6600_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,84,NULL,NULL,NULL,NULL,'40','14',NULL,	
         0,0,0,95.21,0,0,NULL,'1407_40_14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,84,'3A',5928,196,'2003-09-01','46','19',NULL,	
         0,0,0,95.21,0,0,NULL,'1407_46_19',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,85,'4A',NULL,NULL,NULL,'32','9',NULL,	
         0,0,0,10.36,0,0,NULL,'1413_32_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,85,NULL,NULL,NULL,NULL,'33.03','7',NULL,	
         0,0,0,10.36,0,0,NULL,'1413_33.03_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,85,NULL,NULL,NULL,NULL,'33.03','9',NULL,	
         0,0,0,10.36,0,0,NULL,'1413_33.03_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,85,NULL,NULL,NULL,NULL,'33.03','10',NULL,	
         0,0,0,10.36,0,0,NULL,'1413_33.03_10',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1402,86,'3A',21392,1766,'2009-08-14','41001','1.01',NULL,	
         0,0,0,47.91,0,0,NULL,'1402_41001_1.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,87,'3A',20558,283,'2006-05-31','22801','2',NULL, 	
         0,0,0,43.52,0,0,NULL,'1416_22801_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,88,'3A',3761,249,NULL,'30','23',NULL,	
         0,0,0,146.39,0,0,NULL,'1438_30_23',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,89,'3A',24400,1255,'2022-03-25','29','20',NULL,	
         0,0,0,12.15,0,0,NULL,'1438_29_20',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,90,'2',24382,1503,'2022-02-08','47','11',NULL,	
         0,0,0,24.40,0,0,NULL,'1438_47_11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,91,'3A',NULL,NULL,NULL,'109','23',NULL,	
         0,0,0,37.48,0,0,NULL,'1419_109_23',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,92,'3A',22479,1487,'2014-01-01','16','13',NULL,	
         0,0,0,72.33,0,0,NULL,'1407_16_13',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1402,95,'15C',5576,116,'2002-03-04','20701','1',NULL,	
         0,0,0,21.58,0,0,NULL,'1402_20701_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1402,93,'15C',5576,122,'2002-03-04','20901','13.01',NULL,	
         0,0,0,21.58,0,0,NULL,'1402_20901_13.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,94,'3A',NULL,NULL,NULL,'34','1.01',NULL,	
         0,0,0,42.63,0,0,NULL,'1438_34_1.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,95,'3A',24449,282,'2022-06-17','101','13',NULL,	
         0,0,0,9.79,0,0,NULL,'1418_101_13',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,95,NULL,NULL,NULL,NULL,'101','14',NULL,	
         0,0,0,9.79,0,0,NULL,'1418_101_14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,95,NULL,24449,282,'2022-06-17','201','63',NULL, 
         0,0,0,9.79,0,0,NULL,'1418_201_63',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,96,'3A',6277,277,'2004-10-15','10901','5',NULL,	
         0,0,0,33.12,0,0,NULL,'1416_10901_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,97,'3A',24449,142,'2022-06-02','8','3.01',NULL,	
         0,0,0,15.45,0,0,NULL,'1413_8_3.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,98,'3A',3789,111,NULL,'51','23',NULL,	
         0,0,0,88.78,0,0,NULL,'1438_51_23',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,99,NULL,NULL,NULL,'2022-12-20','43','55.01',NULL,	
         0,0,0,41.99,0,0,NULL,'1438_43_55.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,99,'3A',24563,1342,'2022-12-20','43','67',NULL,	
         0,0,0,41.99,0,0,NULL,'1438_43_67',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,99,'3A',24563,1342,'2022-12-20','43','75',NULL,	
         0,0,0,41.99,0,0,NULL,'1438_43_75',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,100,NULL,NULL,NULL,NULL,'61','4',NULL,	
         0,0,0,80.93,0,0,NULL,'1438_61_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,101,NULL,NULL,NULL,NULL,'42','2.01',NULL,	
         0,0,0,20.64,0,0,NULL,'1438_42_2.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,101,'3A',23571,1167,'2019-06-28','42','3',NULL,	
         0,0,0,20.64,0,0,NULL,'1438_42_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,102,'3A',23978,1991,'2020-12-04','32','5',NULL,	
         0,0,0,41.44,0,0,NULL,'1438_32_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,102,NULL,NULL,NULL,NULL,'33','84',NULL,	
         0,0,0,41.44,0,0,NULL,'1438_33_84',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,102,NULL,NULL,NULL,NULL,'33','86',NULL, 
         0,0,0,41.44,0,0,NULL,'1438_33_86',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,103,NULL,NULL,NULL,NULL,'900','1',NULL,	
         0,0,0,20.73,0,0,NULL,'1427_900_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,103,'3A',22028,1789,'2012-04-20','8300','3',NULL,	
         0,0,0,20.73,0,0,NULL,'1427_8300_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,103,NULL,NULL,NULL,NULL,'8300','4',NULL,	
         0,0,0,20.73,0,0,NULL,'1427_8300_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,104,'3A',24371,281,'2022-03-18','51','10',NULL,	
         0,0,0,96.29,0,0,NULL,'1413_51_10',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,105,'3A',24824,1741,'2024-10-07','51','12',NULL,	
         0,0,0,37.42,0,0,NULL,'1413_51_12',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,106,NULL,NULL,NULL,NULL,'15','28.07',NULL,	
         0,0,0,43.75,0,0,NULL,'1407_15_28.07',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,106,'3A',NULL,NULL,NULL,'15','28.08',NULL,	
         0,0,0,43.75,0,0,NULL,'1407_15_28.08',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,107,'4A',23567,65,'2019-04-25','35','4',NULL,	
         0,0,0,26.31,0,0,NULL,'1438_35_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,107,NULL,NULL,NULL,NULL,'38','15',NULL,	
         0,0,0,26.31,0,0,NULL,'1438_38_15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,108,'3A',6191,46,'2004-10-20','17','33',NULL,	
         0,0,0,11.88,0,0,NULL,'1407_17_33',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,108,'4A',NULL,NULL,NULL,'17','33.01',NULL,	
         0,0,0,11.88,0,0,NULL,'1407_17_33.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,108,NULL,NULL,NULL,NULL,'17','50',NULL,	
         0,0,0,11.88,0,0,NULL,'1438_17_50',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,109,'3A',21195,836,'2008-12-02','33','66',NULL,	
         0,0,0,18.01,0,0,NULL,'1438_33_66',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,109,'2',NULL,NULL,NULL,'33','66.01',NULL,	
         0,0,0,18.01,0,0,NULL,'1438_33_66.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,110,'15D',NULL,NULL,NULL,'5300','58',NULL,
         0,0,0,69.36,0,0,NULL,'1427_5300_58',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,111,NULL,NULL,NULL,NULL,'2601','5',NULL,
         0,0,0,10.07,0,0,NULL,'1418_2601_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,111,NULL,NULL,NULL,NULL,'2601','6',NULL,	
         0,0,0,10.07,0,0,NULL,'1418_2601_6',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,111,NULL,NULL,NULL,NULL,'103','9',NULL,	
         0,0,0,10.07,0,0,NULL,'1418_103_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,112,'3A',23250,1222,'2017-11-04','51','7',NULL,	
         0,0,0,28.72,0,0,NULL,'1413_51_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,113,NULL,NULL,NULL,NULL,'15','24',NULL,	
         0,0,0,60.16,0,0,NULL,'1407_15_24',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,113,NULL,NULL,NULL,NULL,'15','28',NULL,	
         0,0,0,60.16,0,0,NULL,'1407_15_28',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,113,NULL,NULL,NULL,NULL,'15','33',NULL,	
         0,0,0,60.16,0,0,NULL,'1407_15_33',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,113,NULL,NULL,NULL,NULL,'15','34',NULL,	
         0,0,0,60.16,0,0,NULL,'1407_15_34',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,113,NULL,NULL,NULL,NULL,'15','39',NULL,	
         0,0,0,60.16,0,0,NULL,'1407_15_39',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,113,NULL,NULL,NULL,NULL,'19','11',NULL,	
         0,0,0,60.16,0,0,NULL,'1407_19_11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,114,NULL,NULL,NULL,NULL,'16','12',NULL,	
         0,0,0,31.82,0,0,NULL,'1407_16_12',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,114,NULL,NULL,NULL,NULL,'16','24',NULL,	
         0,0,0,31.82,0,0,NULL,'1407_16_24',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,115,'3A',24400,1255,'2022-03-25','28','14',NULL,	
         0,0,0,5,0,0,NULL,'1438_28_14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,115,NULL,NULL,NULL,NULL,'28','15',NULL,	
         0,0,0,5,0,0,NULL,'1438_28_15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,116,'4C',22843,695,'2016-01-06','29','2',NULL,	
         0,0,0,28.29,0,0,NULL,'1438_29_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,116,NULL,NULL,NULL,NULL,'18','16',NULL,	
         0,0,0,28.29,0,0,NULL,'1438_18_16',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1435,117,'3A',24493,260,'2022-08-05','50002','1',NULL,	
         0,0,0,12.52,0,0,NULL,'1435_50002_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1435,117,NULL,NULL,NULL,NULL,'50002','2',NULL,
         0,0,0,12.52,0,0,NULL,'1435_50002_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1435,117,NULL,NULL,NULL,NULL,'50002','3',NULL,
         0,0,0,12.52,0,0,NULL,'1435_50002_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1435,117,'2',24092,1358,'2021-03-04','50003','11',NULL,	
         0,0,0,12.52,0,0,NULL,'1435_50003_11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1435,117,'2',23915,535,'2020-10-01','50003','12',NULL,	
         0,0,0,12.52,0,0,NULL,'1435_50003_12',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1435,117,NULL,NULL,NULL,NULL,'50003','13',NULL,
         0,0,0,12.52,0,0,NULL,'1435_50003_13',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1435,117,NULL,NULL,NULL,NULL,'50003','14',NULL,
         0,0,0,12.52,0,0,NULL,'1435_50003_14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,118,NULL,NULL,NULL,NULL,'12','5.01',NULL,	
         0,0,0,37,0,0,NULL,'1438_12_5.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1420,119,NULL,NULL,NULL,'2023-10-02','1102','1',NULL,	
         0,0,0,37,0,0,NULL,'1420_1102_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1420,119,'2',24672,841,'2023-10-02','1502','1',NULL,	
         0,0,0,37,0,0,NULL,'1420_1502_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1407,120,'3A',22692,205,'2014-12-24','15','28.01',NULL,	
         0,0,0,29.94,0,0,NULL,'1407_15_28.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,120,'4A',22692,205,'2014-12-24','15','28.02',NULL,	
         0,0,0,29.94,0,0,NULL,'1407_15_28.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,120,NULL,NULL,NULL,NULL,'19','11',NULL,	
         0,0,0,29.94,0,0,NULL,'1407_19_11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,121,'3A',22711,528,'2014-12-24','15','28.05',NULL,	
         0,0,0,43.75,0,0,NULL,'1407_15_28.05',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,121,NULL,NULL,NULL,NULL,'15','28.06',NULL,	
         0,0,0,43.75,0,0,NULL,'1407_15_28.06',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,122,'3B',5334,45,'2001-02-28','4600','30',NULL,
         0,0,0,4.33,0,0,NULL,'1427_4600_30',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,122,'2',5821,235,'2003-04-08','4600','30.01',NULL,	
         0,0,0,4.33,0,0,NULL,'1427_4600_30.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,122,'4A',22504,1,'2014-03-04','5702','3',NULL,	
         0,0,0,4.33,0,0,NULL,'1427_5702_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,122,'2',22014,1866,'2012-03-27','5702','5',NULL,	
         0,0,0,4.33,0,0,NULL,'1427_5702_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,122,'4A',23021,798,'2016-10-28','5600','3',NULL,	
         0,0,0,4.33,0,0,NULL,'1427_5600_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,122,'3B',22504,7,'2014-03-04','5600','5',NULL,
         0,0,0,4.33,0,0,NULL,'1427_5600_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1408,123,NULL,NULL,NULL,NULL,'5003','14',NULL,
         0,0,0,14.26,0,0,NULL,'1408_5003_14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,124,NULL,NULL,NULL,NULL,'12','24',NULL,
         0,0,0,36.68,0,0,NULL,'1438_12_24',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,124,'2',20845,614,'2007-01-20','12','24.01',NULL,	
         0,0,0,36.68,0,0,NULL,'1438_12_24.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,124,NULL,NULL,NULL,NULL,'12','9',NULL,
         0,0,0,36.68,0,0,NULL,'1438_12_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,125,'3B',23306,177,'2018-02-05','25.02','10.02',NULL,	
         0,0,0,16.28,0,0,NULL,'1413_25.02_10.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,125,'3A',23306,177,'2018-02-05','25.02','10.03',NULL,	
         0,0,0,16.28,0,0,NULL,'1413_25.02_10.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,126,'3B',24650,1979,'2023-08-15','103','7',NULL,		
         0,0,0,11.2,0,0,NULL,'1419_103_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,126,'3B',24650,1980,'2023-08-15','103','8',NULL,		
         0,0,0,11.2,0,0,NULL,'1419_103_8',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,127,NULL,NULL,NULL,NULL,'46.01','35',NULL,	
         0,0,0,43.96,0,0,NULL,'1407_46.01_35',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,127,NULL,NULL,NULL,NULL,'6000','4',NULL,	
         0,0,0,43.96,0,0,NULL,'1407_6000_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,128,'3B',22687,1022,'2015-04-01','7','44.02',NULL,	
         0,0,0,106.08,0,0,NULL,'1407_7_44.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,129,'3A',24630,941,'2023-07-05','7','27',NULL,	
         0,0,0,32.22,0,0,NULL,'1407_7_27',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,141,'3A',24384,299,'2021-12-30','33','4',NULL,	
         0,0,0,0,0,0,NULL,'1407_33_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,130,NULL,NULL,NULL,NULL,'34','4',NULL,	
         0,0,0,0,0,0,NULL,'1407_34_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,130,NULL,NULL,NULL,NULL,'34','5',NULL,	
         0,0,0,0,0,0,NULL,'1407_34_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,131,'3B',23254,1209,'2017-11-03','7','14.01',NULL,	
         0,0,0,30,0,0,NULL,'1407_7_14.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,131,NULL,NULL,NULL,NULL,'105','1',NULL,	
         0,0,0,30,0,0,NULL,'1407_105_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,132,'3B',23188,962,'2017-08-15','33','112.01',NULL,
         0,0,0,0,0,0,NULL,'1407_33_112.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,133,'3A',NULL,NULL,NULL,'26','13',NULL,	
         0,0,0,0,0,0,NULL,'1413_26_13',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,133,'3A',22842,277,'2015-12-31','49','12',NULL,	
         0,0,0,0,0,0,NULL,'1413_49_12',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,133,NULL,NULL,NULL,NULL,'49','12.02',NULL,	
         0,0,0,0,0,0,NULL,'1413_49_12.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,133,NULL,NULL,NULL,NULL,'49','12.03',NULL,	
         0,0,0,0,0,0,NULL,'1413_49_12.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,133,NULL,NULL,NULL,NULL,'49','12.04',NULL,	
         0,0,0,0,0,0,NULL,'1413_49_12.04',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,134,NULL,NULL,NULL,NULL,'6','3',NULL,	
         0,0,0,0,0,0,NULL,'1413_6_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,135,NULL,NULL,NULL,NULL,'3','4',NULL,	
         0,0,0,0,0,0,NULL,'1416_3_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,135,NULL,NULL,NULL,NULL,'1602','16',NULL,	
         0,0,0,0,0,0,NULL,'1416_1602_16',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,135,NULL,NULL,NULL,NULL,'1602','18',NULL,	
         0,0,0,0,0,0,NULL,'1416_1602_18',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,135,NULL,NULL,NULL,NULL,'2902','18',NULL,	
         0,0,0,0,0,0,NULL,'1416_2902_18',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,135,NULL,NULL,NULL,NULL,'2902','19',NULL,	
         0,0,0,0,0,0,NULL,'1416_2902_19',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,135,NULL,NULL,NULL,NULL,'2902','20',NULL,	
         0,0,0,0,0,0,NULL,'1416_2902_20',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,135,NULL,NULL,NULL,NULL,'2902','26',NULL,	
         0,0,0,0,0,0,NULL,'1416_2902_26',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,135,NULL,NULL,NULL,NULL,'3001','1',NULL,	
         0,0,0,0,0,0,NULL,'1416_3001_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,136,NULL,NULL,NULL,NULL,'4','3',NULL,	
         0,0,0,0,0,0,NULL,'1407_4_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,136,NULL,NULL,NULL,NULL,'4','5',NULL,	
         0,0,0,0,0,0,NULL,'1407_4_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,137,'3A',23194,29,'2017-08-23','2301','5',NULL,	
         0,0,0,0,0,0,NULL,'1418_2301_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,138,'3A',24503,387,'2022-09-01','2401','31',NULL,	
         0,0,0,24.62,0,0,NULL,'1418_2401_31',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,139,'3A',NULL,NULL,NULL,'2601','7',	NULL,	
         0,0,0,0,0,0,NULL,'1418_2601_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,139,NULL,NULL,NULL,NULL,'103','10',NULL,	
         0,0,0,0,0,0,NULL,'1418_103_10',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,140,NULL,NULL,NULL,NULL,'1801','16',NULL,	
         0,0,0,0,0,0,NULL,'1418_1801_16',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,140,NULL,NULL,NULL,NULL,'1801','36.04',NULL,	
         0,0,0,0,0,0,NULL,'1418_1801_36.04',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,141,'3A',21042,1753,'2008-03-19','116','17',NULL, 
         0,0,0,0,0,0,NULL,'1419_116_17',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,141,NULL,NULL,NULL,NULL,'116','18',NULL,	
         0,0,0,0,0,0,NULL,'1419_116_18',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,142,'1',NULL,NULL,NULL,'103','6.01',NULL,	
         0,0,0,19.51,0,0,NULL,'1419_103_6.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,142,NULL,NULL,NULL,NULL,'103','6',NULL,	
         0,0,0,19.51,0,0,NULL,'1419_103_6',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,143,'15C',22657,1330,'2015-01-23','6000','5',NULL,	
         0,0,0,0,0,0,NULL,'1427_6000_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,143,'15C',22657,1330,'2015-01-23','6000','6',NULL,	
         0,0,0,0,0,0,NULL,'1427_6000_6',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,144,'1',6548,5,'2005-12-23','4201','1',NULL,	
         0,0,0,0,0,0,NULL,'1431_4201_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,144,'1',NULL,NULL,NULL,'4201','2',NULL,	
         0,0,0,0,0,0,NULL,'1431_4201_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,144,'2',6548,5,'2005-12-23','3803','20',NULL,	
         0,0,0,0,0,0,NULL,'1431_3803_20',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'2',24261,1411,'2021-09-14','13','10',NULL,	
         0,0,0,0,0,0,NULL,'1438_13_10',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'2',24261,1411,'2021-09-14','13','11',NULL,	
         0,0,0,0,0,0,NULL,'1438_13_11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'3A',22616,938,'2014-10-01','13','7',NULL,	
         0,0,0,0,0,0,NULL,'1438_13_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'2',NULL,NULL,NULL,'13','14',NULL,	
         0,0,0,0,0,0,NULL,'1438_13_14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,156,'2',24394,1685,'2022-03-21','14','10',NULL,	
         0,0,0,0,0,0,NULL,'1438_14_10',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'3A',22616,938,'2014-10-01','14','11',NULL,	
         0,0,0,0,0,0,NULL,'1438_14_11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,NULL,NULL,NULL,NULL,'14','7',NULL,	
         0,0,0,0,0,0,NULL,'1407_14_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,NULL,NULL,NULL,NULL,'14','14',NULL,	
         0,0,0,0,0,0,NULL,'1407_14_14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'15C',3493,36,NULL,'14','1.01',NULL,	
         0,0,0,0,0,0,NULL,'1438_14_1.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'15C',4126,215,'1994-12-30','14','12',NULL,	
         0,0,0,0,0,0,NULL,'1438_14_12',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'15C',3493,36,NULL,'14','3',NULL,	
         0,0,0,0,0,0,NULL,'1438_14_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'15C',3493,36,NULL,'14','3.02',NULL, 
         0,0,0,0,0,0,NULL,'1438_14_3.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,NULL,NULL,NULL,NULL,'14','51',NULL,	
         0,0,0,0,0,0,NULL,'1407_14_51',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,NULL,NULL,NULL,NULL,'15','1.01',NULL,	
         0,0,0,0,0,0,NULL,'1407_15_1.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'2',2624,599,'1982-04-08','15','11',NULL,	
         0,0,0,0,0,0,NULL,'1438_15_11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'1',5336,92,'2001-02-27','15','12',NULL,	
         0,0,0,0,0,0,NULL,'1438_15_12',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'2',4979,235,'1999-05-20','15','3',NULL,	
         0,0,0,0,0,0,NULL,'1438_15_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,NULL,NULL,NULL,NULL,'15','3.02',NULL,	
         0,0,0,0,0,0,NULL,'1407_15_3.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,145,'1',24305,1083,'2021-09-22','15','51',NULL,	
         0,0,0,0,0,0,NULL,'1438_15_51',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,146,NULL,NULL,NULL,NULL,'15','28.03',NULL,	
         0,0,0,43.72,0,0,NULL,'1407_15_28.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,146,NULL,NULL,NULL,NULL,'15','28.04',NULL,	
         0,0,0,43.72,0,0,NULL,'1407_15_28.04',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1402,147,'3A',22218,1165,'2012-12-06','30401','1',NULL,	
         0,0,0,0,0,0,NULL,'1402_30401_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1402,147,'3A',NULL,NULL,'1984-12-21','30201','2',NULL,
         0,0,0,0,0,0,NULL,'1402_30201_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1402,148,'4A',23493,1581,'2019-02-08','41301','8',NULL,	
         0,0,0,0,0,0,NULL,'1402_41301_8',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,149,'3A',NULL,NULL,NULL,'8','7',NULL,	
         0,0,0,31.46,0,0,NULL,'1407_8_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,149,NULL,NULL,NULL,NULL,'100','15',NULL,	
         0,0,0,31.46,0,0,NULL,'1407_100_15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,150,NULL,NULL,NULL,NULL,'4','35',NULL,	
         0,0,0,0,0,0,NULL,'1407_4_35',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,150,'3A',23446,1092,'2018-10-26','4','35.02',NULL,	
         0,0,0,0,0,0,NULL,'1407_4_35.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,151,'3A',24004,720,'2020-12-29','7','14.03',NULL,	
         0,0,0,23,0,0,NULL,'1407_7_14.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,152,'3A',23970,100,'2020-10-07','4','11',NULL,	
         0,0,0,0,0,0,NULL,'1413_4_11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,152,NULL,NULL,NULL,NULL,'4','11.01',NULL,	
         0,0,0,0,0,0,NULL,'1407_4_11.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,152,'3A',5523,214,'2001-12-05','4','12',NULL,	
         0,0,0,0,0,0,NULL,'1413_4_12',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,152,NULL,NULL,NULL,NULL,'4','12.01',NULL,	
         0,0,0,0,0,0,NULL,'1407_4_12.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,153,NULL,NULL,NULL,NULL,'4','9',NULL,	
         0,0,0,0,0,0,NULL,'1407_4_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,153,'3A',NULL,NULL,NULL,'6','5',NULL,	
         0,0,0,0,0,0,NULL,'1413_6_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,153,'3A',5918,127,'2003-08-16','6','6',NULL,	
         0,0,0,0,0,0,NULL,'1413_6_6',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,153,NULL,NULL,NULL,NULL,'6','7.02',NULL,	
         0,0,0,0,0,0,NULL,'1413_6_7.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,154,NULL,NULL,NULL,NULL,'22','4.01',NULL,	
         0,0,0,0,0,0,NULL,'1413_22_4.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,155,NULL,NULL,NULL,NULL,'105','1',NULL,	
         0,0,0,0,0,0,NULL,'1419_105_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,156,'3A',23348,1521,'2018-05-11','2401','32',NULL,	
         0,0,0,0,0,0,NULL,'1418_2401_32',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,157,'3A',24855,906,'2024-08-28','2401','31.06',NULL,	
         0,0,0,0,0,0,NULL,'1418_2401_31.06',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,158,NULL,NULL,NULL,NULL,'103','5',NULL,	
         0,0,0,20,0,0,NULL,'1407_103_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1421,159,NULL,NULL,NULL,NULL,'52.02','16.01',NULL,	
         0,0,0,0,0,0,NULL,'1407_52.02_16.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1421,159,NULL,NULL,NULL,NULL,'52.02','16.02',NULL,	
         0,0,0,0,0,0,NULL,'1407_52.02_16.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1422,160,'3A',22810,314,'2015-10-21','4601','1',NULL,	
         0,0,0,48,0,0,NULL,'1422_4601_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,160,NULL,NULL,NULL,NULL,'33','69.02',NULL,	
         0,0,0,8.91,0,0,NULL,'1407_33_69.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,161,'3A',NULL,NULL,NULL,'33','70.02',NULL,	
         0,0,0,8.91,0,0,NULL,'1438_33_70.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,162,'1',NULL,NULL,NULL,'6801','7',NULL,	
         0,0,0,0,0,0,NULL,'1427_6801_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,163,NULL,NULL,NULL,NULL,'8100','10',NULL,	
         0,0,0,0,0,0,NULL,'1427_8100_10',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,163,NULL,NULL,NULL,NULL,'8100','11',NULL,	
         0,0,0,0,0,0,NULL,'1427_8100_11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,163,NULL,NULL,NULL,NULL,'8100','28',NULL,	
         0,0,0,0,0,0,NULL,'1427_8100_28',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,163,NULL,NULL,NULL,NULL,'8100','45',NULL,	
         0,0,0,0,0,0,NULL,'1427_8100_45',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,164,NULL,NULL,NULL,NULL,'7801','6',NULL,	
         0,0,0,0,0,0,NULL,'1427_7801_6',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,164,NULL,NULL,NULL,NULL,'7900','7',NULL,	
         0,0,0,0,0,0,NULL,'1427_7900_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,164,NULL,NULL,NULL,NULL,'8000','2',NULL,	
         0,0,0,0,0,0,NULL,'1427_8000_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,164,NULL,NULL,NULL,NULL,'8000','6',NULL,	
         0,0,0,0,0,0,NULL,'1427_8000_6',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,164,'3B',NULL,NULL,NULL,'8000','14',NULL,	
         0,0,0,0,0,0,NULL,'1427_8000_14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,164,NULL,NULL,NULL,NULL,'8000','7',NULL,	
         0,0,0,0,0,0,NULL,'1427_8000_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,164,NULL,NULL,NULL,NULL,'8000','18',NULL,	
         0,0,0,0,0,0,NULL,'1427_8000_18',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,164,NULL,NULL,NULL,NULL,'8101','9',NULL,	
         0,0,0,0,0,0,NULL,'1427_8101_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,164,'4B',NULL,NULL,NULL,'8101','7',NULL,	
         0,0,0,0,0,0,NULL,'1427_8101_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,164,NULL,NULL,NULL,NULL,'8101','8',NULL,	
         0,0,0,0,0,0,NULL,'1427_8101_8',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,165,'1',23276,1463,'2017-12-21','7700','3',NULL,	
         0,0,0,0,0,0,NULL,'1427_7700_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,165,'2',24108,750,'2021-03-03','7700','1',NULL,	
         0,0,0,0,0,0,NULL,'1427_7700_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,165,NULL,NULL,NULL,NULL,'7700','61',NULL,	
         0,0,0,0,0,0,NULL,'1427_7700_61',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,165,'4C',NULL,NULL,NULL,'7702','3',NULL, 
          0,0,0,0,0,0,NULL,'1427_7702_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,165,NULL,NULL,NULL,NULL,'7702','1',NULL,	
         0,0,0,0,0,0,NULL,'1427_7702_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,165,NULL,NULL,NULL,NULL,'7702','61',NULL,	
         0,0,0,0,0,0,NULL,'1427_7702_61',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,165,'2',22261,1476,'2012-12-13','8100','3',NULL,	
         0,0,0,0,0,0,NULL,'1427_8100_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,165,'2',23936,1408,'2020-09-24','8100','1',NULL,	
         0,0,0,0,0,0,NULL,'1427_8100_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,165,'15C',21909,1907,'2011-11-16','8100','61',NULL,	
         0,0,0,0,0,0,NULL,'1427_8100_61',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,165,NULL,NULL,NULL,NULL,'8200','1',NULL,	
         0,0,0,0,0,0,NULL,'1427_8200_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,166,'3A',6246,30,'2004-12-29','3001','2',NULL,	
         0,0,0,0,0,0,NULL,'1431_3001_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,167,'3A',5905,181,'2003-07-24','2402','13',NULL,	
         0,0,0,0,0,0,NULL,'1431_2402_13',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,167,NULL,NULL,NULL,NULL,'2402','24',NULL,	
         0,0,0,0,0,0,NULL,'1431_2402_24',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,167,'2',4906,265,'1998-12-08','2402','7',NULL,	
         0,0,0,0,0,0,NULL,'1431_2402_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,167,'2',5000,184,'1999-04-22','2402','9',NULL,	
         0,0,0,0,0,0,NULL,'1431_2402_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,167,'2',NULL,NULL,NULL,'2902','13',NULL,	
         0,0,0,0,0,0,NULL,'1431_2902_13',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,167,NULL,NULL,NULL,NULL,'2902','24',NULL,	
         0,0,0,0,0,0,NULL,'1431_2902_24',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,167,'2',4987,40,'1999-05-27','2902','7',NULL,	
         0,0,0,0,0,0,NULL,'1431_2902_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,167,'2',23172,93,'2017-07-21','2902','9',	NULL,	
         0,0,0,0,0,0,NULL,'1431_2902_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,167,NULL,NULL,NULL,NULL,'3001','13',NULL,	
         0,0,0,0,0,0,NULL,'1431_3001_13',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,167,NULL,NULL,NULL,NULL,'3001','24',NULL,	
         0,0,0,0,0,0,NULL,'1431_3001_24',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,167,'3A',4704,90,'1997-12-30','3001','7',NULL,	
         0,0,0,0,0,0,NULL,'1431_3001_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,167,'3A',4478,69,'1996-11-01','3001','9',NULL,	
         0,0,0,0,0,0,NULL,'1431_3001_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1432,168,'15C',22408,1895,'2013-07-30','49','3',NULL,	
         0,0,0,0,0,0,NULL,'1432_49_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1435,169,NULL,NULL,NULL,NULL,'30901','11.01',NULL,	
         0,0,0,35.12,0,0,NULL,'1435_30901_11.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1436,170,NULL,NULL,NULL,NULL,'8701','1',NULL,	
         0,0,0,52.36,0,0,NULL,'1436_8701_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1436,170,NULL,NULL,NULL,NULL,'8701','2.01',NULL,	
         0,0,0,52.36,0,0,NULL,'1436_8701_2.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1436,170,'3A',5132,5,'2000-01-03','8901','2.02',NULL,	
         0,0,0,52.36,0,0,NULL,'1436_8901_2.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,171,'3A','4634','96','1997-07-10','16','14',NULL,	
         0,0,0,0,0,0,NULL,'1438_16_14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,171,'3A','22236','1188','2012-12-13','7','13.23',NULL,	
         0,0,0,0,0,0,NULL,'1407_7_13.23',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,172,NULL,NULL,NULL,NULL,'8','6',NULL,	
         0,0,0,0,0,0,NULL,'1438_8_6',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,173,NULL,NULL,NULL,NULL,'8','9.02',NULL,	
         0,0,0,0,0,0,NULL,'1438_8_9.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,174,'3A','5136','334','2000-01-21','30','71.03',NULL,	
         0,0,0,60,0,0,NULL,'1438_30_71.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,175,'3A',NULL,NULL,NULL,'20.10','44',NULL,	
         0,0,0,0,0,0,NULL,'1438_20.10_44',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,176,NULL,NULL,NULL,NULL,'20','22',NULL,	
         0,0,0,10.635,0,0,NULL,'1438_20_22',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,176,NULL,NULL,NULL,NULL,'20','46.01',NULL,	
         0,0,0,10.635,0,0,NULL,'1438_20_46.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,176,NULL,NULL,NULL,NULL,'20','46.02',NULL,	
         0,0,0,10.635,0,0,NULL,'1438_20_46.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,176,'1','22927','406','2016-06-15','20','50',NULL,	
         0,0,0,10.635,0,0,NULL,'1438_20_50',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,177,'1','23497','782','2019-02-13','22','8',NULL,	
         0,0,0,22.833,0,0,NULL,'1438_22_8',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,177,'2','24740','1189','2024-04-04','22','15',NULL,	
         0,0,0,22.833,0,0,NULL,'1438_22_15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,177,'3A','23376','1604','2018-06-06','22','28',NULL,	
         0,0,0,22.833,0,0,NULL,'1438_22_28',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,178,'3A','24605','578','2023-05-18','38','11',NULL,	
         0,0,0,17.96,0,0,NULL,'1438_38_11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,179,'3A','2563','471','1980-09-05','43','74.01',NULL,	
         0,0,0,37.34,0,0,NULL,'1438_43_74.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,180,'4A','23321',	'789','2018-03-29','33','71.02',NULL,	
         0,0,0,0,0,0,NULL,'1438_33_71.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,180,'2','6062','252','2004-04-22','33','7',NULL,	
         0,0,0,0,0,0,NULL,'1438_33_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,180,'2','21839','722','2011-08-03','33','72',NULL,	
         0,0,0,0,0,0,NULL,'1438_33_72',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,181,'3A','23727','280','2020-02-24','50.02','17',NULL,	
         0,0,0,16.77,0,0,NULL,'1438_50.02_17',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,182,NULL,NULL,NULL,NULL,'5600','5',NULL,	
         0,0,0,0,0,0,NULL,'1427_5600_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,182,'4A',23021,798,'2016-10-28','5600','3',NULL,	
         0,0,0,0,0,0,NULL,'1427_5600_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,182,'2',22014,1866,'2012-03-27','5702','5',NULL,	
         0,0,0,0,0,0,NULL,'1427_5702_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,182,'4A',22504,1,'2014-03-04','5702','3',NULL,	
         0,0,0,0,0,0,NULL,'1427_5702_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,183,'3A','21377','1903','2009-07-14','33','68',NULL,	
         0,0,0,14.31,0,0,NULL,'1438_33_68',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,184,'3A','23079','1849','2013-11-23','43','57',NULL,	
         0,0,0,0,0,0,NULL,'1438_43_57',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,184,NULL,NULL,NULL,NULL,'43','58',NULL,	
         0,0,0,0,0,0,NULL,'1438_43_58',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,184,NULL,NULL,NULL,NULL,'43','59',NULL,	
         0,0,0,0,0,0,NULL,'1438_43_59',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,184,NULL,NULL,NULL,NULL,'43','61',NULL,	
         0,0,0,0,0,0,NULL,'1438_43_61',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,184,NULL,NULL,NULL,NULL,'43','62.03',NULL,	
         0,0,0,0,0,0,NULL,'1438_43_62.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,185,'3A','2876','677','1986-07-21','43','68',NULL,	
         0,0,0,10.02,0,0,NULL,'1438_43_68',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,186,NULL,NULL,NULL,NULL,'6801','10',NULL,	
         0,0,0,9.61,0,0,NULL,'1427_6801_10',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,186,NULL,NULL,NULL,NULL,'6801','10.01',NULL,	
         0,0,0,9.61,0,0,NULL,'1427_6801_10.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,186,NULL,NULL,NULL,NULL,'6801','10.02',NULL,	
         0,0,0,9.61,0,0,NULL,'1427_6801_10.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,187,'3A','23857','527','2020-08-15','900','11',NULL,	
         0,0,0,97.87,0,0,NULL,'1427_900_11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,188,'2',24460,1028,'2022-02-23','8800','33',NULL,	
         0,0,0,0,0,0,NULL,'1427_8800_33',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,189,NULL,NULL,NULL,NULL,'7100','48',NULL,	
         0,0,0,0,0,0,NULL,'1427_7100_48',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,189,'4C',NULL,NULL,NULL,'7801','2',NULL,	
         0,0,0,0,0,0,NULL,'1427_7801_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,189,NULL,NULL,NULL,NULL,'7801','9',NULL,	
         0,0,0,0,0,0,NULL,'1427_7801_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,189,NULL,NULL,NULL,NULL,'7801','10',NULL,	
         0,0,0,0,0,0,NULL,'1427_7801_10',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,189,'3A','21146','804','2008-08-27','7801','11',NULL,	
         0,0,0,0,0,0,NULL,'1427_7801_11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,190,NULL,NULL,NULL,NULL,'900','39',NULL,	
         0,0,0,54.18,0,0,NULL,'1427_900_39',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1436,191,NULL,NULL,NULL,NULL,'9002','1.01',NULL,	
         0,0,0,0,0,0,NULL,'1436_9002_1.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,192,'4A',NULL,NULL,NULL,'3','15',NULL,	
         0,0,0,136,0,0,NULL,'1438_3_15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,193,NULL,NULL,NULL,NULL,'16','20.03',NULL,	
         0,0,0,7.5,0,0,NULL,'1438_16_20.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,193,'3A',24868,1833,'2025-01-13','16','21',NULL,	
         0,0,0,7.5,0,0,NULL,'1438_16_21',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,193,NULL,NULL,NULL,NULL,'16','22',NULL,	
         0,0,0,7.5,0,0,NULL,'1438_16_22',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,194,'3A',NULL,NULL,NULL,'12','4',NULL,	
         0,0,0,100.64,0,0,NULL,'1438_12_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,195,'4A',21079,1057,'2008-05-02','18','27',NULL,	
         0,0,0,0,0,0,NULL,'1438_18_27',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,195,NULL,NULL,NULL,NULL,'18','27.05',NULL,	
         0,0,0,0,0,0,NULL,'1438_18_27.05',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,196,'15F',23532,1647,'2019-02-06','19','5',NULL,
         0,0,0,0,0,0,NULL,'1438_19_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,196,'15C',23532,1647,'2019-02-06','19','7',NULL,	
         0,0,0,0,0,0,NULL,'1438_19_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,197,NULL,NULL,NULL,NULL,'19','3',NULL,	
         0,0,0,12.03,0,0,NULL,'1438_19_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,197,'4A',23243,190,'2017-09-22','19','4',NULL,	
         0,0,0,12.03,0,0,NULL,'1438_19_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,198,'3A',24437,501,'2022-05-24','60','21.03',NULL,	
         0,0,0,0,0,0,NULL,'1438_60_21.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,198,NULL,NULL,NULL,NULL,'60','21.04',NULL,	
         0,0,0,0,0,0,NULL,'1438_60_21.04',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,198,'3A',22865,1550,'2014-10-22','60','22.02',NULL, 
         0,0,0,0,0,0,NULL,'1438_60_22.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,199,'3A',24236,1181,'2021-08-12','54','26',NULL,	
         0,0,0,0,0,0,NULL,'1438_54_26',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,199,NULL,NULL,NULL,NULL,'54','26.01',NULL,
         0,0,0,0,0,0,NULL,'1438_54_26.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,200,NULL,NULL,NULL,NULL,'63','12',NULL,
         0,0,0,35.33,0,0,NULL,'1438_63_12',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,200,NULL,NULL,NULL,NULL,'63','13',NULL,	
         0,0,0,35.33,0,0,NULL,'1438_63_13',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,200,'3A',24549,515,'2022-12-28','63','14',NULL,	
         0,0,0,35.33,0,0,NULL,'1438_63_14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,200,'3A',21810,184,'2011-05-27','63','21',NULL,	
         0,0,0,35.33,0,0,NULL,'1438_63_21',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,200,'3A',21810,184,'2011-05-27','63','22',NULL,	
         0,0,0,35.33,0,0,NULL,'1438_63_22',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,200,NULL,NULL,NULL,NULL,'63','25.01',NULL,
         0,0,0,35.33,0,0,NULL,'1438_63_25.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,201,'3A',2714,958,NULL,'55','9.09',NULL,	
         0,0,0,20.85,0,0,NULL,'1438_55_9.09',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,202,'3A',21683,1,'2010-11-01','55','4.12',NULL,	
         0,0,0,10.48,0,0,NULL,'1438_55_4.12',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,203,'1',20974,396,'2007-11-13','62','19',NULL,	
         0,0,0,0,0,0,NULL,'1438_62_19',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,203,NULL,NULL,NULL,NULL,'63','18',NULL,	
         0,0,0,0,0,0,NULL,'1438_63_18',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,203,NULL,NULL,NULL,NULL,'63','19',NULL,	
         0,0,0,0,0,0,NULL,'1438_63_19',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,203,'3A',21777,224,'2011-04-11','63','20',NULL, 
         0,0,0,0,0,0,NULL,'1438_63_20',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,203,'3A',21897,1,'2011-10-28','63','20.01',NULL,	
         0,0,0,0,0,0,NULL,'1438_63_20.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,204,'3A',20759,203,'2006-12-26','14','4',NULL,	
         0,0,0,0,0,0,NULL,'1438_14_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,204,'1',24305,1083,'2021-09-22','15','51',NULL,	
         0,0,0,0,0,0,NULL,'1438_15_51',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,205,'3A',NULL,NULL,NULL,'42','11.01',NULL,	
         0,0,0,10.60,0,0,NULL,'1438_42_11.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1402,253,'3A',24553,69,'2022-12-12','30701','3',NULL,	
        0,0,0,0.00,0,0,NULL,'1402_30701_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1402,253,'3A',24504,1060,'2022-08-19','30701','4',NULL,	
        0,0,0,0.00,0,0,NULL,'1402_30701_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1402,253,'3A',24504,1060,'2022-08-19','30701','5',NULL,	
        0,0,0,0.00,0,0,NULL,'1402_30701_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,252,'3A',22792,428,'2015-09-28','1401','7',NULL,	
        0,0,0,6.38,0,0,NULL,'1418_1401_7',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1430,251,NULL,NULL,NULL,NUll,'14901','10.01',NULL,	
        0,0,0,3.43,0,0,NULL,'1430_14901_10.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,250,'2',4341,174,'1996-02-07','5002','10.01',NULL,	
        0,0,0,0.00,0,0,NULL,'1427_5002_10.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,249,'3A',20921,759,'2007-08-09','12','3.01',NULL,	
        0,0,0,9.47,0,0,NULL,'1407_12_3.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,249,'3A',6514,161,'2005-12-06','12','3.03',NULL,	
        0,0,0,9.47,0,0,NULL,'1407_12_3.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,248,NULL,NULL,NULL,NULL,'32.02','1',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_32.02_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,248,NULL,NULL,NULL,NULL,'32.02','2',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_32.02_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,248,'3A',3760,93,NULL,'32.02','3',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_32.02_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1430,247,'3A',24300,1045,'2021-11-05','13607','42',NULL,	
        0,0,0,6.12,0,0,NULL,'1430_13607_42',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,246,'3A',22236,1188,'2012-12-13','7','13.23',NULL,	
        0,0,0,24.48,0,0,NULL,'1407_7_13.23',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,245,NULL,NULL,NULL,NULL,'37','29',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_37_29',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,245,'15C',2996,879,'1988-02-02','16','10',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_16_10',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,245,'2',24497,1496,'2022-08-05','17','2',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_16_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,244,NULL,NULL,NULL,NULL,'5002','10',NULL,	
        0,0,0,39.06,0,0,NULL,'1427_5002_10',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,243,'3A',23268,832,'2017-12-14','42','33',NULL,	
        0,0,0,19.53,0,0,NULL,'1407_42_33',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,242,NULL,NULL,NULL,NULL,'33','113.01',NULL,	
        0,0,0,5.965,0,0,NULL,'1407_33_113.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,242,'3A',23057,532,'2016-10-28','33','113.02',NULL,	
        0,0,0,5.965,0,0,NULL,'1407_33_113.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.15',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,'3A',NULL,NULL,NULL,'12','1.16',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.16',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.17',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.17',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.18',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.18',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.19',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.19',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.20',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.20',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.19',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.19',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.20',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.20',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.21',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.21',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.22',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.22',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.23',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.23',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.24',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.24',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.25',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.25',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.26',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.26',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.27',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.27',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,241,NULL,NULL,NULL,NULL,'12','1.28',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.28',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1407,241,NULL,NULL,NULL,NULL,'12','1.29',NULL,			
        0,0,0,4.1,0,0,NULL,'1407_12_1.29',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1407,240,'3A',21517,582,'2010-01-11','26.01','18.01',NULL,	
        0,0,0,8.03,0,0,NULL,'1407_26.01_18.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,239,'15C',22259,714,'2013-02-07','16','22.01',NULL,	
        0,0,0,7.77,0,0,NULL,'1438_16_22.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,238,'3A',24191,40,'2020-10-23','5300','56',NULL,	
        0,0,0,6.595,0,0,NULL,'1427_5300_56',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,238,NULL,NULL,NULL,NULL,'5300','57',NULL,	
        0,0,0,6.595,0,0,NULL,'1427_5300_57',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,237,'3A',24519,541,'2022-09-28','147','42.15',NULL,	
        0,0,0,0.00,0,0,NULL,'1419_147_42.15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,236,NULL,NULL,NULL,NULL,'7','15',NULL,	
        0,0,0,96.21,0,0,NULL,'1407_7_15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1432,235,NULL,NULL,NULL,NULL,'47','34',NULL,	
        0,0,0,0.00,0,0,NULL,'1432_47_34',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1432,235,'1',24341,358,'2021-12-21','47','2',NULL,	
        0,0,0,0.00,0,0,NULL,'1432_47_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1432,235,'3A',24706,1881,'2023-12-28','48','2',NULL,	
        0,0,0,0.00,0,0,NULL,'1432_48_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1432,235,NULL,NULL,NULL,NULL,'48','34',NULL,	
        0,0,0,0.00,0,0,NULL,'1432_48_34',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,234,'3A',0000,0000,NULL,'55','30',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_55_30',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,233,NULL,NULL,NULL,NULL,'55','10.03',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_55_10.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,232,'3A',21447,1317,'2009-11-27','55','9',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_55_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,231,'3A',24871,1732,'2025-01-14','54','30',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_54_30',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,231,NULL,NULL,NULL,NULL,'54','30.01',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_54_30.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1419,230,NULL,NULL,NULL,NULL,'147','42.01',NULL,	
        0,0,0,0.00,0,0,NULL,'1419_147_42.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1419,230,NULL,NULL,NULL,NULL,'147','42.09',NULL,	
        0,0,0,0.00,0,0,NULL,'1419_147_42.09',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1419,230,NULL,NULL,NULL,NULL,'147','42.11',NULL,	
        0,0,0,0.00,0,0,NULL,'1419_147_42.11',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1419,230,'3A',NULL,NULL,NULL,'147','42.14',NULL,	
        0,0,0,0.00,0,0,NULL,'1419_147_42.14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1419,230,NULL,NULL,NULL,NULL,'147','42.16',NULL,	
        0,0,0,0.00,0,0,NULL,'1419_147_42.16',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1419,230,NULL,NULL,NULL,NULL,'147','42.17',NULL,	
        0,0,0,0.00,0,0,NULL,'1419_147_42.17',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,NULL,NULL,NULL,NULL,'41.01','29',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_41.01_29',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,'2',2675,693,'1983-06-10','41.01','13',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_41.01_13',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,229,NULL,NULL,NULL,NULL,'41.01','14.01',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_41.01_14.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,229,NULL,NULL,NULL,NULL,'41.01','14.03',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_41.01_14.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,229,NULL,NULL,NULL,NULL,'41.01','14.04',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_41.01_14.04',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,229,NULL,NULL,NULL,NULL,'42','29',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_42_29',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,'2',24461,166,'2022-04-11','42','13',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_42_13',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,229,NULL,NULL,NULL,NULL,'42','14.01',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_42_14.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,229,NULL,NULL,NULL,NULL,'42','14.03',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_2_14.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,229,NULL,NULL,NULL,NULL,'42','14.04',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_42_14.04',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,NULL,NULL,NULL,NULL,'61','1',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_61_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,NULL,NULL,NULL,NULL,'61','1.03',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_61_1.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,NULL,NULL,NULL,NULL,'61','1.04',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_61_1.04',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,NULL,NULL,NULL,NULL,'61','5.01',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_61_5.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,NULL,NULL,NULL,NULL,'61','5.02',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_61_5.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,NULL,NULL,NULL,NULL,'61','5.03',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_61_5.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,'3A',21352,1621,'2009-05-21','61','6',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_61_6',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,NULL,NULL,NULL,NULL,'61','19',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_61_19',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,'3A',NULL,NULL,NULL,'61','20',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_61_20',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,229,'3A',3458,233,NULL,'61','21',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_61_21',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,228,'2',2715,338,NULL,'43','48.01',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_43_48.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,227,'3A',0000,0000,NULL,'47','25',NULL,	
        0,0,0,2.65,0,0,NULL,'1438_47_25',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,227,NULL,NULL,NULL,NULL,'46','2',NULL,	
        0,0,0,2.65,0,0,NULL,'1438_46_2',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,227,NULL,NULL,NULL,NULL,'46','2.01',NULL,	
        0,0,0,2.65,0,0,NULL,'1438_46_2.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,227,'3A',0000,0000,NULL,'46','3',NULL,	
        0,0,0,2.65,0,0,NULL,'1438_46_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,226,'3A',23554,404,'2019-04-02','50','23',NULL,	
        0,0,0,15.43,0,0,NULL,'1438_50_23',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        
        (1438,225,'3A',23462,1448,'2018-12-05','42.03','23',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_42.03_23',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
         
        (1438,225,'2',22834,740,'2015-12-11','42.03','6',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_42.03_6',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,225,NULL,NULL,NULL,NULL,'62','23',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_62_23',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,225,NULL,NULL,NULL,NULL,'62','6',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_62_6',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,224,'3A',24535,190,'2022-11-17','2401','5',NULL,	
        0,0,0,0.00,0,0,NULL,'1418_2401_5',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,223,'3A',21536,902,'2009-07-08','62','1',NULL,	
        0,0,0,0.00,0,0,NULL,'1438_62_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,222,NULL,NULL,NULL,NULL,'4','42',NULL,	
        0,0,0,0.00,0,0,NULL,'1407_4_42',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,222,'3A',21222,126,'2009-01-29','4','43',NULL,	
        0,0,0,0.00,0,0,NULL,'1407_4_43',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1436,221,'3A',22689,943,'2015-03-28','5601','3',NULL,	
        0,0,0,0.00,0,0,NULL,'1436_5601_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,220,NULL,NULL,NULL,NULL,'12','1.04',NULL,	
        0,0,0,0.00,0,0,NULL,'1407_12_1.04',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,220,NULL,NULL,NULL,NULL,'12','1.05',NULL,	
        0,0,0,0.00,0,0,NULL,'1407_12_1.05',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,220,NULL,NULL,NULL,NULL,'12','1.06',NULL,	
        0,0,0,0.00,0,0,NULL,'1407_12_1.06',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,220,NULL,NULL,NULL,NULL,'12','1.07',NULL,	
        0,0,0,0.00,0,0,NULL,'1407_12_1.07',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,220,NULL,NULL,NULL,NULL,'12','1.08',NULL,	
        0,0,0,0.00,0,0,NULL,'1407_12_1.08',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,220,NULL,NULL,NULL,NULL,'12','1.09',NULL,	
        0,0,0,0.00,0,0,NULL,'1407_12_1.09',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,220,NULL,NULL,NULL,NULL,'12','1.13',NULL,	
        0,0,0,0.00,0,0,NULL,'1407_12_1.13',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,220,NULL,NULL,NULL,NULL,'12','1.14',NULL,	
        0,0,0,0.00,0,0,NULL,'1407_12_1.14',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1416,219,NULL,NULL,NULL,NULL,'3','3',NULL,	
        0,0,0,0.00,0,0,NULL,'1416_3_3',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1419,218,'3A',23910,740,'2020-10-08','109','22',NULL,	
        0,0,0,47.00,0,0,NULL,'1419_109_22',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,217,'3A',22351,597,'2013-05-28','30','21',NULL,	
        0,0,0,97.00,0,0,NULL,'1438_30_21',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,216,NULL,NULL,NULL,NULL,'10','18.02',NULL,	
        0,0,0,9.55,0,0,NULL,'1413_10_18.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,216,'3A',24539,909,'2022-11-21','10','18.03',NULL,	
        0,0,0,9.55,0,0,NULL,'1413_10_18.03',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1413,216,NULL,NULL,NULL,NULL,'10','18.04',NULL,	
        0,0,0,9.55,0,0,NULL,'1413_10_18.04',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,215,'15C',22838,827,'2015-12-18','501','23',NULL,	
        0,0,0,5.25,0,0,NULL,'1418_501_23',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1418,215,NULL,NULL,NULL,NULL,'117','33',NULL,	
        0,0,0,5.25,0,0,NULL,'1418_117_33',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,214,'3A',23446,1092,'2018-10-26','4','35.02',NULL,	
        0,0,0,25.00,0,0,NULL,'1407_4_35.02',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,213,'15C',21340,617,'2009-03-04','33','70.01',NULL,	
        0,0,0,36.04,0,0,NULL,'1438_33_70.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,212,'2',24675,185,'2023-05-20','5300','10',NULL,	
        0,0,0,0.00,0,0,NULL,'1427_5300_10',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1427,212,'3A',24675,185,'2023-05-20','5300','10.01',NULL,	
        0,0,0,0.00,0,0,NULL,'1427_5300_10.01',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,211,NULL,NULL,NULL,NULL,'1602','18',NULL,	
        0,0,0,6.47,0,0,NULL,'1431_1602_18',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,211,NULL,NULL,NULL,NULL,'1602','16',NULL,	
        0,0,0,6.47,0,0,NULL,'1431_1602_16',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,211,NULL,NULL,NULL,NULL,'2902','18',NULL,	
        0,0,0,6.47,0,0,NULL,'1431_2902_18',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,211,'3A',NULL,NULL,NULL,'2902','20',NULL,	
        0,0,0,6.47,0,0,NULL,'1431_2902_20',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,211,'3A',NULL,NULL,NULL,'2902','26',NULL,	
        0,0,0,6.47,0,0,NULL,'1431_2902_26',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,211,'3A',21234,704,'2009-02-20','2902','19',NULL,	
        0,0,0,6.47,0,0,NULL,'1431_2902_19',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1431,211,NULL,NULL,NULL,NULL,'3001','1',NULL,	
        0,0,0,6.47,0,0,NULL,'1431_3001_1',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1438,210,'3A',21447,1317,'2009-11-27','55','9',NULL,	
        0,0,0,19.90,0,0,NULL,'1438_55_9',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1435,209,'3A',23146,742,'2017-06-12','31001','17',NULL,	
        0,0,0,21.00,0,0,NULL,'1435_31001_17',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1435,208,'3A',NULL,NULL,NULL,'50003','8',NULL,	
        0,0,0,17.00,0,0,NULL,'1435_50003_8',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        (1407,207,NULL,NULL,NULL,NULL,'7','15',NULL,	
        0,0,0,97.03,0,0,NULL,'1407_7_15',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),''),
        
        
        (1407,206,'2',23725,1850,'2020-02-14','12','4',NULL,	
        0,0,0,0.00,0,0,NULL,'1407_12_4',NULL,NULL,
        NULL,NULL,NULL,NULL,NULL,1,NULL,NULL,NULL,GetDate(),'')


			 

            COMMIT;
            PRINT 'MunicipalityBlockLotParcel table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH