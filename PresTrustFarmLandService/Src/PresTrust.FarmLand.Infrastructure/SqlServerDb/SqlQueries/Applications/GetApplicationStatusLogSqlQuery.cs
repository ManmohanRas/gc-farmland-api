namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetApplicationStatusLogSqlQuery
{
    private readonly string _sqlCommand =
       @"   SELECT	DISTINCT [StatusId],
			            [StatusDate]
            FROM		[Farm].[FarmApplicationStatusLog]
            WHERE		[ApplicationId] = @p_ApplicationId AND [StatusId] IN (101,102,103,104,105,106,107,108)
            ORDER BY	[StatusDate] DESC;";

    public GetApplicationStatusLogSqlQuery() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
