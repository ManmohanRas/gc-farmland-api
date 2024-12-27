
BEGIN TRY
   BEGIN TRANSACTION

   --Drop Table
   TRUNCATE TABLE [Farm].[#FarmTermAppSiteCharacteristics]

CREATE TABLE [Farm].[#FarmTermAppSiteCharacteristics]
(
	[ApplicationId]						[integer]				    NOT NULL,                                                                                                                                            
    [Area]  							[varchar](50)               NULL,
	[LandUse]                           [varchar](128)              NULL,
    [CropLand]                          [varchar](50)               NULL,                                                                        
    [WoodLand]                          [varchar](50)               NULL,                                                                                                                                     
    [Pasture]                           [varchar](50)               NULL,
	[Orchard]                           [varchar](50)               NULL,
	[Other]                             [varchar](50)               NULL,
	[IsEasement]                        [bit]                       NULL,
	[IsRightOfway]                      [bit]                       NULL,
	[NoteEasementRightOfway]            [varchar](256)              NULL,
	[IsMortgage]                        [bit]                       NULL,
	[IsLines]                           [bit]                       NULL,
	[NoteMortgageLines]                 [varchar](256)              NULL,

CONSTRAINT [PK_#FarmTermAppSiteCharacteristics_Id] PRIMARY KEY CLUSTERED
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


--script to migrate legacy term application into bridge table FarmTermApplicationLegacy

  
		-- Insert From Legacy Table

        INSERT INTO [Farm].[#FarmTermAppSiteCharacteristics]
		(
			[ApplicationId],
			[Area],  		
			[LandUse],     
			[CropLand],    
			[WoodLand],    
			[Pasture],     
			[Orchard],     
			[Other],       
			[IsEasement],  
			[IsRightOfway],
			[NoteEasementRightOfway],
			[IsMortgage],       
			[IsLines],          
			[NoteMortgageLines]
			)
            SELECT 
					[Id],
					NULL AS [Area],
					NULL AS [LandUse],
					NULL AS [CropLand],
					NULL AS [WoodLand],
					NULL AS [Pasture],
					NULL AS [Orchard],
					NULL AS [Other],
					NULL AS [IsEasement],
					NULL AS [IsRightOfway],
					NULL AS [NoteEasementRightOfway],
					NULL AS [IsMortgage],
					NULL AS [IsLines],
					NULL AS  [NoteMortgageLines]
                FROM  [Farm].[TermProgram_Legacy]  

            COMMIT;
            PRINT 'Term application SiteCharacteristics legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH

