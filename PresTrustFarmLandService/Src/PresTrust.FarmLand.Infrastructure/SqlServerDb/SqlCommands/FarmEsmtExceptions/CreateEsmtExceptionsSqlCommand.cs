namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateEsmtExceptionsSqlCommand
{
    private readonly string _sqlCommand =
        @"INSERT INTO [FARM].[FARMESMTAPPEXCEPTIONS]
            (
               ApplicationId
               ,ExpectedTaxLots
               ,ExceptionNonServable
               ,ExceptionTotalNonServable
               ,ExceptionServable
               ,ExceptionTotalServable
               ,Acres
               ,LastUpdatedBy  
			   ,LastUpdatedOn
            )
                
              VALUES
                (
                    @p_ApplicationId					
                    ,@p_ExpectedTaxLots				
                    ,@p_ExceptionNonServable			
                    ,@p_ExceptionTotalNonServable		
                    ,@p_ExceptionServable				
                    ,@p_ExceptionTotalServable		
                    ,@p_Acres						    
                    ,@p_LastUpdatedBy					
					,GetDate()
                );

                SELECT CAST( SCOPE_IDENTITY() AS INT);";


    public CreateEsmtExceptionsSqlCommand()
    {
    }


    public override string ToString()
    {
        return _sqlCommand;
    }
}