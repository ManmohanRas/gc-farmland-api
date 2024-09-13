namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class DeleteEsmtAppAttachmentCSqlCommand
{
    private readonly string  _sqlCommand = @"DELETE 
                                                  FROM [Farm].[FarmEsmtAttachmentC]
                                                  WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";
     

    public DeleteEsmtAppAttachmentCSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
