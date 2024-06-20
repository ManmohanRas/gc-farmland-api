namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateTermFeedbackSqlCommand
{
 
    private readonly string _sqlCommand =
       @"INSERT INTO [Farm].[FarmTermFeedback]
                   ([ApplicationId]
                   ,[SectionId]
                   ,[Feedback]
                   ,[RequestForCorrection]
                   ,[CorrectionStatus]
                   ,[MarkRead]
                   ,[LastUpdatedBy]
                   ,[LastUpdatedOn])
             VALUES
                   (@p_ApplicationId
                   ,@p_SectionId
                   ,@p_Feedback
                   ,@p_RequestForCorrection
                   ,@p_CorrectionStatus
                   ,@p_MarkRead
                   ,@p_LastUpdatedBy
                   ,GETDATE());

           SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateTermFeedbackSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
