namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// This class represents api's command input model and returns the response object
/// </summary>
public class CreateEsmtApplicationCommand: IRequest<CreateEsmtApplicationCommandViewModel>
{
    public string Title { get; set; }
    public int AgencyId { get; set; }
    public string ApplicationType { get; set; }
    public bool IsApprovedByMunicipality { get; set; }
    public int FarmListId { get; set; }  
}
