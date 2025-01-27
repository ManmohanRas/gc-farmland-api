
namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class DeleteTermAppAdminContactsSqlCommand
{
    private readonly string _sqlCommand =
   @" DELETE 
              FROM [Farm].[FarmAppAdminContact]
              WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

 public DeleteTermAppAdminContactsSqlCommand() { }
    public override string ToString()
    {
        return _sqlCommand;
    }
}
