namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories
{
    public class FarmListRepository: IFarmListRepository
    {
        #region " Members ... "

        private readonly PresTrustSqlDbContext context;
        private readonly SystemParameterConfiguration systemParamConfig;

        #endregion

        #region " ctor ... "

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="systemParamConfigOptions"></param>
        public FarmListRepository(
            PresTrustSqlDbContext context,
            IOptions<SystemParameterConfiguration> systemParamConfigOptions
            )
        {
            this.context = context;
            this.systemParamConfig = systemParamConfigOptions.Value;
        }

        #endregion

        public async Task<IEnumerable<FarmListEntity>> GetFarmListAsync()
        {
            IEnumerable<FarmListEntity> results = default;
            using var conn = context.CreateConnection();
            var sqlCommand = new GetFarmListSqlQuery();
            results = (await conn.QueryAsync<FarmListEntity>(sqlCommand.ToString(),
                                commandType: CommandType.Text,
                                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                                param: new { }
                                ));

            return results;
        }
    }
}
