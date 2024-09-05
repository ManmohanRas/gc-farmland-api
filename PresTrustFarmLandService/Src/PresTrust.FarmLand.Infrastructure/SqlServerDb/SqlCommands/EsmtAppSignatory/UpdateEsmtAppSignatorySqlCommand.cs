namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateEsmtAppSignatorySqlCommand
{
    private readonly string _sqlCommand =
      @" UPDATE [Farm].[FarmEsmtAppSignatory]
               SET  ApplicationId = @p_ApplicationId
                   ,AmountPerAcre = @p_AmountPerAcre
                   ,Designation   = @p_Designation
                   ,Title         = @p_Title
                   ,SignedOn      = @p_SignedOn
                   ,LastUpdatedBy = @p_LastUpdatedBy
                   ,LastUpdatedOn = @p_LastUpdatedOn
             WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId";

    public UpdateEsmtAppSignatorySqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
