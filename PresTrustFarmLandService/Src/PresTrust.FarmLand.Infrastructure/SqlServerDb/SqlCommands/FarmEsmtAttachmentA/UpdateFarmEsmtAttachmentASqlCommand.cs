namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateFarmEsmtAttachmentASqlCommand
{
    private readonly string _sqlCommand =
       @" UPDATE [FARM].[FarmEsmtAttachmentA]
            SET              ApplicationId                  =   @p_ApplicationId
                            ,IsOfferPriceIndicated          =   @p_IsOfferPriceIndicated
                            ,OfferPriceOpinion              =   @p_OfferPriceOpinion
                            ,AveragePerAcre                 =   @p_AveragePerAcre
                            ,OfferPriceComments             =   @p_OfferPriceComments
                            ,LastUpdatedBy                  =   @p_LastUpdatedBy  
			                ,LastUpdatedOn                  =   @p_LastUpdatedOn

             WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

    public UpdateFarmEsmtAttachmentASqlCommand()
    { }


    public override string ToString()
    {
        return _sqlCommand;
    }
}
