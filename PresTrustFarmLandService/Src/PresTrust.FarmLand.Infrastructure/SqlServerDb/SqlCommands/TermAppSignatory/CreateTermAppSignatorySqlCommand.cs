namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class CreateTermAppSignatorySqlCommand
{
    private readonly string _sqlCommand =
                 @"INSERT INTO [Farm].[FarmTermAppSignature]
						(
							 ApplicationId
							,Designation
							,Title	
							,SignedOn
							,LastUpdatedBy  
							,LastUpdatedOn	
						)

						VALUES
						(
							 @p_ApplicationId
							,@p_Designation
							,@p_Title	
							,@p_SignedOn
							,@p_LastUpdatedBy  
							,GETDATE()	
						);

				  SELECT CAST( SCOPE_IDENTITY() AS INT);";


    public CreateTermAppSignatorySqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
