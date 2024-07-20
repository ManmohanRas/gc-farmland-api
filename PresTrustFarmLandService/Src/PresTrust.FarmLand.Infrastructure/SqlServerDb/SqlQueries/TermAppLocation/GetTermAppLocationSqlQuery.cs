namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetTermAppLocationSqlQuery
{
    private readonly string _sqlCommand =
        @"  SELECT 
            P.Id AS ParcelId,
            P.Block, 
            P.Lot,
            P.PamsPin,
            L.IsChecked,
            L.ApplicationId
            FROM [Farm].[FarmMunicipalityBlockLotParcel] AS P
           LEFT JOIN [Farm].[FarmTermAppLocation] AS L ON (P.FarmListID = L.FarmListID and P.Id = L.ParcelId)
           WHERE P.FarmListID = @p_FarmListID;";
    public GetTermAppLocationSqlQuery()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
