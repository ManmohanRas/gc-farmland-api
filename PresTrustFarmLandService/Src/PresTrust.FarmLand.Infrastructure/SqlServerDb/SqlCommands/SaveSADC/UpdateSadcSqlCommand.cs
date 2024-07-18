namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateSadcSqlCommand
{
    private readonly string _sqlCommand =
          @" UPDATE [Farm].[FarmApplication]
               SET
                        [IsSadc] = 1,
               WHERE    [Id] = @p_Id;";

    public UpdateSadcSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
