
using Microsoft.Extensions.Options;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class TermAppAdminContactsRepository : ITermAppAdminContactsRepository

{
    private readonly PresTrustSqlDbContext context;
    protected readonly SystemParameterConfiguration systemParamConfig;

    public TermAppAdminContactsRepository(
        PresTrustSqlDbContext context,
     IOptions< SystemParameterConfiguration> systemParamConfigOptions)
    {
        this.context = context;
        this.systemParamConfig = systemParamConfigOptions.Value;
    }

    public async Task<List<TermAppAdminContactsEntity>> GetAllContactsAsync(int applicationId)
    {
        List<TermAppAdminContactsEntity> results;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetTermAppAdminContactsSqlCommand();
        results = (await conn.QueryAsync<TermAppAdminContactsEntity>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new { @p_ApplicationId = applicationId })).ToList();
        return results ?? new();
    }




    public async Task<TermAppAdminContactsEntity> SaveAsync(TermAppAdminContactsEntity contact)
    {
        if (contact.Id > 0)
            return await UpdateAsync(contact);
        else
            return await CreateAsync(contact);
    }

    private async Task<TermAppAdminContactsEntity> UpdateAsync(TermAppAdminContactsEntity contact)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateTermAppAdminContactsSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = contact.Id,
                @p_ApplicationId = contact.ApplicationId,
                @p_ContactName = contact.ContactName,
                @p_Agency = contact.Agency,
                @p_Email = contact.Email,
                @p_MainNumber = contact.MainNumber,
                @p_AlternateNumber = contact.AlternateNumber,
                @p_SelContact = contact.SelectContact,
                @p_LastUpdatedBy = contact.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return contact;
    }
    private async Task<TermAppAdminContactsEntity> CreateAsync(TermAppAdminContactsEntity contact)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateTermAppAdminContactsSqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_ApplicationId = contact.ApplicationId,
                @p_ContactName = contact.ContactName,
                @p_Agency = contact.Agency,
                @p_Email = contact.Email,
                @p_MainNumber = contact.MainNumber,
                @p_AlternateNumber = contact.AlternateNumber,
                @p_SelContact = contact.SelectContact,
                @p_LastUpdatedBy = contact.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        contact.Id = id;

        return contact;
    }

    public async Task DeleteContactAsync(TermAppAdminContactsEntity contact)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new DeleteTermAppAdminContactsSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = contact.Id,
                @p_ApplicationId = contact.ApplicationId
            });
    }
}



