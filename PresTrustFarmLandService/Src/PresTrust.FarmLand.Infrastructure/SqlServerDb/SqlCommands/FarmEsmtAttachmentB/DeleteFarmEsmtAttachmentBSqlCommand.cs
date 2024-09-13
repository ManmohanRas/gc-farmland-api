namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class DeleteFarmEsmtAttachmentBSqlCommand
{
    private readonly string _sqlCommand =
        @" DELETE 
              FROM [Farm].[FarmEsmtExceptionsAttachmentB]
              WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

    public DeleteFarmEsmtAttachmentBSqlCommand()
    { }


    public override string ToString()
    {
        return _sqlCommand;
    }

}
