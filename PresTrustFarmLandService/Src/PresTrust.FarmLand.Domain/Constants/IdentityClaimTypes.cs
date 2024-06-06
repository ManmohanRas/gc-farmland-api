namespace PresTrust.FarmLand.Domain.Constants;

public partial class FarmLandDomainConstants
{
    /// <summary>
    /// Class to hold constants for Preservation Trust Claim Types
    /// </summary>
    public static class IdentityClaimTypes
    {
        /// <summary>
        /// Constant to hold Claim Type for GivenName 
        /// </summary>
        public const string NAME = "given_name";
        /// <summary>
        /// Constant to hold Claim Type for Email 
        /// </summary>
        public const string EMAIL = "email";
        /// <summary>
        /// Constant to hold Claim Type for FarmAgencyAdmin
        /// </summary>
        public const string FARM_AGENCY_ADMIN = "farm_agencyadmin";
        /// <summary>
        /// Constant to hold Claim Type for FarmAgencySignature
        /// </summary>
        public const string FARM_AGENCY_SIGNATURE = "farm_agencysignature";
        /// <summary>
        /// Constant to hold Claim Type for FarmAgencyEditor
        /// </summary>
        public const string FARM_AGENCY_EDITOR = "farm_agencyeditor";
        /// <summary>
        /// Constant to hold Claim Type for FarmAgencyReadOnly
        /// </summary>
        public const string FARM_AGENCY_READONLY = "farm_agencyreadonly";
    }
}
