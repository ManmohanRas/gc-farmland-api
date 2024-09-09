
using PresTrust.FarmLand.Domain.Configurations;
using System;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class EsmtAppExistUsesRepository : IEsmtAppExistUsesRepository
{
    PresTrustSqlDbContext _context;
    private readonly SystemParameterConfiguration SystemParameterConfiguration;



    public EsmtAppExistUsesRepository(PresTrustSqlDbContext context,
      IOptions<SystemParameterConfiguration> configOptions)
    {
        _context = context;
        this.SystemParameterConfiguration = configOptions.Value;

    }
    public  async Task<EsmtAppExistUsesEntity> GetEsmtAppExistUses(int applicationId)
    {
        EsmtAppExistUsesEntity result = default;

         using var conn = _context.CreateConnection();
        var sqlCommand = new GetEsmtAppExistUsesSqlCommand();
        
        var results = await conn.QueryAsync<EsmtAppExistUsesEntity>(sqlCommand.ToString(),

           commandType:CommandType.Text,
           commandTimeout:SystemParameterConfiguration.SQLCommandTimeoutInSeconds,
           param: new {@p_ApplicationId =  applicationId}                      
           );
        result = results.FirstOrDefault();

            return result ?? new();
    }

    public async Task<EsmtAppExistUsesEntity> SaveEsmtAppExistUses(EsmtAppExistUsesEntity entity)
    {


        if (entity.ApplicationId > 0)
        {
            return await UpdateAsync(entity);
           
        }
        else {
            return await SaveAsync(entity);
        }      
    }

    public async Task<EsmtAppExistUsesEntity> SaveAsync(EsmtAppExistUsesEntity existUses)
    {
        using var conn = _context.CreateConnection();
        var sqlCommand = new CreateEsmtAppExistUsesSqlCommand();
        var id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: SystemParameterConfiguration.SQLCommandTimeoutInSeconds,
            param : new
            {
                @p_ApplicationId = existUses.ApplicationId,
                @p_IsSubdivisionApprovals = existUses.IsSubdivisionApprovals,
                @p_InfoAboutPremises = existUses.InfoAboutPremises,
                @p_LastUpdatedBy = existUses.LastUpdatedBy

            });
        existUses.Id = id;
        return existUses;
    }


    public async Task<EsmtAppExistUsesEntity> UpdateAsync(EsmtAppExistUsesEntity existUses)
    {
        using var conn = _context.CreateConnection();
        var sqlCommand = new UpdateEsmtAppExistUsesSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandTimeout: SystemParameterConfiguration.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = existUses.Id,
                @p_ApplicationId = existUses.ApplicationId,
                @p_IsSubdivisionApprovals = existUses.IsSubdivisionApprovals,
                @p_InfoAboutPremises = existUses.InfoAboutPremises,
                @p_LastUpdatedBy = existUses.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now,

            });           
        return existUses;
    }
}
