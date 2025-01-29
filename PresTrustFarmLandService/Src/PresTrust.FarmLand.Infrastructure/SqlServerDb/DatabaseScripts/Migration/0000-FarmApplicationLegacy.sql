BEGIN TRY
   BEGIN TRANSACTION

   --Drop Table
   DROP TABLE [Farm].[FarmTermApplicationLegacy]


CREATE TABLE [Farm].[FarmTermApplicationLegacy]
(
	[LegacyApplicationId]               [integer]              NOT NULL,  
    [LegacyApplicationTitle]            [varchar](128)         NOT NULL,
    [LegacyFarmListId]                  [integer]              NOT NULL,                                                                                    
    [LegacyApplicationStatus]           [varchar](128)         NOT NULL,                                                                        
    [LegacyAgencyId]                    [integer]              NOT NULL,                                                                                                                                     
    [FarmApplicationId]                 [integer]              NULL,
CONSTRAINT [PK_FarmTermApplicationLegacy_Id] PRIMARY KEY CLUSTERED
(
	[LegacyApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


--script to migrate legacy term application into bridge table FarmTermApplicationLegacy




		-- Insert From Legacy Table

       INSERT INTO [Farm].[FarmTermApplicationLegacy]
		(
        LegacyApplicationId,
        LegacyApplicationTitle,
        LegacyFarmListId,
        LegacyApplicationStatus,
        LegacyAgencyId,
        FarmApplicationId
        )
      SELECT 
			[Id],
			[ProjectName],
			ISNULL([FarmListID], 0) AS [FarmListID],
			[Status],
            [AgencyID],
			NULL AS [FarmApplicationId]
     FROM  [Farm].[TermProgram_Legacy] 

            COMMIT;
            PRINT 'Term application legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH



