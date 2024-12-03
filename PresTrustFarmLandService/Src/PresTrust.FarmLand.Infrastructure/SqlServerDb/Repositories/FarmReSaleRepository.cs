namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class FarmReSaleRepository : IFarmReSaleRepository
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
        public FarmReSaleRepository(
            PresTrustSqlDbContext context,
            IOptions<SystemParameterConfiguration> systemParamConfigOptions
            )
        {
            this.context = context;
            this.systemParamConfig = systemParamConfigOptions.Value;
        }

        #endregion

        public async Task<IEnumerable<FarmReSaleEntity>> GetFarmReSaleAsync()
        {
            IEnumerable<FarmReSaleEntity> results = default;
            using var conn = context.CreateConnection();
            var sqlCommand = new GetFarmReSaleSqlQuery();
            results = (await conn.QueryAsync<FarmReSaleEntity>(sqlCommand.ToString(),
                                commandType: CommandType.Text,
                                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                                param: new { }
                                ));

            return results;
        }

        public async Task<FarmReSaleEntity> SaveFarmReSaleAsync(FarmReSaleEntity farmResale)
        {
            if (farmResale.Id > 0)
                return await UpdateAsync(farmResale);
            else
                return await SaveAsync(farmResale);
        }

        private async Task<FarmReSaleEntity> SaveAsync(FarmReSaleEntity farmResale)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new CreateFarmReSaleSqlCommand();
            var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {
                    @p_FarmNumber = farmResale.FarmNumber,
                    @p_ReSellDate = farmResale.ReSellDate,
                    @p_ReSellPriceTotal = farmResale.ReSellPriceTotal,
                    @p_ReSellPricePerAcre = farmResale.ReSellPricePerAcre,
                    @p_ReSellNotes = farmResale.ReSellNotes,
                    @p_CurrentDeedBook = farmResale.CurrentDeedBook,
                    @p_CurrentDeedPage = farmResale.CurrentDeedPage,
                    @p_CurrentDeedFiled = farmResale.CurrentDeedFiled,
                    @p_InterestedinSelling = farmResale.InterestedinSelling
                });

            farmResale.Id = id;

            return farmResale;
        }

        private async Task<FarmReSaleEntity> UpdateAsync(FarmReSaleEntity farmResale)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new UpdateFarmReSaleSqlCommand();
            await conn.ExecuteAsync(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {
                    @p_Id = farmResale.Id,
                    @p_FarmNumber = farmResale.FarmNumber,
                    @p_ReSellDate = farmResale.ReSellDate,
                    @p_ReSellPriceTotal = farmResale.ReSellPriceTotal,
                    @p_ReSellPricePerAcre = farmResale.ReSellPricePerAcre,
                    @p_ReSellNotes = farmResale.ReSellNotes,
                    @p_CurrentDeedBook = farmResale.CurrentDeedBook,
                    @p_CurrentDeedPage = farmResale.CurrentDeedPage,
                    @p_CurrentDeedFiled = farmResale.CurrentDeedFiled,
                    @p_InterestedinSelling = farmResale.InterestedinSelling
                });

            return farmResale;
        }

    //Delete Re-Sale Data By ID

    public async Task<bool> DeleteFarmReSaleById(int id)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new DeleteFarmReSaleSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
                    commandType: CommandType.Text,
                    commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                    param: new { @p_Id = id });

        return true;
    }
}

