namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateTermAppAdminDeedDetailsSqlCommand
{
    private readonly string _sqlCommand =
     @"INSERT INTO [Farm].[FarmTermAppDeedDetails]
              (
                 ApplicationId
                ,ParcelId
	            ,OriginalBlock				
	            ,OriginalLot					
	            ,OriginalBook				
	            ,OriginalPage					
                ,NOTBlock						
                ,NOTLot						
                ,NOTBook						
                ,NOTPage						
                ,RDBlock						
                ,RDLot							
                ,RDBook						
                ,RDPage	
                ,IsChecked
                ,LastUpdatedBy
                ,LastUpdatedOn
              )
              VALUES(
                @p_ApplicationId
               ,@p_ParcelId
               ,@p_OriginalBlock				
               ,@p_OriginalLot					
               ,@p_OriginalBook				
               ,@p_OriginalPage					
               ,@p_NOTBlock						
               ,@p_NOTLot						
               ,@p_NOTBook						
               ,@p_NOTPage						
               ,@p_RDBlock						
               ,@p_RDLot							
               ,@p_RDBook						
               ,@p_RDPage	
               ,@p_IsChecked
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
