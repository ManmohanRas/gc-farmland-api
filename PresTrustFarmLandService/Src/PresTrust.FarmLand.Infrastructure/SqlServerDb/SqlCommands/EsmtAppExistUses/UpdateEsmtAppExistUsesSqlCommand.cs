namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateEsmtAppExistUsesSqlCommand
{

    private readonly string _sqlCommand = @"
      UPDATE [Farm].[FarmEsmtExistNonAgriUses] 
       SET                         
                IsSubdivisionApproval      =      @p_IsSubdivisionApproval,   
                InfoAboutPremises           =      @p_InfoAboutPremises,      
                LastUpdatedBy		          =      @p_LastUpdatedBy,
                LastUpdatedOn               =      @p_LastUpdatedOn
            
      WHERE  Id = @p_Id AND  ApplicationId = @p_ApplicationId ;";

    public UpdateEsmtAppExistUsesSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }

}
