namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries
{
    public class GetFarmListSqlQuery
    {
        private readonly string _sqlCommand =
            @" SELECT 
               [FarmListID]
              ,[OriginProgram]
              ,[ProjectID]
              ,[FarmNumber]
              ,[TermID]
              ,[FarmName]
              ,[ProjectName]
              ,[Status]
              ,[LastName]
              ,[FirstName]
              ,[OriginalLandowner]
              ,[Address1]
              ,[Address2]
              ,[MunicipalID]
              ,[Block]
              ,[Lots]
              ,[BlocksAddl]
              ,[LotsAddl]
              ,[AgencyID]
              FROM [PresTrust_RAS].[Farm].[FarmList]
               WHERE FarmName IS NOT NULL;";

        public override string ToString()
        {
            return _sqlCommand;
        }

    }
}
