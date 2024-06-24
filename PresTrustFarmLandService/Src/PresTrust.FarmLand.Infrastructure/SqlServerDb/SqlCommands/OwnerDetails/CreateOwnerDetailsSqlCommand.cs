namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateOwnerDetailsSqlCommand
{
    private readonly string _sqlCommand =
    @"INSERT INTO  [Farm].[FarmTermAppOwnerDetails]
              (
                         [ApplicationId]
                       ,[FirstName]
                       ,[LastName]                      
                        ,[PropertyLocation]                            
                        ,[Municipality]           
                        ,[MailingAddress1]                       
                        ,[MailingAddress2]                     
                        ,[PhoneNumber]                                      
                        ,[City]                                     
                        ,[State]                                  
                        ,[ZipCode]                                   
                        ,[LastUpdatedBy]      
                       ,[LastUpdatedOn]
              )

			  VALUES
			  (  
                      @P_ApplicationId,
                      @P_FirstName,
                      @P_LastName,                      
                       @P_PropertyLocation,                        
                       @P_Municipality,   
                       @P_MailingAddress1,
                       @P_MailingAddress2,
                       @P_PhoneNumber,
                       @P_City,                            
                       @P_State,                                  
                       @P_ZipCode,                                   
                       @P_LastUpdatedBy,
                       GETDATE()
						);

				  SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateOwnerDetailsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
