namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateTermCommentSqlCommand
{
    private readonly string _sqlCommand =
                     @"INSERT INTO [Farm].[FarmApplicationComment]
              (
                 Comment
                ,CommentTypeId
                ,ApplicationId
                ,ApplicationTypeId
                ,LastUpdatedBy
                ,LastUpdatedOn
              )
              VALUES(
                @p_Comment
               ,@p_CommentTypeId
               ,@p_ApplicationId
               ,@p_ApplicationTypeId
               ,@p_LastUpdatedBy
               ,GetDate());

			SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateTermCommentSqlCommand()
    {

    }

    public override string ToString()
    {
        return _sqlCommand;
    }

}
