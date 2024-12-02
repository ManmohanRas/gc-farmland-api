namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class EmailTemplateRepository : IEmailTemplateRepository
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
    public EmailTemplateRepository(PresTrustSqlDbContext context, IOptions<SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        systemParamConfig = systemParamConfigOptions.Value;
    }

    #endregion

    public async Task<IEnumerable<FarmEmailTemplateEntity>> GetAllEmailTemplates()
    {
        IEnumerable<FarmEmailTemplateEntity> results = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new GetAllEmailTemplateSqlCommand();
        results = await conn.QueryAsync<FarmEmailTemplateEntity>(sqlCommand.ToString(),
                    commandType: CommandType.Text,
                    commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds);

        return results;
    }

    /// <summary>
    /// Get Email Template Details
    /// </summary>
    /// <param name="emailTemplateCode"></param>
    /// <returns></returns>
    public async Task<FarmEmailTemplateEntity> GetEmailTemplate(string emailTemplateCode)
    {
        FarmEmailTemplateEntity result = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new GetEmailTemplateSqlCommand();
        var results = await conn.QueryAsync<FarmEmailTemplateEntity>(sqlCommand.ToString(),
                    commandType: CommandType.Text,
                    commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                    param: new { @p_EmailTemplateCode = emailTemplateCode });

        result = results.FirstOrDefault();

        return result;
    }

    public async Task<FarmEmailTemplateEntity> SaveEmailAsync(FarmEmailTemplateEntity template)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateEmailTemplateSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = template.Id,
                @p_Title = template.Title,
                @p_Description = template.Description,
                @p_TemplateCode = template.TemplateCode,
                @p_LastUpdatedBy = template.LastUpdatedBy
            });

        return template;
    }
}
