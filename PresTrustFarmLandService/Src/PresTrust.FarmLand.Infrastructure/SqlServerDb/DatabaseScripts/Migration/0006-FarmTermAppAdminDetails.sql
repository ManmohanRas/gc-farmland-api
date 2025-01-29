
 BEGIN TRY
	BEGIN TRANSACTION

	--===================================================================================================================================================
-- Create Table
CREATE TABLE #FarmTermAppAdminDetails(
	[Id]							[integer] 		IDENTITY(1,1)	NOT NULL,
	[ApplicationId]					[integer]						NOT NULL,
	[SADCId]						[integer]							NULL,
	[MaxGrant]						[decimal](18,2)						NULL,
	[PermanentlyPreserved]			[bit]								NULL,
	[MunicipallyApproved]			[bit]								NULL,
	[EnrollmentDate]				[dateTime]							NULL,
	[RenewalDate]					[dateTime]							NULL,
	[ExpirationDate]				[dateTime]							NULL,
	[RenewalExpirationDate]			[dateTime]							NULL,
	[Comment]						[varchar](128)						Null,
	[LastUpdatedBy]					[varchar](128)						NULL,
	[LastUpdatedOn]					[datetime]							NOT NULL,
);

	  INSERT INTO #FarmTermAppAdminDetails
		(
			[ApplicationId],						                                                                                                                                             
			[SADCId],	                                                                                    
			[MaxGrant],                                                                                               
			[PermanentlyPreserved],                                                                                                                                                                
			[MunicipallyApproved],                        
			[EnrollmentDate],                      
			[RenewalDate],                         
			[ExpirationDate],                       
			[RenewalExpirationDate],                 
			[Comment],                         
			[LastUpdatedBy],	
			[LastUpdatedOn]
			)
            SELECT 
					[ID],
					[SADC ID#] AS [SADCId], -- [ID]
					[Max Grant $] AS [MaxGrant],
					[Permanently Preserved?] AS [PermanentlyPreserved],
					[Municipally Approved?] AS [MunicipallyApproved],
					[Enrollment Date] AS [EnrollmentDate],
					[Renewal Date] AS [RenewalDate],
					[Expiration Date] AS [ExpirationDate],
					[Renew Expir Date] AS [RenewalExpirationDate],
					[Comment],
					NULL AS LastUpdatedBy,
					GetDate() AS [LastUpdatedOn]
                FROM  [Farm].[TermProgram_Legacy] 

            COMMIT;
            PRINT 'Term application Admin Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH