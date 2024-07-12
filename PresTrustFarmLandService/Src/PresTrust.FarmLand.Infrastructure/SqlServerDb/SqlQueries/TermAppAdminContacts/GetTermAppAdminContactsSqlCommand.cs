

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetTermAppAdminContactsSqlCommand
{
    private readonly string _sqlCommand =
       @"  SELECT [Id]   
                   ,[ApplicationId]
                   ,[ContactName]
                   ,[Agency]
                   ,[Email]
                   ,[MainNumber]
                   ,[AlternateNumber]
                   ,[SelectContact]
                   ,[LastUpdatedOn]
                   ,[LastUpdatedBy]
                FROM [Farm].[FarmTermAppAdminContacts] 
                WHERE [ApplicationId] = @p_ApplicationId;"
       ;

    public GetTermAppAdminContactsSqlCommand() { }
    public override string ToString()
    {
        return _sqlCommand;
    }
}
