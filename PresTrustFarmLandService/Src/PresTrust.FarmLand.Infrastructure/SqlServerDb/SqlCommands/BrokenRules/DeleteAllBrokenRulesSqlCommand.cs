namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class DeleteAllBrokenRulesSqlCommand
{
    private readonly string _sqlCommand =

		  @" DELETE FROM [Farm].[FarmApplicationBrokenRules]
			 WHERE	ApplicationId = @p_ApplicationId;";
    public DeleteAllBrokenRulesSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
