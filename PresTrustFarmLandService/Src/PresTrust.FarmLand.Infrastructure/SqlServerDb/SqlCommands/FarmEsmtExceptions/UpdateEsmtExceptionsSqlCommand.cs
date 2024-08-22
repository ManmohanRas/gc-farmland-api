namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateEsmtExceptionsSqlCommand
{
    private readonly string _sqlCommand =
        @" UPDATE [FARM].[FARMESMTAPPEXCEPTIONS]
                SET ApplicationId                 = @p_ApplicationId
                    ,ExpectedTaxLots              = @p_ExpectedTaxLots
                    ,ExceptionNonServable         = @p_ExceptionNonServable
                    ,ExceptionTotalNonServable    = @P_ExceptionTotalNonServable
                    ,ExceptionServable            = @p_ExceptionServable
                    ,ExceptionTotalServable       = @p_ExceptionTotalServable
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
