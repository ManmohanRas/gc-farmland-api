namespace PresTrust.FarmLand.Application;

public class FarmEsmtAppSecurityManager
{
    private UserRoleEnum userRole = default;
    private EsmtAppStatusEnum applicationStatus = default;
    private ApplicationTypeEnum applicationTypeEnum = default;
    private EsmtAppPermissionEntity permission = default;
    private List<NavigationItemEntity> navigationItems = default;
    private List<NavigationItemEntity> adminNavigationItems = default;
    private List<NavigationItemEntity> postApprovedNavigationItems = default;
    private NavigationItemEntity defaultNavigationItem = default;
    private List<FarmFeedbacksEntity> corrections = new List<FarmFeedbacksEntity>();
    public FarmEsmtAppSecurityManager(UserRoleEnum userRole, EsmtAppStatusEnum applicationStatus, List<FarmFeedbacksEntity> corrections = null)
    {
        this.userRole = userRole;
        this.applicationStatus = applicationStatus;
        this.corrections = corrections ?? new List<FarmFeedbacksEntity>();

        ConfigurePermissions();
    }

    public EsmtAppPermissionEntity Permission { get { return permission; } }
    public List<NavigationItemEntity> NavigationItems { get => navigationItems; }
    public List<NavigationItemEntity> AdminNavigationItems { get => adminNavigationItems; }
    public List<NavigationItemEntity> PostApprovedNavigationItems { get => postApprovedNavigationItems; }
    public NavigationItemEntity DefaultNavigationItem { get => defaultNavigationItem; }

    public void ConfigurePermissions()
    {
        this.DeriveDraftStatePermissions();
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
                Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Exceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Structures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Liens(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_EDIT,
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
                Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Exceptions(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Structures(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                Liens(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);


                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_EDIT,
                    SortOrder = 1
                };
                break;
            case UserRoleEnum.PROGRAM_COMMITTEE:
            case UserRoleEnum.PROGRAM_READONLY:
            case UserRoleEnum.AGENCY_SIGNATORY:
            case UserRoleEnum.AGENCY_READONLY:

                Location();
                OwnerDetails();
                Roles();

                if (userRole == UserRoleEnum.AGENCY_SIGNATORY)
                {
                    Signatory(enumViewOrEdit: ApplicationTabEditOrViewEnum.EDIT);
                }
                else
                    Signatory();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;

            default:
                Location();
                OwnerDetails();
                Roles();

                this.defaultNavigationItem = new NavigationItemEntity()
                {
                    Title = EsmtAppNavigationItemTitles.LOCATION,
                    RouterLink = EsmtAppRouterLinks.LOCATION_VIEW,
                    SortOrder = 1
                };
                break;
        }
    }


    private void Location(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                permission.CanViewLocationSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.LOCATION, RouterLink = EsmtAppRouterLinks.LOCATION_VIEW, SortOrder = 1, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditLocationSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.LOCATION, RouterLink = EsmtAppRouterLinks.LOCATION_EDIT, SortOrder = 1, Icon = (correction == true ? "report_problem" : "") });
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
                permission.CanViewOwnerDetailsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.OWNER_DETAILS, RouterLink = EsmtAppRouterLinks.OWNER_DETAILS_VIEW, SortOrder = 2, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditOwnerDetailsSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.OWNER_DETAILS, RouterLink = EsmtAppRouterLinks.OWNER_DETAILS_EDIT, SortOrder = 2, Icon = (correction == true ? "report_problem" : "") });
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
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ROLES, RouterLink = EsmtAppRouterLinks.ROLES_VIEW, SortOrder = 3, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditRolesSection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.ROLES, RouterLink = EsmtAppRouterLinks.ROLES_EDIT, SortOrder = 3, Icon = (correction == true ? "report_problem" : "") });
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
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SIGNATORY, RouterLink = EsmtAppRouterLinks.SIGNATORY_VIEW, SortOrder = 4, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                permission.CanEditSignatorySection = true;
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.SIGNATORY, RouterLink = EsmtAppRouterLinks.SIGNATORY_EDIT, SortOrder = 4, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void Exceptions(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.EXCEPTIONS, RouterLink = EsmtAppRouterLinks.EXCEPTIONS_VIEW, SortOrder = 5, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.EXCEPTIONS, RouterLink = EsmtAppRouterLinks.EXCEPTIONS_EDIT, SortOrder = 5, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void Structures(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.RESI_NON_RESI_STRUCTURES, RouterLink = EsmtAppRouterLinks.RESI_NON_RESI_STRUCTURES_VIEW, SortOrder = 6, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.RESI_NON_RESI_STRUCTURES, RouterLink = EsmtAppRouterLinks.RESI_NON_RESI_STRUCTURES_EDIT, SortOrder = 6, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void Liens(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.LIENS_EASEMENT_ROW, RouterLink = EsmtAppRouterLinks.LIENS_EASEMENT_ROW_VIEW, SortOrder = 7, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.LIENS_EASEMENT_ROW, RouterLink = EsmtAppRouterLinks.LIENS_EASEMENT_ROW_EDIT, SortOrder = 7, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }

    private void ExistingUses(bool correction = false, ApplicationTabEditOrViewEnum enumViewOrEdit = ApplicationTabEditOrViewEnum.VIEW)
    {
        switch (enumViewOrEdit)
        {
            case ApplicationTabEditOrViewEnum.VIEW:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.EXIS_NON_AGRI_USES, RouterLink = EsmtAppRouterLinks.EXIS_NON_AGRI_USES_VIEW, SortOrder = 8, Icon = (correction == true ? "report_problem" : "") });
                break;
            case ApplicationTabEditOrViewEnum.EDIT:
                navigationItems.Add(new NavigationItemEntity() { Title = EsmtAppNavigationItemTitles.EXIS_NON_AGRI_USES, RouterLink = EsmtAppRouterLinks.EXIS_NON_AGRI_USES_EDIT, SortOrder = 8, Icon = (correction == true ? "report_problem" : "") });
                break;
            default:
                break;
        }
    }
}

