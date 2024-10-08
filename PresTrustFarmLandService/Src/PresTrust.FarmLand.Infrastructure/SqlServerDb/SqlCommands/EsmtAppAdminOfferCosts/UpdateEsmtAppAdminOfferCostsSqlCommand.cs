
namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class UpdateEsmtAppAdminOfferCostsSqlCommand
{
    private readonly string _sqlCommand =
        @" UPDATE [Farm].[FarmEsmtAppAdminOfferCost]
                  
               SET                        ApplicationId         =  @p_ApplicationId,
                                          CadbLandOwnerOffer    =  @p_CadbLandOwnerOffer,
                                          IsOfferAccepted       =  @p_IsOfferAccepted,
                                          TotalCostPerAcre      =  @p_TotalCostPerAcre,
                                          TotalCost             =  @p_TotalCost,
                                          MCCostSharePct        =  @p_MCCostSharePct,
                                          McCountyCostShareTotal=  @p_McCountyCostShareTotal,
                                          SADCCostSharePct      =  @p_SADCCostSharePct,
                                          SADCCostShareTotal    =  @p_SADCCostShareTotal,
                                          OtherCostShareTotal   =  @p_OtherCostShareTotal,
                                          OtherSource           =  @p_OtherSource,
                                          CostNote              =  @p_CostNote,
                                          LastUpdatedBy         =  @p_LastUpdatedBy,
                                          LastUpdatedOn         =  @p_LastUpdatedOn

                      WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

    public UpdateEsmtAppAdminOfferCostsSqlCommand() { }
    public override string ToString()
    {
        return _sqlCommand;
    }

}
