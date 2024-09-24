namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateEsmtExceptionsSqlCommand
{
    private readonly string _sqlCommand =
        @"INSERT INTO [FARM].[FARMESMTAPPEXCEPTIONS]
            (
               ApplicationId
               ,ExpectedTaxLots
               ,ExceptionNonSeverable
               ,ExceptionTotalNonSeverable
               ,ExceptionSeverable
               ,ExceptionTotalSeverable
               ,Acres
               ,LastUpdatedBy  
			   ,LastUpdatedOn
            )
                
              VALUES
                (
                    @p_ApplicationId					
                    ,@p_ExpectedTaxLots				
                    ,@p_ExceptionNonSeverable			
                    ,@p_ExceptionTotalNonSeverable		
                    ,@p_ExceptionSeverable				
                    ,@p_ExceptionTotalSeverable		
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