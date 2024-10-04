namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateEsmtAppAdminSADCSqlCommand
{
    private readonly string _sqlCommand =
        @"INSERT INTO [Farm].[FarmEsmtAppAdminSADC]
            (
                ApplicationId
               ,ProgramName
               ,SADCFundingRoundYear
               ,SADCQualityScore
               ,SADCPrelimRank
               ,SADCFinalRank
               ,SADCFinalScore
               ,LastUpdatedBy  
			   ,LastUpdatedOn
            )
            
                VALUES
            (
                 @p_ApplicationId
                ,@p_ProgramName
                ,@p_SADCFundingRoundYear
                ,@p_SADCQualityScore
                ,@p_SADCPrelimRank
                ,@p_SADCFinalRank
                ,@p_SADCFinalScore
                ,@p_LastUpdatedBy  
                ,GetDate()
            );

                SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateEsmtAppAdminSADCSqlCommand()
    { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
