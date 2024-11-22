namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;
public class GetFarmEsmtSadcAppEligiblityTwoSqlCommand
{

    private readonly string _sqlCommand =
        @"
                      SELECT   [Id]
                              ,[ApplicationId]
                              ,[Prime]
                              ,[PrimeacresPct]
                              ,[Statewide]
                              ,[StatewideAcresPct]
                              ,[Local]
                              ,[LocalAcresPct]
                              ,[Unique]
                              ,[UniqueAcresPct]
                              ,[UniqueSoils]
                              ,[ListCropUniqueSoil]
                              ,[Other]
                              ,[OtherAcresPct]
                              ,[TotalNetAcres]
                              ,[TotalNetAcresPct]
                              ,[CroplandHarvested]
                              ,[CroplandHarvestedPct]
                              ,[CroplandPastured]
                              ,[CroplandPasturedPct]
                              ,[PermanentPasture]
                              ,[PermanentPasturePct]
                              ,[Woodlands]
                              ,[WoodlandsPct]
                              ,[ExceptionOther]
                              ,[ExceptionOtherPct]
                              ,[ExceptionTotalNetAcres]
                              ,[ExceptionTotalNetAcresPct]
                              ,[ZoningCode]
                              ,[MinimumLotSize]
                              ,[Regional]
                              ,[IsHighlandsRegion]
                              ,[IsPreservation]
                              ,[IsPlanningArea]
                              ,[CountyaverageRank]
                              ,[LastUpdatedBy]
                              ,[LastUpdatedOn]
                         FROM 
                          [Farm].[FarmEsmtSadcEligibilityTwo]
                           WHERE ApplicationId =@p_ApplicationId ;";

    public GetFarmEsmtSadcAppEligiblityTwoSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
