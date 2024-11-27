namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories
{
    public class EsmtAppAdminAppraisalReportRepository : IFarmEsmtAppAdminAppraisalReportRepository
    {
        #region " Members ... "

        private readonly PresTrustSqlDbContext context;
        protected readonly SystemParameterConfiguration systemParamConfig;

        #endregion

        #region " ctor ... "

        /// <summary>
        /// </summary>
        /// <param name="context"></param>
        /// <param name="systemParamConfigOptions"></param>
        public EsmtAppAdminAppraisalReportRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
        {
            this.context = context;
            systemParamConfig = systemParamConfigOptions.Value;
        }

        #endregion

        /// <summary>
        ///  Procedure to fetch tech details by Id.
        /// </summary>
        /// <param name="applicationId"> Id.</param>
        ///// <returns> Returns esmtLiens Entity.</returns>
        public async Task<FarmEsmtAppAdminAppraisalReportEntity> GetAppraisalReport(int applicationId)
        {
            FarmEsmtAppAdminAppraisalReportEntity result = default;
            using var conn = context.CreateConnection();
            var sqlCommand = new GetEsmtAppAdminAppraisalReportSqlCommand();
            var results = await conn.QueryAsync<FarmEsmtAppAdminAppraisalReportEntity>(sqlCommand.ToString(),
                                commandType: CommandType.Text,
                                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                                param: new
                                {
                                    @p_ApplicationId = applicationId,
                                });

            result = results.FirstOrDefault();

            return result ?? new();

        }


        /// <summary>
        ///
        /// </summary>
        /// <param name="esmtLiens"></param>
        /// <returns></returns>
        private async Task<FarmEsmtAppAdminAppraisalReportEntity> SaveAsync(FarmEsmtAppAdminAppraisalReportEntity appraisal)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new CreateEsmtAppAdminAppraisalReportSqlCommand();
            var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {
                    @p_ApplicationId = appraisal.ApplicationId
                    ,@p_AsOfDate = appraisal.AsOfDate
                    ,@p_AppraiserName1 = appraisal.AppraiserName1
                    ,@p_AppraiserName2 = appraisal.AppraiserName2
                    ,@p_LowerAppraiser = appraisal.LowerAppraiser
                    ,@p_HigherAppraiser = appraisal.HigherAppraiser
                    ,@p_PreHLBeforeValue1 = appraisal.PreHLBeforeValue1
                    ,@p_PreHLAfterValue1 = appraisal.PreHLAfterValue1
                    ,@p_PreHLEsmtValue1 = appraisal.PreHLEsmtValue1
                    ,@p_PreHLBeforeValue2 = appraisal.PreHLBeforeValue2
                    ,@p_PreHLAfterValue2 = appraisal.PreHLAfterValue2
                    ,@p_PreHLEsmtValue2 = appraisal.PreHLEsmtValue2
                    ,@p_PostHLBeforeValue1 = appraisal.PostHLBeforeValue1
                    ,@p_PostHLAfterValue1 = appraisal.PostHLAfterValue1
                    ,@p_PostHLEsmtValue1 = appraisal.PostHLEsmtValue1
                    ,@p_PostHLBeforeValue2 = appraisal.PostHLBeforeValue2
                    ,@p_PostHLAfterValue2 = appraisal.PostHLAfterValue2
                    ,@p_PostHLEsmtValue2 = appraisal.PostHLEsmtValue2
                    ,@p_DiffInEsmtAppraisals = appraisal.DiffInEsmtAppraisals
                    ,@p_PostHLDifference = appraisal.PostHLDifference
                    ,@p_DiffInPreandPostHL = appraisal.DiffInPreandPostHL
                    ,@p_WithInHighlands = appraisal.WithInHighlands
                    ,@p_WithInPreservationArea = appraisal.WithInPreservationArea
                    ,@p_SADCCertifiedEsmttotal = appraisal.SADCCertifiedEsmttotal
                    ,@p_SADCEsmtBeforePct = appraisal.SADCEsmtBeforePct
                    ,@p_AppraisedZoning = appraisal.AppraisedZoning
                    ,@p_ApraisedZoningClass = appraisal.ApraisedZoningClass
                    ,@p_AppraisalComments = appraisal.AppraisalComments
                    ,@p_FreeHolderDate = appraisal.FreeHolderDate
                    ,@p_CurrentZoning = appraisal.CurrentZoning
                    ,@p_CADBEasement = appraisal.CADBEasement
                    ,@p_CADBBefore = appraisal.CADBBefore
                    ,@p_CADBEaseBefore = appraisal.CADBEaseBefore
                    ,@p_LastUpdatedBy = appraisal.LastUpdatedBy
                });

            appraisal.Id = id;

            return appraisal;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="esmtLiens"></param>
        /// <returns></returns>
        private async Task<FarmEsmtAppAdminAppraisalReportEntity> UpdateAsync(FarmEsmtAppAdminAppraisalReportEntity appraisal)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new UpdateEsmtAppAdminAppraisalReportSqlCommand();
            await conn.ExecuteAsync(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {
                    @p_Id = appraisal.Id
                    ,@p_ApplicationId = appraisal.ApplicationId
                    ,@p_AsOfDate = appraisal.AsOfDate
                    ,@p_AppraiserName1 = appraisal.AppraiserName1
                    ,@p_AppraiserName2 = appraisal.AppraiserName2
                    ,@p_LowerAppraiser = appraisal.LowerAppraiser
                    ,@p_HigherAppraiser = appraisal.HigherAppraiser
                    ,@p_PreHLBeforeValue1 = appraisal.PreHLBeforeValue1
                    ,@p_PreHLAfterValue1 = appraisal.PreHLAfterValue1
                    ,@p_PreHLEsmtValue1 = appraisal.PreHLEsmtValue1
                    ,@p_PreHLBeforeValue2 = appraisal.PreHLBeforeValue2
                    ,@p_PreHLAfterValue2 = appraisal.PreHLAfterValue2
                    ,@p_PreHLEsmtValue2 = appraisal.PreHLEsmtValue2
                    ,@p_PostHLBeforeValue1 = appraisal.PostHLBeforeValue1
                    ,@p_PostHLAfterValue1 = appraisal.PostHLAfterValue1
                    ,@p_PostHLEsmtValue1 = appraisal.PostHLEsmtValue1
                    ,@p_PostHLBeforeValue2 = appraisal.PostHLBeforeValue2
                    ,@p_PostHLAfterValue2 = appraisal.PostHLAfterValue2
                    ,@p_PostHLEsmtValue2 = appraisal.PostHLEsmtValue2
                    ,@p_DiffInEsmtAppraisals = appraisal.DiffInEsmtAppraisals
                    ,@p_PostHLDifference = appraisal.PostHLDifference
                    ,@p_DiffInPreandPostHL = appraisal.DiffInPreandPostHL
                    ,@p_WithInHighlands = appraisal.WithInHighlands
                    ,@p_WithInPreservationArea = appraisal.WithInPreservationArea
                    ,@p_SADCCertifiedEsmttotal = appraisal.SADCCertifiedEsmttotal
                    ,@p_SADCEsmtBeforePct = appraisal.SADCEsmtBeforePct
                    ,@p_AppraisedZoning = appraisal.AppraisedZoning
                    ,@p_ApraisedZoningClass = appraisal.ApraisedZoningClass
                    ,@p_AppraisalComments = appraisal.AppraisalComments
                    ,@p_FreeHolderDate = appraisal.FreeHolderDate
                    ,@p_CurrentZoning = appraisal.CurrentZoning
                    ,@p_CADBEasement = appraisal.CADBEasement
                    ,@p_CADBBefore = appraisal.CADBBefore
                    ,@p_CADBEaseBefore = appraisal.CADBEaseBefore
                    ,@p_LastUpdatedBy = appraisal.LastUpdatedBy
                    ,@p_LastUpdatedOn = DateTime.Now,
                });

            return appraisal;
        }
        /// <summary>
        /// Save .
        /// </summary>
        /// <param name="esmtLiens"></param>
        /// <returns></returns>

        public async Task<FarmEsmtAppAdminAppraisalReportEntity> SaveAppraisalAsync(FarmEsmtAppAdminAppraisalReportEntity appraisal)
        {
            if (appraisal.Id > 0)
                return await UpdateAsync(appraisal);
            else
                return await SaveAsync(appraisal);
        }

    }
}

