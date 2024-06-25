namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class RequestForApplicationCorrectionSqlCommand
{
    private readonly string _sqlCommand =
        @"    UPDATE	    [Farm].[FarmApplicationFeedback]
                SET			[CorrectionStatus] = @p_CorrectionStatus,
			                [LastUpdatedOn] = GETDATE()
                WHERE	    [ApplicationId] = @p_ApplicationId 
                               AND ISNULL([RequestForCorrection],0) = 1 
                               AND ISNULL([CorrectionStatus], '') = 'PENDING';";

    public RequestForApplicationCorrectionSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
