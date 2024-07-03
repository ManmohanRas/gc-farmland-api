namespace PresTrust.FarmLand.Application.Queries;

public class GetTermBrokenRulesQuery : IRequest<IEnumerable<GetTermBrokenRulesQueryViewModel>>
{
    public int ApplicationId { get; set; }
}
