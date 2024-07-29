namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateTermFeedbackSqlCommand
{
    private readonly string _sqlCommand =
     @"UPDATE		       [Farm].[FarmApplicationFeedback]
             SET			   [Feedback] = @p_Feedback
			                  ,[RequestForCorrection] = @p_RequestForCorrection
                              ,[SectionId] = @p_SectionId
			                  ,[LastUpdatedBy] = @p_LastUpdatedBy
			                  ,[LastUpdatedOn] = GETDATE()
             WHERE		       Id = @p_Id AND ApplicationId = @p_ApplicationId;";

    public UpdateTermFeedbackSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
