namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class TermBrokenRuleRepository : ITermBrokenRuleRepository
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
    public TermBrokenRuleRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    public async Task<List<TermBrokenRuleEntity>> GetBrokenRulesAsync(int applicationId)
    {
        List<TermBrokenRuleEntity> results = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new GetBrokenRulesSqlCommand();
        results = (await conn.QueryAsync<TermBrokenRuleEntity>(sqlCommand.ToString(),
                    commandType: CommandType.Text,
                    commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                    param: new { @p_ApplicationId = applicationId })).ToList();

        return results ?? new();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="brokenRule"></param>
    /// <returns></returns>
    public async Task SaveBrokenRules(List<TermBrokenRuleEntity> brokenRules)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new SaveBrokenRuleSqlCommand();

        foreach (var brokenRule in brokenRules)
        {
            await conn.ExecuteAsync(sqlCommand.ToString(),
                      commandType: CommandType.Text,
                      commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                      param: new
                      {
                          @p_ApplicationId = brokenRule.ApplicationId,
                          @p_SectionId = brokenRule.SectionId,
                          @p_Message = brokenRule.Message,
                          @p_IsApplicantFlow = brokenRule.IsApplicantFlow
                      });
        }
      
    }

    /// <summary>
    /// Delete broken rules 
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="section"></param>
    /// <returns></returns>
    public async Task DeleteBrokenRulesAsync(int applicationId, ApplicationSectionEnum section)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new DeleteBrokenRulesSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_SectionId = (int)section,
                @p_ApplicationId = applicationId
            });
    }
}
