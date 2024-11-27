namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetOwnerDetailsSqlCommand
{
    private readonly string _sqlCommand =
    @"  SELECT         [Id]                                                        
                        ,[ApplicationId]
                       ,[Salutation]
                       ,[FirstName]
                       ,[LastName]                      
                        ,[PropertyLocation]                            
                        ,[MunicipalityId]           
                        ,[MailingAddress1]                       
                        ,[MailingAddress2]                     
                        ,[PhoneNumber]                                      
                        ,[City]                                     
                        ,[State]                                  
                        ,[ZipCode] 
                       ,[EmailAddress]
                       ,[CurrentOwnerMailingName]
                        ,[LastUpdatedBy]                                           
                        ,[LastUpdatedOn]
            FROM [Farm].[FarmTermAppOwnerDetails] WHERE ApplicationId = @p_ApplicationId";

     public GetOwnerDetailsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
