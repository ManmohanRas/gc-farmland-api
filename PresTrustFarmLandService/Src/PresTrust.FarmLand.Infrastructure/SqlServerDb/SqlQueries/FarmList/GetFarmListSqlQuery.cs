namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries
{
    public class GetFarmListSqlQuery
    {
        private readonly string _sqlCommand =
            @" SELECT
               [FarmListID]
              ,[FarmNumber]
              ,[TermID]
              ,[FarmName]
              ,[ProjectName]
              ,[Status]
              ,[AgencyID]
              ,[OriginalLandowner]
              ,[Address1]
              ,[Address2]
              ,[MunicipalID]
              FROM [PresTrust_RAS].[Farm].[FarmList]
               WHERE FarmName IS NOT NULL;";

        public override string ToString()
        {
            return _sqlCommand;
        }

    }
}
