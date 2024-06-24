namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

class UpdateTermCommentSqlCommand
{
    private readonly string _sqlCommand =
       @"  UPDATE [Farm].[FarmApplicationComment]
                SET Comment = @p_Comment
                    ,CommentTypeId = @p_CommentTypeId
                   ,LastUpdatedBy = @p_LastUpdatedBy
                   ,LastUpdatedOn = GETDATE()
                WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

    public UpdateTermCommentSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
