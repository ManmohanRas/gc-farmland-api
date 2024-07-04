using static  PresTrust.FarmLand.Domain.Constants.FarmLandDomainConstants;

namespace PresTrust.FarmLand.Domain.Entities;

public class TermBrokenRuleEntity
{
    public int ApplicationId { get; set; }
    public int SectionId { get; set; }
    public string Message { get; set; }
    public bool IsApplicantFlow { get; set; }

    public ApplicationSectionEnum Section
    {
        get
        {
            return (ApplicationSectionEnum)SectionId;
        }
        set
        {
            this.SectionId = (int)value;
        }
    }

    public string RouterLink
    {
        get
        {
            string val = string.Empty;
            switch (this.Section)
            {
                case ApplicationSectionEnum.LOCATION:
                    val = TermApplicationRouterLinks.LOCATION_EDIT;
                    break;
                case ApplicationSectionEnum.ROLES:
                    val = TermApplicationRouterLinks.ROLES_EDIT;
                    break;
                case ApplicationSectionEnum.OWNER_DETAILS:
                    val = TermApplicationRouterLinks.OWNER_DETAILS_EDIT;
                    break;
                case ApplicationSectionEnum.SITE_CHARACTERISTICS:
                    val = TermApplicationRouterLinks.SITE_CHARACTERISTICS_EDIT;
                    break;
                case ApplicationSectionEnum.SIGNATORY:
                    val = TermApplicationRouterLinks.SIGNATORY_EDIT;
                    break;
                case ApplicationSectionEnum.OTHER_DOCUMENTS:
                    val = TermApplicationRouterLinks.OTHER_DOCUMENTS_EDIT;
                    break;
                case ApplicationSectionEnum.ADMIN_DOCUMENT_CHECKLIST:
                    val = TermApplicationRouterLinks.ADMIN_DOCUMENT_CHECKLIST_EDIT;
                    break;
                case ApplicationSectionEnum.ADMIN_DETAILS:
                    val = TermApplicationRouterLinks.ADMIN_DETAILS_EDIT;
                    break;
                case ApplicationSectionEnum.ADMIN_DEED_DETAILS:
                    val = TermApplicationRouterLinks.DEED_DETAILS_EDIT;
                    break;
                default:
                    break;
            }
            return val;
        }
    }

    public TermBrokenRuleEntity()
    {
    }

    public TermBrokenRuleEntity(int applicationId, int sectionId, string message, bool isApplicantFlow)
    {
        this.ApplicationId = applicationId;
        this.SectionId = sectionId;
        this.Message = message;
        this.IsApplicantFlow = isApplicantFlow;
    }
}
