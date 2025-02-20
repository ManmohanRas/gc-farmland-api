USE PrestrustTemp;

BEGIN TRY
   BEGIN TRANSACTION

               DECLARE  @v_LEGACY_RECORD_COUNT  AS INT
                        ,@v_LEGACY_RECORD_INDEX AS INT;

             DROP TABLE IF EXISTS #temp_farmlist_legacy;
             CREATE TABLE #temp_farmlist_legacy (Id INT IDENTITY(1,1), LegacyFarmListId INTEGER)

             INSERT INTO      #temp_farmlist_legacy (LegacyFarmListId)
                   SELECT     LegacyFarmListId
                    FROM      [Farm].[FarmListLegacy]
                    WHERE    ISNULL(NewFarmListId,0) = 0;

                     SET   @v_LEGACY_RECORD_COUNT = @@ROWCOUNT;
                     SET   @v_LEGACY_RECORD_INDEX = 1;
                                                
                   WHILE (@v_LEGACY_RECORD_INDEX <= @v_LEGACY_RECORD_COUNT)
                   BEGIN
                   DECLARE   @v_LEGACY_FARMLIST_ID AS INT,
                              @v_NEW_FARMLIST_ID AS INT;
                                                                                                

                   SELECT @v_LEGACY_FARMLIST_ID = LegacyFarmListId 
                   FROM   #temp_farmlist_legacy
                   WHERE  ID = @v_LEGACY_RECORD_INDEX;

                  --select * from [PresTrust_DEV].Farm.FarmList
                  INSERT INTO Farm.FarmList
                            ([FarmNumber],                                                                                               
                             [FarmName],                        
                             [Status],                         
                             [AgencyID],                       
                             [OriginalLandowner],                 
                             [Address1],                         
                             [Address2],     
                             [MunicipalId]
                           )
                    SELECT  TOP(1)
                           [FarmNumber],
                           [FarmName],
                           [Status],
                           ISNULL([AgencyID],0) AS [AgencyID],
                           [OriginalLandowner],
                           [Street1],
                           [Street2],
                           [MunicipalId]

                     FROM  [Farm].[FarmListLegacy] FLL
					 LEFT JOIN
					 [Farm].[OwnerPropertyLEGACY_Rev02] OWRL ON (FLL.LegacyFarmListId =  OWRL.FarmListID)
                     WHERE   LegacyFarmListId = @v_LEGACY_FARMLIST_ID

                    SET @v_NEW_FarmList_ID = SCOPE_IDENTITY();

                     --SELECT @v_NEW_FarmList_ID;

                    UPDATE [Farm].[FarmListLegacy] 
                    SET NewFarmListId = @v_NEW_FarmList_ID 
                    WHERE LegacyFarmListId = @v_LEGACY_FARMLIST_ID;

                   SET @v_LEGACY_RECORD_INDEX = @v_LEGACY_RECORD_INDEX + 1;
 END

                                --select * from Farm.FarmList;
                                --SELECT * FROM [Farm].[FarmListLegacy];
                                                                 

                                --select 1/0;
   COMMIT;
   PRINT 'FarmList legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);
    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;

    SELECT @ErrorMessage;
END CATCH
