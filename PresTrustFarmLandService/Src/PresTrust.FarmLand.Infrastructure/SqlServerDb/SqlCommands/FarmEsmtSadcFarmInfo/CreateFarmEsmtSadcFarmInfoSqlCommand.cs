namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands;
public class CreateFarmEsmtSadcFarmInfoSqlCommand
{
    private readonly string _sqlCommand =
        @" INSERT INTO [Farm].[FarmEsmtSadcFarmInfo]
       (
          ApplicationId,
          AlternatePhoneNumber,
          County,
          TotalFarmAcreage,
          Acres,
          IsContactSame,
          IsOtherContact,
          OtherPrimaryFirstName,
          OtherPrimaryRelation,
          OtherPrimaryPhoneNumber,
          OtherPrimaryEmail,
          OtherPrimaryAddress,
          IsVisitPrimaryContact,
          IsVisitLandOwner,
          IsVisitOther,
          VisitName,
          VisitRelation,
          VisitPhoneNumber,
          VisitEmail,
          VisitSADCID,
          VisitDateRecieved,
          IsImmediateCurrentMember,
          Position,
          Term,
          LastUpdatedBy,  
		  LastUpdatedOn          
        )
           VALUES   (
                     @p_ApplicationId,
                     @p_AlternatePhoneNumber,
                     @p_County,
                     @p_TotalFarmAcreage,
                     @p_Acres,
                     @p_IsContactSame,
                     @p_IsOtherContact,
                     @p_OtherPrimaryFirstName,
                     @p_OtherPrimaryRelation,
                     @p_OtherPrimaryPhoneNumber,
                     @p_OtherPrimaryEmail,
                     @p_OtherPrimaryAddress,
                     @p_IsVisitPrimaryContact,
                     @p_IsVisitLandOwner,
                     @p_IsVisitOther,
                     @p_VisitName,
                     @p_VisitRelation,
                     @p_VisitPhoneNumber,
                     @p_VisitEmail,
                     @p_VisitSADCID,
                     @p_VisitDateRecieved,
                     @p_IsImmediateCurrentMember,
                     @p_Position,
                     @p_Term,
                     @p_LastUpdatedBy,
                     GetDate()
                 );
                  SELECT CAST( SCOPE_IDENTITY() AS INT);";

    public CreateFarmEsmtSadcFarmInfoSqlCommand(){}

    public override string ToString()
    {
        return _sqlCommand;
    }
}
