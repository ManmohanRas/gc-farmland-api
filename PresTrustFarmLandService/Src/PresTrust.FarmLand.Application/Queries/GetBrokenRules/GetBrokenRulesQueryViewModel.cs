namespace PresTrust.FarmLand.Application.Queries;
/// <summary>
/// This class represents api's query input model and returns the response object
/// </summary>
public class GetBrokenRulesQueryViewModel
{
    public int ApplicationId { get; set; }
    public string Section { get; set; }
    public string Message { get; set; }
    public string RouterLink { get; set; }

}