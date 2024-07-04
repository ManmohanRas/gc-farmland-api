namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class SaveBrokenRuleSqlCommand
{
    private readonly string _sqlCommand =
           @"  INSERT INTO [Farm].[FarmApplicationBrokenRules]
				([ApplicationId]
				,[SectionId]
				,[Message]
				,[IsApplicantFlow])
			VALUES
				(@p_ApplicationId
				,@p_SectionId 
				,@p_Message
				,@p_IsApplicantFlow)

			SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public SaveBrokenRuleSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
