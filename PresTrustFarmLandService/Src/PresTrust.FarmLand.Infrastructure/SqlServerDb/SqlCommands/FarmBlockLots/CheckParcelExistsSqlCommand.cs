namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CheckParcelExistsSqlCommand
{
    private readonly string _sqlCommand =
         @"SELECT COUNT(*) FROM [Farm].[FarmMunicipalityBlockLotParcel]
                         WHERE PamsPin = @p_PamsPin;";

    public CheckParcelExistsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
