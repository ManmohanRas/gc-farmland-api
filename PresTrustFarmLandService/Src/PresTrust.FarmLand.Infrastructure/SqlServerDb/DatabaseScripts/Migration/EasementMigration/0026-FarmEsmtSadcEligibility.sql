BEGIN TRY
BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmEsmtSadcEligibility

-- Create Table
CREATE TABLE #FarmEsmtSadcEligibility(
	[Id]												   [integer] 		IDENTITY(1,1)  NOT NULL,
	[ApplicationId]                                        [integer]                       NOT NULL,
	[ProjectAreaAppEl]									   [varchar](4000)		               NULL,
	[RankScore]							                   [decimal](18,2)					   NULL,
	[RankPoints]									       [decimal](18,2)		               NULL,
	[SoilPercentage]									   [decimal](18,2)		               NULL,
	[IsLandsLessThan10Ac]								   [bit]        		               NULL,
    [IsLandsGreaterThan10Ac]							   [bit]        		               NULL,
	[Is75PercentTillable]								   [bit]				        	   NULL,
	[Percent75Tillable1]								   [decimal](18,2)					   NULL,
	[Acre75Tillable]									   [decimal](18,2)					   NULL,
	[Is75PercentLand]									   [bit]        					   NULL,
	[Percent75Land]								           [decimal](18,2)					   NULL,
	[Acre75Land]								           [decimal](18,2)					   NULL,
	[Is50PercentTillable]								   [bit]					           NULL,
	[Percent50Tillable]									   [decimal](18,2)					   NULL,
	[Acre50Tillable]								       [decimal](18,2)					   NULL,
	[Is50PercentLand]								       [bit]        					   NULL,
	[Percent50Land]										   [decimal](18,2)					   NULL,
	[Acre50Land]								           [decimal](18,2)					   NULL,
	[LastUpdatedBy]										   [varchar](128)		               NULL,
	[LastUpdatedOn]										   [datetime]			           NOT NULL,
CONSTRAINT [PK_#FarmEsmtSadcEligibility _Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

---Insert Script For #FarmEsmtSadcEligibility
INSERT INTO #FarmEsmtSadcEligibility
            (
			  ApplicationId          
			 ,ProjectAreaAppEl       
			 ,RankScore              
			 ,RankPoints             
			 ,SoilPercentage         
			 ,IsLandsLessThan10Ac    
			 ,IsLandsGreaterThan10Ac 
			 ,Is75PercentTillable    
			 ,Percent75Tillable1     
			 ,Acre75Tillable         
			 ,Is75PercentLand        
			 ,Percent75Land          
			 ,Acre75Land             
			 ,Is50PercentTillable    
			 ,Percent50Tillable      
			 ,Acre50Tillable         
			 ,Is50PercentLand        
			 ,Percent50Land          
			 ,Acre50Land             
			 ,LastUpdatedBy
			 ,LastUpdatedOn
			)
	        SELECT
	          ProjectID      
			 ,ProjectRegion
			 ,NULL AS RankScore              
			 ,NULL AS RankPoints             
			 ,NULL AS SoilPercentage         
			 ,NULL AS IsLandsLessThan10Ac    
			 ,NULL AS IsLandsGreaterThan10Ac 
			 ,NULL AS Is75PercentTillable  
			 ,NULL AS Percent75Tillable1     
			 ,NULL AS Acre75Tillable      
			 ,NULL AS Is75PercentLand        
			 ,NULL AS Percent75Land         
			 ,NULL AS Acre75Land           
			 ,NULL AS Is50PercentTillable    
			 ,NULL AS Percent50Tillable     
			 ,NULL AS Acre50Tillable       
			 ,NULL AS Is50PercentLand        
			 ,NULL AS Percent50Land         
			 ,NULL AS Acre50Land
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application SADC Application Eligibility1 Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH