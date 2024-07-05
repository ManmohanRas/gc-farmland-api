namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class UpdateTermAppSignatorySqlCommand
{
    private readonly string _sqlCommand =
      @" UPDATE [Farm].[FarmTermAppSignature]
               SET  ApplicationId = @p_ApplicationId
                   ,Designation   = @p_Designation
                   ,Title         = @p_Title
                   ,SignedOn      = @p_SignedOn
                   ,LastUpdatedBy = @p_LastUpdatedBy
                   ,LastUpdatedOn = @p_LastUpdatedOn
             WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId";

    public UpdateTermAppSignatorySqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}

