namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetApplicationStatusLogSqlQuery
{
    private readonly string _sqlCommand =
       @"   SELECT	DISTINCT [StatusId],
			            [StatusDate]
            FROM		[Farm].[FarmApplicationStatusLog]
            WHERE		[ApplicationId] = @p_ApplicationId AND [StatusId] IN (2,3,4,5,6,7,8)
            ORDER BY	[StatusDate] DESC;";

    public GetApplicationStatusLogSqlQuery() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
