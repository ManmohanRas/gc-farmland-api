namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class CreateEsmtAppAttachmentCSqlCommand
{
    private readonly String _sqlCommand = @"INSERT INTO [Farm].[FarmEsmtAttachmentC]
                                 (                 
                                                   ApplicationId,                                         
                                                   IsExceptionAreaPreserved,                                
                                                   IsNonAgriPremisesPreserved,                               
                                                   DescNonAgriUses,				          
                                                   NonAgriAreaUtilization,			 	           
                                                   NonAgriLease,				    
                                                   NonAgriUseAccessParcel,				             
                                                   LastUpdatedBy,				         
                                                   LastUpdatedOn
                                  )
                                    VALUES(
                                                   
                                                   @p_ApplicationId,                                         
                                                   @p_IsExceptionAreaPreserved,                                
                                                   @p_IsNonAgriPremisesPreserved,                               
                                                   @p_DescNonAgriUses,				          
                                                   @p_NonAgriAreaUtilization,			 	           
                                                   @p_NonAgriLease,				    
                                                   @p_NonAgriUseAccessParcel,				             
                                                   @p_LastUpdatedBy,				         
                                                   GETDATE()
                                          )
                     SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateEsmtAppAttachmentCSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}

