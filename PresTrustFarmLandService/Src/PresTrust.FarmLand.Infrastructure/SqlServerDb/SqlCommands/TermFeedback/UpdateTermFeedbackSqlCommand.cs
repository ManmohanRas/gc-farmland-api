namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateTermFeedbackSqlCommand
{
    private readonly string _sqlCommand =
     @"UPDATE		       [Farm].[FarmTermFeedback]
             SET			   [Feedback] = @p_Feedback
                              ,[ApplicationTypeId] = @p_ApplicationTypeId
			                  ,[RequestForCorrection] = @p_RequestForCorrection
			                  ,[LastUpdatedBy] = @p_LastUpdatedBy
			                  ,[LastUpdatedOn] = GETDATE()
             WHERE		       Id = @p_Id AND ApplicationId = @p_ApplicationId;";

    public UpdateTermFeedbackSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
