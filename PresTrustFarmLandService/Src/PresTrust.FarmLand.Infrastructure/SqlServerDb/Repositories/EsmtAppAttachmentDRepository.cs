using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics.Metrics;
using System.Diagnostics;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories
{
    public class EsmtAppAttachmentDRepository : IEsmtAppAttachmentDRepository
    {
        #region " Members ... "
        private readonly PresTrustSqlDbContext context;
        private readonly SystemParameterConfiguration systemParamConfig;
        #endregion
        #region " Members ... "
        public EsmtAppAttachmentDRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfig)
        {
            this.context = context;
            this.systemParamConfig = systemParamConfig.Value;
        }
        #endregion
      
        public async Task<List<FarmEsmtAttachmentDSourseEntity>> GetAttachmentSourcesAsync(int applicationId)
        {
            List<FarmEsmtAttachmentDSourseEntity> results;
            using var conn = context.CreateConnection();
            var sqlCommand = new GetFarmEsmtAttachmentDSourceByApplicationIdSqlCommand();
            results = (await conn.QueryAsync<FarmEsmtAttachmentDSourseEntity>(sqlCommand.ToString(),
                                commandType: CommandType.Text,
                                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                                param: new { @p_ApplicationId = applicationId })).ToList();

            return results ?? new();
        }

        private async Task<FarmEsmtAttachmentDSourseEntity> CreateAsync(FarmEsmtAttachmentDSourseEntity activitySource)
        {
            int id = default;

            using var conn = context.CreateConnection();
            var sqlCommand = new CreateFarmEsmtAttachmentDSourceSqlCommand();
            id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
                {
                    @p_ApplicationId = activitySource.ApplicationId,
                    @p_EquineActivityTypeId = activitySource.EquineActivityTypeId,
                    @p_Counts = activitySource.Counts,
                    @p_Number = activitySource.Number,
                    @p_NumberOfHorses = activitySource.NumberOfHorses,
                    @p_NumberOfHorsesActivity = activitySource.NumberOfHorsesActivity,
                    @p_NumberOfStalls = activitySource.NumberOfStalls,
                    @p_RunInSheds = activitySource.RunInSheds,
                    @p_IndoorRidingArena = activitySource.IndoorRidingArena,
                    @p_OutdoorRidingArena = activitySource.OutdoorRidingArena,
                    @p_LastUpdatedBy = activitySource.LastUpdatedBy,
                    @p_LastUpdatedOn =  DateTime.Now
                });

            activitySource.Id = id;

            return activitySource;
        }

        /// <summary>
        /// Save Funding source.
        /// </summary>
        /// <param name="fundingSource"></param>
        /// <returns></returns>
        public async Task<FarmEsmtAttachmentDSourseEntity> SaveAsync(FarmEsmtAttachmentDSourseEntity activitySource)
        {
            if (activitySource.Id > 0)
                return await UpdateAsync(activitySource);
            else
                return await CreateAsync(activitySource);

        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="fundingSource"></param>
        /// <returns></returns>
        private async Task<FarmEsmtAttachmentDSourseEntity> UpdateAsync(FarmEsmtAttachmentDSourseEntity activitySource)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new UpdateFarmEsmtAttachmentDSourceSqlCommand();
            await conn.ExecuteAsync(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {
                    @p_Id = activitySource.Id,
                    @p_ApplicationId = activitySource.ApplicationId,
                    @p_EquineActivityTypeId = activitySource.EquineActivityTypeId,
                    @p_Counts = activitySource.Counts,
                    @p_Number = activitySource.Number,
                    @p_NumberOfHorses = activitySource.NumberOfHorses,
                    @p_NumberOfHorsesActivity = activitySource.NumberOfHorsesActivity,
                    @p_NumberOfStalls = activitySource.NumberOfStalls,
                    @p_RunInSheds = activitySource.RunInSheds,
                    @p_IndoorRidingArena = activitySource.IndoorRidingArena,
                    @p_OutdoorRidingArena = activitySource.OutdoorRidingArena,
                    @p_LastUpdatedBy = activitySource.LastUpdatedBy,
                    @p_LastUpdatedOn = DateTime.Now
                });

            return activitySource;
        }

        public async Task DeleteAsync(FarmEsmtAttachmentDSourseEntity activity)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new DeleteFarmEsmtAttachmentDSourceSqlCommand();
            await conn.ExecuteAsync(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {
                    @p_Id = activity.Id,
                    @p_ApplicationId =activity.ApplicationId
                });

        }
    }
}
