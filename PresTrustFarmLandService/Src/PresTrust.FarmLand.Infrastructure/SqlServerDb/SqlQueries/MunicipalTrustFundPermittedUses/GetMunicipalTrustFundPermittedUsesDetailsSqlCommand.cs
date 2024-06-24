namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetMunicipalTrustFundPermittedUsesDetailsSqlCommand
{
    private readonly string _sqlCommand =
        @"SELECT [Id]
                      ,[AgencyId]
                      ,[YearOfInception]
                      ,[AcquisitionOfLands]
                      ,[AcquisitionOfFarmLands]
                      ,[DevelopmentOfLands]
                      ,[MaintenanceOfLands]
                      ,[SalariesAndBenefits]
                      ,[BondDownPayments]
                      ,[HistoricPreservation]
                      ,[OpenspaceMasterPlan]
                      ,[OpenspaceMasterPlanDate]
                      ,[GreenAcresGrant]
                      ,[Other]
                      ,[TrustFundComments]
             FROM   [Farm].[FarmMunicipalTrustFundPermittedUses]
             WHERE	AgencyId = @p_AgencyId;";


    public GetMunicipalTrustFundPermittedUsesDetailsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
