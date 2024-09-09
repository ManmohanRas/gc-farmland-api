namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateEsmtAppExistUsesSqlCommand
{

    private readonly string _sqlCommand = @"
      UPDATE [FARM].[FARMESMTEXISTNONAGRIUSES] 
       SET                         
                IsSubdivisionApprovals      =      @p_IsSubdivisionApprovals,   
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
