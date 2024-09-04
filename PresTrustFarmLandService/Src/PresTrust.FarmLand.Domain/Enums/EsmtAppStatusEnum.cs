namespace PresTrust.FarmLand.Domain.Enums;

public enum EsmtAppStatusEnum
{
    /// <summary>
    /// Application Status Type for None
    /// </summary>
    NONE = 0,

    /// <summary>
    /// Application Status Type for Draft
    /// </summary>
    DRAFT_APPLICATION = 201,

    /// <summary>
    /// Application Status Type for Submit
    /// </summary>
    APPLICATION_SUBMITTED = 202,

    /// <summary>
    /// Application Status Type for In review
    /// </summary>
    IN_REVIEW = 203,

    /// <summary>
    /// Application Status Type for Pending
    /// </summary>
    PENDING = 204,

    /// <summary>
    /// Application Status Type for Active
    /// </summary>
    ACTIVE = 205,

    /// <summary>
    /// Application Status Type for Preserved
    /// </summary>
    PRESERVED = 206,

    /// <summary>
    /// Application Status Type for Rejected
    /// </summary>
    REJECTED = 207,

    /// <summary>
    /// Application Status Type for Withdrawn
    /// </summary>
    WITHDRAWN = 208,

    /// <summary>
    /// Application Status Type for Closing
    /// </summary>
    CLOSING = 209,

    /// <summary>
    /// Application Status Type for Post Closing
    /// </summary>
    POST_CLOSING = 210,

}
