namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateApplicationWorkflowStatusSqlCommand
{
    private readonly string _sqlCommand =
            @" UPDATE [Farm].[FarmApplication]
               SET
                        [StatusId] = @p_StatusId,
                        [LastUpdatedBy] = @p_LastUpdatedBy,
                        [LastUpdatedOn] = GetDate()
               WHERE    [Id] = @p_ApplicationId;";

    public UpdateApplicationWorkflowStatusSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
