namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries
{
    public class GetFarmSadcAppEligibilitySqlQuery
    {
        private readonly string _sqlCommand =
       @"  SELECT         Id 
                         ,ApplicationId
                         ,ProjectAreaAppEl
                         ,RankScore
                         ,RankPoints
                         ,SoilPercentage
                         ,IsLandsLessThan10Ac
                         ,IsLandsGreaterThan10Ac
                         ,Is75PercentTillable
                         ,Percent75Tillable1
                         ,Acre75Tillable
                         ,Is75PercentLand
                         ,Percent75Land
                         ,Acre75Land
                         ,Is50PercentTillable
                         ,Percent50Tillable
                         ,Acre50Tillable
                         ,Is50PercentLand
                         ,Percent50Land
                         ,Acre50Land
                         ,LastUpdatedBy
                         ,LastUpdatedOn
            FROM [Farm].[FarmEsmtSadcEligibility] WHERE ApplicationId = @p_ApplicationId";

        public GetFarmSadcAppEligibilitySqlQuery()
        {
        }

        public override string ToString()
        {
            return _sqlCommand;
        }
    }
}