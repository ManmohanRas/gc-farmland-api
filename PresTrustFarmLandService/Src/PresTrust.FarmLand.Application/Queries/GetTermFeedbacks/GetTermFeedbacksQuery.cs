namespace PresTrust.FarmLand.Application.Queries;

public class GetTermFeedbacksQuery: IRequest<IEnumerable<GetTermFeedbacksQueryViewModel>>
{
    public int ApplicationId { get; set; }
}
