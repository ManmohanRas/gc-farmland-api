namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

class DeleteTermCommentSqlCommand
{
    private readonly string _sqlCommand =
    @" DELETE 
              FROM [Farm].[FarmApplicationComment]
              WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

    public DeleteTermCommentSqlCommand()
    { 
    }

    public override string ToString()
    {
        return _sqlCommand;
    }

}
