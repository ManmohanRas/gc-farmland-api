namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlQueries;

public class GetEsmtAppAdminAppraisalReportSqlCommand
{
    private readonly string _sqlCommand =
                        @"select
                                      Id
                                    , ApplicationId
                                    , AsOfDate
                                    , AppraiserName1
                                    , AppraiserName2
                                    , LowerAppraiser
                                    , HigherAppraiser
                                    , PreHLBeforeValue1
                                    , PreHLAfterValue1
                                    , PreHLEsmtValue1
                                    , PreHLBeforeValue2
                                    , PreHLAfterValue2
                                    , PreHLEsmtValue2
                                    , PostHLBeforeValue1
                                    , PostHLAfterValue1
                                    , PostHLEsmtValue1
                                    , PostHLBeforeValue2
                                    , PostHLAfterValue2
                                    , PostHLEsmtValue2
                                    , DiffInEsmtAppraisals
                                    , PostHLDifference
                                    , DiffInPreandPostHL
                                    , WithInHighlands
                                    , WithInPreservationArea
                                    , SADCCertifiedEsmttotal
                                    , SADCEsmtBeforePct
                                    , AppraisedZoning
                                    , ApraisedZoningClass
                                    , AppraisalComments
                                    , FreeHolderDate 
                                    , CurrentZoning
                                    , CADBEasement
                                    , CADBBefore
                                    , CADBEaseBefore
                                    , LastUpdatedBy
                                    , LastUpdatedOn
                                     from  [Farm].[FarmEsmtAppAdminAppraisalReport]
                                     WHERE ApplicationId = @p_ApplicationId;";

    public GetEsmtAppAdminAppraisalReportSqlCommand()
    { }

    public override string ToString()
    {
        return _sqlCommand;
    }
}
