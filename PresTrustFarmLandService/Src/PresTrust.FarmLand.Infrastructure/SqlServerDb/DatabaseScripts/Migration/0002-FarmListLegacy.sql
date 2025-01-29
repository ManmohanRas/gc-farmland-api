BEGIN TRY
   BEGIN TRANSACTION

   --Drop Table
   DROP TABLE IF EXISTS [Farm].[LegacyFarmList];

CREATE TABLE [Farm].[LegacyFarmList] (
			LegacyFarmListId    INT				NOT NULL,
			LegacyFarmName      VARCHAR(128)    NULL,
			NewFarmListId		INT             NULL,
		
CONSTRAINT [PK_LegacyFarmList_Id] PRIMARY KEY CLUSTERED
(
	[LegacyFarmListId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


---insert into legacyFarmList Table

	INSERT INTO [Farm].[LegacyFarmList]
		(
			LegacyFarmListId,
			LegacyFarmName,
			NewFarmListId
		)
		SELECT
			FarmListId,
			FarmName,
			NULL AS NewFarmListId
		FROM [Farm].[TermProgram_LEGACY]

		COMMIT;
		PRINT 'FarmList legacy table has been populated';


END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH