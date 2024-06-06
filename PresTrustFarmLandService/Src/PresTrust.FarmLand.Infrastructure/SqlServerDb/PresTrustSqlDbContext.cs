namespace PresTrust.FarmLand.Infrastructure.SqlServerDb
{
    public class PresTrustSqlDbContext
    {
        private readonly IConfiguration config;
        private readonly string connString;

        public PresTrustSqlDbContext(IConfiguration config)
        {
            this.config = config;
            connString = this.config.GetConnectionString(FarmLandDomainConstants.AppSettingKeys.PRESTRUST_SQL_DB_CONNECTION_STRING_SECTION);
        }

        public IDbConnection CreateConnection() => new SqlConnection(connString);

    }
}
