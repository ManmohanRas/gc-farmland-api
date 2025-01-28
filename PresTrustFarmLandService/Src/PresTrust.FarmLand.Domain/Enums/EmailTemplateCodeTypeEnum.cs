namespace PresTrust.FarmLand.Domain.Enums;

public enum EmailTemplateCodeTypeEnum
{

    /// <summary>
    /// Default Email Template Code Type
    /// </summary>
    NONE = 0,
    /// <summary>
    /// Email Template Code Type for CHANGE_STATUS_FROM_DRAFT_TO_REQUESTED
    /// </summary>
    CHANGE_STATUS_FROM_DRAFT_TO_REQUESTED,

    /// <summary>
    /// Email Template Code Type for CHANGE_STATUS_FROM_REQUESTED_TO_APPROVED
    /// </summary>
    CHANGE_STATUS_FROM_REQUESTED_TO_APPROVED,

    /// <summary>
    /// Email Template Code Type for CHANGE_STATUS_FROM_AGREEMENT_APPROVED_TO_ACTIVE
    /// </summary>
    CHANGE_STATUS_FROM_AGREEMENT_APPROVED_TO_ACTIVE,

    /// <summary>
    /// Email Template Code Type for CHANGE_STATUS_FROM_AGREEMENT_APPROVED_TO_ACTIVE
    /// </summary>
    TRIGER_THE_EMAIL_WHEN_SADC_IS_ENABLED,

    //Easement
    
    /// <summary>
    /// Email Template Code Type for CHANGE_STATUS_FROM_CREATE_TO_DRAFT_APPLICATION
    /// </summary>
    CHANGE_STATUS_FROM_CREATE_TO_DRAFT_APPLICATION,

    /// <summary>
    /// Email Template Code Type for CHANGE_STATUS_FROM_DRAFT_APPLICATION_TO_APPLICATION_SUBMITTED
    /// </summary>
    CHANGE_STATUS_FROM_DRAFT_APPLICATION_TO_APPLICATION_SUBMITTED,

    /// <summary>
    /// Email Template Code Type for CHANGE_STATUS_FROM_IN_REVIEW_TO_PENDING
    /// </summary>
    CHANGE_STATUS_FROM_IN_REVIEW_TO_PENDING,

    /// <summary>
    /// Email Template Code Type for CHANGE_STATUS_FROM_IN_REVIEW_TO_REJECTED
    /// </summary>
    CHANGE_STATUS_FROM_IN_REVIEW_TO_REJECTED,

    /// <summary>
    /// Email Template Code Type for CHANGE_STATUS_PENDING_TO_ACTIVE
    /// </summary>
    CHANGE_STATUS_PENDING_TO_ACTIVE,

    /// <summary>
    /// Email Template Code Type for CHANGE_STATUS_FROM_CLOSING_TO_POST_CLOSING
    /// </summary>
    CHANGE_STATUS_FROM_CLOSING_TO_POST_CLOSING,

    /// <summary>
    /// Email Template Code Type for CHANGE_STATUS_FROM_IN_POST_CLOSING_TO_PRESERVED
    /// </summary>
    CHANGE_STATUS_FROM_IN_POST_CLOSING_TO_PRESERVED,

    /// <summary>
    /// Email Template Code Type for FEEDBACK_RECEIVED_EMAIL
    /// </summary>
    FEEDBACK_RECEIVED_EMAIL,

    /// <summary>
    /// Email Template Code Type for FARM_MONITORING
    /// </summary>
    FARM_MONITORING
}
