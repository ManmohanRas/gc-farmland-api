BEGIN TRY
   BEGIN TRANSACTION

		TRUNCATE TABLE [Farm].[FarmTermAppDeedLocation];
		INSERT INTO [Farm].[FarmTermAppDeedLocation]
		(
		  ApplicationId
		 ,ParcelId
		 ,DeedId
		 ,IsChecked
		)
		SELECT ApplicationId,
			   ParcelId,
			   NULL,
			   1
		FROM [Farm].[FarmAppLocationDetails];
						

		COMMIT;
		PRINT 'Farm DeedLocation table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);
    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;

    SELECT @ErrorMessage;
END CATCH
