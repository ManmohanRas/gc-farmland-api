namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetBrokenRulesSqlCommand
{
    private readonly string _sqlCommand =
        @"   SELECT		 [ApplicationId]
							,[SectionId]
							,[Message]
							,[IsApplicantFlow]
				FROM		 [Farm].[FarmApplicationBrokenRules]
				WHERE		 ApplicationId = @p_ApplicationId
				ORDER BY	 SectionId ASC;";

    public GetBrokenRulesSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
