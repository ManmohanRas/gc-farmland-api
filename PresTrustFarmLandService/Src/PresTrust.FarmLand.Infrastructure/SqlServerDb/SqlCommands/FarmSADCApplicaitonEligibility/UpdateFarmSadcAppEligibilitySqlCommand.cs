namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands
{
    public class UpdateFarmSadcAppEligibilitySqlCommand
    {
        private readonly string _sqlCommand =
            @" UPDATE [Farm].[FarmEsmtSadcEligibility]
                SET 
                     ApplicationId          = @p_ApplicationId
                    ,ProjectAreaAppEl       = @p_ProjectAreaAppEl
                    ,RankScore              = @p_RankScore
                    ,RankPoints             = @p_RankPoints
                    ,SoilPercentage         = @p_SoilPercentage
                    ,IsLandsLessThan10Ac    = @p_IsLandsLessThan10Ac
                    ,IsLandsGreaterThan10Ac = @p_IsLandsGreaterThan10Ac
                    ,Is75PercentTillable    = @p_Is75PercentTillable
                    ,Percent75Tillable1     = @p_Percent75Tillable1
                    ,Acre75Tillable         = @p_Acre75Tillable
                    ,Is75PercentLand        = @p_Is75PercentLand
                    ,Percent75Land          = @p_Percent75Land
                    ,Acre75Land             = @p_Acre75Land
                    ,Is50PercentTillable    = @p_Is50PercentTillable
                    ,Percent50Tillable      = @p_Percent50Tillable
                    ,Acre50Tillable         = @p_Acre50Tillable
                    ,Is50PercentLand        = @p_Is50PercentLand
                    ,Percent50Land          = @p_Percent50Land
                    ,Acre50Land             = @p_Acre50Land
                    ,LastUpdatedBy          = @p_LastUpdatedBy
                    ,LastUpdatedOn          = @p_LastUpdatedOn
             WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

        public UpdateFarmSadcAppEligibilitySqlCommand()
        {

        }

        public override string ToString()
        {
            return _sqlCommand;
        }
    }
}
