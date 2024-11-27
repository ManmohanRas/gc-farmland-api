namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateFarmEsmtSadcHistorySqlCommand
{
        private readonly string _sqlCommand =
     @" UPDATE [Farm].[FarmEsmtSadcHistory]
            SET              ApplicationId          = @p_ApplicationId
                            ,SquareFootage          = @p_SquareFootage
                            ,PreliminaryExpiration  = @p_PreliminaryExpiration
                            ,FinalExpiration        = @p_FinalExpiration
                            ,EstateWill             = @p_EstateWill
                            ,TaxWaiver              = @p_TaxWaiver
                            ,NoWaiver               = @p_NoWaiver
                            ,TrustWill              = @p_TrustWill
                            ,TrustDocuments         = @p_TrustDocuments
                            ,LastUpdatedBy          = @p_LastUpdatedBy
                            ,LastUpdatedOn          = @p_LastUpdatedOn
                 WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

        public UpdateFarmEsmtSadcHistorySqlCommand()
        { }


        public override string ToString()
        {
            return _sqlCommand;
        }
}