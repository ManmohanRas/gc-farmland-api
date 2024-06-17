namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries
{
    public class GetFarmListSqlQuery
    {
        private readonly string _sqlCommand =
            @" SELECT 
               ProjectID,
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
               FROM [Farm].[OwnerPropertyLEGACY_Rev01];";

        public override string ToString()
        {
            return _sqlCommand;
        }

    }
}
