namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateFarmReSaleSqlCommand
{
    private readonly string _sqlCommand =
 @" UPDATE [Farm].[FarmReSaleDetails]
            SET              FarmNumber           = @p_FarmNumber
                            ,ReSellDate           = @p_ReSellDate         
                            ,ReSellPriceTotal     = @p_ReSellPriceTotal   
                            ,ReSellPricePerAcre   = @p_ReSellPricePerAcre 
                            ,ReSellNotes          = @p_ReSellNotes        
                            ,CurrentDeedBook      = @p_CurrentDeedBook    
                            ,CurrentDeedPage      = @p_CurrentDeedPage    
                            ,CurrentDeedFiled     = @p_CurrentDeedFiled   
                            ,InterestedinSelling  = @p_InterestedinSelling
                            ,LastUpdatedBy        = @p_LastUpdatedBy
                            ,LastUpdatedOn        = @p_LastUpdatedOn
                            WHERE Id = @p_Id;";

    public UpdateFarmReSaleSqlCommand()
    { }


    public override string ToString()
    {
        return _sqlCommand;
    }
}
