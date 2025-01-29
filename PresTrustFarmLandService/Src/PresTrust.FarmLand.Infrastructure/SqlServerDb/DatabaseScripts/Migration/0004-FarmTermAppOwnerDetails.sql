BEGIN TRY
   BEGIN TRANSACTION

   --Drop Table
   DROP TABLE #FarmAppOwnerDetailList

CREATE TABLE #FarmAppOwnerDetailList
(
	[ApplicationId]						[integer]				      NOT NULL,                                                                                                                                            
    [FirstName]							[varchar](128)              NULL,
	[LastName]                          [varchar](128)              NULL,
    [PropertyLocation]                  [varchar](128)              NULL,                                                                        
    [MunicipalityId]                    [integer]                   NULL,                                                                                                                                     
    [MailingAddress1]                   [varchar](128)              NOT NULL,
	[MailingAddress2]                   [varchar](128)              NULL,
	[PhoneNumber]                       [varchar](15)               NOT NULL,
	[City]                              [varchar](128)              NOT NULL,
	[State]                             [varchar](128)              NOT NULL,
	[ZipCode]                           [integer]                   NOT NULL,
	[Salutation]                        [varchar](15)               NOT NULL,
	[EmailAddress]                      [varchar](128)              NOT NULL,
	[CurrentOwnerMailingName]           [varchar](128)              NOT NULL,
	[LastUpdatedBy]						[varchar](128)				    NULL, 
	[LastUpdatedOn]						[Datetime]				    NOT NULL,

CONSTRAINT [PK_#FarmAppOwnerDetailList_Id] PRIMARY KEY CLUSTERED
(
	[ApplicationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]


--script to migrate legacy term application into bridge table FarmTermApplicationLegacy

  
		-- Insert From Legacy Table

        INSERT INTO #FarmAppOwnerDetailList
		(
			[ApplicationId],
			[FirstName],                                                                                                                                            
			[LastName],                                                                                    
			[PropertyLocation],                                                                        
			[MunicipalityId],                                                                                                                                                        
			[MailingAddress1],                   
			[MailingAddress2],                   
			[PhoneNumber],                       
			[City],                             
			[State],                            
			[ZipCode],
			[Salutation],
			[EmailAddress],
			[CurrentOwnerMailingName]
			)
            SELECT 
					[Id],
					[FirstName],
					[LastName],
					NULL AS [PropertyLocation],
					[MunicipalID],
					[Address1] AS [MailingAddress1],
					[Address2] AS [MailingAddress2],
					NULL AS [PhoneNumber],
					[Town] AS [City],
					[State],
					[Zip Code],
					NULL AS [Salutation],
					NULL AS [EmailAddress],
					NULL AS  [CurrentOwnerMailingName]
                FROM  [Farm].[TermProgram_Legacy]  

            COMMIT;
            PRINT 'Term application Owner Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH
