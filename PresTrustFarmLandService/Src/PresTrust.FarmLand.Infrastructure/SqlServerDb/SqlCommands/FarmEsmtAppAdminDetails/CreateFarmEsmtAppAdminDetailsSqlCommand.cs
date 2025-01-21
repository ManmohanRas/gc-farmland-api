namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateFarmEsmtAppAdminDetailsSqlCommand
{
    private readonly string _sqlCommand =
                 @"INSERT INTO [Farm].[FarmEsmtAppAdminDetails]
						(
                             [ApplicationId]
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
                            ,[OriginalDeed]
                            ,[OriginalPage]
                            ,[SmallOrLargeSign]
                            ,[Year]
                            ,[LastUpdatedBy] 
							,[LastUpdatedOn]
						)

						VALUES
						(
							 @p_ApplicationId
							,@p_FarmerName
                            ,@p_FarmerPhone
                            ,@p_FarmerContactInfo
                            ,@p_FarmFeatures
                            ,@p_AgreestoHaveSign
                            ,@p_ConsPlanDate
                            ,@p_ConsPlanComment
                            ,@p_DroppedProjectWhy
                            ,@p_ImperviousPercentage
                            ,@p_ImperviousSurfaceAcreage
                            ,@p_InterestedinSADCSign
                            ,@p_IsConservationPlan
                            ,@p_PossibleClosingDate
                            ,@p_PreservedOrder
                            ,@p_SADCSignLocation
                            ,@p_StaffComments
                            ,@p_ZoningJan12004
                            ,@p_RFPIsAppraisal
                            ,@p_RFPIsSurvey
                            ,@p_RFPIsWetlands
                            ,@p_CADBAppYear
                            ,@p_ProjectYear
                            ,@p_OriginalDeed
                            ,@p_OriginalPage
                            ,@p_SmallOrLargeSign
                            ,@p_Year
							,@p_LastUpdatedBy  
							,GETDATE()	
						);

				  SELECT CAST( SCOPE_IDENTITY() AS INT);";


    public CreateFarmEsmtAppAdminDetailsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
