namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateFarmReSaleSqlCommand
{
    private readonly string _sqlCommand =
             @"INSERT INTO [Farm].[FarmReSaleDetails]
						(
                                FarmNumber
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
                        )
                        VALUES
                        (
                                @p_FarmNumber
                               ,@p_ReSellDate
                               ,@p_ReSellPriceTotal
                               ,@p_ReSellPricePerAcre
                               ,@p_ReSellNotes
                               ,@p_CurrentDeedBook
                               ,@p_CurrentDeedPage
                               ,@p_CurrentDeedFiled
                               ,@p_InterestedinSelling
                               ,@p_LastUpdatedBy
                               ,GETDATE()	
                        );
                        SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateFarmReSaleSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }

}
