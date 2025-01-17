namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateFarmEsmtAppAdminDetailsSqlCommand
{
    private readonly string _sqlCommand =
      @" UPDATE [Farm].[FarmEsmtAppAdminDetails]
                        SET  ApplicationId             = @p_ApplicationId
                            ,FarmerName                = @p_FarmerName
                            ,FarmerPhone               = @p_FarmerPhone
                            ,FarmerContactInfo         = @p_FarmerContactInfo
                            ,FarmFeatures              = @p_FarmFeatures
                            ,AgreestoHaveSign          = @p_AgreestoHaveSign
                            ,ConsPlanDate              = @p_ConsPlanDate
                            ,ConsPlanComment           = @p_ConsPlanComment
                            ,DroppedProjectWhy         = @p_DroppedProjectWhy
                            ,ImperviousPercentage      = @p_ImperviousPercentage
                            ,ImperviousSurfaceAcreage  = @p_ImperviousSurfaceAcreage
                            ,InterestedinSADCSign      = @p_InterestedinSADCSign
                            ,IsConservationPlan        = @p_IsConservationPlan
                            ,PossibleClosingDate       = @p_PossibleClosingDate
                            ,PreservedOrder            = @p_PreservedOrder
                            ,SADCSignLocation          = @p_SADCSignLocation
                            ,StaffComments             = @p_StaffComments
                            ,ZoningJan12004            = @p_ZoningJan12004
                            ,RFPIsAppraisal            = @p_RFPIsAppraisal
                            ,RFPIsSurvey               = @p_RFPIsSurvey
                            ,RFPIsWetlands             = @p_RFPIsWetlands
                            ,CADBAppYear               = @p_CADBAppYear
                            ,ProjectYear               = @p_ProjectYear
                            ,OriginalDeed              = @p_OriginalDeed        
                            ,OriginalPage              = @p_OriginalPage
                            ,SmallOrLargeSign          = @p_SmallOrLargeSign
                            ,Year                      = @p_Year
                            ,LastUpdatedBy             = @p_LastUpdatedBy
                            ,LastUpdatedOn             = @p_LastUpdatedOn
                    WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId";

    public UpdateFarmEsmtAppAdminDetailsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
