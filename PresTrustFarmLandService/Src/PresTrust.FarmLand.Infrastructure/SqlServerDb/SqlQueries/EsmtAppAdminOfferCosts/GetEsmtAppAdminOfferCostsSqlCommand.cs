namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;
public class GetEsmtAppAdminOfferCostsSqlCommand
{

    private readonly string _sqlCommand =
      @" SELECT    
                     [Id],
                     [ApplicationId],
                     [CadbLandOwnerOffer],
                     [IsOfferAccepted],
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
