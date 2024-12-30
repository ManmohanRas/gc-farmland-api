namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class FarmMonitoringRepository : IFarmMonitoringRepository
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
        public FarmMonitoringRepository(
            PresTrustSqlDbContext context,
            IOptions<SystemParameterConfiguration> systemParamConfigOptions
            )
        {
            this.context = context;
            this.systemParamConfig = systemParamConfigOptions.Value;
        }

        #endregion

        public async Task<IEnumerable<FarmMonitoringEntity>> GetFarmMonitoringAsync()
        {
            IEnumerable<FarmMonitoringEntity> results = default;
            using var conn = context.CreateConnection();
            var sqlCommand = new GetFarmMonitoringSqlQuery();
            results = (await conn.QueryAsync<FarmMonitoringEntity>(sqlCommand.ToString(),
                                commandType: CommandType.Text,
                                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                                param: new { }
                                ));

            return results;
        }

        public async Task<FarmMonitoringEntity> SaveFarmMonitoringAsync(FarmMonitoringEntity farmMonitoring)
        {
           if (farmMonitoring.Id > 0)
                return await UpdateAsync(farmMonitoring);
            else
                return await SaveAsync(farmMonitoring);
        }

        private async Task<FarmMonitoringEntity> SaveAsync(FarmMonitoringEntity farmMonitoring)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new CreateFarmMonitoringSqlCommand();
            var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {

                    @p_FarmListID = farmMonitoring.FarmListID,
                    @p_FarmNumber = farmMonitoring.FarmNumber,
                    @p_OriginalLandowner = farmMonitoring.OriginalLandowner,
                    @p_PresentOwner = farmMonitoring.PresentOwner,
                    @p_FarmName = farmMonitoring.FarmName,
                    @p_FarmerName = farmMonitoring.FarmerName,
                    @p_IsConservationPlan = farmMonitoring.IsConservationPlan,
                    @p_ConsPlanDate = farmMonitoring.ConsPlanDate,
                    @p_ConsPlanComment = farmMonitoring.ConsPlanComment,
                    @p_Street1 = farmMonitoring.Street1,
                    @p_Street2 = farmMonitoring.Street2,
                    @p_FirstName = farmMonitoring.FirstName,
                    @p_LastName = farmMonitoring.LastName,
                    @p_PhoneNumber = farmMonitoring.PhoneNumber,
                    @p_City = farmMonitoring.City,
                    @p_State = farmMonitoring.State,
                    @p_ZipCode = farmMonitoring.ZipCode,
                    @p_ClosingDate = farmMonitoring.ClosingDate,
                    @p_TitlePolicy = farmMonitoring.TitlePolicy,
                    @p_TitleCompany = farmMonitoring.TitleCompany,
                    @p_EPDeedBook = farmMonitoring.EPDeedBook,
                    @p_EPDeedPage = farmMonitoring.EPDeedPage,
                    @p_EPDeedFiled = farmMonitoring.EPDeedFiled,
                    @p_GrossAcers = farmMonitoring.GrossAcers,
                    @p_RDSOsNum = farmMonitoring.RDSOsNum,
                    @p_RDSOExplan = farmMonitoring.RDSOExplan,
                    @p_IsRDSOExercised = farmMonitoring.IsRDSOExercised,
                    @p_ImprovRes = farmMonitoring.ImprovRes,
                    @p_ImprovAg = farmMonitoring.ImprovAg,
                    @p_AreNonAgUses = farmMonitoring.AreNonAgUses,
                    @p_NonAgExplan = farmMonitoring.NonAgExplan,
                    @p_FirstInspect = farmMonitoring.FirstInspect,
                    @p_PreviousInspect = farmMonitoring.PreviousInspect,
                    @p_LastInspect = farmMonitoring.LastInspect,
                    @p_ChangesSinceLastInspect = farmMonitoring.ChangesSinceLastInspect,
                    @p_IssuesImpactingFarm = farmMonitoring.IssuesImpactingFarm,
                    @p_IsInCompliance = farmMonitoring.IsInCompliance,
                    @p_NonComplianceExplan = farmMonitoring.NonComplianceExplan,
                    @p_InspectionComments = farmMonitoring.InspectionComments,
                    @p_CurrentDeedBook = farmMonitoring.CurrentDeedBook,
                    @p_CurrentDeedPage = farmMonitoring.CurrentDeedPage,
                    @p_CurrentDeedFiled = farmMonitoring.CurrentDeedFiled,
                    @p_LastUpdatedBy = farmMonitoring.LastUpdatedBy,
                    @p_LastUpdatedOn = DateTime.Now
                });

            farmMonitoring.Id = id;

            return farmMonitoring;
        }

        private async Task<FarmMonitoringEntity> UpdateAsync(FarmMonitoringEntity farmMonitoring)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new UpdateFarmMonitoringSqlCommand();
            await conn.ExecuteAsync(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {
                    @p_Id = farmMonitoring.Id,
                    @p_FarmListID = farmMonitoring.FarmListID,
                    @p_FarmNumber = farmMonitoring.FarmNumber,
                    @p_OriginalLandowner = farmMonitoring.OriginalLandowner,
                    @p_PresentOwner = farmMonitoring.PresentOwner,
                    @p_FarmName = farmMonitoring.FarmName,
                    @p_FarmerName = farmMonitoring.FarmerName,
                    @p_IsConservationPlan = farmMonitoring.IsConservationPlan,
                    @p_ConsPlanDate = farmMonitoring.ConsPlanDate,
                    @p_ConsPlanComment = farmMonitoring.ConsPlanComment,
                    @p_Street1 = farmMonitoring.Street1,
                    @p_Street2 = farmMonitoring.Street2,
                    @p_FirstName = farmMonitoring.FirstName,
                    @p_LastName = farmMonitoring.LastName,
                    @p_PhoneNumber = farmMonitoring.PhoneNumber,
                    @p_City = farmMonitoring.City,
                    @p_State = farmMonitoring.State,
                    @p_ZipCode = farmMonitoring.ZipCode,
                    @p_ClosingDate = farmMonitoring.ClosingDate,
                    @p_TitlePolicy = farmMonitoring.TitlePolicy,
                    @p_TitleCompany = farmMonitoring.TitleCompany,
                    @p_EPDeedBook = farmMonitoring.EPDeedBook,
                    @p_EPDeedPage = farmMonitoring.EPDeedPage,
                    @p_EPDeedFiled = farmMonitoring.EPDeedFiled,
                    @p_GrossAcers = farmMonitoring.GrossAcers,
                    @p_RDSOsNum = farmMonitoring.RDSOsNum,
                    @p_RDSOExplan = farmMonitoring.RDSOExplan,
                    @p_IsRDSOExercised = farmMonitoring.IsRDSOExercised,
                    @p_ImprovRes = farmMonitoring.ImprovRes,
                    @p_ImprovAg = farmMonitoring.ImprovAg,
                    @p_AreNonAgUses = farmMonitoring.AreNonAgUses,
                    @p_NonAgExplan = farmMonitoring.NonAgExplan,
                    @p_FirstInspect = farmMonitoring.FirstInspect,
                    @p_PreviousInspect = farmMonitoring.PreviousInspect,
                    @p_LastInspect = farmMonitoring.LastInspect,
                    @p_ChangesSinceLastInspect = farmMonitoring.ChangesSinceLastInspect,
                    @p_IssuesImpactingFarm = farmMonitoring.IssuesImpactingFarm,
                    @p_IsInCompliance = farmMonitoring.IsInCompliance,
                    @p_NonComplianceExplan = farmMonitoring.NonComplianceExplan,
                    @p_InspectionComments = farmMonitoring.InspectionComments,
                    @p_CurrentDeedBook = farmMonitoring.CurrentDeedBook,
                    @p_CurrentDeedPage = farmMonitoring.CurrentDeedPage,
                    @p_CurrentDeedFiled = farmMonitoring.CurrentDeedFiled,
                    @p_LastUpdatedBy = farmMonitoring.LastUpdatedBy,
                    @p_LastUpdatedOn = DateTime.Now
                });

            return farmMonitoring;
        }
}
