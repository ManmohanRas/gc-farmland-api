namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateFarmEsmtAgriculturalEnterpriseSqlCommand
{
    private readonly string _sqlCommand =
     @" UPDATE [Farm].[FarmEsmtAgriculturalAndProduction]
               SET  
                   AverageGrossReceipts  = @p_AverageGrossReceipts
                   ,IsFullTimeFarmer      = @p_IsFullTimeFarmer
                   ,HasSoilConservationPlan = @p_HasSoilConservationPlan
                   ,PlanDate                = @p_PlanDate
                   ,ConservationPractices   = @p_ConservationPractices
                   ,AgriculturalInvestments = @p_AgriculturalInvestments
                   ,LastUpdatedBy = @p_LastUpdatedBy
                   ,LastUpdatedOn = @p_LastUpdatedOn
             WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId";

    public UpdateFarmEsmtAgriculturalEnterpriseSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
