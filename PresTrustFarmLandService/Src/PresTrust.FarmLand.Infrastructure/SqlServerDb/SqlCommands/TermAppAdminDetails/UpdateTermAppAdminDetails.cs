namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateTermAppAdminDetails
{
    private readonly string _sqlCommand =
       @" UPDATE [Farm].[FarmTermAppAdminDetails]
               SET   ApplicationId           =   @p_ApplicationId
                    ,SADCId					=   @p_SADCId						
                    ,MaxGrant				=   @p_MaxGrant						
                    ,PermanentlyPreserved	=   @p_PermanentlyPreserved			
                    ,MunicipallyApproved	=   @p_MunicipallyApproved			
                    ,EnrollmentDate			=   @p_EnrollmentDate				
                    ,RenewalDate			=   @p_RenewalDate					
                    ,ExpirationDate			=   @p_ExpirationDate				
                    ,RenewalExpirationDate	=   @p_RenewalExpirationDate
                    ,Comment                =   @p_Comment
                    ,LastUpdatedBy          =   @p_LastUpdatedBy
                    ,LastUpdatedOn          =   @p_LastUpdatedOn
             WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId";

    public UpdateTermAppAdminDetails()
    {
    }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
