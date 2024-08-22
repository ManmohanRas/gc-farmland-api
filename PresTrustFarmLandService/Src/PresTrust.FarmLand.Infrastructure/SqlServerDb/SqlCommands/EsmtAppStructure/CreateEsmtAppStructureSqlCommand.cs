namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateEsmtAppStructureSqlCommand
{

    private readonly string _sqlCommand = 
        @"INSERT INTO [FARM].[FarmEsmtAppStructure]
                (
                 ApplicationId,
                 IsResipreserved,							
                 StdSingleFamilyResidence,					
                 MfWithHomePermFoundation,				
                 Duplex,
                 MfWithOutHomePermFoundation,		                            
                 ResiGarage,		                        
                 Dormitory,		                            
                 ApartmentAttachedTo,		                
                 CarriageHouseOrCabin,		                
                 ResiOther,		                            
                 UnitsAgricuturalLabor,						
                 UnitsRentedOrLease,		                
                 IsNonResiStructure,						
                 Barn,		                                
                 Shed,		                                
                 NonResiGarage,		                        
                 Silo,		                                
                 Stable,		                            
                 NonResiOther,		                        
                 IsHistBuildingOrStructure,					
                 HistoricSignificance,		                
                 LastUpdatedBy,					            
                 LastUpdatedOn
                 )
           VALUES(
                       @p_ApplicationId,               
                       @p_IsResipreserved,              
                       @p_StdSingleFamilyResidence,     
                       @p_MfWithHomePermFoundation,     
                       @p_Duplex,                       
                       @p_MfWithOutHomePermFoundation,  
                       @p_ResiGarage,  
                       @p_Dormitory,  
                       @p_ApartmentAttachedTo,  
                       @p_CarriageHouseOrCabin,  
                       @p_ResiOther,  
                       @p_UnitsAgricuturalLabor,  
                       @p_UnitsRentedOrLease,  
                       @p_IsNonResiStructure,  
                       @p_Barn,  
                       @p_Shed,  
                       @p_NonResiGarage,  
                       @p_Silo,  
                       @p_Stable,  
                       @p_NonResiOther,  
                       @p_IsHistBuildingOrStructure,  
                       @p_HistoricSignificance,  
                       @p_LastUpdatedBy,
                       GETDATE()
               );
             SELECT CAST(SCOPE_IDENTITY() AS INT);";

    public CreateEsmtAppStructureSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }

}
