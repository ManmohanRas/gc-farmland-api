namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetApplicationStatusLogSqlQuery
{
    private readonly string _sqlCommand =
       @"   SELECT	DISTINCT [StatusId],
			            [StatusDate]
            FROM		[Farm].[FarmApplicationStatusLog]
            WHERE		[ApplicationId] = @p_ApplicationId
            ORDER BY	[StatusDate] DESC;";

    public GetApplicationStatusLogSqlQuery() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
