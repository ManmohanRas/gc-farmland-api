namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetEsmtAppAdminExceotionRDSOSqlQuery
{
    private readonly string _sqlCommand =
         @" SELECT
             [Id]
            ,[ApplicationId]
            ,[NumberofExceps]           
		    ,[Excep1Acres]              
		    ,[X1Purpose]                
		    ,[X1Severable]              
		    ,[X1IsSubdividable]         
		    ,[X1IsRTF]                  
		    ,[Excep2Acres]              
		    ,[X2Purpose]                
		    ,[X2IsSeverable]            
		    ,[X2IsSubdividable]        
		    ,[X2IsRTF]                  
		    ,[Excep3Acres]              
		    ,[X3Purpose]                
		    ,[X3IsSeverable]            
		    ,[X3IsSubdividable]         
		    ,[X3IsRTF]                  
		    ,[RDSOsNum]		   
		    ,[RDSOExplan]               
		    ,[IsRDSOExercised]          
		    ,[LastUpdatedBy]            
		    ,[LastUpdatedOn]

			FROM [Farm].[FarmEsmtAppAdminExceptionRDSO] WHERE ApplicationId = @p_ApplicationId";

	public GetEsmtAppAdminExceotionRDSOSqlQuery()
	{ 
	}

    public override string ToString()
    {
        return _sqlCommand;
    }
}
