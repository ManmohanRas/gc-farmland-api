namespace PresTrust.FarmLand.Application.Queries;

public class GetBrokenRulesQuery : IRequest<IEnumerable<GetBrokenRulesQueryViewModel>>
{
    public int ApplicationId { get; set; }
}
