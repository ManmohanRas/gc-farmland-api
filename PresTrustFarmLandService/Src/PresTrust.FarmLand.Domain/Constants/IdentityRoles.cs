namespace PresTrust.FarmLand.Domain.Constants;

public partial class FarmLandDomainConstants
{
    /// <summary>
    /// Class to hold constants for Preservation Trust Claim Types
    /// </summary>
    public static class IdentityRoles
    {
        /// <summary>
        /// Constant to hold role for System Admin 
        /// </summary>
        public const string SYSTEM_ADMIN = "system_admin";
        /// <summary>
        /// Constant to hold role for Farm Program Admin 
        /// </summary>
        public const string FARM_PROGRAM_ADMIN = "farm_program_admin";
        /// <summary>
        /// Constant to hold role for Farm Mitigation Program Editor 
        /// </summary>
        public const string FARM_PROGRAM_EDITOR = "farm_program_editor";
        /// <summary>
        /// Constant to hold role for Farm Mitigation Program Committee 
        /// </summary>
        public const string FARM_PROGRAM_COMMITTEE = "farm_program_committee";
        /// <summary>
        /// Constant to hold role for Farm Mitigation Program ReadOnly 
        /// </summary>
        public const string FARM_PROGRAM_READONLY = "farm_program_readonly";
    }
}
