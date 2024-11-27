namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class UpdateFarmEsmtSadcAppEligiblityTwoSqlCommand
{
    private readonly string _sqlCommand = @"

    Update [Farm].[FarmEsmtSadcEligibilityTwo]
      SET       ApplicationId            = @p_ApplicationId,
                Prime                    = @p_Prime,
                PrimeacresPct            = @p_PrimeacresPct,
                Statewide                = @p_Statewide,
                StatewideAcresPct        = @p_StatewideAcresPct,
                [Local]                  = @p_Local,
                LocalAcresPct            = @p_LocalAcresPct,
                [Unique]                 = @p_Unique,
                UniqueAcresPct           = @p_UniqueAcresPct,
                UniqueSoils              = @p_UniqueSoils,
                ListCropUniqueSoil       = @p_ListCropUniqueSoil,
                Other                    = @p_Other,
                OtherAcresPct            = @p_OtherAcresPct,
                TotalNetAcres            = @p_TotalNetAcres,
                TotalNetAcresPct         = @p_TotalNetAcresPct,
                CroplandHarvested        = @p_CroplandHarvested,
                CroplandHarvestedPct     = @p_CroplandHarvestedPct,
                CroplandPastured         = @p_CroplandPastured,
                CroplandPasturedPct      = @p_CroplandPasturedPct,
                PermanentPasture         = @p_PermanentPasture,
                PermanentPasturePct      = @p_PermanentPasturePct,
                Woodlands                = @p_Woodlands,
                WoodlandsPct             = @p_WoodlandsPct,
                ExceptionOther           = @p_ExceptionOther,
                ExceptionOtherPct        = @p_ExceptionOtherPct,
                ExceptionTotalNetAcres   = @p_ExceptionTotalNetAcres,
                ExceptionTotalNetAcresPct = @p_ExceptionTotalNetAcresPct,
                ZoningCode               = @p_ZoningCode,
                MinimumLotSize           = @p_MinimumLotSize,
                Regional                 = @p_Regional,
                IsHighlandsRegion        = @p_IsHighlandsRegion,
                IsPreservation           = @p_IsPreservation,
                IsPlanningArea           = @p_IsPlanningArea,
                CountyaverageRank        = @p_CountyaverageRank,
                LastUpdatedBy            = @p_LastUpdatedBy,
                LastUpdatedOn            = @p_LastUpdatedOn
         WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

    public UpdateFarmEsmtSadcAppEligiblityTwoSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }

}
