namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;
public class GetFarmEsmtSadcFarmInfoSqlCommand
{
    private readonly string _sqlCommand =
        @"SELECT   
                 Id,
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
           FROM  [Farm].[FarmEsmtSadcFarmInfo]  WHERE ApplicationId = @p_ApplicationId;
      ";


    public GetFarmEsmtSadcFarmInfoSqlCommand() { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
