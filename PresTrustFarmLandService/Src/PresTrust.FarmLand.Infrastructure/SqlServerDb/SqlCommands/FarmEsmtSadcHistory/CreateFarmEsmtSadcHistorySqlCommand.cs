namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class CreateFarmEsmtSadcHistorySqlCommand
{
        private readonly string _sqlCommand =
                 @"INSERT INTO [Farm].[FarmEsmtSadcHistory]
						(
                             ApplicationId
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
                        )
                        VALUES
                        (
                             @p_ApplicationId
                            ,@p_SquareFootage
                            ,@p_PreliminaryExpiration
                            ,@p_FinalExpiration
                            ,@p_EstateWill
                            ,@p_TaxWaiver
                            ,@p_NoWaiver
                            ,@p_TrustWill
                            ,@p_TrustDocuments
                            ,@p_LastUpdatedBy
                            ,GETDATE()	
                        );
                        SELECT CAST( SCOPE_IDENTITY() AS INT);";

        public CreateFarmEsmtSadcHistorySqlCommand()
        {
        }

        public override string ToString()
        {
            return _sqlCommand;
        }

}
