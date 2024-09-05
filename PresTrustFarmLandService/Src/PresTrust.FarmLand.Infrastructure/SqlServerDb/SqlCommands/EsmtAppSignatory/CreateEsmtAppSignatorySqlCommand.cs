namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateEsmtAppSignatorySqlCommand
{
    private readonly string _sqlCommand =
                 @"INSERT INTO [Farm].[FarmEsmtAppSignatory]
						(
							 ApplicationId
                            ,AmountPerAcre
							,Designation
							,Title	
							,SignedOn
							,LastUpdatedBy  
							,LastUpdatedOn	
						)

						VALUES
						(
							 @p_ApplicationId
                            ,@p_AmountPerAcre
							,@p_Designation
							,@p_Title	
							,@p_SignedOn
							,@p_LastUpdatedBy  
							,GETDATE()	
						);

				  SELECT CAST( SCOPE_IDENTITY() AS INT);";


    public CreateEsmtAppSignatorySqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
