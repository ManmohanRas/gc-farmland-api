namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries
{
    public class GetApplicationSqlQuery
    {
        private readonly string _sqlCommand =
            @" SELECT * FROM [Flood].[FloodApplication];";

        public override string ToString()
        {
            return _sqlCommand;
        }

    }

}
