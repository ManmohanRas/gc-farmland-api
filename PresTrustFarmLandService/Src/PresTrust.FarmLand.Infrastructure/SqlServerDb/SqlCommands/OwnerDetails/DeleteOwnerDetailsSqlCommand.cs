namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class DeleteOwnerDetailsSqlCommand
{
    private readonly string _sqlCommand =
       @" DELETE 
              FROM [Farm].[FarmAppOwnerDetailList]
              WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

    public DeleteOwnerDetailsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
