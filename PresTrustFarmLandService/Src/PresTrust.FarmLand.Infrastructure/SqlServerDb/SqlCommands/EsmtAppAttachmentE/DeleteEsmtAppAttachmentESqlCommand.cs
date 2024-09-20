namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class DeleteEsmtAppAttachmentESqlCommand
{
    private readonly string _SqlCommand = @"DELETE
                                                 FROM [Farm].[FarmEsmtAppAttachmentE] 
                                                 WHERE  Id = @p_Id AND  ApplicationId = @p_ApplicationId";
   public DeleteEsmtAppAttachmentESqlCommand() { }

    public override string ToString()
    {
        return _SqlCommand;
    }

}
