namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;
public class GetTermAppSignatorySqlCommand
{
    private readonly string _sqlCommand =
        @"  SELECT   [Id]
                    ,[ApplicationId]
                    ,[Designation]
                    ,[Title]
                    ,[SignedOn]
                    ,[LastUpdatedBy]
                    ,[LastUpdatedOn]
            FROM [Farm].[FarmTermAppSignature]
            WHERE ApplicationId = @p_ApplicationId";


    public GetTermAppSignatorySqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
