namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetTermAppAdminDetailsSqlCommand
{
    private readonly string _sqlCommand =
  @"  SELECT   [Id]							 
                  ,[ApplicationId]					 
                  ,[SADCId]						 
                  ,[MaxGrant]						 
                  ,[PermanentlyPreserved]			 
                  ,[EnrollmentDate]				 
                  ,[RenewalDate]					 
                  ,[ExpirationDate]				 
                  ,[RenewalExpirationDate]
                  ,[Comment]
                  ,[LastUpdatedBy]					 
                   [LastUpdatedOn]					 
            FROM [Farm].[FarmTermAppAdminDetails]
            WHERE ApplicationId = @p_ApplicationId";

    public GetTermAppAdminDetailsSqlCommand()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
