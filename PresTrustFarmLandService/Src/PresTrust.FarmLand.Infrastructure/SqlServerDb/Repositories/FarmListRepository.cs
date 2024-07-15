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

        public async Task<FarmListEntity> SaveFarmListAsync(FarmListEntity farmList)
        {
            if (farmList.FarmListID > 0)
                return await UpdateAsync(farmList);
            else
                return await SaveAsync(farmList);
        }

        private async Task<FarmListEntity> SaveAsync(FarmListEntity farmList)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new CreateFarmSqlCommand();
            var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {

                    @p_FarmName = farmList.FarmName,
                    @p_Status = farmList.Status,
                    @p_Address1 = farmList.Address1,
                    @p_Address2 = farmList.Address2,
                    @p_AgencyID = farmList.AgencyID,
                    @p_OriginalLandowner = farmList.OriginalLandowner,
                    @p_FarmNumber = farmList.FarmNumber
                });

            farmList.FarmListID = id;

            return farmList;
        }

        private async Task<FarmListEntity> UpdateAsync(FarmListEntity farmList)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new UpdateFarmSqlCommand();
            await conn.ExecuteAsync(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {
                    @p_FarmListID = farmList.FarmListID,
                    @p_FarmName = farmList.FarmName,
                    @p_Status = farmList.Status,
                    @p_Address1 = farmList.Address1,
                    @p_Address2 = farmList.Address2,
                    @p_AgencyID = farmList.AgencyID,
                    @p_OriginalLandowner = farmList.OriginalLandowner,
                    @p_FarmNumber = farmList.FarmNumber
                });

            return farmList;
        }
    }
}
