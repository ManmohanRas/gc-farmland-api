using Microsoft.Data.SqlClient;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateTermAppAdminDeedDetailsSqlCommand
{
    private readonly string _sqlCommand =
        @"  UPDATE [Farm].[FarmTermAppDeedDetails]
                SET ApplicationId = @p_ApplicationId
                   ,OriginalBlock = @p_OriginalBlock				
                   ,OriginalLot	  = @p_OriginalLot					
                   ,OriginalBook  = @p_OriginalBook				
                   ,OriginalPage  = @p_OriginalPage	
                   ,NOTBlock	  = @p_NOTBlock						
                   ,NOTLot		  = @p_NOTLot						
                   ,NOTBook		  = @p_NOTBook						
                   ,NOTPage		  = @p_NOTPage						
                   ,RDBlock		  = @p_RDBlock						
                   ,RDLot		  = @p_RDLot							
                   ,RDBook		  = @p_RDBook						
                   ,RDPage        = @p_RDPage
                   ,LastUpdatedBy = @p_LastUpdatedBy
                   ,LastUpdatedOn = GETDATE()
                WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";
    public  UpdateTermAppAdminDeedDetailsSqlCommand()
    {
        

    }
    public override string ToString()
    {
        return _sqlCommand;
    }
}
