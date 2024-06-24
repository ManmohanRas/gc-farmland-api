namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetTermFeedbacksSqlCommand
{
    private readonly string _sqlCommand =
       @"  SELECT		   [Id]
							  ,[ApplicationId]
							  ,[ApplicationTypeId]
							  ,[SectionId]
							  ,[Feedback]
							  ,[RequestForCorrection]
							  ,[CorrectionStatus]
							  ,[MarkRead]
							  ,[LastUpdatedBy]
							  ,[LastUpdatedOn]
				FROM		  [Farm].[FarmApplicationFeedback]
				WHERE		   ApplicationId = @p_ApplicationId
							   AND CorrectionStatus = CASE WHEN @p_CorrectionStatus = '' THEN CorrectionStatus ELSE @p_CorrectionStatus END;";

    public GetTermFeedbacksSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
