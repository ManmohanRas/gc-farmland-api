BEGIN TRY
BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmEsmtAppAdminExceptionRDSO
 
-- Create Table
CREATE TABLE #FarmEsmtAppAdminExceptionRDSO (
	[Id]						[integer] IDENTITY(1,1) NOT NULL,
	[ApplicationId]				[integer]               NOT NULL,
	[NumberofExceps]			[integer]					NULL,
	[Excep1Acres]				[decimal](18,2)				NULL,
	[X1Purpose]					[varchar](128)				NULL,
	[X1Severable]				[bit]						NULL,
	[X1IsSubdividable]			[bit]						NULL,
	[X1IsRTF]					[bit]						NULL,
	[Excep2Acres]				[decimal](18,2)             NULL,
	[X2Purpose]					[varchar](128)              NULL,
	[X2IsSeverable]				[bit]					    NULL,
	[X2IsSubdividable]			[bit] 					    NULL,
	[X2IsRTF]					[bit] 					    NULL,
	[Excep3Acres]				[decimal](18,2) 		    NULL,
	[X3Purpose]					[varchar](128)			    NULL,
	[X3IsSeverable]				[bit] 					    NULL,
	[X3IsSubdividable]			[bit] 				        NULL,
	[X3IsRTF]                   [bit]                       NULL,
	[RDSOsNum]		            [integer]				    NULL,
	[RDSOExplan]				[varchar](128)			    NULL,
	[IsRDSOExercised]			[bit]					    NULL,
	[LastUpdatedBy]				[varchar](128) 			    NULL,
	[LastUpdatedOn]				[datetime]              NOT NULL,
CONSTRAINT [PK_#FarmEsmtAppAdminExceptionRDSO_Id] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

----Insert Script For #FarmEsmtAppAdminExceptionRDSO
INSERT INTO #FarmEsmtAppAdminExceptionRDSO
            (
			  ApplicationId
			 ,NumberofExceps           
			 ,Excep1Acres              
			 ,X1Purpose                
			 ,X1Severable              
			 ,X1IsSubdividable         
			 ,X1IsRTF                  
			 ,Excep2Acres              
			 ,X2Purpose                
			 ,X2IsSeverable            
			 ,X2IsSubdividable        
			 ,X2IsRTF                  
			 ,Excep3Acres              
			 ,X3Purpose                
			 ,X3IsSeverable            
			 ,X3IsSubdividable         
			 ,X3IsRTF                  
			 ,RDSOSNum		   
			 ,RDSOExplan               
			 ,IsRDSOExercised          
			 ,LastUpdatedBy            
			 ,LastUpdatedOn
			)
            SELECT 
		      ProjectID
		     ,NumberofExceps
		     ,Excep1Acres
		     ,TRY_CAST(X1Purpose AS nvarchar(max))
		     ,CASE 
			      WHEN X1Severable = 'Yes' THEN 1
				  WHEN X1Severable = 'No' THEN 0
				  ELSE NULL
				  END AS X1Severable   
             ,CASE 
			      WHEN X1IsSubdividable = 'Yes' THEN 1
				  WHEN X1IsSubdividable = 'No' THEN 0
				  ELSE NULL
				  END AS X1IsSubdividable 
			 ,CASE 
			      WHEN X1IsRTF = 'Yes' THEN 1
				  WHEN X1IsRTF = 'No' THEN 0
				  ELSE NULL
				  END AS X1IsRTF 	  
		     ,Excep2Acres
		     ,TRY_CAST(X2Purpose AS nvarchar(max))
		     ,CASE 
			      WHEN X2IsSeverable = 'Yes' THEN 1
				  WHEN X2IsSeverable = 'No' THEN 0
				  ELSE NULL
				  END AS X2IsSeverable   
             ,CASE 
			      WHEN X2IsSubdividable = 'Yes' THEN 1
				  WHEN X2IsSubdividable = 'No' THEN 0
				  ELSE NULL
				  END AS X2IsSubdividable 
			 ,CASE 
			      WHEN X2IsRTF = 'Yes' THEN 1
				  WHEN X2IsRTF = 'No' THEN 0
				  ELSE NULL
				  END AS X2IsRTF
		     ,Excep3Acres
		     ,TRY_CAST(X3Purpose AS nvarchar(max))
		     ,CASE 
			      WHEN X3IsSeverable = 'Yes' THEN 1
				  WHEN X3IsSeverable = 'No' THEN 0
				  ELSE NULL
				  END AS X3IsSeverable   
             ,CASE 
			      WHEN X3IsSubdividable = 'Yes' THEN 1
				  WHEN X3IsSubdividable = 'No' THEN 0
				  ELSE NULL
				  END AS X3IsSubdividable 
			 ,CASE 
			      WHEN X3IsRTF = 'Yes' THEN 1
				  WHEN X3IsRTF = 'No' THEN 0
				  ELSE NULL
				  END AS X3IsRTF
		     ,RDSOsNum
		     ,TRY_CAST(RDSOExplan AS nvarchar(max))
			 ,CASE 
			      WHEN IsRDSOExercised = 'Yes' THEN 1
				  WHEN IsRDSOExercised = 'No' THEN 0
				  ELSE NULL
				  END AS IsRDSOExercised
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application Admin Actions ExceptionRDSO Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH