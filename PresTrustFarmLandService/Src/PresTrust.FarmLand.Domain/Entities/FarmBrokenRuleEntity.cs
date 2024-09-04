using static PresTrust.FarmLand.Domain.Constants.FarmLandDomainConstants;

namespace PresTrust.FarmLand.Domain.Entities;

public class FarmBrokenRuleEntity
{
    public int ApplicationId { get; set; }
    public int SectionId { get; set; }
    public string Message { get; set; }
    public bool IsApplicantFlow { get; set; }

    public dynamic Section
    {
        get
        {
            if (this.SectionId > 199)
            {
                return (EsmtAppSectionEnum)SectionId;
            }
            else
                return (TermAppSectionEnum)SectionId;
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
            if (this.SectionId > 199)
            {
                switch (this.Section)
                {
                    case EsmtAppSectionEnum.LOCATION:
                        val = EsmtAppRouterLinks.LOCATION_EDIT;
                        break;
                    case EsmtAppSectionEnum.ROLES:
                        val = EsmtAppRouterLinks.ROLES_EDIT;
                        break;
                    case EsmtAppSectionEnum.OWNER_DETAILS:
                        val = EsmtAppRouterLinks.OWNER_DETAILS_EDIT;
                        break;
                    case EsmtAppSectionEnum.EXCEPTIONS:
                        val = EsmtAppRouterLinks.EXCEPTIONS_EDIT;
                        break;
                    case EsmtAppSectionEnum.RESI_NON_RESI_STRUCTURES:
                        val = EsmtAppRouterLinks.RESI_NON_RESI_STRUCTURES_EDIT;
                        break;
                    case EsmtAppSectionEnum.LIENS_EASEMENT_ROW:
                        val = EsmtAppRouterLinks.LIENS_EASEMENT_ROW_EDIT;
                        break;
                    case EsmtAppSectionEnum.EXIS_NON_AGRI_USES:
                        val = EsmtAppRouterLinks.EXIS_NON_AGRI_USES_EDIT;
                        break;
                    case EsmtAppSectionEnum.AGRICULTURAL_USE_PRODUCTION:
                        val = EsmtAppRouterLinks.AGRICULTURAL_USE_PRODUCTION_EDIT;
                        break;
                    case EsmtAppSectionEnum.EQUINE_USES:
                        val = EsmtAppRouterLinks.EQUINE_USES_EDIT;
                        break;
                    case EsmtAppSectionEnum.OTHER_DOCUMENTS:
                        val = EsmtAppRouterLinks.OTHER_DOCUMENTS_EDIT;
                        break;
                    case EsmtAppSectionEnum.SIGNATORY:
                        val = EsmtAppRouterLinks.SIGNATORY_EDIT;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (this.Section)
                {
                    case TermAppSectionEnum.LOCATION:
                        val = TermApplicationRouterLinks.LOCATION_EDIT;
                        break;
                    case TermAppSectionEnum.ROLES:
                        val = TermApplicationRouterLinks.ROLES_EDIT;
                        break;
                    case TermAppSectionEnum.OWNER_DETAILS:
                        val = TermApplicationRouterLinks.OWNER_DETAILS_EDIT;
                        break;
                    case TermAppSectionEnum.SITE_CHARACTERISTICS:
                        val = TermApplicationRouterLinks.SITE_CHARACTERISTICS_EDIT;
                        break;
                    case TermAppSectionEnum.SIGNATORY:
                        val = TermApplicationRouterLinks.SIGNATORY_EDIT;
                        break;
                    case TermAppSectionEnum.OTHER_DOCUMENTS:
                        val = TermApplicationRouterLinks.OTHER_DOCUMENTS_EDIT;
                        break;
                    case TermAppSectionEnum.ADMIN_DOCUMENT_CHECKLIST:
                        val = TermApplicationRouterLinks.ADMIN_DOCUMENT_CHECKLIST_EDIT;
                        break;
                    case TermAppSectionEnum.ADMIN_DETAILS:
                        val = TermApplicationRouterLinks.ADMIN_DETAILS_EDIT;
                        break;
                    case TermAppSectionEnum.ADMIN_DEED_DETAILS:
                        val = TermApplicationRouterLinks.ADMIN_DEED_DETAILS_EDIT;
                        break;
                    case TermAppSectionEnum.ADMIN_CONTACTS:
                        val = TermApplicationRouterLinks.ADMIN_CONTACTS_EDIT;
                        break;
                    default:
                        break;
                }
            }

            return val;
        }
    }

    public FarmBrokenRuleEntity()
    {

    }

    public FarmBrokenRuleEntity(int applicationId, int sectionId, string message, bool isApplicantFlow)
    {
        this.ApplicationId = applicationId;
        this.SectionId = sectionId;
        this.Message = message;
        this.IsApplicantFlow = isApplicantFlow;
    }
}
