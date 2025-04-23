namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class DeleteTermAppDeedLocationSqlCommand
{
    private readonly string _sqlCommand = @"
                DELETE [Farm].[FarmTermAppDeedLocation]          
            WHERE	ApplicationId = @p_ApplicationId AND ParcelId = @p_ParcelId;";

    public DeleteTermAppDeedLocationSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
