namespace PresTrust.FarmLand.Application;

public class FarmApplicationSecurityManager
{
    private UserRoleEnum userRole = default;
    private ApplicationStatusEnum applicationStatus = default;
    private ApplicationStatusEnum applicationPrevStatus = default;
    private TermAppPermissionEntity permission = default;
    private List<NavigationItemEntity> navigationItems = default;
    private List<NavigationItemEntity> adminNavigationItems = default;
    private List<NavigationItemEntity> postApprovedNavigationItems = default;
    private NavigationItemEntity defaultNavigationItem = default;

    public FarmApplicationSecurityManager(ApplicationTypeEnum applicationType)
    {
        if(applicationType == ApplicationTypeEnum.TERM)
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

        permission.CanEditLocationSection = true;
        navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.LOCATION, RouterLink = TermApplicationRouterLinks.LOCATION_EDIT, SortOrder = 1 });

        permission.CanEditOwnerDetailsSection = true;
        navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.OWNER_DETAILS, RouterLink = TermApplicationRouterLinks.OWNER_DETAILS_EDIT, SortOrder = 2 });

        permission.CanEditRolesSection = true;
        navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.ROLES, RouterLink = TermApplicationRouterLinks.ROLES_EDIT, SortOrder = 3 });

        permission.CanEditSiteCharacteristicsSection = true;
        navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.SITE_CHARACTERISTICS, RouterLink = TermApplicationRouterLinks.SITE_CHARACTERISTICS_EDIT, SortOrder = 4 });

        permission.CanEditSignatorySection = true;
        navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.SIGNATORY, RouterLink = TermApplicationRouterLinks.SIGNATORY_EDIT, SortOrder = 5 });

        permission.CanEditOtherDocsSection = true;
        navigationItems.Add(new NavigationItemEntity() { Title = TermAppNavigationItemTitles.OTHER_DOCUMENTS, RouterLink = TermApplicationRouterLinks.OTHER_DOCUMENTS_EDIT, SortOrder = 5 });

        this.defaultNavigationItem = new NavigationItemEntity()
        {
            Title = TermAppNavigationItemTitles.OTHER_DOCUMENTS,
            RouterLink = TermApplicationRouterLinks.OTHER_DOCUMENTS_EDIT,
            SortOrder = 5
        };
    }


    //Easement Program
    public void ConfigureEasementPermissions()
    {

    }
}
