namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateOwnerDetailsSqlCommand
{
    private readonly string _sqlCommand =
  @"UPDATE  [Farm].[FarmTermAppOwnerDetails]
                 SET
                        [ApplicationId]       = @P_ApplicationId,
                       [FirstName]           = @P_FirstName,
                       [LastName]            = @P_LastName,         
                        [PropertyLocation]    = @P_PropertyLocation                      
                        [Municipality]        = @P_Municipality
                        [MailingAddress1]     = @P_MailingAddress1,                   
                        [MailingAddress2]     = @P_MailingAddress2,                  
                        [PhoneNumber]         = @P_PhoneNumber,                            
                        [city]                = @P_city,                    
                        [state]               = @P_state,                 
                        [ZipCode]             = @P_ZipCode,                    
                        [LastUpdatedBy]        = @P_LastUpdatedBy,                                
                        [LastUpdatedOn]       = @P_LastUpdatedOn                
                                                          
                      WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId";

						

    public UpdateOwnerDetailsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
