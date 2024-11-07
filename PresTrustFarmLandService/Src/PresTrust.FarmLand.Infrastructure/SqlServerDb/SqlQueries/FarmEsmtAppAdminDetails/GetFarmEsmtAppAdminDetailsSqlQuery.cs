namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmEsmtAppAdminDetailsSqlQuery
{
    private readonly string _sqlCommand =
        @"       SELECT      [Id]
                            ,[ApplicationId]
                            ,[FarmerName]
                            ,[FarmerPhone]
                            ,[FarmerContactInfo]
                            ,[FarmFeatures]
                            ,[AgreestoHaveSign]
                            ,[ConsPlanDate]
                            ,[ConsPlanComment]
                            ,[DroppedProjectWhy]
                            ,[ImperviousPercentage]
                            ,[ImperviousSurfaceAcreage]
                            ,[InterestedinSADCSign]
                            ,[IsConservationPlan]
                            ,[PossibleClosingDate]
                            ,[PreservedOrder]
                            ,[SADCSignLocation]
                            ,[StaffComments]
                            ,[ZoningJan12004]
                            ,[RFPIsAppraisal]
                            ,[RFPIsSurvey]
                            ,[RFPIsWetlands]
                            ,[CADBAppYear]
                            ,[ProjectYear]
                            ,[ContactPerson]
                            ,[ContactPhone]
                            ,[ContactFax]
                            ,[LastUpdatedBy]
                            ,[LastUpdatedOn]
            FROM [Farm].[FarmEsmtAppAdminDetails]
            WHERE ApplicationId = @p_ApplicationId";


    public GetFarmEsmtAppAdminDetailsSqlQuery()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
