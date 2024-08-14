namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmEsmtExceptionsSqlQuery
{
    private readonly string _sqlCommand =
        @" SELECT 
            [Id]
           ,[ApplicationId]
           ,[ExpectedTaxLots]
           ,[ExceptionNonServable]
           ,[ExceptionTotalNonServable]
           ,[ExceptionServable]
           ,[ExceptionTotalServable]
           ,[Acres]
           ,[LastUpdatedBy]
           ,[LastUpdatedOn]
            FROM [FARM].[FARMESMTAPPEXCEPTIONS] WHERE ApplicationId = @p_ApplicationId";

    public GetFarmEsmtExceptionsSqlQuery()
    {

    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
