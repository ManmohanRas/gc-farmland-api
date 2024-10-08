
namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;
public class EsmtAppAdminOfferCostsRepository : IEsmtAppAdminOfferCostsRepository
{
    private PresTrustSqlDbContext _context;
    private SystemParameterConfiguration config; 
    
    public EsmtAppAdminOfferCostsRepository(
        PresTrustSqlDbContext context,
        IOptions<SystemParameterConfiguration> config) 
    {
      _context = context;
      this.config = config.Value;
    }
    public async Task<EsmtAppAdminOfferCostsEntity> GetEsmtAppAdminOfferCostsAsync(int applicationId)
    {
        EsmtAppAdminOfferCostsEntity? result = default;
        using var conn = _context.CreateConnection();
        var sqlcommand = new GetEsmtAppAdminOfferCostsSqlCommand();

        var results = await conn.QueryAsync<EsmtAppAdminOfferCostsEntity>(
            sqlcommand.ToString(),
            new { @p_ApplicationId = applicationId },
            commandType: CommandType.Text,
            commandTimeout: config.SQLCommandTimeoutInSeconds);

        result = results.FirstOrDefault();
        return result ?? new EsmtAppAdminOfferCostsEntity();
    }

    public async Task<EsmtAppAdminOfferCostsEntity> SaveEsmtAppAdminOfferCostsAsync(EsmtAppAdminOfferCostsEntity request)
    {
        if (request.Id > 0)
        {
            return await UpdateAsync(request);
        }
        else
        {
            return await SaveAsync(request);
        }
    }


    public async Task<EsmtAppAdminOfferCostsEntity> SaveAsync(EsmtAppAdminOfferCostsEntity request)
    {   
        int id = default;
        using var conn = _context.CreateConnection();
        var sqlCommand = new CreateEsmtAppAdminOfferCostsSqlCommand();
         id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(), commandType:CommandType.Text,
                                     commandTimeout:config.SQLCommandTimeoutInSeconds,
                                     param: new
                                     {
                                         @p_Id                 = request.Id,
                                         @p_ApplicationId      = request.ApplicationId,
                                         @p_CadbLandOwnerOffer = request.CadbLandOwnerOffer,
                                         @p_IsOfferAccepted = request.IsOfferAccepted,
                                         @p_TotalCostPerAcre = request.TotalCostPerAcre,
                                         @p_TotalCost = request.TotalCost,
                                         @p_MCCostSharePct = request.MCCostSharePct,
                                         @p_McCountyCostShareTotal = request.McCountyCostShareTotal,
                                         @p_SADCCostSharePct = request.SADCCostSharePct,
                                         @p_SADCCostShareTotal = request.SADCCostShareTotal,
                                         @p_OtherCostShareTotal = request.OtherCostShareTotal,
                                         @p_OtherSource = request.OtherSource,
                                         @p_CostNote = request.CostNote,
                                         @p_LastUpdatedBy = request.LastUpdatedBy,
                                         @p_LastUpdatedOn = DateTime.Now,
                                     });
        request.Id = id;
        return request;
    }

    public async Task<EsmtAppAdminOfferCostsEntity> UpdateAsync(EsmtAppAdminOfferCostsEntity request) 
    { 
        using var conn = _context.CreateConnection();
        var sqlCommand = new UpdateEsmtAppAdminOfferCostsSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandTimeout: config.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = request.Id,
                @p_ApplicationId = request.ApplicationId,
                @p_CadbLandOwnerOffer = request.CadbLandOwnerOffer,
                @p_IsOfferAccepted = request.IsOfferAccepted,
                @p_TotalCostPerAcre = request.TotalCostPerAcre,
                @p_TotalCost = request.TotalCost,
                @p_MCCostSharePct = request.MCCostSharePct,
                @p_McCountyCostShareTotal = request.McCountyCostShareTotal,
                @p_SADCCostSharePct = request.SADCCostSharePct,
                @p_SADCCostShareTotal = request.SADCCostShareTotal,
                @p_OtherCostShareTotal = request.OtherCostShareTotal,
                @p_OtherSource = request.OtherSource,
                @p_CostNote = request.CostNote,
                @p_LastUpdatedBy = request.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now,
            });
        return request;
    } 

}
