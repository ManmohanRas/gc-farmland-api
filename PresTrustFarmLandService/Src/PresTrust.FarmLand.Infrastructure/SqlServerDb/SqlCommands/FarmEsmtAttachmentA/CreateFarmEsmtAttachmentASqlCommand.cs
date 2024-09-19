namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateFarmEsmtAttachmentASqlCommand
{
    private readonly string _sqlCommand =
         @"INSERT INTO [FARM].[FarmEsmtAttachmentA]
            (
                             ApplicationId
                            ,IsOfferPriceIndicated
                            ,OfferPriceOpinion
                            ,AvaragePerAcre
                            ,OfferPriceComments
                            ,LastUpdatedBy  
			                ,LastUpdatedOn
             )
                VALUES
                    (
                             @p_ApplicationId
                            ,@p_IsOfferPriceIndicated
                            ,@p_OfferPriceOpinion
                            ,@p_AvaragePerAcre
                            ,@p_OfferPriceComments
                            ,@p_LastUpdatedBy  
			                ,GetDate()
                    );

            SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateFarmEsmtAttachmentASqlCommand()
    { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
