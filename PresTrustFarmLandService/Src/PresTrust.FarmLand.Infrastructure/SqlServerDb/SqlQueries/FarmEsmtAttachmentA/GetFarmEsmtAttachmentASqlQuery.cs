namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmEsmtAttachmentASqlQuery
{
    private readonly string _sqlCommand =
       @" SELECT            [Id]
                            ,[ApplicationId]
                            ,[IsOfferPriceIndicated]
                            ,[OfferPriceOpinion]
                            ,[AvaragePerAcre]
                            ,[OfferPriceComments]
                            ,[LastUpdatedBy]  
			                ,[LastUpdatedOn]
                 FROM [FARM].[FarmEsmtAttachmentA] WHERE ApplicationId = @p_ApplicationId";

    public GetFarmEsmtAttachmentASqlQuery()
    { }


    public override string ToString()
    {
        return _sqlCommand;
    }
}
