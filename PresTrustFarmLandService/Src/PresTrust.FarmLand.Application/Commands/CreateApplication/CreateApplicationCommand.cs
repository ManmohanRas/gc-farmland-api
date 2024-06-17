namespace PresTrust.FarmLand.Application.Commands;

/// <summary>
/// This class represents api's command input model and returns the response object
/// </summary>
public class CreateApplicationCommand: IRequest<CreateApplicationCommandViewModel>
{
    public string Title { get; set; }
    public int AgencyId { get; set; }
    public string ApplicationType { get; set; }
    public bool IsMunicipallyApproved { get; set; }
}
