namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class UpdateFarmEsmtSadcFarmInfoSqlCommand
{
    private readonly string _sqlCommand = @"

       Update [Farm].[FarmEsmtSadcFarmInfo]
         SET       ApplicationId            = @p_ApplicationId,
                   AlternatePhoneNumber     = @p_AlternatePhoneNumber,
                   County                   = @p_County,
                   TotalFarmAcreage         = @p_TotalFarmAcreage,
                   Acres                    = @p_Acres,
                   IsContactSame            = @p_IsContactSame,
                   IsOtherContact            = @p_IsOtherContact,
                   OtherPrimaryFirstName    = @p_OtherPrimaryFirstName,
                   OtherPrimaryRelation     = @p_OtherPrimaryRelation,
                   OtherPrimaryPhoneNumber  = @p_OtherPrimaryPhoneNumber,
                   OtherPrimaryEmail        =  @p_OtherPrimaryEmail,
                   OtherPrimaryAddress      = @p_OtherPrimaryAddress,
                   IsVisitPrimaryContact    = @p_IsVisitPrimaryContact,
                   IsVisitLandOwner         = @p_IsVisitLandOwner,
                   IsVisitOther             = @p_IsVisitOther,
                   VisitName                =  @p_VisitName,
                   VisitRelation            = @p_VisitRelation,
                   VisitPhoneNumber         = @p_VisitPhoneNumber,
                   VisitEmail               = @p_VisitEmail,
                   VisitSADCID              = @p_VisitSADCID,
                   VisitDateRecieved        = @p_VisitDateRecieved,
                   IsImmediateCurrentMember = @p_IsImmediateCurrentMember,
                   Position                 = @p_Position,
                   Term                     = @p_Term,
                   LastUpdatedBy            =  @p_LastUpdatedBy ,
                   LastUpdatedOn            = @p_LastUpdatedOn
            WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

    public UpdateFarmEsmtSadcFarmInfoSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
