namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries
{
    public class GetFarmListSqlQuery
    {
        private readonly string _sqlCommand =
            @" SELECT 
               ProjectID AS FarmListId,
               AgencyId,
               MunicipalID,
               Municipality,
               FarmNumber,
               FarmName,
               OriginalLandowner,
               OwnerFirst,
               OwnerLast,
               Street1,
               Street2,
               City,
               State,
               ZipCode
               FROM [Farm].[OwnerPropertyLEGACY_Rev01]
               WHERE FarmName IS NOT NULL;";

        public override string ToString()
        {
            return _sqlCommand;
        }

    }
}
