namespace PresTrust.FarmLand.Domain.Enums
{
    public enum EsmtUserPermissionEnum
    {
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
    }
}
