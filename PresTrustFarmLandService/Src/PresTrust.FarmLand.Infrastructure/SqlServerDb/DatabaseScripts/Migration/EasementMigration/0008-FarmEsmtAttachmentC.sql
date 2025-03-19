BEGIN TRY
   BEGIN TRANSACTION

--DROP TABLE
DROP TABLE IF EXISTS #FarmEsmtAttachmentC

--CREATE TABLE
CREATE TABLE #FarmEsmtAttachmentC(
   [Id]							   [integer] 		       IDENTITY(1,1)  NOT NULL,
   [ApplicationId]                 [integer]                              NOT NULL,
   [IsExceptionAreaPreserved]      [bit]                                  NOT NULL,
   [IsNonAgriPremisesPreserved]    [bit]                                  NOT NULL, 
   [DescNonAgriUses]		       [varchar](4000)		                      NULL, 
   [NonAgriAreaUtilization]		   [varchar](4000)		                      NULL, 
   [NonAgriLease]                  [varchar](4000)		                      NULL, 
   [NonAgriUseAccessParcel]		   [varchar](4000)		                      NULL,  
   [IsLeaseWithAnotherParty]	   [bit]									  NULL,
   [LastUpdatedBy]				   [varchar](128)		                      NULL, 
   [LastUpdatedOn]				   [datetime]			                  NOT NULL
   CONSTRAINT [PK_#FarmEsmtAttachmentC_Id] PRIMARY KEY CLUSTERED
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtAttachmentC
INSERT INTO #FarmEsmtAttachmentC
            (                 
              ApplicationId                                        
             ,IsExceptionAreaPreserved                              
             ,IsNonAgriPremisesPreserved
             ,IsLeaseWithAnotherParty
             ,DescNonAgriUses
             ,NonAgriAreaUtilization			 	           
             ,NonAgriLease				    
             ,NonAgriUseAccessParcel				             
             ,LastUpdatedBy				         
             ,LastUpdatedOn
            )
			SELECT
			  ProjectID
			 ,0 AS IsExceptionAreaPreserved
			 ,CASE 
			       WHEN AreNonAgUses ='Yes' THEN 1
			       ELSE 0
			   END AS IsNonAgriPremisesPreserved
             ,NULL AS IsLeaseWithAnotherParty
			 ,NonAgExplan
			 ,NULL AS NonAgriAreaUtilization			 	           
             ,NULL AS NonAgriLease				    
             ,NULL AS NonAgriUseAccessParcel
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			  FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application FarmEsmtAttachmentC Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH