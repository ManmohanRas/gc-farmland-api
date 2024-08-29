namespace PresTrust.FarmLand.Domain.Enums;

public enum TermAppStatusEnum
{
    /// <summary>
    /// Application Status Type for None
    /// </summary>
    NONE = 0,

     /// <summary>
    /// Application Status Type for Draft
    /// </summary>
    PETITION_DRAFT = 101,

    /// <summary>
    /// Application Status Type for Submitted
    /// </summary>
    PETITION_REQUEST = 102,

    /// <summary>
    /// Application Status Type for In Review
    /// </summary>
    PETITION_APPROVED = 103,

    /// <summary>
    /// Application Status Type for In Review
    /// </summary>
    AGREEMENT_APPROVED = 104,

    /// <summary>
    /// Application Status Type for Active
    /// </summary>
    ACTIVE = 105,

    /// <summary>
    /// Application Status Type for Closed
    /// </summary>
    EXPIRED = 106,

    /// <summary>
    /// Application Status Type for Rejected
    /// </summary>
    REJECTED = 107,

    /// <summary>
    /// Application Status Type for Withdrawn
    /// </summary>
    WITHDRAWN = 108,

    /// <summary>
    /// Application Status Type for ENABLE_SADC
    /// </summary>
    ENABLE_SADC = 109,

    //EASEMENT

    /// <summary>
    /// Application Status Type for Draft
    /// </summary>
    DRAFT_APPLICATION = 201,

    /// <summary>
    /// Application Status Type for Draft
    /// </summary>
    APPLICATION_SUBMITTED = 202,

    /// <summary>
    /// Application Status Type for In Review
    /// </summary>
    IN_REVIEW = 203,

}
