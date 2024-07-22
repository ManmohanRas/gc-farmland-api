namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.Repositories;

public class TermCommentsRepository : ITermCommentsRepository
{
    private readonly PresTrustSqlDbContext context;
    protected readonly SystemParameterConfiguration systemParamConfig;

    public TermCommentsRepository(
         PresTrustSqlDbContext context,
        IOptions<SystemParameterConfiguration> systemParamConfigOptions
        )
    {
        this.context = context;
        this.systemParamConfig = systemParamConfigOptions.Value;
    }

    public async Task<List<TermCommentsEntity>> GetAllCommentsAsync(int applicationId)
    {
        List<TermCommentsEntity> results;
        using var conn = context.CreateConnection();
        var sqlCommand = new GetTermCommentSqlCommand();
        results = (await conn.QueryAsync<TermCommentsEntity>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
                            param: new { @p_ApplicationId = applicationId })).ToList();
        return results ?? new();
    }

    public async Task<TermCommentsEntity> SaveAsync(TermCommentsEntity comment)
    {
        if (comment.Id > 0)
            return await UpdateAsync(comment);
        else
            return await CreateAsync(comment);
    }

    private async Task<TermCommentsEntity> UpdateAsync(TermCommentsEntity comment)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new UpdateTermCommentSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = comment.Id,
                @p_ApplicationId = comment.ApplicationId,
                @p_Comment = comment.Comment,
                @p_CommentTypeId = comment.CommentTypeId,
                @p_LastUpdatedBy = comment.LastUpdatedBy,
                @p_LastUpdatedOn = DateTime.Now
            });

        return comment;
    }

    private async Task<TermCommentsEntity> CreateAsync(TermCommentsEntity comment)
    {
        int id = default;

        using var conn = context.CreateConnection();
        var sqlCommand = new CreateTermCommentSqlCommand();
        id = await conn.ExecuteScalarAsync<int>(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Comment = comment.Comment,
                @p_CommentTypeId = comment.CommentTypeId,
                @p_ApplicationId = comment.ApplicationId,
                @p_LastUpdatedBy = comment.LastUpdatedBy,
               
            });

        comment.Id = id;

        return comment;
    }

    public async Task DeleteCommentAsync(TermCommentsEntity comment)
    {
        using var conn = context.CreateConnection();
        var sqlCommand = new DeleteTermCommentSqlCommand();
        await conn.ExecuteAsync(sqlCommand.ToString(),
            commandType: CommandType.Text,
            commandTimeout: systemParamConfig.SQLCommandTimeoutInSeconds,
            param: new
            {
                @p_Id = comment.Id,
                @p_ApplicationId = comment.ApplicationId,
            });
    }
}
