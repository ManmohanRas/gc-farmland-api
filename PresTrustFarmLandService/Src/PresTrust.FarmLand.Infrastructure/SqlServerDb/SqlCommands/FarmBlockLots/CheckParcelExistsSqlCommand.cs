namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CheckParcelExistsSqlCommand
{
    private readonly string _sqlCommand =
         @"SELECT COUNT(*) FROM [Farm].[FarmMunicipalityBlockLotParcel]
                         WHERE PamsPin = @p_PamsPin and FarmListID = @p_FarmListId;";

    public CheckParcelExistsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
