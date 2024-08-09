
namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetEsmtAppStructureSqlCommand
{
    private readonly string _sqlCommand =
          @"
         SELECT  [Id],
                 [ApplicationId],
                 [IsResipreserved],							
                 [StdSingleFamilyResidence],					
                 [MfWithHomePermFoundation],				
                 [Duplex],
                 [MfWithOutHomePermFoundation],		                            
                 [ResiGarage],		                        
                 [Dormitory],		                            
                 [ApartmentAttachedTo],		                
                 [CarriageHouseOrCabin],		                
                 [ResiOther],		                            
                 [UnitsAgricuturalLabor],						
                 [UnitsRentedOrLease],		                
                 [IsNonResiStructure],						
                 [Barn],		                                
                 [Shed],		                                
                 [NonResiGarage],		                        
                 [Silo],		                                
                 [Stable],		                            
                 [NonResiOther],		                        
                 [IsHistBuildingOrStructure],					
                 [HistoricSignificance],		                
                 [LastUpdatedBy],					            
                 [LastUpdatedOn] 
            FROM [FARM].[FarmEsmtAppStructure] 
            WHERE [ApplicationId] = @p_ApplicationId;";

    public GetEsmtAppStructureSqlCommand(){ }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
