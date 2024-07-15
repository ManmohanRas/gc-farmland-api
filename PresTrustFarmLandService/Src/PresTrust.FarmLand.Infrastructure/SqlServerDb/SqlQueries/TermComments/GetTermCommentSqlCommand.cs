namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetTermCommentSqlCommand
{
    private readonly string _sqlCommand =
        @"  SELECT [Id]
                      ,[Comment]
                      ,[CommentTypeId]
                      ,[ApplicationId]
                      ,[LastUpdatedOn]
                      ,[LastUpdatedBy]
                FROM [Farm].[FarmApplicationComment] 
                WHERE [ApplicationId] = @p_ApplicationId;"
        ;
    public GetTermCommentSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
