using Microsoft.Data.SqlClient;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetTermAppAdminDeedDetailsSqlCommand
{
    private readonly string _sqlCommand =
       @"  SELECT [Id]   
                    ,[ApplicationId]
                    ,[OriginalBlock]
                    ,[OriginalLot]
                    ,[OriginalBook]
                    ,[OriginalPage]
                    ,[NOTBook]
                    ,[NOTPage]
                    ,[RDBook]
                    ,[RDPage]
                    ,[LastUpdatedBy]
                    ,[LastUpdatedOn]
                FROM [Farm].[[Farm].[FarmTermAppDeedDetails] 
                WHERE [ApplicationId] = @p_ApplicationId;"
       ;
   
    public GetTermAppAdminDeedDetailsSqlCommand()
    { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
