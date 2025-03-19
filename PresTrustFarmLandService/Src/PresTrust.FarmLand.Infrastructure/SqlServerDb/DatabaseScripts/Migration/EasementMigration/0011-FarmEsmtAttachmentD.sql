BEGIN TRY
   BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmEsmtAttachmentD

-- Create Table
CREATE TABLE #FarmEsmtAttachmentD(
	[Id]									[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]							[integer]						NOT NULL,
	[EquineActivityTypeId]                  [integer]							NULL,
	[Counts]								[decimal](18,2)						NULL,
	[Number]								[integer]							NULL,
	[NumberOfHorses]						[integer]							NULL,
	[NumberOfHorsesActivity]				[integer]							NULL,
	[NumberOfStalls]						[integer]							NULL,
	[RunInSheds]							[integer]							NULL,
	[IndoorRidingArena]						[integer]							NULL,
	[OutdoorRidingArena]					[integer]							NULL,
	[LastUpdatedBy]							[varchar](128)						NULL,
	[LastUpdatedOn]							[datetime]						NOT NULL,
		
CONSTRAINT [PK_#FarmEsmtAttachmentD_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtAttachmentD
INSERT INTO #FarmEsmtAttachmentD
            (
              ApplicationId
             ,EquineActivityTypeId
             ,Counts
             ,Number
             ,NumberOfHorses
             ,NumberOfHorsesActivity
             ,NumberOfStalls
             ,RunInSheds
             ,IndoorRidingArena
             ,OutdoorRidingArena
             ,LastUpdatedBy
             ,LastUpdatedOn
           )
		   SELECT
			  ProjectID
			 ,NULL AS EquineActivityTypeId
             ,NULL AS Counts
             ,NULL AS Number
             ,NULL AS NumberOfHorses
             ,NULL AS NumberOfHorsesActivity
             ,NULL AS NumberOfStalls
             ,NULL AS RunInSheds
             ,NULL AS IndoorRidingArena
             ,NULL AS OutdoorRidingArena
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application Equine Uses Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH