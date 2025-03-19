BEGIN TRY
   BEGIN TRANSACTION

--DROP TABLE
DROP TABLE IF EXISTS #FarmEsmtExistNonAgriUses

--CREATE TABLE
CREATE TABLE #FarmEsmtExistNonAgriUses(

   [Id]							   [integer] 		IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                 [integer]                       NOT NULL,
   [IsSubdivisionApproval]         [bit]                           NOT NULL,
   [InfoAboutPremises]             [varchar](4000)                     NULL,   
   [LastUpdatedBy]				   [varchar](128)		               NULL, 
   [LastUpdatedOn]				   [datetime]			           NOT NULL
   CONSTRAINT [PK_#FarmEsmtExistNonAgriUses_ID] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

--Insert Script For #FarmEsmtExistNonAgriUses
INSERT INTO #FarmEsmtExistNonAgriUses
            (                              
              ApplicationID                  
             ,IsSubdivisionApproval         
             ,InfoAboutPremises                
             ,LastUpdatedBy	   
             ,LastUpdatedOn
            )
			SELECT
			  ProjectID
			 ,0 AS IsSubdivisionApproval         
             ,NULL AS InfoAboutPremises
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			  FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application FarmEsmtExistNonAgriUses Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH