namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class DeleteTermAppDocumentSqlCommand
{
    private readonly string _sqlCommand =
              @" DELETE 
            FROM	[Farm].[FarmApplicationDocument]
            WHERE	Id = @p_Id;";

    public DeleteTermAppDocumentSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
