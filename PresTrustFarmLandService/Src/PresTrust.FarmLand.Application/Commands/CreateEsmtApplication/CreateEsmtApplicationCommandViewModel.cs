namespace PresTrust.FarmLand.Application.Commands;

public class CreateEsmtApplicationCommandViewModel
{
    public int Id { get; set; }
    public int AgencyId { get; set; }
    public string Title { get; set; }
    public int ApplicationTypeId { get; set; }
    public string ApplicationType { get; set; }
    public string Status { get; set; }
    public bool CreatedByProgramUser { get; set; }
    public bool IsApprovedByMunicipality { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public FarmAgencyEntity Agency { get; set; }
    public int MunicipalID { get; set; }
    public string Municipality { get; set; }
    public int FarmListId { get; set; }
    public string FarmName { get; set; }
    public IEnumerable<FarmCommentsEntity> Comments { get; set; }
    public IEnumerable<FarmFeedbacksEntity> Feedbacks { get; set; }
    public EsmtAppPermissionEntity Permission { get; set; } = new EsmtAppPermissionEntity();
    public IEnumerable<NavigationItemEntity> NavigationItems { get; set; } = new List<NavigationItemEntity>();
    public IEnumerable<NavigationItemEntity> AdminNavigationItems { get; set; } = new List<NavigationItemEntity>();
    public IEnumerable<NavigationItemEntity> PostApprovedNavigationItems { get; set; } = new List<NavigationItemEntity>();
    public NavigationItemEntity DefaultNavigationItem { get; set; } = new NavigationItemEntity();
}
