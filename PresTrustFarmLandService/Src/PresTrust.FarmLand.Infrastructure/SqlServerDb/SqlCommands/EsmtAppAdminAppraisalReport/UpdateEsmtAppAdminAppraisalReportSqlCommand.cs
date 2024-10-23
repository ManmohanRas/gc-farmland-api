using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresTrust.FarmLand.Infrastructure.SqlServerDb.SqlCommands.EsmtAppAdminApprisalReport
{
    public class UpdateEsmtAppAdminAppraisalReportSqlCommand
    {
        private readonly string _sqlCommand =
     @" UPDATE [Farm].[FarmEsmtAppAdminAppraisalReport]
            SET              ApplicationId          = @p_ApplicationId
                            ,AsOfDate               = @p_AsOfDate
                            ,AppraiserName1         = @p_AppraiserName1
                            ,AppraiserName2         = @p_AppraiserName2
                            ,LowerAppraiser         = @p_LowerAppraiser
                            ,HigherAppraiser        = @p_HigherAppraiser
                            ,PreHLBeforeValue1      = @p_PreHLBeforeValue1
                            ,PreHLAfterValue1       = @p_PreHLAfterValue1
                            ,PreHLEsmtValue1        = @p_PreHLEsmtValue1
                            ,PreHLBeforeValue2      = @p_PreHLBeforeValue2
                            ,PreHLAfterValue2       = @p_PreHLAfterValue2
                            ,PreHLEsmtValue2        = @p_PreHLEsmtValue2
                            ,PostHLBeforeValue1     = @p_PostHLBeforeValue1
                            ,PostHLAfterValue1      = @p_PostHLAfterValue1
                            ,PostHLEsmtValue1       = @p_PostHLEsmtValue1
                            ,PostHLBeforeValue2     = @p_PostHLBeforeValue2
                            ,PostHLAfterValue2      = @p_PostHLAfterValue2
                            ,PostHLEsmtValue2       = @p_PostHLEsmtValue2
                            ,DiffInEsmtAppraisals   = @p_DiffInEsmtAppraisals
                            ,PostHLDifference       = @p_PostHLDifference
                            ,DiffInPreandPostHL     = @p_DiffInPreandPostHL
                            ,WithInHighlands        = @p_WithInHighlands
                            ,WithInPreservationArea = @p_WithInPreservationArea
                            ,SADCCertifiedEsmttotal = @p_SADCCertifiedEsmttotal
                            ,SADCEsmtBeforePct      = @p_SADCEsmtBeforePct
                            ,AppraisedZoning        = @p_AppraisedZoning
                            ,ApraisedZoningClass    = @p_ApraisedZoningClass
                            ,AppraisalComments      = @p_AppraisalComments
                            ,FreeHolderDate         = @p_FreeHolderDate     
                            ,CurrentZoning          = @p_CurrentZoning
                            ,CADBEasement           = @p_CADBEasement
                            ,CADBBefore             = @p_CADBBefore
                            ,CADBEaseBefore         = @p_CADBEaseBefore
                            ,LastUpdatedBy          = @p_LastUpdatedBy
                            ,LastUpdatedOn          = @p_LastUpdatedOn
                 WHERE Id = @p_Id AND ApplicationId = @p_ApplicationId;";

        public UpdateEsmtAppAdminAppraisalReportSqlCommand()
        { }


        public override string ToString()
        {
            return _sqlCommand;
        }
    }
}
