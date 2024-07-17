namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateTermAppAdminDeedDetailsSqlCommand
{
    private readonly string _sqlCommand =
     @"INSERT INTO [Farm].[FarmTermAppDeedDetails]
              (
                 ApplicationId
	            ,OriginalBlock				
	            ,OriginalLot					
	            ,OriginalBook				
	            ,OriginalPage					
	            ,NOTBook						
	            ,NOTPage						
	            ,RDBook						
	            ,RDPage						
                ,LastUpdatedBy
                ,LastUpdatedOn
              )
              VALUES(
                @p_ApplicationId
               ,@p_OriginalBlock				
               ,@p_OriginalLot					
               ,@p_OriginalBook				
               ,@p_OriginalPage					
               ,@p_NOTBook						
               ,@p_NOTPage		
               ,@p_RDBook						
               ,@p_RDPage						
               ,@p_LastUpdatedBy
               ,GetDate());

			SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateTermAppAdminDeedDetailsSqlCommand()
    {
        


    }
    public override string ToString()
    {
        return _sqlCommand;
    }
}
