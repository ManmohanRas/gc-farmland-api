
namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;

public class UpdateEsmtAppAttachmentCSqlCommand
{
    private readonly String _sqlCommand = @"
                                  UPDATE   [Farm].[FarmEsmtAttachmentC]
                                 SET    ApplicationId                  =   @p_ApplicationId,
                                        IsExceptionAreaPreserved       =  @p_IsExceptionAreaPreserved,
                                        IsNonAgriPremisesPreserved     = @p_IsNonAgriPremisesPreserved,
                                        IsLeaseWithAnotherParty        = @p_IsLeaseWithAnotherParty,
                                        DescNonAgriUses                = @p_DescNonAgriUses,
                                        NonAgriAreaUtilization         = @p_NonAgriAreaUtilization,
                                        NonAgriLease                   =  @p_NonAgriLease,
                                        NonAgriUseAccessParcel         = @p_NonAgriUseAccessParcel,
                                        LastUpdatedBy                  = @p_LastUpdatedBy,
                                        LastUpdatedOn                  = @p_LastUpdatedOn

                       WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;
            ";

   

    public UpdateEsmtAppAttachmentCSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
