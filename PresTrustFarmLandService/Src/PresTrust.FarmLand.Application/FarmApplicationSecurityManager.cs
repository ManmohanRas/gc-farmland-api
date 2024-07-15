namespace PresTrust.FarmLand.Application;

public class FarmApplicationSecurityManager
{
    private UserRoleEnum userRole = default;
    private ApplicationStatusEnum applicationStatus = default;
    private TermAppPermissionEntity permission = default;
    private List<NavigationItemEntity> navigationItems = default;
    private List<NavigationItemEntity> adminNavigationItems = default;
    private List<NavigationItemEntity> postApprovedNavigationItems = default;
    private NavigationItemEntity defaultNavigationItem = default;
    private List<TermFeedbacksEntity> corrections = new List<TermFeedbacksEntity>();

    public FarmApplicationSecurityManager(UserRoleEnum userRole, ApplicationStatusEnum applicationStatus, ApplicationTypeEnum applicationType)
    {
        this.userRole = userRole;
        this.applicationStatus = applicationStatus;

        this.userRole = userRole;

        if (applicationType == ApplicationTypeEnum.TERM)
        {
            ConfigureTermPermissions();
        }
        else if (applicationType == ApplicationTypeEnum.EASEMENT)
        {
            ConfigureEasementPermissions();
        }
    }


    public TermAppPermissionEntity Permission { get { return permission; } }
    public List<NavigationItemEntity> NavigationItems { get => navigationItems; }
    public List<NavigationItemEntity> AdminNavigationItems { get => adminNavigationItems; }
    public List<NavigationItemEntity> PostApprovedNavigationItems { get => postApprovedNavigationItems; }
    public NavigationItemEntity DefaultNavigationItem { get => defaultNavigationItem; }

    //need to re work on it
    //Term Program
    public void ConfigureTermPermissions()
    {


        permission = new TermAppPermissionEntity();
        navigationItems = new List<NavigationItemEntity>();
        adminNavigationItems = new List<NavigationItemEntity>();
        postApprovedNavigationItems = new List<NavigationItemEntity>();

        if (userRole == UserRoleEnum.AGENCY_ADMIN || userRole == UserRoleEnum.SYSTEM_ADMIN || userRole == UserRoleEnum.PROGRAM_ADMIN || userRole == UserRoleEnum.PROGRAM_EDITOR)
        {
            permission.CanCreateApplication = true;
        }

        switch (applicationStatus)
        {
            case ApplicationStatusEnum.NONE:
                break;
            case ApplicationStatusEnum.PETITION_DRAFT:
                DeriveDraftStatePermissions();
                break;
            case ApplicationStatusEnum.REQUESTED:
                DeriveRequestedStatePermissions();
                break;
            case ApplicationStatusEnum.APPROVED:
                DeriveRequestedStatePermissions();
                break;
            case ApplicationStatusEnum.ACTIVE:
                DeriveRequestedStatePermissions();
                break;
            case ApplicationStatusEnum.WITHDRAWN:
                DeriveWithdrawnStatePermissions();
                break;
            case ApplicationStatusEnum.REJECTED:
                DeriveWithdrawnStatePermissions();
                break;
        }

    }

    private void DeriveDraftStatePermissions()
    {
        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
            case UserRoleEnum.PROGRAM_EDITOR:
                if (userRole == UserRoleEnum.SYSTEM_ADMIN || userRole == UserRoleEnum.PROGRAM_ADMIN)
                {
                    permission.CanSubmitApplication = true;
                }

                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;

                Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                if (userRole == UserRoleEnum.AGENCY_ADMIN)
                {
                    permission.CanSubmitApplication = true;
                }
                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;

                Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

            
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
            default:
                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
        }
    }

    private void DeriveRequestedStatePermissions()
    {
        TermFeedbacksEntity correction = default;

        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:

                permission.CanReviewApplication = true;
                permission.CanRequestForAnApplicationCorrection = true;
                permission.CanRespondToTheRequestForAnApplicationCorrection = true;
                permission.CanEditFeedback = true;
                permission.CanDeleteFeedback = true;
                permission.CanViewFeedback = true;
                permission.CanViewComments = true;
                permission.CanEditComments = true;
                permission.CanDeleteComments = true;
                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;
                permission.CanRejectApplication = true;


                Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDeedDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                if (userRole == UserRoleEnum.AGENCY_ADMIN)
                {
                    permission.CanSubmitApplication = true;
                }
                permission.CanSaveDocument = true;
                permission.CanDeleteDocument = true;

                Location(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OwnerDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Roles(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                SiteCharacteristics(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                OtherDocuments(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDocumentChecklist(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminDeedDetails(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                AdminContacts(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
            default:
                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
        }
    }

    private void DeriveWithdrawnStatePermissions()
    {
        switch (userRole)
        {
            case UserRoleEnum.SYSTEM_ADMIN:
            case UserRoleEnum.PROGRAM_ADMIN:
            case UserRoleEnum.PROGRAM_EDITOR:
                if (userRole == UserRoleEnum.SYSTEM_ADMIN || userRole == UserRoleEnum.PROGRAM_ADMIN)
                {
                    permission.CanCloseApplication = true;
                    permission.CanReinitiateApplication = true;
                }
                permission.CanViewFeedback = true;
                permission.CanViewComments = true;
                permission.CanEditComments = true;
                permission.CanDeleteComments = true;

                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();
                //Admin Document Checklist
                AdminDocumentChecklist();
                //Admin Details
                AdminDetails();
                //Admin Deed Details
                AdminDeedDetails();
                //Admin Contacts
                AdminContacts();

                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
            case UserRoleEnum.AGENCY_ADMIN:
            case UserRoleEnum.AGENCY_EDITOR:
                permission.CanViewFeedback = true;
                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();
                //Admin Document Checklist
                AdminDocumentChecklist();
                //Admin Details
                AdminDetails();
                //Admin Deed Details
                AdminDeedDetails();
                //Admin Contacts
                AdminContacts();
                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 7
                };
                break;
            default:
                if (userRole != UserRoleEnum.AGENCY_READONLY)
                {
                    permission.CanViewFeedback = true;
                }
                Location();
                OwnerDetails();
                Roles();
                SiteCharacteristics();
                OtherDocuments();
                Signatory();
                // Default Navigation Item
                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = TermAppNavigationItemTitles.LOCATION,
                    RouterLink = TermApplicationRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
        }
    }

    //Easement Program
    public void ConfigureEasementPermissions()
    {

    }

    private void Location(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewLocationSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.LOCATION, RouterLink = TermApplicationRouterLinks.LOCATION_VIEW, SortOrder = 1, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditLocationSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.LOCATION, RouterLink = TermApplicationRouterLinks.LOCATION_EDIT, SortOrder = 1, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void OwnerDetails(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewLocationSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.OWNER_DETAILS, RouterLink = TermApplicationRouterLinks.OWNER_DETAILS_VIEW, SortOrder = 2, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditLocationSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.OWNER_DETAILS, RouterLink = TermApplicationRouterLinks.OWNER_DETAILS_EDIT, SortOrder = 2, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void Roles(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewRolesSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ROLES, RouterLink = TermApplicationRouterLinks.ROLES_VIEW, SortOrder = 3, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditRolesSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ROLES, RouterLink = TermApplicationRouterLinks.ROLES_EDIT, SortOrder = 3, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void SiteCharacteristics(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewSiteCharacteristicsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.SITE_CHARACTERISTICS, RouterLink = TermApplicationRouterLinks.SITE_CHARACTERISTICS_VIEW, SortOrder = 4, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditSiteCharacteristicsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.SITE_CHARACTERISTICS, RouterLink = TermApplicationRouterLinks.SITE_CHARACTERISTICS_EDIT, SortOrder = 4, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void OtherDocuments(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewOtherDocsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.OTHER_DOCUMENTS, RouterLink = TermApplicationRouterLinks.OTHER_DOCUMENTS_VIEW, SortOrder = 5, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditOtherDocsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.OTHER_DOCUMENTS, RouterLink = TermApplicationRouterLinks.OTHER_DOCUMENTS_EDIT, SortOrder = 5, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void Signatory(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewSignatorySection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.SIGNATORY, RouterLink = TermApplicationRouterLinks.SIGNATORY_VIEW, SortOrder = 6, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditSignatorySection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.SIGNATORY, RouterLink = TermApplicationRouterLinks.SIGNATORY_EDIT, SortOrder = 6, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminDocumentChecklist(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewAdminDocChkListSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_DOCUMENT_CHECKLIST, RouterLink = TermApplicationRouterLinks.ADMIN_DOCUMENT_CHECKLIST_VIEW, SortOrder = 7, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditAdminDocChkListSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_DOCUMENT_CHECKLIST, RouterLink = TermApplicationRouterLinks.ADMIN_DOCUMENT_CHECKLIST_EDIT, SortOrder = 7, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminDetails(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewAdminDocChkListSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_DETAILS, RouterLink = TermApplicationRouterLinks.ADMIN_DETAILS_VIEW, SortOrder = 8, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditAdminDocChkListSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_DETAILS, RouterLink = TermApplicationRouterLinks.ADMIN_DETAILS_EDIT, SortOrder = 8, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminDeedDetails(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewAdminDeedDetailsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_DEED_DETAILS, RouterLink = TermApplicationRouterLinks.ADMIN_DEED_DETAILS_VIEW, SortOrder = 9, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditAdminDeedDetailsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_DEED_DETAILS, RouterLink = TermApplicationRouterLinks.ADMIN_DEED_DETAILS_EDIT, SortOrder = 9, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void AdminContacts(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewAdminDeedDetailsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_CONTACTS, RouterLink = TermApplicationRouterLinks.ADMIN_CONTACTS_EDIT, SortOrder = 10, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditAdminDeedDetailsSection = true;
                adminNavigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ADMIN_CONTACTS, RouterLink = TermApplicationRouterLinks.ADMIN_CONTACTS_EDIT, SortOrder = 10, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }
}
