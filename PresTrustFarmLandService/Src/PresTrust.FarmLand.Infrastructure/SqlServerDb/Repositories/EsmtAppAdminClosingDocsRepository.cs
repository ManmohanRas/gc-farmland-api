using System;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories
{
    public class EsmtAppAdminClosingDocsRepository : IFarmEsmtAppAdminClosingDocsRepository
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
        public EsmtAppAdminClosingDocsRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
        {
            this.context = context;
            systemParamConfig = systemParamConfigOptions.Value;
        }

        #endregion

        /// <summary>
        ///  Procedure to fetch tech details by Id.
        /// </summary>
        /// <param name="applicationId"> Id.</param>
        /// <returns> Returns esmtLiens Entity.</returns>
        public async Task<FarmEsmtAppAdminClosingDocsEntity> GetClosingDocsAsync(int applicationId)
        {
            FarmEsmtAppAdminClosingDocsEntity result = default;
            using var conn = context.CreateConnection();
            var sqlCommand = new GetEsmtAppAdminClosingDocsSqlQuery();
            var results = await conn.QueryAsync<FarmEsmtAppAdminClosingDocsEntity>(sqlCommand.ToString(),
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
        private async Task<FarmEsmtAppAdminClosingDocsEntity> SaveAsync(FarmEsmtAppAdminClosingDocsEntity closingDocs)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new CreateEsmtAppAdminClosingDocsSqlCommand();
            var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {
                     @p_ApplicationId    = closingDocs.ApplicationId
                    ,@p_ProjectStatus    = closingDocs.ProjectStatus
                    ,@p_EPDeedBook    = closingDocs.EPDeedBook
                    ,@p_EPDeedPage    = closingDocs.EPDeedPage
                    ,@p_EPDeedFiled    = closingDocs.EPDeedFiled
                    ,@p_EPDeedClerkID    = closingDocs.EPDeedClerkID
                    ,@p_CountyAttorney    = closingDocs.CountyAttorney
                    ,@p_CountyAttorneyInfo    = closingDocs.CountyAttorneyInfo
                    ,@p_SurveyDate    = closingDocs.SurveyDate
                    ,@p_Surveyor    = closingDocs.Surveyor
                    ,@p_TitleCompany    = closingDocs.TitleCompany
                    ,@p_TitlePolicy    = closingDocs.TitlePolicy
                    ,@p_ClosingDate    = closingDocs.ClosingDate
                    ,@p_EndorsementDates    = closingDocs.EndorsementDates
                    ,@p_LastUpdatedBy    = closingDocs.LastUpdatedBy

                });

            closingDocs.Id = id;

            return closingDocs;
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="esmtLiens"></param>
        /// <returns></returns>
        private async Task<FarmEsmtAppAdminClosingDocsEntity> UpdateAsync(FarmEsmtAppAdminClosingDocsEntity closingDocs)
        {
            using var conn = context.CreateConnection();
            var sqlCommand = new UpdateEsmtAppAdminClosingDocsSqlCommand();
            await conn.ExecuteAsync(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {
                     @p_Id = closingDocs.Id
                    ,@p_ApplicationId = closingDocs.ApplicationId
                    ,@p_ProjectStatus = closingDocs.ProjectStatus
                    ,@p_EPDeedBook = closingDocs.EPDeedBook
                    ,@p_EPDeedPage = closingDocs.EPDeedPage
                    ,@p_EPDeedFiled = closingDocs.EPDeedFiled
                    ,@p_EPDeedClerkID = closingDocs.EPDeedClerkID
                    ,@p_CountyAttorney = closingDocs.CountyAttorney
                    ,@p_CountyAttorneyInfo = closingDocs.CountyAttorneyInfo
                    ,@p_SurveyDate = closingDocs.SurveyDate
                    ,@p_Surveyor = closingDocs.Surveyor
                    ,@p_TitleCompany = closingDocs.TitleCompany
                    ,@p_TitlePolicy = closingDocs.TitlePolicy
                    ,@p_ClosingDate = closingDocs.ClosingDate
                    ,@p_EndorsementDates = closingDocs.EndorsementDates
                    ,@p_LastUpdatedBy = closingDocs.LastUpdatedBy
                    ,@p_LastUpdatedOn = DateTime.Now,
                });

            return closingDocs;
        }
        /// <summary>
        /// Save .
        /// </summary>
        /// <param name="esmtLiens"></param>
        /// <returns></returns>

        public async Task<FarmEsmtAppAdminClosingDocsEntity> SaveClosingDocsAsync(FarmEsmtAppAdminClosingDocsEntity closingDocs)
        {
            if (closingDocs.Id > 0)
                return await UpdateAsync(closingDocs);
            else
                return await SaveAsync(closingDocs);
        }

    }
}
