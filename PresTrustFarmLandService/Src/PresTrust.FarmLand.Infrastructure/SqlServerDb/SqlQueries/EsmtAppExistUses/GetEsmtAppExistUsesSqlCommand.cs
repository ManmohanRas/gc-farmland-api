namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;
public class GetEsmtAppExistUsesSqlCommand
{

    private readonly string  _sqlCommand = @"
       SELECT
               [ID],                            
               [ApplicationId],                  
               [IsSubdivisionApprovals],         
               [InfoAboutPremises],                
               [LastUpdatedBy],		   
               [LastUpdatedOn]

          FROM  [FARM].[FARMESMTEXISTNONAGRIUSES]
          WHERE  [ApplicationId]  =@p_ApplicationID; 
     ";


    public GetEsmtAppExistUsesSqlCommand()
    {

    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
