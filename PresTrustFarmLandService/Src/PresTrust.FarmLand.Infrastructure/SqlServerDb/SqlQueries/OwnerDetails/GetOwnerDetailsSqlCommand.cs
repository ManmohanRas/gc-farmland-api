namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetOwnerDetailsSqlCommand
{
    private readonly string _sqlCommand =
    @"  SELECT         [Id]                                                        
                        ,[ApplicationId]
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
            FROM [Farm].[FarmTermAppOwnerDetails] WHERE ApplicationId = @p_ApplicationId";

     public GetOwnerDetailsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
