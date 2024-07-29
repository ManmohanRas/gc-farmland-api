namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetTermAppLocationSqlQuery
{
    private readonly string _sqlCommand =
        @"  SELECT 
            P.Id AS ParcelId,
            P.Block, 
            P.Lot,
            P.PamsPin,
            P.[FarmListID],
            P.[Block],
            P.[Lot],
            P.[DeedBook],
            P.[DeedPage],
			P.[QualificationCode], 
            P.[IsWarning],
            P.[CreatedByProgramUser],
            L.IsChecked,
            L.ApplicationId,
            CM.[Municipality] AS Municipality
            FROM [Farm].[FarmMunicipalityBlockLotParcel] AS P
           LEFT JOIN [Farm].[FarmTermAppLocation] AS L ON (P.FarmListID = L.FarmListID and P.Id = L.ParcelId AND L.applicationId = @p_ApplicationId)
           LEFT JOIN [Core].[View_AgencyEntities_FARM] ViewAgency ON (P.MunicipalityId = ViewAgency.AgencyId)
           LEFT JOIN [Core].[Municipality] CM ON (P.MunicipalityId = CM.MunicipalId AND CM.InCounty = 1)
           WHERE P.FarmListID = @p_FarmListID;";
    public GetTermAppLocationSqlQuery()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
