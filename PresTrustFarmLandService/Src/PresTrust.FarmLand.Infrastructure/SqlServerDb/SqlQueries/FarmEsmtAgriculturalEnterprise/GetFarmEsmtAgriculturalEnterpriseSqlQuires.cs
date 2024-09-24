namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmEsmtAgriculturalEnterpriseSqlQuires
{
    private readonly string _sqlCommand =
        @"  SELECT   Id
                    ,ApplicationId
                    ,AverageGrossReceipts
                    ,IsFullTimeFarmer
                    ,HasSoilConservationPlan
                    ,PlanDate
                    ,ConservationPractices
                    ,AgriculturalInvestments
                    ,LastUpdatedBy
                    ,LastUpdatedOn
            FROM [Farm].[FarmEsmtAgriculturalAndProduction]
            WHERE ApplicationId = @p_ApplicationId";


    public GetFarmEsmtAgriculturalEnterpriseSqlQuires()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
