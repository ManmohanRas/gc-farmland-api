using System.Security.Cryptography.X509Certificates;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class CreateEsmtAppExistUsesSqlCommand
{

    private readonly string _sqlCommand = @"
    INSERT INTO [Farm].[FarmEsmtExistNonAgriUses]
    (                              
   ApplicationID,                  
   IsSubdivisionApproval,         
   InfoAboutPremises,                
   LastUpdatedBy,		   
   LastUpdatedOn
   )
    VALUES(
      
      @p_ApplicationID,
      @p_IsSubdivisionApproval,
      @p_InfoAboutPremises,
      @p_LastUpdatedBy,
      GETDATE()
      )
     SELECT CAST(SCOPE_IDENTITY() AS INT);";


    public CreateEsmtAppExistUsesSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
