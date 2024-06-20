namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetApplicationDetailsSqlCommand
{
    private readonly string _sqlCommand =
    @" SELECT Distinct
                A.[Id],
				A.[AgencyId],
				A.[Title],
			    A.[ApplicationTypeId],
                A.[StatusId],
                A.[CreatedOn]
               FROM [Farm].[FarmApplication] AS A
               WHERE A.Id = @p_Id;";

    public override string ToString()
    {
        return _sqlCommand;
    }
}
