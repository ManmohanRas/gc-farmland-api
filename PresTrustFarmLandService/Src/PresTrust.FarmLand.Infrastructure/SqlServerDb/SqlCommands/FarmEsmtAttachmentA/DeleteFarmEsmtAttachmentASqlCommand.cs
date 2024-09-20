namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class DeleteFarmEsmtAttachmentASqlCommand
{
    private readonly string _sqlCommand =
        @" DELETE 
              FROM [Farm].[FarmEsmtAttachmentA]
              WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

    public DeleteFarmEsmtAttachmentASqlCommand()
    { }


    public override string ToString()
    {
        return _sqlCommand;
    }
}
