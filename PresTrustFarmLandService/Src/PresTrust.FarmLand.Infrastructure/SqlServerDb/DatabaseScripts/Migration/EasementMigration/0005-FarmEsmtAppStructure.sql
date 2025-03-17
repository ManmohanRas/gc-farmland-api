BEGIN TRY
   BEGIN TRANSACTION

-- Drop Table
DROP TABLE IF EXISTS #FarmEsmtAppStructure


-- Create Table
CREATE TABLE #FarmEsmtAppStructure(
	[Id]						               	[integer] 		              IDENTITY(1,1) NOT NULL,
	[ApplicationId]					            [integer]						            NOT NULL,
	[IsResipreserved]							[bit]					                        NULL,
	[StdSingleFamilyResidence]					[varchar](128)			        			    NULL, 
	[MfWithHomePermFoundation]					[varchar](128)						            NULL, 	                                                                                                                                                    
    [Duplex]		                            [varchar](128)						            NULL, 
	[MfWithOutHomePermFoundation]				[varchar](128)						            NULL,
	[ResiGarage]		                        [varchar](128)						            NULL, 
	[Dormitory]		                            [varchar](128)						            NULL, 
	[ApartmentAttachedTo]		                [varchar](128)						            NULL, 
	[CarriageHouseOrCabin]		                [varchar](128)						            NULL, 
	[ResiOther]		                            [varchar](4000)						            NULL, 
	[UnitsAgricuturalLabor]						[varchar](4000)						            NULL, 
	[UnitsRentedOrLease]		                [varchar](4000)						            NULL, 
	[IsNonResiStructure]						[bit]						                    NULL, 
	[Barn]		                                [varchar](128)						            NULL, 
	[Shed]		                                [varchar](128)						            NULL, 
	[NonResiGarage]		                        [varchar](128)						            NULL, 
	[Silo]		                                [varchar](128)						            NULL, 
	[Stable]		                            [varchar](128)						            NULL, 
	[NonResiOther]		                        [varchar](128)						            NULL, 
	[IsHistBuildingOrStructure]					[bit]						                    NULL, 
	[HistoricSignificance]		                [varchar](4000)						            NULL, 
	[LastUpdatedBy]					            [varchar](128)					                NULL, 
	[LastUpdatedOn]					            [DateTime]					               	NOT NULL, 
CONSTRAINT [PK_#FarmEsmtAppStructure_Id] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

----Insert Script For FarmEsmtAppStructure
INSERT INTO #FarmEsmtAppStructure
            (
              ApplicationId
             ,IsResipreserved							
             ,StdSingleFamilyResidence					
             ,MfWithHomePermFoundation				
             ,Duplex
             ,MfWithOutHomePermFoundation		                            
             ,ResiGarage               
             ,Dormitory		                            
             ,ApartmentAttachedTo		                
             ,CarriageHouseOrCabin		                
             ,ResiOther		                            
             ,UnitsAgricuturalLabor						
             ,UnitsRentedOrLease	                
             ,IsNonResiStructure						
             ,Barn		                                
             ,Shed		                                
             ,NonResiGarage		                        
             ,Silo	                                
             ,Stable		                            
             ,NonResiOther	                        
             ,IsHistBuildingOrStructure				
             ,HistoricSignificance		                
             ,LastUpdatedBy					            
             ,LastUpdatedOn
            )
			 SELECT
			  ProjectID
			 ,IsResidenceOnPresLand
			 ,NULL AS StdSingleFamilyResidence					
             ,NULL AS MfWithHomePermFoundation				
             ,NULL AS Duplex
             ,NULL AS MfWithOutHomePermFoundation		                            
             ,NULL AS ResiGarage               
             ,NULL AS Dormitory		                            
             ,NULL AS ApartmentAttachedTo		                
             ,NULL AS CarriageHouseOrCabin		                
             ,NULL AS ResiOther		                            
             ,NULL AS UnitsAgricuturalLabor						
             ,NULL AS UnitsRentedOrLease	                
             ,NULL AS IsNonResiStructure						
             ,NULL AS Barn		                                
             ,NULL AS Shed		                                
             ,NULL AS NonResiGarage		                        
             ,NULL AS Silo	                                
             ,NULL AS Stable		                            
             ,NULL AS NonResiOther	                        
             ,NULL AS IsHistBuildingOrStructure				
             ,NULL AS HistoricSignificance
			 ,SUSER_SNAME()  AS LastUpdatedBy
             ,GETDATE() AS LastUpdatedOn
			 FROM FARM.OwnerPropertyLEGACY_Rev02

            COMMIT;
            PRINT 'Esmt application Resi & Non Resi Structure Details legacy table has been populated';
END TRY
BEGIN CATCH
    DECLARE     @ErrorMessage  NVARCHAR(4000);

    SET         @ErrorMessage = ERROR_MESSAGE();
    ROLLBACK;


    SELECT @ErrorMessage;
END CATCH