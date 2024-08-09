namespace PresTrust.FarmLand.Infrastructure.SqlServerDb;

public class UpdateEsmtAppStructureSqlCommand
{
    private readonly string _SqlCommand = @"
     UPDATE [FARM].[FarmEsmtAppStructure] 

            SET 
                 [IsResipreserved]	            =	@p_IsResipreserved,					
                 [StdSingleFamilyResidence]		=	@p_StdSingleFamilyResidence,		
                 [MfWithHomePermFoundation]     =	@p_MfWithHomePermFoundation,			
                 [Duplex]                       =   @p_Duplex,
                 [MfWithOutHomePermFoundation]  =	@p_MfWithOutHomePermFoundation,	                            
                 [ResiGarage]                   =	@p_ResiGarage,                        
                 [Dormitory]                    =	@p_Dormitory,	                            
                 [ApartmentAttachedTo]          =	@p_ApartmentAttachedTo,	                
                 [CarriageHouseOrCabin]         =	@p_CarriageHouseOrCabin,	                
                 [ResiOther]                    =	@p_ResiOther,	                            
                 [UnitsAgricuturalLabor]        =	@p_UnitsAgricuturalLabor,					
                 [UnitsRentedOrLease]           =	@p_UnitsRentedOrLease,	                
                 [IsNonResiStructure]           =	@p_IsNonResiStructure,					
                 [Barn]                         =	@p_Barn,	                                
                 [Shed]                         =	@p_Shed,	                                
                 [NonResiGarage]                =	@p_NonResiGarage,	                        
                 [Silo]                         =	@p_Silo,	                                
                 [Stable]                       =	@p_Stable,	                            
                 [NonResiOther]                 =	@p_NonResiOther,	                        
                 [IsHistBuildingOrStructure]    =	@p_IsHistBuildingOrStructure,				
                 [HistoricSignificance]         =	@p_HistoricSignificance,	                
                 [LastUpdatedBy]                =	@p_LastUpdatedBy,				            
                 [LastUpdatedOn]                =   @p_LastUpdatedOn
           WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId ";
    public UpdateEsmtAppStructureSqlCommand() { }

    public override string ToString()
    {
        return _SqlCommand;
    }

}
