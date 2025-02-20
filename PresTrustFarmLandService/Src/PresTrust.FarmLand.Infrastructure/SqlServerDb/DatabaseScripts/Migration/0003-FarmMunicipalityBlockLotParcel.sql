
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