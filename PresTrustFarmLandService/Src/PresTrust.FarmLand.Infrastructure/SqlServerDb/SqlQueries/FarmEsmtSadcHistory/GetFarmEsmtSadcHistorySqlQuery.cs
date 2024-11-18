namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmEsmtSadcHistorySqlQuery
{
        private readonly string _sqlCommand =
                            @"select
                                     Id
                                    ,ApplicationId
                                    ,SquareFootage
                                    ,PreliminaryExpiration
                                    ,FinalExpiration
                                    ,EstateWill
                                    ,TaxWaiver
                                    ,NoWaiver
                                    ,TrustWill
                                    ,TrustDocuments
                                    ,LastUpdatedBy
                                    ,LastUpdatedOn
                                     FROM  [Farm].[FarmEsmtSadcHistory]
                                     WHERE ApplicationId = @p_ApplicationId;";

        public GetFarmEsmtSadcHistorySqlQuery()
        { }

        public override string ToString()
        {
            return _sqlCommand;
        }
}
