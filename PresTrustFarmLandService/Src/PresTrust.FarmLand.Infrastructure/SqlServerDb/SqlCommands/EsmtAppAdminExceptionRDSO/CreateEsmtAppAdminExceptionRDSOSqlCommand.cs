namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateEsmtAppAdminExceptionRDSOSqlCommand
{
    private readonly string _sqlCommand =
         @"INSERT INTO [Farm].[FarmEsmtAppAdminExceptionRDSO]
            (
                ApplicationId
               ,NumberofExceps           
		       ,Excep1Acres              
		       ,X1Purpose                
		       ,X1Severable              
		       ,X1IsSubdividable         
		       ,X1IsRTF                  
		       ,Excep2Acres              
		       ,X2Purpose                
		       ,X2IsSeverable            
		       ,X2IsSubdividable        
		       ,X2IsRTF                  
		       ,Excep3Acres              
		       ,X3Purpose                
		       ,X3IsSeverable            
		       ,X3IsSubdividable         
		       ,X3IsRTF                  
		       ,RDSOsNum		   
		       ,RDSOExplan               
		       ,IsRDSOExercised          
		       ,LastUpdatedBy            
		       ,LastUpdatedOn
            )
				VALUES
			(
				@p_ApplicationId
               ,@p_NumberofExceps           
		       ,@p_Excep1Acres              
		       ,@p_X1Purpose                
		       ,@p_X1Severable              
		       ,@p_X1IsSubdividable         
		       ,@p_X1IsRTF                  
		       ,@p_Excep2Acres              
		       ,@p_X2Purpose                
		       ,@p_X2IsSeverable            
		       ,@p_X2IsSubdividable        
		       ,@p_X2IsRTF                  
		       ,@p_Excep3Acres              
		       ,@p_X3Purpose                
		       ,@p_X3IsSeverable            
		       ,@p_X3IsSubdividable         
		       ,@p_X3IsRTF                  
		       ,@p_RDSOsNum		   
		       ,@p_RDSOExplan               
		       ,@p_IsRDSOExercised          
		       ,@p_LastUpdatedBy            
		       ,GetDate()
			);


			SELECT CAST( SCOPE_IDENTITY() AS INT);";


	public CreateEsmtAppAdminExceptionRDSOSqlCommand()
	{

	}

    public override string ToString()
    {
        return _sqlCommand;
    }
}
