namespace PresTrust.FarmLand.Domain.Enums;

public enum ApplicationStatusEnum
{
    /// <summary>
    /// Application Status Type for None
    /// </summary>
    NONE = 0,

    /// <summary>
    /// Application Status Type for Draft
    /// </summary>
    PETITION_DRAFT = 1,

    /// <summary>
    /// Application Status Type for Submitted
    /// </summary>
    REQUESTED = 2,

    /// <summary>
    /// Application Status Type for In Review
    /// </summary>
    APPROVED = 3,

    /// <summary>
    /// Application Status Type for In Review
    /// </summary>
    AGREEMENT_APPROVED = 4,

    /// <summary>
    /// Application Status Type for Active
    /// </summary>
    ACTIVE = 5,

    /// <summary>
    /// Application Status Type for Closed
    /// </summary>
    EXPIRED = 6,

    /// <summary>
    /// Application Status Type for Rejected
    /// </summary>
    REJECTED = 7,

    /// <summary>
    /// Application Status Type for Withdrawn
    /// </summary>
    WITHDRAWN = 8
}
