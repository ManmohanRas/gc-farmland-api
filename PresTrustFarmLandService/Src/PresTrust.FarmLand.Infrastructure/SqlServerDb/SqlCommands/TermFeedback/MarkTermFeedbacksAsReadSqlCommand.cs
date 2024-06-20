namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class MarkTermFeedbacksAsReadSqlCommand
{
    private readonly string _sqlCommand =
       @"UPDATE		       [Farm].[FarmTermFeedback]
             SET			   [MarkRead] = 1
             WHERE		       Id IN @p_FeedbackIds;";

    public MarkTermFeedbacksAsReadSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
