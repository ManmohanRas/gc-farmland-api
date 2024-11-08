namespace PresTrust.FarmLand.Domain.Entities;

public class EsmtAppPermissionEntity
{
    public bool CanViewLocationSection { get; set; } = false;
    public bool CanEditLocationSection { get; set; } = false;

    public bool CanViewOwnerDetailsSection { get; set; } = false;
    public bool CanEditOwnerDetailsSection { get; set; } = false;

    public bool CanViewRolesSection { get; set; } = false;
    public bool CanEditRolesSection { get; set; } = false;

    public bool CanViewSiteCharacteristicsSection { get; set; } = false;
    public bool CanEditSiteCharacteristicsSection { get; set; } = false;

    public bool CanViewSignatorySection { get; set; } = false;
    public bool CanEditSignatorySection { get; set; } = false;

    public bool CanViewOtherDocsSection { get; set; } = false;
    public bool CanEditOtherDocsSection { get; set; } = false;

    //---------------------------------------------------------------------//
    //  Application Admin Action Section Permissions
    //---------------------------------------------------------------------//

    public bool CanViewAdminDocChkListSection { get; set; } = false;
    public bool CanEditAdminDocChkListSection { get; set; } = false;

    public bool CanViewAdminCostDetailsSection { get; set; } = false;
    public bool CanEditAdminCostDetailsSection { get; set; } = false;

    public bool CanViewAdminAppraisalReportSection { get; set; } = false;
    public bool CanEditAdminAppraisalReportSection { get; set; } = false;

    public bool CanViewAdminOfferCostsSection { get; set; } = false;
    public bool CanEditAdminOfferCostsSection { get; set; } = false;

    public bool CanViewAdminStructuresSection { get; set; } = false;
    public bool CanEditAdminStructuresSection { get; set; } = false;

    public bool CanViewAdminExceptionsSection { get; set; } = false;
    public bool CanEditAdminExceptionsSection { get; set; } = false;

    public bool CanViewAdminSADCSection { get; set; } = false;
    public bool CanEditAdminSADCSection { get; set; } = false;

    public bool CanViewAdminClosingDocsSection { get; set; } = false;
    public bool CanEditAdminClosingDocsection { get; set; } = false;

    public bool CanViewAdminDetailsSection { get; set; } = false;
    public bool CanEditAdminDetailsSection {  get; set; } = false;

    public bool CanViewAdminContactsSection { get; set; } = false;
    public bool CanEditAdminContactsSection { get; set; } = false;

    //SADC section
    public bool CanViewSADCFarmInformationSection { get; set; } = false;
    public bool CanEditSADCFarmInformationSection { get; set; } = false;

    public bool CanViewSADCResionEsmtAreaSection { get; set; } = false;
    public bool CanEditSADCResionEsmtAreaSection { get; set; } = false;

    public bool CanViewSADCFarmHistorySection { get; set; } = false;
    public bool CanEditSADCFarmHistorySection { get; set; } = false;

    public bool CanViewSADCAppEligibilityISection { get; set; } = false;
    public bool CanEditSADCAppEligibilityISection { get; set; } = false;

    public bool CanViewSADCAppEligibilityIISection { get; set; } = false;
    public bool CanEditSADCAppEligibilityIISection { get; set; } = false;

    public bool CanSubmitApplication { get; set; } = false;
    public bool CanReviewApplication { get; set; } = false;
    public bool CanPendingApplication { get; set; } = false;
    public bool CanApproveApplication { get; set; } = false;
    public bool CanActivateApplication { get; set; } = false;
    public bool CanCloseApplication { get; set; } = false;
    public bool CanRejectApplication { get; set; } = false;
    public bool CanWithdrawApplication { get; set; } = false;
    public bool CanAgreementApproveApplication { get; set; } = false;
    public bool CanSwitchSADC { get; set; } = false;


    //---------------------------------------------------------------------//
    //  Application Details Permissions
    //---------------------------------------------------------------------//

    public bool CanCreateApplication { get; set; } = false;

    public bool CanViewComments { get; set; } = false;
    public bool CanEditComments { get; set; } = false;
    public bool CanDeleteComments { get; set; } = false;

    //---------------------------------------------------------------------//

    public bool CanViewFeedback { get; set; } = false;
    public bool CanEditFeedback { get; set; } = false;
    public bool CanDeleteFeedback { get; set; } = false;
    public bool CanRequestForAnApplicationCorrection { get; set; } = false;
    public bool CanRespondToTheRequestForAnApplicationCorrection { get; set; } = false;

    //---------------------------------------------------------------------//

    public bool CanSaveDocument { get; set; } = false;
    public bool CanDeleteDocument { get; set; } = false;
}
