namespace PresTrust.FarmLand.Application.Commands;

public class CreateApplicationCommandViewModel
{
    public int Id { get; set; }
    public int AgencyId { get; set; }
    public string Title { get; set; }
    public int ApplicationTypeId { get; set; }
    public int StatusId { get; set; }
    public bool CreatedByProgramUser { get; set; }
    public bool IsApprovedByMunicipality { get; set; }
    public string LastUpdatedBy { get; set; }
    public DateTime LastUpdatedOn { get; set; }
    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
}
