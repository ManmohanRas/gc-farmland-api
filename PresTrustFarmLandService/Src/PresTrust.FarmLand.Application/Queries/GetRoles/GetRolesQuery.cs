namespace PresTrust.FarmLand.Application.Queries;
/// <summary>
/// This class represents api's query input model and returns the response object
/// </summary>
public class GetRolesQuery: IRequest<IEnumerable<FarmRolesViewModel>>
{
    public int ApplicationId { get; set; }
    public int? AgencyId { get; set; }
}
