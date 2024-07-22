namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateParcelWarningSqlCommand
{
    private readonly string _sqlCommand =
         @"UPDATE [Farm].[FarmMunicipalityBlockLotParcel]
                       SET [IsWarning] = 0
                         WHERE Id = @p_Id;";

    public UpdateParcelWarningSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
