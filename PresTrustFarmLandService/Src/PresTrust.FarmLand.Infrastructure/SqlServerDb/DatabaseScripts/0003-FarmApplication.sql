BEGIN TRY
   BEGIN TRANSACTION

   --Drop Table
   TRUNCATE TABLE [Farm].[FarmApplication]

  CREATE TABLE [Farm].[#FarmApplication]
(
	[Id]								 [integer]              NOT NULL,                                                                                                                                            
    [Title]								 [varchar](256)         NOT NULL,                                                                                    
    [AgencyId]							 [integer]              NOT NULL,                                                                        
    [FarmListId]                         [integer]              NOT NULL,                                                                                                                                     
    [ApplicationTypeId]                  [integer]              NOT NULL,
	[StatusId]                           [integer]              NOT NULL, 
	[CreatedByProgramUser]               [bit]                  NOT NULL,
	[IsApprovedByMunicipality]           [bit]                  NOT NULL,
	[CreatedOn]                          [DateTime]             NOT NULL,
	[CreatedBy]                          [varchar](128)         NULL,    
	[IsActive]                           [bit]                  NULL,
	[IsSADC]                             [bit]                  NULL
CONSTRAINT [PK_#FarmApplication_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


		-- Insert From Legacy Table

        INSERT INTO [Farm].[#FarmApplication]
		(
			[Id] ,
			[Title],
			[AgencyId],
			[FarmListId],
			[ApplicationTypeId],
			[StatusId],
			[CreatedByProgramUser],
			[IsApprovedByMunicipality] ,
			[CreatedOn],
			[CreatedBy],
			[IsActive],
			[IsSADC]
			  
			)
            SELECT 
					[Id],
					[ProjectName] AS [Title], -- [ID]
					[AgencyId],
					[FarmListID],
					NULL AS [ApplicationTypeId],
					NULL AS [StatusId],
					NULL AS [CreatedByProgramUser],
					[Municipally Approved?],
					NULL AS [CreatedOn],
					NULL AS [CreatedBy],
					NULL AS [IsActive],
					NULL AS [IsSADC]
                FROM  [Farm].[TermProgram_Legacy]  

            COMMIT;
            PRINT 'Application table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH