namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories
{
    public class FarmSadcAppEligibilityRepository : IFarmSadcAppEligibilityRepository
    {

        #region " Members ... "

        private readonly PresTrustSqlDbContext context;
        protected readonly SystemParameterConfiguration systemParamConfig;

        #endregion

        #region " ctor ... "

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="systemParamConfigOptions"></param>
        public FarmSadcAppEligibilityRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
        {
            this.context = context;
            systemParamConfig = systemParamConfigOptions.Value;
        }

        #endregion



        /// <summary>
        /// </summary>
        ///  Procedure to fetch Signatory details by Id.
        /// <param name="applicationId"> Id.</param>
        /// <returns> Returns FarmEsmtAppAdminDetailsEntity.</returns>
        public async Task<FarmSadcAppEligibilityEntity> GetAppEligibilityDetailsAsync(int applicationId)
        {
            FarmSadcAppEligibilityEntity result = default;
            using var conn = context.CreateConnection();
            var sqlCommand = new GetFarmSadcAppEligibilitySqlQuery();
            var results = await conn.QueryAsync<FarmSadcAppEligibilityEntity>(sqlCommand.ToString(),
                                commandType: CommandType.Text,
                                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                                param: new
                                {
                                    @p_ApplicationId = applicationId
                                });

            result = results.FirstOrDefault();

            return result ?? new();
        }

        /// <summary>
        /// Save Signatory.
        /// </summary>
        /// <param name="farmEsmtAppAdminDetails"></param>
        /// <returns></returns>
        public async Task<FarmSadcAppEligibilityEntity> SaveAsync(FarmSadcAppEligibilityEntity farmSadcAppEligibilityDetails)
        {
            if (farmSadcAppEligibilityDetails.Id > 0)
                return await UpdateAsync(farmSadcAppEligibilityDetails);
            else
                return await CreateAsync(farmSadcAppEligibilityDetails);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="farmEsmtAppAdminDetails"></param>
        /// <returns></returns>
        private async Task<FarmSadcAppEligibilityEntity> CreateAsync(FarmSadcAppEligibilityEntity farmSadcAppEligibilityDetails)
        {
            int id = default;

            using var conn = context.CreateConnection();
            var sqlCommand = new CreateFarmSadcAppEligibilitySqlCommand();
            id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {

                    @p_ApplicationId            = farmSadcAppEligibilityDetails.ApplicationId     
                    ,@p_ProjectAreaAppEl        = farmSadcAppEligibilityDetails.ProjectAreaAppEl     
                    ,@p_RankScore               = farmSadcAppEligibilityDetails.RankScore     
                    ,@p_RankPoints              = farmSadcAppEligibilityDetails.RankPoints     
                    ,@p_SoilPercentage          = farmSadcAppEligibilityDetails.SoilPercentage     
                    ,@p_IsLandsLessThan10Ac     = farmSadcAppEligibilityDetails.IsLandsLessThan10Ac     
                    ,@p_IsLandsGreaterThan10Ac  = farmSadcAppEligibilityDetails.IsLandsGreaterThan10Ac     
                    ,@p_Is75PercentTillable     = farmSadcAppEligibilityDetails.Is75PercentTillable     
                    ,@p_Percent75Tillable1      = farmSadcAppEligibilityDetails.Percent75Tillable1     
                    ,@p_Acre75Tillable          = farmSadcAppEligibilityDetails.Acre75Tillable     
                    ,@p_Is75PercentLand         = farmSadcAppEligibilityDetails.Is75PercentLand     
                    ,@p_Percent75Land           = farmSadcAppEligibilityDetails.Percent75Land     
                    ,@p_Acre75Land              = farmSadcAppEligibilityDetails.Acre75Land     
                    ,@p_Is50PercentTillable     = farmSadcAppEligibilityDetails.Is50PercentTillable     
                    ,@p_Percent50Tillable       = farmSadcAppEligibilityDetails.Percent50Tillable     
                    ,@p_Acre50Tillable          = farmSadcAppEligibilityDetails.Acre50Tillable     
                    ,@p_Is50PercentLand         = farmSadcAppEligibilityDetails.Is50PercentLand     
                    ,@p_Percent50Land           = farmSadcAppEligibilityDetails.Percent50Land     
                    ,@p_Acre50Land              = farmSadcAppEligibilityDetails.Acre50Land
                    ,@p_LastUpdatedBy           = farmSadcAppEligibilityDetails.LastUpdatedBy
                    ,@p_LastUpdatedOn           = DateTime.Now
                });

            farmSadcAppEligibilityDetails.Id = id;

            return farmSadcAppEligibilityDetails;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="farmEsmtAppAdminDetails"></param>
        /// <returns></returns>
        private async Task<FarmSadcAppEligibilityEntity> UpdateAsync(FarmSadcAppEligibilityEntity farmSadcAppEligibilityDetails)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new UpdateFarmSadcAppEligibilitySqlCommand();
            await conn.ExecuteAsync(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {
                     @p_Id                      = farmSadcAppEligibilityDetails.Id
                    ,@p_ApplicationId           = farmSadcAppEligibilityDetails.ApplicationId     
                    ,@p_ProjectAreaAppEl        = farmSadcAppEligibilityDetails.ProjectAreaAppEl     
                    ,@p_RankScore               = farmSadcAppEligibilityDetails.RankScore     
                    ,@p_RankPoints              = farmSadcAppEligibilityDetails.RankPoints     
                    ,@p_SoilPercentage          = farmSadcAppEligibilityDetails.SoilPercentage     
                    ,@p_IsLandsLessThan10Ac     = farmSadcAppEligibilityDetails.IsLandsLessThan10Ac     
                    ,@p_IsLandsGreaterThan10Ac  = farmSadcAppEligibilityDetails.IsLandsGreaterThan10Ac     
                    ,@p_Is75PercentTillable     = farmSadcAppEligibilityDetails.Is75PercentTillable     
                    ,@p_Percent75Tillable1      = farmSadcAppEligibilityDetails.Percent75Tillable1     
                    ,@p_Acre75Tillable          = farmSadcAppEligibilityDetails.Acre75Tillable     
                    ,@p_Is75PercentLand         = farmSadcAppEligibilityDetails.Is75PercentLand     
                    ,@p_Percent75Land           = farmSadcAppEligibilityDetails.Percent75Land     
                    ,@p_Acre75Land              = farmSadcAppEligibilityDetails.Acre75Land     
                    ,@p_Is50PercentTillable     = farmSadcAppEligibilityDetails.Is50PercentTillable     
                    ,@p_Percent50Tillable       = farmSadcAppEligibilityDetails.Percent50Tillable     
                    ,@p_Acre50Tillable          = farmSadcAppEligibilityDetails.Acre50Tillable     
                    ,@p_Is50PercentLand         = farmSadcAppEligibilityDetails.Is50PercentLand     
                    ,@p_Percent50Land           = farmSadcAppEligibilityDetails.Percent50Land     
                    ,@p_Acre50Land              = farmSadcAppEligibilityDetails.Acre50Land
                    ,@p_LastUpdatedBy           = farmSadcAppEligibilityDetails.LastUpdatedBy
                    ,@p_LastUpdatedOn           = DateTime.Now
                });

            return farmSadcAppEligibilityDetails;
        }

    }

}

