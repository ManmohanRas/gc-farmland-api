

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateTermAppAdminContactsSqlCommand
{
    private readonly string _sqlCommand =
      @"INSERT INTO [Farm].[FarmTermAppAdminContacts]
              (
                 ApplicationId
                ,ContactName
                ,Agency
                ,Email
                ,MainNumber
                ,AlternateNumber
                ,SelectContact
                ,LastUpdatedBy
                ,LastUpdatedOn
              )
              VALUES(
                @p_ApplicationId
               ,@p_ContactName
               ,@p_Agency
               ,@p_Email
               ,@p_MainNumber
               ,@p_AlternateNumber
               ,@p_SelContact
               ,@p_LastUpdatedBy
               ,GetDate());

			SELECT CAST( SCOPE_IDENTITY() AS INT);";


    public CreateTermAppAdminContactsSqlCommand()
    {

    }
    public override string ToString()
    {
        return _sqlCommand;
    }
}
