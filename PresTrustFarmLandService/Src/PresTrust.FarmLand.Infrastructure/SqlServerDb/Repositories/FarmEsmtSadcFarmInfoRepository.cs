
using System;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories
{
    public class FarmEsmtSadcFarmInfoRepository : IFarmEsmtSadcFarmInfoRepository
    {

        private readonly PresTrustSqlDbContext _context;
        private readonly SystemParameterConfiguration config;

        public FarmEsmtSadcFarmInfoRepository
        (
            PresTrustSqlDbContext context,
            IOptions<SystemParameterConfiguration> config
        )
        {
            _context = context;
            this.config = config.Value;
        }
        public async Task<FarmEsmtSadcFarmInfoEntity> GetEsmtSadcFarmInfo(int ApplicationId)
        {
            FarmEsmtSadcFarmInfoEntity result = default;
            var sqlCommand = new GetFarmEsmtSadcFarmInfoSqlCommand();
            using var connection = _context.CreateConnection();
            var results = await connection.QueryAsync<FarmEsmtSadcFarmInfoEntity>(sqlCommand.ToString(),
               commandType: CommandType.Text,
               commandTimeout: config.SQLCommandTimeoutInSeconds,
               param: new { @p_ApplicationId = ApplicationId });
            result = results.FirstOrDefault();

            return result ?? new();
        }

        public async Task<FarmEsmtSadcFarmInfoEntity> SaveEsmtSadcFarmInfo(FarmEsmtSadcFarmInfoEntity request)
        {            
            if (request.Id > 0)
            {
                return await UpdateAsync(request);
            }
            else {
                return await SaveAsync(request);
            }           
        }

        public async Task <FarmEsmtSadcFarmInfoEntity> SaveAsync(FarmEsmtSadcFarmInfoEntity request)
        {
            using var connection = _context.CreateConnection();
            var sqlCommand = new CreateFarmEsmtSadcFarmInfoSqlCommand();
            var id = await connection.ExecuteScalarAsync<int>(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: config.SQLCommandTimeoutInSeconds,
                param: new
                {
                    @p_ApplicationId = request.ApplicationId,
                    @p_AlternatePhoneNumber = request.AlternatePhoneNumber,
                    @p_County = request.County,
                    @p_TotalFarmAcreage = request.TotalFarmAcreage,
                    @p_Acres = request.Acres,
                    @p_IsContactSame = request.IsContactSame,
                    @p_IsOtherContact = request.IsOtherContact,
                    @p_OtherPrimaryFirstName = request.OtherPrimaryFirstName,
                    @p_OtherPrimaryRelation = request.OtherPrimaryRelation,
                    @p_OtherPrimaryPhoneNumber = request.OtherPrimaryPhoneNumber,
                    @p_OtherPrimaryEmail = request.OtherPrimaryEmail,
                    @p_OtherPrimaryAddress = request.OtherPrimaryAddress,
                    @p_IsVisitPrimaryContact = request.IsVisitPrimaryContact,
                    @p_IsVisitLandOwner = request.IsVisitLandOwner,
                    @p_IsVisitOther = request.IsVisitOther,
                    @p_VisitName = request.VisitName,
                    @p_VisitRelation = request.VisitRelation,
                    @p_VisitPhoneNumber = request.VisitPhoneNumber,
                    @p_VisitEmail = request.VisitEmail,
                    @p_VisitSADCID = request.VisitSADCID,
                    @p_VisitDateRecieved = request.VisitDateRecieved,
                    @p_IsImmediateCurrentMember = request.IsImmediateCurrentMember,
                    @p_Position = request.Position,
                    @p_Term = request.Term,
                    @p_LastUpdatedBy = request.LastUpdatedBy,
                });
            request.Id = id;
            return request;
        }

        public async Task<FarmEsmtSadcFarmInfoEntity> UpdateAsync(FarmEsmtSadcFarmInfoEntity request)
        {
            using var connection = _context.CreateConnection();
            var sqlCommand = new UpdateFarmEsmtSadcFarmInfoSqlCommand();
            var id = await connection.ExecuteAsync(sqlCommand.ToString(),
                commandTimeout: config.SQLCommandTimeoutInSeconds,
                param: new
                {
                    @p_Id = request.Id,
                    @p_ApplicationId = request.ApplicationId,
                    @p_AlternatePhoneNumber = request.AlternatePhoneNumber,
                    @p_County = request.County,
                    @p_TotalFarmAcreage = request.TotalFarmAcreage,
                    @p_Acres = request.Acres,
                    @p_IsContactSame = request.IsContactSame,
                    @p_IsOtherContact = request.IsOtherContact,
                    @p_OtherPrimaryFirstName = request.OtherPrimaryFirstName,
                    @p_OtherPrimaryRelation = request.OtherPrimaryRelation,
                    @p_OtherPrimaryPhoneNumber = request.OtherPrimaryPhoneNumber,
                    @p_OtherPrimaryEmail = request.OtherPrimaryEmail,
                    @p_OtherPrimaryAddress = request.OtherPrimaryAddress,
                    @p_IsVisitPrimaryContact = request.IsVisitPrimaryContact,
                    @p_IsVisitLandOwner = request.IsVisitLandOwner,
                    @p_IsVisitOther = request.IsVisitOther,
                    @p_VisitName = request.VisitName,
                    @p_VisitRelation = request.VisitRelation,
                    @p_VisitPhoneNumber = request.VisitPhoneNumber,
                    @p_VisitEmail = request.VisitEmail,
                    @p_VisitSADCID = request.VisitSADCID,
                    @p_VisitDateRecieved = request.VisitDateRecieved,
                    @p_IsImmediateCurrentMember = request.IsImmediateCurrentMember,
                    @p_Position = request.Position,
                    @p_Term = request.Term,
                    @p_LastUpdatedBy = request.LastUpdatedBy,
                    @p_LastUpdatedOn = DateTime.Now
                });
            return request;

        }
    }
}
