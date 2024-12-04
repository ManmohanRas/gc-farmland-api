namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetFarmReSaleSqlQuery
{
    private readonly string _sqlCommand =
        @"  SELECT  Id
                   ,FarmNumber
                   ,ReSellDate
                   ,ReSellPriceTotal
                   ,ReSellPricePerAcre
                   ,ReSellNotes
                   ,CurrentDeedBook
                   ,CurrentDeedPage
                   ,CurrentDeedFiled
                   ,InterestedinSelling
				   ,LastUpdatedBy  
				   ,LastUpdatedOn	
            FROM [Farm].[FarmReSaleDetails]
           ";


    public GetFarmReSaleSqlQuery()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
