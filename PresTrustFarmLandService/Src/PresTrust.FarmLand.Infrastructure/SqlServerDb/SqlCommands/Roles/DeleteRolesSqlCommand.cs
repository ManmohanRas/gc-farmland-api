namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class DeleteRolesSqlCommand
{
    private readonly string _sqlCommand =
        @" DELETE
            FROM  [Farm].[FarmApplicationUser]
            WHERE ApplicationId = @p_ApplicationId;";

    public DeleteRolesSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}