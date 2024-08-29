namespace PresTrust.FarmLand.Domain.Enums;
public enum TermUserPermissionEnum
{
    /// <summary>
    /// Permission Type for None
    /// </summary>
    NONE = 0,

    VIEW_LOCATION_SECTION = 1,
    /// <summary>
    /// Permission to edit location details
    /// </summary>
    EDIT_LOCATION_SECTION = 2,

    VIEW_OWNER_DETAILS_SECTION = 3,
    /// <summary>
    /// Permission to edit owner details
    /// </summary>
    EDIT_OWNER_DETAILS_SECTION = 4,

    VIEW_ROLES_SECTION = 5,
    /// <summary>
    /// Permission to edit roles
    /// </summary>
    EDIT_ROLES_SECTION = 6,

    VIEW_SITE_CHARACTERISTICS_SECTION = 7,
    /// <summary>
    /// Permission to site characteristics
    /// </summary>
    EDIT_SITE_CHARACTERISTICS_SECTION = 8,

    VIEW_SIGNATORY_SECTION = 9,
    /// <summary>
    /// Permission to edit signatory
    /// </summary>
    EDIT_SIGNATORY_SECTION = 10,

    /// <summary>
    /// Permission to view other docs details
    /// </summary>
    VIEW_OTHER_DOCS_SECTION = 11,
    /// <summary>
    /// Permission to edit other docs details
    /// </summary>
    EDIT_OTHER_DOCS_SECTION = 12,

    /// <summary>
    /// Permission to view document check lists
    /// </summary>
    VIEW_ADMIN_DOC_CHK_LIST_SECTION = 13,
    /// <summary>
    /// Permission to edit document check lists
    /// </summary>
    EDIT_ADMIN_DOC_CHK_LIST_SECTION = 14,
    /// <summary>
    /// Permission to view admin details section
    /// </summary>
    VIEW_ADMIN_DETAILS_SECTION = 15,
    /// <summary>
    /// Permission to edit admin details section
    /// </summary>
    EDIT_ADMIN_DETAILS_SECTION = 16,
    /// <summary>
    /// Permission to view admin details section
    /// </summary>
    VIEW_ADMIN_DEED_DETAILS_SECTION = 17,
    /// <summary>
    /// Permission to edit admin details section
    /// </summary>
    EDIT_ADMIN_DEED_DETAILS_SECTION = 18,
    /// <summary>
    /// Permission to view admin contacts section
    /// </summary>
    VIEW_ADMIN_CONTACTS_SECTION = 19,
    /// <summary>
    /// Permission to edit admin contacts section
    /// </summary>
    EDIT_ADMIN_CONTACTS_SECTION = 20,

    /// <summary>
    /// Permission to view comments
    /// </summary>
    VIEW_COMMENTS = 101,
    /// <summary>
    /// Permission to edit feedback
    /// </summary>
    EDIT_COMMENTS = 102,
    /// <summary>
    /// Permission to delete comments
    /// </summary>
    DELETE_COMMENTS = 103,
    /// <summary>
    /// Permission to view feedback
    /// </summary>
    VIEW_FEEDBACK = 104,
    /// <summary>
    /// Permission to edit feedback
    /// </summary>
    EDIT_FEEDBACK = 105,
    /// <summary>
    /// Permission to delete feedbacks
    /// </summary>
    DELETE_FEEDBACKS = 106,
    /// <summary>
    /// Permission to request for an application correction
    /// </summary>
    REQUEST_FOR_AN_APPLICATION_CORRECTION = 107,
    /// <summary>
    /// Permission to respond to the request for an application correction
    /// </summary>
    RESPOND_TO_THE_REQUEST_FOR_AN_APPLICATION_CORRECTION = 108,
    /// <summary>
    /// Permission to save document
    /// </summary>
    SAVE_DOCUMENT = 109,
    /// <summary>
    /// Permission to delete document
    /// </summary>
    DELETE_DOCUMENT = 110,
    /// <summary>
    /// Permission to create application
    /// </summary>
    CREATE_APPLICATION = 201,
    /// <summary>
    /// Permission to submit application
    /// </summary>
    SUBMIT_APPLICATION = 202,
    /// <summary>
    /// Permission to review application
    /// </summary>
    REVIEW_APPLICATION = 205,
    /// <summary>
    /// Permission to activate application
    /// </summary>
    ACTIVATE_APPLICATION = 206,
    /// <summary>
    /// Permission to close application
    /// </summary>
    CLOSE_APPLICATION = 207,
    /// <summary>
    /// Permission to reject application
    /// </summary>
    REJECT_APPLICATION = 208,
    /// <summary>
    /// Permission to withdraw application
    /// </summary>
    WITHDRAW_APPLICATION = 209,
    /// <summary>
    /// Permission to reinitiate application
    /// </summary>
    REINITIATE_APPLICATION = 210
}
