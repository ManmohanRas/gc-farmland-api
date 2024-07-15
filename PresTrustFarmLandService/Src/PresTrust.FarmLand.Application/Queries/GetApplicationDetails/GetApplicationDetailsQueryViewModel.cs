namespace PresTrust.FarmLand.Application.Queries;

public class GetApplicationDetailsQueryViewModel
{
    public int Id { get; set; }
    public int AgencyId { get; set; }
    public string Title { get; set; }
    public int ApplicationTypeId { get; set; }
    public string ApplicationType { get; set; }
    public string Status { get; set; }
    public bool IsApprovedByMunicipality { get; set; }
    public FarmAgencyEntity Agency { get; set; }
    public int MunicipalID { get; set; }
    public string Municipality { get; set; }
    public IEnumerable<TermCommentsEntity> Comments { get; set; }
    public IEnumerable<TermFeedbacksEntity> Feedbacks { get; set; }
    public TermAppPermissionEntity Permission { get; set; } = new TermAppPermissionEntity();
    public IEnumerable<NavigationItemEntity> NavigationItems { get; set; } = new List<NavigationItemEntity>();
    public IEnumerable<NavigationItemEntity> AdminNavigationItems { get; set; } = new List<NavigationItemEntity>();
    public IEnumerable<NavigationItemEntity> PostApprovedNavigationItems { get; set; } = new List<NavigationItemEntity>();
    public NavigationItemEntity DefaultNavigationItem { get; set; } = new NavigationItemEntity();
}
