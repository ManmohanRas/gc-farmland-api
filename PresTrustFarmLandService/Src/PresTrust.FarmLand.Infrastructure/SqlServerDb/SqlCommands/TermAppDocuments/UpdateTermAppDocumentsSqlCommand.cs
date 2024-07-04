namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateTermAppDocumentsSqlCommand
{
    private readonly string _sqlCommand =
          @" UPDATE [Farm].[FarmApplicationDocument]
				SET  [Title] = @p_Title
					,[Description] = @p_Description
					,[UseInReport] = @p_UseInReport
					,[HardCopy] = @p_HardCopy
					,[Approved] = @p_Approved
					,[ReviewComment] = @p_ReviewComment
					,[ShowCommittee] = @p_ShowCommittee
					,[LastUpdatedOn] = GETDATE()
					,[LastUpdatedBy] = @p_LastUpdatedBy
					
				WHERE Id = @p_Id;";
    public UpdateTermAppDocumentsSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}

