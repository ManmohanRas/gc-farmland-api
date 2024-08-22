namespace PresTrust.FarmLand.Application.Queries;

public class GetApplicationStatusLogQuery : IRequest<IEnumerable<GetApplicationStatusLogQueryViewModel>>
{
    public int ApplicationId { get; set; }
}
