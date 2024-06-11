using PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands.Applications;
using static System.Net.Mime.MediaTypeNames;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories
{
    public class ApplicationRepository : IApplicationRepository
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

        public async Task<FarmLandApplicationEntity> GetApplicationAsync(int applicationId)
        {
            FarmLandApplicationEntity result = default;
            using var conn = context.CreateConnection();
            var sqlCommand = new GetApplicationSqlQuery();
            var results = await conn.QueryAsync<FarmLandApplicationEntity>(sqlCommand.ToString(),
                                commandType: CommandType.Text,
                                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                                param: new { @p_Id = applicationId });
            result = results.FirstOrDefault();

            return result ?? new();
        }

        public async Task<List<FarmLandApplicationEntity>> GetApplicationsAsync()
        {
            List<FarmLandApplicationEntity> results = default;
            using var conn = context.CreateConnection();
            var sqlCommand = new GetApplicationSqlQuery();
            results = (await conn.QueryAsync<FarmLandApplicationEntity>(sqlCommand.ToString(),
                                commandType: CommandType.Text,
                                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                                param: new { }
                                )).ToList();

            return results ?? new();
        }

        public async Task<FarmLandApplicationEntity> SaveAsync(FarmLandApplicationEntity application)
        {
            if (application.Id > 0)
                return await UpdateAsync(application);
            else
                return await CreateAsync(application);

        }

        private async Task<FarmLandApplicationEntity> CreateAsync(FarmLandApplicationEntity application)
        {
            int id = default;

            using var conn = context.CreateConnection();
            var sqlCommand = new CreateApplicationSqlCommand();
            id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                    @p_Title = application.Title,
                    //@p_AgencyId = application.AgencyId,
                    //@p_ApplicationTypeId = application.ApplicationTypeId,
                    //@p_StatusId = application.StatusId,
                    //@p_CreatedByProgramAdmin = application.CreatedByProgramAdmin,
                    //@p_LastUpdatedBy = application.LastUpdatedBy
                });

            application.Id = id;

            return application;
        }

        private async Task<FarmLandApplicationEntity> UpdateAsync(FarmLandApplicationEntity application)
        {
            int id = default;

            return application;
        }
    }
}
