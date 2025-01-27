
 BEGIN TRY
	BEGIN TRANSACTION

	--===================================================================================================================================================
DROP TABLE IF EXISTS Farm.#FarmMunicipalityBlockLotParcel


-- Create Table
CREATE TABLE Farm.#FarmMunicipalityBlockLotParcel(
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
	[LastUpdatedBy]         [varchar](256)           NULL,   
	);

	   INSERT INTO Farm.#FarmMunicipalityBlockLotParcel
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
			(NULL,1407,116,NULL,0,0,NULL,'15','24',NULL,
			 0,0,0,0,0,0,NULL,'1407_15_24',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL) ,
			 
			 (NULL,1407,116,NULL,0,0,NULL,'15','26',NULL,
			 0,0,0,0,0,0,NULL,'1407_15_26',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL) ,
			 
			 (NULL,1407,116,NULL,0,0,NULL,'15','28',NULL,
			 0,0,0,0,0,0,NULL,'1407_15_28',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL) ,
			 
			 (NULL,1407,116,NULL,0,0,NULL,'15','33',NULL,
			 0,0,0,0,0,0,NULL,'1407_15_33',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 
			 (NULL,1407,116,NULL,0,0,NULL,'15','34',NULL,
			 0,0,0,0,0,0,NULL,'1407_15_34',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1407,116,NULL,0,0,NULL,'19','11',NULL,
			 0,0,0,0,0,0,NULL,'1407_19_11',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1407,277,'15C',5323,124,'2001-01-22','10','52',NULL,
			 0,0,79,0,0,0,NULL,'1407_10_52',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1407,277,'15C',5695,76,'2002-08-15','10','107',NULL,
			 0,0,79,0,0,0,NULL,'1407_10_107',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1407,278,'2',22994,62,'2016-07-27','16.01','1',NULL,
			 0,0,89,0,0,0,NULL,'1407_16.01_1',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1407,279,NULL,NULL,NULL,NULL,'46.01','35',NULL,
			 0,0,26,0,0,0,NULL,'1407_46.01_35',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1407,279,'3A',23057,532,'2016-10-28','33','113.01',NULL,
			 0,0,26,0,0,0,NULL,'1407_33_113.01',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1407,279,NULL,NULL,NULL,NULL,'6000','4',NULL,
			 0,0,26,0,0,0,NULL,'1407_6000_4',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1430,280,NULL,NULL,NULL,NULL,'194','6',NULL,
			 0,0,0,0,0,0,NULL,'1430_194_6',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1430,280,NULL,NULL,NULL,NULL,'194','6.1',NULL,
			 0,0,0,0,0,0,NULL,'1430_194_6.1',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1430,280,NULL,NULL,NULL,NULL,'194','41',NULL,
			 0,0,0,0,0,0,NULL,'1430_194_41',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1430,280,NULL,NULL,NULL,NULL,'225','10.01',NULL,
			 0,0,0,0,0,0,NULL,'1430_225_10.01',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1430,280,NULL,NULL,NULL,NULL,'225','11',NULL,
			 0,0,0,0,0,0,NULL,'1430_225_11',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1430,280,NULL,NULL,NULL,NULL,'225','12',NULL,
			 0,0,0,0,0,0,NULL,'1430_225_12',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1430,280,NULL,NULL,NULL,NULL,'225','13',NULL,
			 0,0,0,0,0,0,NULL,'1430_225_13',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,22,'3B',22579,198,'2014-08-12','33','51','QFARM',
			 0,0,39.5,0,0,0,NULL,'1438_33_51',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,22,'3B',22579,198,'2014-08-12','34','50',NULL,
			 0,0,39.5,0,0,0,NULL,'1438_34_50',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,282,'3B',23348,650,'2018-05-09','46','6',NULL,
			 0,0,11.99,0,0,0,NULL,'1438_46_6',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,282,NULL,NULL,NULL,NULL,'46','6.1',NULL,
			 0,0,11.99,0,0,0,NULL,'1438_46_6.1',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,282,'3B',2785,5660,'1985-03-29','46','7','QFARM',
			 0,0,11.99,0,0,0,NULL,'1438_46_7',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,283,'3A',23571,1494,'2019-06-20','37','26',NULL,
			 0,0,0,0,0,0,NULL,'1438_37_26',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,283,NULL,NULL,NULL,NULL,'37','39',NULL,
			 0,0,0,0,0,0,NULL,'1438_37_39',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,284,NULL,NULL,NULL,NULL,'2','27',NULL,
			 0,0,0,0,0,0,NULL,'1438_2_27',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,284,NULL,NULL,NULL,NULL,'2','28.1',NULL,
			 0,0,0,0,0,0,NULL,'1438_2_28.1',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,284,NULL,NULL,NULL,NULL,'2','28.2',NULL,
			 0,0,0,0,0,0,NULL,'1438_2_28.2',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,285,'3B',NULL,NULL,NULL,'62','6',NULL,
			 0,0,9.63,0,0,0,NULL,'1438_62_6',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,21,'2',5486,16,'2001-10-04','34','38',NULL,
			 0,0,0,0,0,0,NULL,'1438_34_38',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,48,'3A',24696,185,'2023-12-14','28','4',NULL,
			 0,0,10,0,0,0,NULL,'1438_28_4',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,193,'3B',5887,243,'2003-06-19','34','37','QFARM',
			 0,0,0,0,0,0,NULL,'1438_34_37',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,30,'3B',2787,8020,NULL,'33','70','QFARM',
			 0,0,0,0,0,0,NULL,'1438_33_70',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,23,'3B',24322,453,'2021-11-09','28','16','QFARM',
			 0,0,0,0,0,0,NULL,'1438_28_16',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,23,NULL,NULL,NULL,NULL,'28','16.1',NULL,
			 0,0,0,0,0,0,NULL,'1438_28_16.1',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,23,NULL,NULL,NULL,NULL,'28','16.2',NULL,
			 0,0,0,0,0,0,NULL,'1438_28_16.2',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,23,'3A',24322,453,'2021-11-09','36','41',NULL,
			 0,0,0,0,0,0,NULL,'1438_36_41',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,31,'3B',24551,1034,'2023-01-05','55','6','QFARM',
			 0,0,0,0,0,0,NULL,'1438_55_6',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,31,'3B',24551,1034,'2023-01-05','55','8','QFARM',
			 0,0,0,0,0,0,NULL,'1438_55_8',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,31,'3B',24551,1034,'2023-01-05','55','28','QFARM',
			 0,0,0,0,0,0,NULL,'1438_55_28',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,29,'3B',24551,1041,'2023-01-05','55','20','QFARM',
			 0,0,0,0,0,0,NULL,'1438_55_20',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,29,'3B',24551,1041,'2023-01-05','55','20','QFARM',
			 0,0,0,0,0,0,NULL,'1438_55_20',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,28,'3A',3021,344,NULL,'55','14',NULL,
			 0,0,0,0,0,0,NULL,'1438_55_14',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,28,NULL,NULL,NULL,NULL,'55','14.1',NULL,
			 0,0,0,0,0,0,NULL,'1438_55_14.1',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 
			 (NULL,1438,45,'3B',5146,289,'2000-03-04','34','39','QFARM',
			 0,0,59,0,0,0,NULL,'1438_34_39',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1418,302,'3A',22792,428,'2015-09-28','1401','7',NULL,
			 0,0,7.5,0,0,0,NULL,'1418_1401_7',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,55,'3A',2759,726,NULL,'55','15',NULL,
			 0,0,12.1,0,0,0,NULL,'1438_55_15',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 
			 (NULL,1438,297,'3B',3760,93,NULL,'32.02','2','QFARM',
			 0,0,8,0,0,0,NULL,'1438_32.02_2',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,297,'3A',3760,93,NULL,'32.02','3','QFARM',
			 0,0,8,0,0,0,NULL,'1438_32.02_3',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1407,110,'3A',3760,93,'2004-10-20','17','33',NULL,
			 0,0,16.501,0,0,0,NULL,'1407_17_33',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1407,110,NULL,NULL,NULL,NULL,'17','50',NULL,
			 0,0,16.501,0,0,0,NULL,'1407_17_50',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1407,79,NULL,NULL,NULL,NULL,'15','42HL',NULL,
			 0,0,60.6,0,0,0,NULL,'1407_15_42HL',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,300,'3A',NULL,NULL,NULL,'20.10','44',NULL,
			 0,0,55.54,0,0,0,NULL,'1438_20.10_44',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
			 
			 (NULL,1438,15,'3B',22996,424,'2016-09-12','55','4.07','QFARM',
			 0,0,20.28,0,0,0,NULL,'1438_55_4.07',NULL,NULL,
			 NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)
			 


            COMMIT;
            PRINT 'MunicipalityBlockLotParcel table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH