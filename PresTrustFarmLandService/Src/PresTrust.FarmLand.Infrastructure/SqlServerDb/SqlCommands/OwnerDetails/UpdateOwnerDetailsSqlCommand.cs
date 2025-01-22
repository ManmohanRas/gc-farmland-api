namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateOwnerDetailsSqlCommand
{
    private readonly string _sqlCommand =
  @"UPDATE  [Farm].[FarmAppOwnerDetailList]
                 SET
                        [ApplicationId]         = @p_ApplicationId,
                       [FirstName]             = @p_FirstName,
                       [LastName]              = @p_LastName,         
                        [PropertyLocation]      = @p_PropertyLocation,                     
                        [MunicipalityId]        = @p_MunicipalityId,
                        [MailingAddress1]       = @p_MailingAddress1,                   
                        [MailingAddress2]       = @p_MailingAddress2,                  
                        [PhoneNumber]           = @p_PhoneNumber,                            
                        [City]                  = @p_City,                    
                        [State]                 = @p_State,                 
                        [ZipCode]               = @p_ZipCode,
                       [Salutation]            = @p_Salutation,
                       [EmailAddress]          = @p_EmailAddress,
                       [CurrentOwnerMailingName]=@p_CurrentOwnerMailingName,
                        [LastUpdatedBy]           = @p_LastUpdatedBy,                                
                        [LastUpdatedOn]         = @p_LastUpdatedOn                
                                                          
                      WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId";

						

    public UpdateOwnerDetailsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
