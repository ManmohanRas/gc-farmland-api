namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateEsmtAppAdminExceptionRDSOSqlCommand
{

    private readonly string _sqlCommand =
         @" UPDATE [Farm].[FarmEsmtAppAdminExceptionRDSO]
                SET  ApplicationId     =   @p_ApplicationId
					,NumberofExceps    =   @p_NumberofExceps                  
					,Excep1Acres       =   @p_Excep1Acres                     
					,X1Purpose         =   @p_X1Purpose                       
					,X1Severable       =   @p_X1Severable                     
					,X1IsSubdividable  =   @p_X1IsSubdividable                
					,X1IsRTF           =   @p_X1IsRTF                         
					,Excep2Acres       =   @p_Excep2Acres                     
					,X2Purpose         =   @p_X2Purpose                       
					,X2IsSeverable     =   @p_X2IsSeverable                   
					,X2IsSubdividable  =   @p_X2IsSubdividable              
					,X2IsRTF           =   @p_X2IsRTF                         
					,Excep3Acres       =   @p_Excep3Acres                     
					,X3Purpose         =   @p_X3Purpose                       
					,X3IsSeverable     =   @p_X3IsSeverable                   
					,X3IsSubdividable  =   @p_X3IsSubdividable                
					,X3IsRTF           =   @p_X3IsRTF                         
					,RDSOSNum		   =   @p_RDSOSNum		   
					,RDSOExplan        =   @p_RDSOExplan                      
					,IsRDSOExercised   =   @p_IsRDSOExercised                 
					,LastUpdatedBy     =   @p_LastUpdatedBy                   
					,LastUpdatedOn	   =   @p_LastUpdatedOn
			 WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;"; 

	public UpdateEsmtAppAdminExceptionRDSOSqlCommand()
	{

	}

    public override string ToString()
    {
        return _sqlCommand;
    }
}
