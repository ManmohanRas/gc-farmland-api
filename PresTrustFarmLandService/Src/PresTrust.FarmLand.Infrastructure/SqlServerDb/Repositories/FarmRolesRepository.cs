namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class FarmRolesRepository : IFarmRolesRepository
{
    private readonly PresTrustSqlDbContext context;
    protected readonly SystemParameterConfiguration systemParamConfig;

    public FarmRolesRepository
        (
        PresTrustSqlDbContext context,
        IOptions<SystemParameterConfiguration> systemParamConfigOptions
        )
    {
        this.context = context;
        this.systemParamConfig = systemParamConfigOptions.Value;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationId"></param>
    /// <returns></returns>
    public async Task<List<FarmRolesEntity>> GetRolesAsync(int applicationId)
    {
        List<FarmRolesEntity>? results = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new GetRolesSqlCommand();
        results = (await conn.QueryAsync<FarmRolesEntity>(sqlCommand.ToString(),
                    commandType: CommandType.Text,
                    commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                    param: new { @p_ApplicationId = applicationId })).ToList();

        return results ?? new();
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="applicationUsers"></param>
    /// <returns></returns>
    public async Task SaveAsync(List<FarmRolesEntity> applicationUsers)
    {
        using var conn = context.CreateConnection();
        foreach (var user in applicationUsers)
        {
            var sqlCommand = new CreateRolesSqlCommand();
            await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
                commandType: CommandType.Text,
                commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                param: new
                {
                    @p_ApplicationId = user.ApplicationId,
                    @p_UserId = user.UserId,
                    @p_Email = user.Email,
                    @p_UserName = user.UserName,
                    @p_FirstName = user.FirstName,
                    @p_LastName = user.LastName,
                    @p_Title = user.Title,
                    @p_PhoneNumber = user.PhoneNumber,
                    @p_PrimaryContact = user.IsPrimaryContact,
                    @p_IsAlternateContact = user.IsAlternateContact,
                    @p_LastUpdatedBy = user.LastUpdatedBy
                });
        }
    }
}
