namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class DeleteFarmBlockLotSqlCommand
{
    private readonly string _sqlCommand =
        @" DELETE
            FROM  [Farm].[FarmMunicipalityBlockLotParcel]
            WHERE Id = @p_Id;";

    public DeleteFarmBlockLotSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
