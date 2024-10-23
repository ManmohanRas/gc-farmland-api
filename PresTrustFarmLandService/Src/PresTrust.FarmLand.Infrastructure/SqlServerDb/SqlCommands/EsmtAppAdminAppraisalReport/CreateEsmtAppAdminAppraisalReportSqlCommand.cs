namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands.EsmtAppAdminApprisalReport
{
    public class CreateEsmtAppAdminAppraisalReportSqlCommand
    {
        private readonly string _sqlCommand =
                 @"INSERT INTO [Farm].[FarmEsmtAppAdminAppraisalReport]
						(
                             ApplicationId
                            ,AsOfDate
                            ,AppraiserName1
                            ,AppraiserName2
                            ,LowerAppraiser
                            ,HigherAppraiser
                            ,PreHLBeforeValue1
                            ,PreHLAfterValue1
                            ,PreHLEsmtValue1
                            ,PreHLBeforeValue2
                            ,PreHLAfterValue2
                            ,PreHLEsmtValue2
                            ,PostHLBeforeValue1
                            ,PostHLAfterValue1
                            ,PostHLEsmtValue1
                            ,PostHLBeforeValue2
                            ,PostHLAfterValue2
                            ,PostHLEsmtValue2
                            ,DiffInEsmtAppraisals
                            ,PostHLDifference
                            ,DiffInPreandPostHL
                            ,WithInHighlands
                            ,WithInPreservationArea
                            ,SADCCertifiedEsmttotal
                            ,SADCEsmtBeforePct
                            ,AppraisedZoning
                            ,ApraisedZoningClass
                            ,AppraisalComments
                            ,FreeHolderDate 
                            ,CurrentZoning
                            ,CADBEasement
                            ,CADBBefore
                            ,CADBEaseBefore
                            ,LastUpdatedBy
                            ,LastUpdatedOn
                        )
                        VALUES
                        (
                             @p_ApplicationId
                            ,@p_AsOfDate
                            ,@p_AppraiserName1
                            ,@p_AppraiserName2
                            ,@p_LowerAppraiser
                            ,@p_HigherAppraiser
                            ,@p_PreHLBeforeValue1
                            ,@p_PreHLAfterValue1
                            ,@p_PreHLEsmtValue1
                            ,@p_PreHLBeforeValue2
                            ,@p_PreHLAfterValue2
                            ,@p_PreHLEsmtValue2
                            ,@p_PostHLBeforeValue1
                            ,@p_PostHLAfterValue1
                            ,@p_PostHLEsmtValue1
                            ,@p_PostHLBeforeValue2
                            ,@p_PostHLAfterValue2
                            ,@p_PostHLEsmtValue2
                            ,@p_DiffInEsmtAppraisals
                            ,@p_PostHLDifference
                            ,@p_DiffInPreandPostHL
                            ,@p_WithInHighlands
                            ,@p_WithInPreservationArea
                            ,@p_SADCCertifiedEsmttotal
                            ,@p_SADCEsmtBeforePct
                            ,@p_AppraisedZoning
                            ,@p_ApraisedZoningClass
                            ,@p_AppraisalComments
                            ,@p_FreeHolderDate 
                            ,@p_CurrentZoning
                            ,@p_CADBEasement
                            ,@p_CADBBefore
                            ,@p_CADBEaseBefore
                            ,@p_LastUpdatedBy
                            ,GETDATE()	
                        );
                        SELECT CAST( SCOPE_IDENTITY() AS INT);";

        public CreateEsmtAppAdminAppraisalReportSqlCommand()
        {
        }

        public override string ToString()
        {
            return _sqlCommand;
        }
    
    }
}
