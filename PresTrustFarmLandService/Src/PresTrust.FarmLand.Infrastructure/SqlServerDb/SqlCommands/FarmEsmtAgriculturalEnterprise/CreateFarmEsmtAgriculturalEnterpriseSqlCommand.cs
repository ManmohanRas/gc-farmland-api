namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateFarmEsmtAgriculturalEnterpriseSqlCommand
{
    private readonly string _sqlCommand =
                @"INSERT INTO [Farm].[FarmEsmtAgriculturalAndProduction]
						(
							 ApplicationId
                            ,AverageGrossReceipts
                            ,IsFullTimeFarmer
                            ,HasSoilConservationPlan
                            ,PlanDate
                            ,ConservationPractices
                            ,AgriculturalInvestments
							,LastUpdatedBy  
							,LastUpdatedOn	
						)

						VALUES
						(
							 @p_ApplicationId
                            ,@p_AverageGrossReceipts
                            ,@p_IsFullTimeFarmer
                            ,@p_HasSoilConservationPlan
                            ,@p_PlanDate
                            ,@p_ConservationPractices
                            ,@p_AgriculturalInvestments
							,@p_LastUpdatedBy  
							,GETDATE()	
						);

				  SELECT CAST( SCOPE_IDENTITY() AS INT);";


    public CreateFarmEsmtAgriculturalEnterpriseSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
