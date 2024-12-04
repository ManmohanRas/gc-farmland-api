namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class DeleteFarmReSaleSqlCommand
{
    private readonly string _sqlCommand =
        @" DELETE
            FROM  [Farm].[FarmReSaleDetails]
            WHERE Id = @p_Id;";

    public DeleteFarmReSaleSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
