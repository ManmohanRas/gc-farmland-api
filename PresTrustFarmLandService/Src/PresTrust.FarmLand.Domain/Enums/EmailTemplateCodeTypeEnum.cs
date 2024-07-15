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
    TRIGER_THE_EMAIL_WHEN_SADC_IS_ENABLED

}
