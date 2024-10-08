using System.Runtime.InteropServices;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class CreateEsmtAppAdminOfferCostsSqlCommand
{

    private readonly string _sqlCommand =
               @"INSERT INTO [Farm].[FarmEsmtAppAdminOfferCost]
                                    (
                                       ApplicationId,
                                       CadbLandOwnerOffer,
                                       IsOfferAccepted,
                                       TotalCostPerAcre,
                                       TotalCost,
                                       MCCostSharePct,
                                       McCountyCostShareTotal,
                                       SADCCostSharePct,
                                       SADCCostShareTotal,
                                       OtherCostShareTotal,
                                       OtherSource,
                                       CostNote,
                                       LastUpdatedBy,
                                       LastUpdatedOn
                                   )

                        VALUES(
                                @p_ApplicationId,
                                @p_CadbLandOwnerOffer,
                                @p_IsOfferAccepted,
                                @p_TotalCostPerAcre,
                                @p_TotalCost,
                                @p_MCCostSharePct,
                                @p_McCountyCostShareTotal,
                                @p_SADCCostSharePct,
                                @p_SADCCostShareTotal,
                                @p_OtherCostShareTotal,
                                @p_OtherSource,
                                @p_CostNote,
                                @p_LastUpdatedBy,
                                GetDate()
                              );
                                 SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateEsmtAppAdminOfferCostsSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
