namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmSadcResidenceSqlQuery
{
    private readonly string _sqlCommand =
                        @"select
                                     Id
                                    ,ApplicationId
                                    ,IsAgriculturalLabor
                                    ,UnitsUsedForLabor
                                    ,Occupants
                                    ,MonthsOccupied
                                    ,IsOccupantsWork
                                    ,PleaseExplain
                                    ,IsResidencesRented
                                    ,RDSOsReserve
                                    ,ExcepAcres1
                                    ,NonSeverable1
                                    ,Severable1
                                    ,AdditionalComment1
                                    ,ExcepAcres2
                                    ,NonSeverable2
                                    ,Severable2
                                    ,AdditionalComment2
                                    ,EsmtOthersText
                                    ,IsSightTriangle
                                    ,LastUpdatedBy
                                    ,LastUpdatedOn
                                     FROM  [Farm].[FarmEsmtSadcResidence]
                                     WHERE ApplicationId = @p_ApplicationId;";

    public GetFarmSadcResidenceSqlQuery()
    { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
