namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateEsmtExceptionsSqlCommand
{
    private readonly string _sqlCommand =
        @" UPDATE [FARM].[FARMESMTAPPEXCEPTIONS]
                SET ApplicationId                 = @p_ApplicationId
                    ,ExpectedTaxLots              = @p_ExpectedTaxLots
                    ,ExceptionNonSeverable        = @p_ExceptionNonSeverable
                    ,ExceptionTotalNonSeverable   = @p_ExceptionTotalNonSeverable
                    ,ExceptionSeverable           = @p_ExceptionSeverable
                    ,ExceptionTotalSeverable      = @p_ExceptionTotalSeverable
                    ,Acres                        = @p_Acres
                    ,LastUpdatedBy                = @p_LastUpdatedBy
                    ,LastUpdatedOn                 = @p_LastUpdatedOn
             WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;"; 

    public UpdateEsmtExceptionsSqlCommand()
    {

    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
