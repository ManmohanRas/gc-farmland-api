namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class DeleteAppLocationBlockLotSqlCommand
{
    private readonly string _sqlCommand =
          @" DELETE 
            FROM	[Farm].[FarmAppLocationDetails]
            WHERE	ApplicationId = @p_ApplicationId AND ParcelId = @p_ParcelId;";

    public DeleteAppLocationBlockLotSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
