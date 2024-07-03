namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;
public class GetApplicationSignatorySqlCommand
{
    private readonly string _sqlCommand =
        @"  SELECT   [Id]
                    ,[ApplicationId]
                    ,[Designation]
                    ,[Title]
                    ,[SignedOn]
                    ,[LastUpdatedBy]
                    ,[LastUpdatedOn]
            FROM [Farm].[FarmApplicationSignatory]
            WHERE ApplicationId = @p_ApplicationId";


    public GetApplicationSignatorySqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
