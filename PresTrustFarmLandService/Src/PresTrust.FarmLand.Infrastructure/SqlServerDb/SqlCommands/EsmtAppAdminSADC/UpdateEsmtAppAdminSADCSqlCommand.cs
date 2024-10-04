namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateEsmtAppAdminSADCSqlCommand
{
    private readonly string _sqlCommand =
         @" UPDATE [Farm].[FarmEsmtAppAdminSADC]
            SET  ApplicationId        =   @p_ApplicationId
                ,ProgramName          =   @p_ProgramName
                ,SADCFundingRoundYear =   @p_SADCFundingRoundYear
                ,SADCQualityScore     =   @p_SADCQualityScore
                ,SADCPrelimRank       =   @p_SADCPrelimRank
                ,SADCFinalRank        =   @p_SADCFinalRank
                ,SADCFinalScore       =   @p_SADCFinalScore
                ,LastUpdatedBy        =   @p_LastUpdatedBy  
                ,LastUpdatedOn        =   @p_LastUpdatedOn
             WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";
    
    public UpdateEsmtAppAdminSADCSqlCommand()
    { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}