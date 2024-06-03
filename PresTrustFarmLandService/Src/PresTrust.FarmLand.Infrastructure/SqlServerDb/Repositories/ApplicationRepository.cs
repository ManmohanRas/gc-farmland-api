namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories
{
    public class ApplicationRepository: IApplicationRepository
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
        public ApplicationRepository(
            PresTrustSqlDbContext context,
            IOptions<SystemParameterConfiguration> systemParamConfigOptions
            )
        {
            this.context = context;
            this.systemParamConfig = systemParamConfigOptions.Value;
        }

        #endregion

        public async Task<List<FarmLandApplicationEntity>> GetApplicationsAsync()
        {
            List<FarmLandApplicationEntity> results = default;
            using var conn = context.CreateConnection();
            var sqlCommand = new GetApplicationSqlQuery();
            results = (await conn.QueryAsync<FarmLandApplicationEntity>(sqlCommand.ToString(),
                                commandType: CommandType.Text,
                                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                                param: new {}
                                )).ToList();

            return results ?? new();
        }
    }
}
