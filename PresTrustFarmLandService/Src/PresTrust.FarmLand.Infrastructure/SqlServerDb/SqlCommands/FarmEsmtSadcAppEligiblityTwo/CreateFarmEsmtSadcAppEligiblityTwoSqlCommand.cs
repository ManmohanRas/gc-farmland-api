namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class CreateFarmEsmtSadcAppEligiblityTwoSqlCommand
{
    private readonly string _sqlCommand =
    @" INSERT INTO [Farm].[FarmEsmtSadcEligibilityTwo]
    (
       ApplicationId,
       Prime,
       PrimeacresPct,
       Statewide,
       StatewideAcresPct,
       [Local],
       LocalAcresPct,
       [Unique],
       UniqueAcresPct,
       UniqueSoils,
       ListCropUniqueSoil,
       Other,
       OtherAcresPct,
       TotalNetAcres,
       TotalNetAcresPct,
       CroplandHarvested,
       CroplandHarvestedPct,
       CroplandPastured,
       CroplandPasturedPct,
       PermanentPasture,
       PermanentPasturePct,
       Woodlands,
       WoodlandsPct,
       ExceptionOther,
       ExceptionOtherPct,
       ExceptionTotalNetAcres,
       ExceptionTotalNetAcresPct,
       ZoningCode,
       MinimumLotSize,
       Regional,
       IsHighlandsRegion,
       IsPreservation,
       IsPlanningArea,
       CountyaverageRank,
       LastUpdatedBy,  
       LastUpdatedOn          
    )
    VALUES   (
       @p_ApplicationId,
       @p_Prime,
       @p_PrimeacresPct,
       @p_Statewide,
       @p_StatewideAcresPct,
       @p_Local,
       @p_LocalAcresPct,
       @p_Unique,
       @p_UniqueAcresPct,
       @p_UniqueSoils,
       @p_ListCropUniqueSoil,
       @p_Other,
       @p_OtherAcresPct,
       @p_TotalNetAcres,
       @p_TotalNetAcresPct,
       @p_CroplandHarvested,
       @p_CroplandHarvestedPct,
       @p_CroplandPastured,
       @p_CroplandPasturedPct,
       @p_PermanentPasture,
       @p_PermanentPasturePct,
       @p_Woodlands,
       @p_WoodlandsPct,
       @p_ExceptionOther,
       @p_ExceptionOtherPct,
       @p_ExceptionTotalNetAcres,
       @p_ExceptionTotalNetAcresPct,
       @p_ZoningCode,
       @p_MinimumLotSize,
       @p_Regional,
       @p_IsHighlandsRegion,
       @p_IsPreservation,
       @p_IsPlanningArea,
       @p_CountyaverageRank,
       @p_LastUpdatedBy,
       GetDate()
    );
    SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateFarmEsmtSadcAppEligiblityTwoSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }

}
