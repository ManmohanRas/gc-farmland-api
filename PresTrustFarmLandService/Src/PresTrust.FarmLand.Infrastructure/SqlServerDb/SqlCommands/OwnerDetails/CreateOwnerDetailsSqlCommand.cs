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
                      @p_ApplicationId,
                      @p_FirstName,
                      @p_LastName,                      
                       @p_PropertyLocation,                        
                       @p_Municipality,   
                       @p_MailingAddress1,
                       @p_MailingAddress2,
                       @p_PhoneNumber,
                       @p_City,                            
                       @p_State,                                  
                       @p_ZipCode,                                   
                       @p_LastUpdatedBy,
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
