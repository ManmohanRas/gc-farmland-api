namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;
public class GetEsmtAppAdminOfferCostsSqlCommand
{

    private readonly string _sqlCommand =
      @" SELECT    
                     [Id],
                     [ApplicationId],
                     [CadbLandOwnerOffer],
                     [IsOfferAccepted],
                     [TotalCostPerAcre],
                     [TotalCost],
                     [MCCostSharePct],
                     [McCountyCostShareTotal],
                     [SADCCostSharePct],
                     [SADCCostShareTotal],
                     [OtherCostShareTotal],
                     [OtherSource],
                     [CostNote],
                     [LastUpdatedBy],
                     [LastUpdatedOn]
                  FROM [Farm].[FarmEsmtAppAdminOfferCost] WHERE ApplicationId = @p_ApplicationId";

   
	

    public GetEsmtAppAdminOfferCostsSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
