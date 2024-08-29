namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Contracts;

public interface ITermBrokenRuleRepository
{

    /// <summary>
    /// get broken rules
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    Task<List<FarmBrokenRuleEntity>> GetBrokenRulesAsync(int applicationId);
    /// <summary>
    /// save broken rules
    /// </summary>
    /// <param name="brokenRules"></param>
    /// <returns></returns>
    Task SaveBrokenRules(List<FarmBrokenRuleEntity> brokenRules);
    /// <summary>
    /// Delete broken rules 
    /// </summary>
    /// <param name="applicationId"></param>
    /// <param name="section"></param>
    /// <returns></returns>
    Task DeleteBrokenRulesAsync(int applicationId, TermAppSectionEnum section);
}
