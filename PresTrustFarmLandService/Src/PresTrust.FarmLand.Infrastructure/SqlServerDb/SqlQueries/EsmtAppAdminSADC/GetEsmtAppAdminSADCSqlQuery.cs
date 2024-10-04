namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetEsmtAppAdminSADCSqlQuery
{
    private readonly string _sqlCommand =
         @" SELECT
              [Id]
             ,[ApplicationId]
             ,[ProgramName]
             ,[SADCFundingRoundYear]
             ,[SADCQualityScore]
             ,[SADCPrelimRank]
             ,[SADCFinalRank]
             ,[SADCFinalScore]
             ,[LastUpdatedBy]
             ,[LastUpdatedOn]
            FROM [Farm].[FarmEsmtAppAdminSADC] WHERE ApplicationId = @p_ApplicationId";

    public GetEsmtAppAdminSADCSqlQuery()
    { }


    public override string ToString()
    {
        return _sqlCommand;
    }
}
