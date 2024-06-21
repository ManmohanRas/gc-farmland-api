namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateApplicationStatusLogSqlCommand
{
    private readonly string _sqlCommand =
            @"  

                INSERT INTO [Farm].[FarmApplicationStatusLog]
			    (
                    [ApplicationId],
                    [StatusId],
                    [StatusDate],
                    [Notes],
                    [LastUpdatedBy],
                    [LastUpdatedOn]
			    )
                VALUES
                    (
                    @p_ApplicationId,
                    @p_StatusId,
                    @p_StatusDate,
                    @p_Notes,
                    @p_LastUpdatedBy,
                    GetDate()
                );";

    public CreateApplicationStatusLogSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
